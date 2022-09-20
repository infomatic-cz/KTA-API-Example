using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KtaApiWebRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost/TotalAgility/Services/SDK/JobService.svc/json/CreateJob");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            httpWebRequest.Headers.Add("jsonendpoint", "true");
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = @"
                    {
                        ""sessionId"":""68BB738BCA4E364593A2222D27750691"",
                        ""processIdentity"":
                        {
                            ""Id"":""CAC8696155DFABE37347995E2C162DB2"",
                            ""Version"":1,
                            ""Name"":""ApiWebRequestTest""
                        },
                        ""jobInitialization"":
                        {
                            ""InputVariableCollection"":
                            [
                                { ""Id"": ""STR1"", ""Value"": ""ahoj""},
                                { ""Id"": ""DYNCOM1"", ""Value"": [[1,42],[1,42]]}
                                
                            ]
                        }
                    }";

            streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine(httpResponse.Method);
                Console.WriteLine(httpResponse.StatusCode);
                Console.WriteLine(httpResponse.StatusDescription);
                Console.ReadLine();

            }


        }

    }
}
