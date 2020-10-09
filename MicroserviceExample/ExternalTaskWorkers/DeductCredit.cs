using Camunda.Api.Client;
using Camunda.Api.Client.ExternalTask;
using Camunda.ExternalTask.Client;
using Camunda.ExternalTask.Client.Adapter;
using Camunda.ExternalTask.Client.TopicManager;
using System;
using System.Collections.Generic;
using System.Net;

namespace MicroserviceExample.ExternalTaskWorkers
{
    [ExternalTaskTopic("deduct-credit", MaxTasks = 1, LockDurationInMilliseconds = 1000)]
    class DeductCredit : IExternalTaskAdapter
    {
        public void Execute(LockedExternalTask externalTask, ref Dictionary<string, VariableValue> resultVariables)
        {
            bool creditBooleans;
            var amount = (double)externalTask.Variables["amount"].Value;
            var credit = (double)externalTask.Variables["credit"].Value;
            var remaining = credit - amount;

            if (remaining > 0)
            {
                creditBooleans = true;
            }
            else
            {
                creditBooleans = false;
            }

            resultVariables.Add("remaining", VariableValue.FromObject(remaining));
            resultVariables.Add("creditSufficient", VariableValue.FromObject(creditBooleans));
        }
    }
}
