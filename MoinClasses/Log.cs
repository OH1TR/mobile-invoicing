using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Data.Entity.Validation;

namespace MoinClasses
{
    public static class Log
    {
        public static void Exception(Exception ex)
        {
            Exception i=ex;
            StringBuilder sb=new StringBuilder();
            do
            {
                sb.Append(string.Format("Exception {0} at {1}", i.Message, i.StackTrace));

                if (i is DbEntityValidationException)
                {
                    DbEntityValidationException evex = ex as DbEntityValidationException;
                    StringBuilder sb2 = new StringBuilder();

                    foreach (var failure in evex.EntityValidationErrors)
                    {
                        sb2.AppendFormat("{0} failed validation"+Environment.NewLine, failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb2.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb2.AppendLine();
                        }
                    }
                    sb.Append("Validation errors:");
                    sb.Append(sb2);
                }


                i = i.InnerException;
                if (i != null)
                {
                    sb.Append(Environment.NewLine + "Contains inner exception" + Environment.NewLine);
                }
            }
            while (i != null);
            
                WriteLine(sb.ToString());
         }

        public static void WriteLine(string format)
        {
            WriteLine(format, new Object[]{});
        }

        public static void WriteLine(string format, params Object[] args)
        {
            StackTrace st = new StackTrace(true);
            MethodBase method = st.GetFrame(1).GetMethod();
            string str=DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ") + method.DeclaringType.Name + "." + method.Name + " " + string.Format(format, args);

            if (System.IO.Directory.Exists("/tmp"))
                System.IO.File.AppendAllText("/tmp/moinlog.txt", str + Environment.NewLine);

            //Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ") + method.DeclaringType.Name + "." + method.Name + " " + string.Format(format, args));
        }
    }
}
