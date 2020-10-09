using Camunda.Api.Client;
using Camunda.Api.Client.ExternalTask;
using Camunda.ExternalTask.Client;
using Camunda.ExternalTask.Client.Adapter;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroserviceExample.ExternalTaskWorkers
{
    [ExternalTaskTopic("cleanup-credit", MaxTasks = 1, LockDurationInMilliseconds = 1000)]
    class CleanUpWorker : IExternalTaskAdapter
    {
        public void Execute(LockedExternalTask externalTask, ref Dictionary<string, VariableValue> resultVariables)
        {
            var credit = (double)externalTask.Variables["credit"].Value;
            resultVariables.Add("remaining", VariableValue.FromObject(credit));
        }
    }
}
