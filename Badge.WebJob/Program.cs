using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IoTHub.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            AscoltatoreDispositivi sender = new AscoltatoreDispositivi("HostName=badge.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=A9AJoMmDSvwtdpvflTKXl6z3LJdhhwGH4VdCVNMHJMU=");
            var tasks = new List<Task>();
            foreach (string partition in sender.HubClient.GetRuntimeInformation().PartitionIds)
            {
                tasks.Add(sender.RicezioneMessaggiDaDispositivi(partition)); // mi metto in ascolto dei messaggi dei device
            }
            
            Task.WaitAll(tasks.ToArray());
        }
    }
}
