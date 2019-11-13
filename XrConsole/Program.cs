using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XrConsole.TestService;
using XrCore.Extends;
using XrCore.Tools.Config;

namespace XrConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var host = new ServiceHost(typeof(User));
            //host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
            //foreach (var endPoint in host.Description.Endpoints)
            //{
            //    Console.WriteLine(endPoint.Address);
            //}
            //host.Opened += (s, e) => Console.WriteLine("WCF Open");
            //host.Closed += (s, e) => Console.WriteLine("WCF Close");
            //host.UnknownMessageReceived += (s, e) => Console.WriteLine("WCF UnknownMessageReceived");
            //host.Faulted += (s, e) => Console.WriteLine("WCF Fault");
            //host.Open();
            //Fukc();
            //Console.WriteLine("233");
            var index = 0;
            while (true)
            {
                UserClient uc = new UserClient();
                var cur = SendValueXmlConfig.Current;
                Console.WriteLine(uc.CommandUserAsync(cur.MethodName, cur.ToString()).Result.Body.CommandUserResult);
                index++;
                cur.MethodName = $"T{index}";
                cur.Save();
                Thread.Sleep(3000);
            }
        }
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
