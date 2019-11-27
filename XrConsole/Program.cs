using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XrConsole.TestService;
using XrCore.Extends;
using XrCore.Pattern.IOC;
using XrCore.Pattern.Template;
using XrCore.Sockets;
using XrCore.Tools.Config;
using XrCore.Tools.Log;
using System.Web.Services.Description;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace XrConsole
{
    [Container(typeof(object), "1")]
    [Serializable]
    public class temp
    {
        public int index { get; set; } = 1;
        public fuckc sss { get; set; } = fuckc.c;
        public bool getta(fuckc c)
        {
            return (sss | c) == c;
        }
    }
    public enum fuckc
    {
        a = 1,
        b = 2,
        c = 4,
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new temp();
            var b = (temp)a.CloneReflection();
            Console.WriteLine(b.getta(fuckc.a | fuckc.c));
            b.index = 2;
            Console.Write(a.index);
            var sw = new Stopwatch();
            while (true)
            {
                sw.Reset();
                sw.Start();
                var testLog = new UnitLogger("testLog");//Logger.GetLogger("testLog");
                
                testLog.Info("fukc");
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                //InvokeWebService("http://localhost:8057/User", "", "", null);
                Thread.Sleep(1000);
            }
        }
        static object InvokeWebService(string url, string classname, string methodname, object[] args)
        {
            string @namespace = "EnterpriseServerBase.WebService.DynamicWebCalling";
            if ((classname == null) || (classname == ""))
            {
                string[] parts = url.Split('/');
                string[] pps = parts[parts.Length - 1].Split('.');
                classname = pps[0];
            }
            try
            {                   //获取WSDL   
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url + "?WSDL");
                ServiceDescription sd = ServiceDescription.Read(stream);
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                CodeNamespace cn = new CodeNamespace(@namespace);
                //生成客户端代理类代码          
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                //sdi.Import(cn, ccu);
                CSharpCodeProvider icc = new CSharpCodeProvider();
                //设定编译参数                 
                CompilerParameters cplist = new CompilerParameters();
                cplist.GenerateExecutable = false;
                cplist.OutputAssembly = "DynmicWebServiceJR.dll";
                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");
                //编译代理类                 
                CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);
                icc.Dispose(); wc.Dispose();
                stream.Dispose();

                if (true == cr.Errors.HasErrors)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }
                //生成代理实例，并调用方法  
                Assembly assembly = Assembly.LoadFrom("DynmicWebServiceJR.dll");
                if (methodname.Contains("mainEntrance"))
                {
                    classname = "app" + classname;
                }
                var types = assembly.GetTypes();
                Type t = assembly.GetType(@namespace + "." + classname, true, true);
                object obj = Activator.CreateInstance(t);
                MethodInfo mi = t.GetMethod(methodname);
                //return mi.Invoke(obj, args);
                var ret = mi.Invoke(obj, args);
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return "fail";
        }
        //public static object InvokeWebService(string url, string classname, string methodname, object[] args)
        //{
        //    string @namespace = "EnterpriseServerBase.WebService.DynamicWebCalling";
        //    if ((classname == null) || (classname == ""))
        //    {
        //        classname = WSHelper.GetWsClassName(url);
        //    }
        //    var key = new WebSerivceDicKey()
        //    {
        //        Url = url,
        //        ClassName = classname,
        //        MethodName = methodname
        //    };
        //    try
        //    {
        //        Assembly ass = null;
        //        if (ServiceDic.Keys.Contains(key)) ass = ServiceDic[key];
        //        else
        //        {                //获取WSDL   
        //            WebClient wc = new WebClient();
        //            Stream stream = wc.OpenRead(url + "?WSDL");
        //            ServiceDescription sd = ServiceDescription.Read(stream);
        //            ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
        //            sdi.AddServiceDescription(sd, "", "");
        //            CodeNamespace cn = new CodeNamespace(@namespace);
        //            //生成客户端代理类代码          
        //            CodeCompileUnit ccu = new CodeCompileUnit();
        //            ccu.Namespaces.Add(cn);
        //            sdi.Import(cn, ccu);
        //            CSharpCodeProvider icc = new CSharpCodeProvider();
        //            //设定编译参数                 
        //            CompilerParameters cplist = new CompilerParameters();
        //            cplist.GenerateExecutable = false;
        //            cplist.GenerateInMemory = true;
        //            cplist.ReferencedAssemblies.Add("System.dll");
        //            cplist.ReferencedAssemblies.Add("System.XML.dll");
        //            cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
        //            cplist.ReferencedAssemblies.Add("System.Data.dll");
        //            //编译代理类                 
        //            CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);
        //            if (true == cr.Errors.HasErrors)
        //            {
        //                System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //                foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
        //                {
        //                    sb.Append(ce.ToString());
        //                    sb.Append(System.Environment.NewLine);
        //                }
        //                throw new Exception(sb.ToString());
        //            }
        //            //生成代理实例，并调用方法  
        //            ass = cr.CompiledAssembly;
        //            lock (locObj)
        //            {
        //                if (!ServiceDic.ContainsKey(key))
        //                {
        //                    ServiceDic.Add(key, ass);
        //                }
        //            }
        //            stream.Dispose();
        //        }
        //        Type t = ass.GetType(@namespace + "." + classname, true, true);
        //        object obj = Activator.CreateInstance(t);
        //        System.Reflection.MethodInfo mi = t.GetMethod(methodname);
        //        //return mi.Invoke(obj, args);
        //        var ret = mi.Invoke(obj, args);
        //        return ret;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        static async void Fukc()
        {
            await ASYNCM();
        }
        static int i = 0;
        static async Task ASYNCM()
        {
            i++;
            TestService.UserClient b = new TestService.UserClient();
            var asyncRes = b.CommandUserAsync("t1", "skt t1");
            if (i < 5)
            {
                Console.WriteLine(i);
                await ASYNCM();
            }
            Console.WriteLine($"233{i}");
            Thread.Sleep(3000);
            await asyncRes;
            Console.WriteLine($"{asyncRes.Result.Body.CommandUserResult}{i}");
        }
    }
    [Description("send vlaue")]
    [XmlConfig(100)]
    public class SendValueXmlConfig : XmlConfigBase<SendValueXmlConfig>
    {
        public SendValueXmlConfig()
        {

        }
        [Description("fuck")]
        [XmlElement()]
        public string MethodName { get; set; }
        [Description("you")]
        [XmlElement()]
        public string XmlParams { get; set; }
    }
    [ServiceContract, XmlSerializerFormat(Style = OperationFormatStyle.Document)]
    public interface IUser
    {
        [OperationContract]
        string GetUserInfo();
        [OperationContract]
        string CommandUser(string methodName, string xmlPara);
    }
    [ServiceBehavior]
    public class User : IUser
    {
        public string GetUserInfo()
        {
            Console.WriteLine("WCF Called GetUserInfo");
            return "0235";
        }

        public string CommandUser(string methodName, string xmlPara)
        {
            Console.WriteLine($"MethodName:{methodName}\r\nXmlPara:{xmlPara}");
            return "success";
        }


    }
}
