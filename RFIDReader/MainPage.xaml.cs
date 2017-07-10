using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;
using Rc522;
using RFIDReader.Entity;
using System;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RFIDReader
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DeviceClient _client;
        public MainPage()
        {
            this.InitializeComponent();
            Task.Run(() => 
            {
                _client = DeviceClient.CreateFromConnectionString(
                    "HostName=badge.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=pmnck0gcq+TFjDW6LCtotsE4on1IN7UMPwb6x2XguqE="
                    , "badgepi"
                    , Microsoft.Azure.Devices.Client.TransportType.Mqtt);
                try
                {
                    _client.OpenAsync().Wait();
                }
                catch (Exception ex)
                {

                    throw;
                }
                _client.SetMethodHandlerAsync("MetodoInvocatoDaServer", MetodoInvocatoDaServer, "");

            }).Wait();
            
            Task read = Task.Run(async () => await ReadAsync()); // Lancio il task in backgroud  
           // Task read2 = Task.Run(async () => await RegistraMetodoSulDispositivoAsync()); // Lancio il task in backgroud  
        }

        private async Task ReadAsync()
        {
           

            var mfrc = new Mfrc522();
            await mfrc.InitIOAsync();            
            await ResetAsync();

            while (true)
            {
                try
                {
                    if (mfrc.IsTagPresent())
                    {
                        Uid uid = mfrc.ReadUid();
                        if (uid.IsValid)
                        {
                            await SuccesReadAsync(uid);
                            DataBadge badge = new DataBadge
                            {
                                Orario = DateTime.Now,
                                Id = uid.FullUid,
                                Posizione = "Villafranca"

                            };

                            var messageString = JsonConvert.SerializeObject(badge);
                            var message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(messageString));
                            await _client.SendEventAsync(message);
                        }
                        else
                            await ErrorReadAsync(uid);

                        mfrc.HaltTag();
                    }
                }
                catch (Exception ex)
                {
                    await _client.CloseAsync();
                    var e = ex;
                }
            }
        }

        public async Task RegistraMetodoSulDispositivoAsync()
        {
           
        }


        /// <summary>
        /// Logica del metodo richiamato dal server.
        /// </summary>
        /// <param name="methodRequest"></param>
        /// <param name="userContext"></param>
        /// <returns></returns>
        public async Task<MethodResponse> MetodoInvocatoDaServer(MethodRequest methodRequest, object userContext)
        {
            var person = methodRequest.DataAsJson;
            string clientVerbose = $"Metodo invocato dal client: Attivazione lavori in data {((DateTimeOffset)userContext).Date.ToString()}";
            Console.WriteLine(clientVerbose);
            MethodResponse response = new MethodResponse(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(true)), 0);
            return response;
        }


        private async Task SuccesReadAsync(Uid uid)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Result.Fill = new SolidColorBrush(Windows.UI.Colors.Green);
                Uid.Text = $"{uid.FullUid[0]} - {uid.FullUid[1]} - {uid.FullUid[2]} - {uid.FullUid[3]} - {uid.FullUid[4]}";
            });
            await ResetAsync();
        }

        private async Task ErrorReadAsync(Uid uid)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Result.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                Uid.Text = $"{uid.FullUid[0]} - {uid.FullUid[1]} - {uid.FullUid[2]} - {uid.FullUid[3]} - {uid.FullUid[4]}";
            });
            await ResetAsync();
        }

        private async Task ResetAsync()
        {
            await Task.Delay(5000);
            await ResetReadAsync();
        }

        private async Task ResetReadAsync()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Result.Fill = new SolidColorBrush(Windows.UI.Colors.LightGray);
                Uid.Text = "Passa il Badge";
            });
        }
    }
}
