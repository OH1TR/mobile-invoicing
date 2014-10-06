using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using MoinClasses.Tables;

namespace TSGenerator
{
    class Program
    {
        static string TypeToTSDef(Type t,bool allowArrayPostfix)
        {
            string s;

            if(t.IsArray)
                s = t.GetElementType().Name;
            else
                s=t.Name;

            if (s == "String")
                s = "string";

            if (s.Contains("MoinRowState"))
                s = "number";

            if (s.StartsWith("ccc"))
                s = s.Substring(s.LastIndexOf('.'), s.Length - s.LastIndexOf('.'));

            if (t.IsArray && allowArrayPostfix)
                s += "[]";

            return (s);
        }

        static string BuildWSCode()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("module IMoin {\r\n");
             MethodInfo[] mi = typeof(IMoinWS).GetMethods();

            foreach (MethodInfo i in mi)
            {
                bool separator = false;
                bool voidReturn=(i.ReturnType.Name=="Void");

                var paras =i.GetParameters();

                sb.Append("export function " + i.Name + "(");
                foreach(var p in paras)
                {
                    if (separator)
                        sb.Append(",");

                    string tsDef = TypeToTSDef(p.ParameterType,true);
                    sb.Append(p.Name + ":" + tsDef);

                    separator = true;
                }
                if (separator)
                    sb.Append(",");

                if (voidReturn)
                    sb.Append("callback : () => any,scope? : any)\r\n{");
                else
                    sb.Append("callback : (result : " + TypeToTSDef(i.ReturnType, true) + ") => any,scope? : any)\r\n{");
                sb.Append(@"
    $.getJSON('Moin.svc/"+i.Name);

                if (paras.Length> 0)
                    sb.Append("?");

                separator = false;
                foreach (var p in paras)
                {
                    if (separator)
                        sb.Append("&");

                    sb.Append(p.Name + "='+" + p.Name + "+'");

                    separator = true;
                }                
                
                sb.Append(@"',
        function (result, status) 
        {
            ");
                if(i.ReturnType.ToString().StartsWith("Moin"))
                {
                    if(i.ReturnType.IsArray)
                        sb.Append("var o="+TypeToTSDef(i.ReturnType,false)+"ArrayFromJSON(result);");
                    else
                        sb.Append("var o=new "+TypeToTSDef(i.ReturnType,false)+"(result);");
                }
                else
                    sb.Append("var o=result");
                sb.Append(@"
            if (typeof scope === 'undefined')            
                callback("+(voidReturn ? "" :"o")+@");
            else
                scope.$apply(
                    function () { 
                        callback(" + (voidReturn ? "" : "o") + @");
                    });
            
        });
}

");
        }
            sb.Append("}");
            return (sb.ToString());
        }

        static void Main(string[] args)
        {
            string classesProjectDir = args[0];
            string outputFilePath = args[1];

            TSClassesTemplate template = new TSClassesTemplate();
            File.WriteAllText(outputFilePath, template.TransformText()+BuildWSCode()); 
            

        }


   


    }
}
