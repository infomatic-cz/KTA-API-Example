using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // uncomment method calls for testing as necessary

            // all methods require specific processes in KTA to work, if you wish to call them and not just review source code
            // contact your KTA consultant directly or at support@infomatic.cz and ask for KTA package to be imported to your system
            
            // if not executed on KTA app/web server, endpoint address in config file needs to be updated with KTA app/web server

            KTA_REST_API_Example.ExamplesClass exampleClass = new KTA_REST_API_Example.ExamplesClass();

            // create job
            //exampleClass.CreateJob("68BB738BCA4E364593A2222D27750691");

            // create job sync
            var job = exampleClass.CreateJobSync("B4664F8548580D4794626CD7B4759719");
            Console.WriteLine(job.Job.Id);


            // execute business rule
            //exampleClass.ExecuteBR("68BB738BCA4E364593A2222D27750691");

            // get document
            //Console.WriteLine("Please provide document id: ");
            //string docId = Console.ReadLine();
            //exampleClass.GetDocument("68BB738BCA4E364593A2222D27750691", docId);

            Console.WriteLine("Please view and edit source code for details");
            Console.ReadLine();
        }
    }
}
