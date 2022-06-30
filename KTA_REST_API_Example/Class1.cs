using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_REST_API_Example
{
    public class ExamplesClass
    {
        // Concepts
        // https://docshield.kofax.com/KTA/en_US/740-uc0n6j0c5s/help/API/latest/concepts.html

        // Examples
        // https://docshield.kofax.com/KTA/en_US/740-uc0n6j0c5s/help/API/latest/examples.html


        // Create Job - https://docshield.kofax.com/KTA/en_US/740-uc0n6j0c5s/help/API/latest/class_agility_1_1_sdk_1_1_services_1_1_job_service.html#a8818c093038e68fc9c5fb871e3b759b1
        public JobService.JobIdentity CreateJob(string sessionId)
        {
            // create service client so we can call it
            JobService.JobServiceClient JobService = new JobService.JobServiceClient();

            // returns JobIdentity object containing unique JobId
            return JobService.CreateJob(
                sessionId,      // session id of job creator (for detail about session concept see help)
                new JobService.ProcessIdentity()
                {
                    Id = "25618A5FAF0F4C3C8F601592CCFA728A",          // unique identity of process map
                    Name = "REST API test job"       // name can be specified for better legibility, optional
                },
                new JobService.JobInitialization()
                {
                    InputVariables = new JobService.InputVariableCollection()     // job inicialization parameters based on selected process map
                     {
                          new JobService.InputVariable()      // 1. variable identity and value
                          { Id = "INPUT_STRING", Value = "foo" },
                          new JobService.InputVariable()      // 2. variable identity and value
                          {Id = "INPUT_INT32", Value = 123456 }
                     }
                }
                );
        }


        public JobService.SyncJob CreateJobSync(string sessionId)
        {
            // create service client so we can call it
            JobService.JobServiceClient JobService = new JobService.JobServiceClient();

            object[][] dynamicComplexVariable = new object[5][];

            for (int i = 0; i < 5; i++)
            {
                dynamicComplexVariable[i] = new object[4];
                dynamicComplexVariable[i][0] = i;
                dynamicComplexVariable[i][1] = "foo";
                dynamicComplexVariable[i][2] = DateTime.Now;
                dynamicComplexVariable[i][3] = true;
            }

            // returns JobIdentity object containing unique JobId
            JobService.SyncJob job = JobService.CreateJobSync(
                sessionId,      // session id of job creator (for detail about session concept see help)
                new JobService.ProcessIdentity()
                {
                    Id = "5CDA4AF2C27E6250F69E0DFE39EDDD7E",          // unique identity of process map
                    Name = "REST API test job"       // name can be specified for better legibility, optional
                },
                new JobService.JobInitialization()
                {
                    InputVariables = new JobService.InputVariableCollection()     // job inicialization parameters based on selected process map
                     {
                          new JobService.InputVariable()      // 1. variable identity and value
                          { Id = "IN_BOOL", Value = true },
                          new JobService.InputVariable()      // 2. variable identity and value
                          {Id = "IN_COMPLEX", Value = dynamicComplexVariable },
                          new JobService.InputVariable()      // 3. variable identity and value
                          {Id = "IN_LONG", Value = 42 },
                          new JobService.InputVariable()      // 4. variable identity and value
                          {Id = "IN_STR", Value = "ferda" }
                     }
                }, new JobService.VariableIdentityCollection()
                {
                    new JobService.VariableIdentity()
                    { Id = "", Name = "" }
                }
                );

            return job;
        }


        // Execute Business Rule - https://docshield.kofax.com/KTA/en_US/740-uc0n6j0c5s/help/API/latest/class_agility_1_1_sdk_1_1_services_1_1_business_rule_service.html#aafebd185fd1128323ed16cd1b34c4144
        public void ExecuteBR(string sessionId)
        {
            // create service client so we can call it
            BusinessRuleService.BusinessRuleServiceClient BRService = new BusinessRuleService.BusinessRuleServiceClient();

            JobService.JobServiceClient JService = new JobService.JobServiceClient();

            object[][] dynamicComplexVariable = new object[5][];

            for (int i = 0; i < 5; i++)
            {
                dynamicComplexVariable[i] = new object[2];
                dynamicComplexVariable[i][0] = i;
                dynamicComplexVariable[i][1] = "foo";
            }

            // create output object and create BR that will fill it
            BusinessRuleService.BusinessRuleOutputCollection output = BRService.ExecuteBusinessRule(
                sessionId,
                new BusinessRuleService.BusinessRuleRuntimeIdentity()
                {
                    Id = "627A9583638642BB83B0DE0022B11948",                            // unique identity of business rule
                    Name = "REST API test BR"                         // name can be specified for better legibility, optional
                },
                new BusinessRuleService.BusinessRuleInputCollection()       // inicialization parameters based on selected BR
                {
                    new BusinessRuleService.BusinessRuleInput()
                    {
                        Name = "INPUT_STR", Value = "foo", Type = 8                     // 1. variable identity, value and type
                    },
                    new BusinessRuleService.BusinessRuleInput()
                    {
                        Name = "inout_DynComplex", Value = dynamicComplexVariable, Type = 8204
                    }
                    // ,
                    // new BusinessRuleService.BusinessRuleInput()
                    // {
                    //     Name = "", Value = "", Type = 8                     // n. variable identity, value and type if BR has more inputs
                    // }
                }
                );

            // loop output variables
            foreach (var item in output)
            {
                object value = item.Value;
                short type = item.Type;
                string name = item.Name;
            }
        }


        // Get Document - https://docshield.kofax.com/KTA/en_US/740-uc0n6j0c5s/help/API/latest/class_agility_1_1_sdk_1_1_services_1_1_capture_document_service.html#a66f04740e3b9b005bf074de3d2779a3a
        public void GetDocument(string sessionId, string documentId)
        {
            // create service client so we can call it
            CaptureDocumentService.CaptureDocumentServiceClient cds = new CaptureDocumentService.CaptureDocumentServiceClient();

            // get document
            CaptureDocumentService.Document document = cds.GetDocument(sessionId, null, documentId);

            // loop fields
            foreach (var field in document.Fields)
            {
                // field value
                object fieldValue = field.Value;

                // fields table as DataSet
                if (field.FieldType == 4)
                {
                    // get table field as dataset
                    System.Data.DataSet table = cds.GetDocumentTableFieldValue(sessionId, null, documentId, new CaptureDocumentService.TableFieldIdentity() { Id = field.Id });

                    // 1. row, 1. column of table
                    // table.Tables[0].Rows[0].ItemArray[0].ToString();
                }
            }
        }
        

        
    }
}
