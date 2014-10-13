using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoinClasses.Tables;

namespace MoinClasses
{
    public static class Extensions
    {
        public static void Import<table>(this MoinDbContext ctx, table item) where table : MoinClassesBase
        {
#if DEBUG
            if (item.ID == null)
                throw new Exception("ID==null, are you missing override or [DataMember] attribute?");
#endif
            switch (item.RowState)
            {
                case MoinRowState.New:
                    ctx.Set(typeof(table)).Add(item);
                    break;
                case MoinRowState.Updated:
                    ctx.Set(typeof(table)).Attach(item);
                    ctx.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    break;
                case MoinRowState.Deleted:
                    ctx.Set(typeof(table)).Attach(item);
                    ctx.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    break;
            }

        }
    }
}
