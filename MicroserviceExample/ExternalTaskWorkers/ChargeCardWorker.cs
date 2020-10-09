using Camunda.Api.Client;
using Camunda.Api.Client.ExternalTask;
using Camunda.ExternalTask.Client.Adapter;
using Camunda.ExternalTask.Client.TopicManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroserviceExample.ExternalTaskWorkers
{
    [ExternalTaskTopic("charge-credit", MaxTasks = 1, LockDurationInMilliseconds = 1000)]
    class ChargeCardWorker : IExternalTaskAdapter
    {
        public void Execute(LockedExternalTask externalTask, ref Dictionary<string, VariableValue> resultVariables)
        {
            Random _random = new Random();
            var randomNumber = _random.Next(0, 10);
            Console.WriteLine("Charging started");
            var remaining = (double)externalTask.Variables["remaining"].Value;

            if (randomNumber >= 5)
            {
                resultVariables.Add("credit", VariableValue.FromObject(remaining));
            }
            else
            {
                throw new UnrecoverableBusinessErrorException("ChargingFailure", "Charging failed");
            }
        }
    }
}
