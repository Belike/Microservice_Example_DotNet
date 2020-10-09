using Camunda.ExternalTask.Client;
using System;

namespace MicroserviceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IExternalTaskClient externalTaskClient = ExternalTaskClientBuilder.Create()
                 .BaseUrl("http://localhost:8080/engine-rest")
                 .WorkerId("MicroserviceTrainingExample")
                 .Build();

            externalTaskClient.Startup();
            Console.ReadLine();
            externalTaskClient.Shutdown();
        }
    }
}
