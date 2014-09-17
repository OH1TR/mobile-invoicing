using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace MoinClasses
{
    public static class Log
    {
        public static void Exception(Exception ex)
        {
            if (ex.InnerException == null)
                WriteLine("Exception {0} at {1}", ex.Message, ex.StackTrace);
            else
                WriteLine("Exception {0} at {1} inner exception {2} at {3}", ex.Message, ex.StackTrace,ex.InnerException.Message,ex.InnerException.StackTrace);
        }

        public static void WriteLine(string format, params Object[] args)
        {
            StackTrace st = new StackTrace(true);
            MethodBase method = st.GetFrame(1).GetMethod();
            string str=DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ") + method.DeclaringType.Name + "." + method.Name + " " + string.Format(format, args);

            if (System.IO.Directory.Exists("/tmp"))
                System.IO.File.AppendAllText("/tmp/moinlog.txt", str + "\r");

            //Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ") + method.DeclaringType.Name + "." + method.Name + " " + string.Format(format, args));
        }
    }
}
