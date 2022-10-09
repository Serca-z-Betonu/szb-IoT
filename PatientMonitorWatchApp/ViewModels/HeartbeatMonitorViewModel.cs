using System;
using System.Windows.Input;

using PatientMonitorWatchApp.Mvvm;
using Xamarin.Forms;
using System.Collections.Generic;

namespace PatientMonitorWatchApp.ViewModels
{
    public class HeartbeatMonitorViewModel : BaseViewModel
    {

        public event EventHandler OnButtonClicked;
        public event EventHandler<int> OnDataReceived;
        Services.HeartRateMonitorService HRM;
        // Services.NetworkAccessService Network = new Services.NetworkAccessService();
        private bool isUsed = true;
        private bool isDisposed = true;
        int HeartBeat;
        Dictionary<string, string> results = new Dictionary<string, string>();
        public HeartbeatMonitorViewModel()
        {
            ClickButtonCommand = new Command(() => ClickButton());
        }

        private void manageHRM() 
        {
            if(isDisposed) {
                HRM = new Services.HeartRateMonitorService();
                isDisposed = false;
            } else {
                HRM.Dispose();
                isDisposed = true;
            }
        }

        public ICommand ClickButtonCommand { get; private set; }

        // Called when the button is clicked.
        private void ClickButton()
        {
            isUsed = !isUsed;
            if (isUsed)
            {
                prompt = "Pomiar zakończono.";
                reasumeButton = "Rozpocznij Pomiar";
                HRM.SensorDataUpdated -= OnDataChanged;
                HRM.Stop();
                // SendData(results);
                results.Clear();
                manageHRM();
            } else
            {
                manageHRM();
                prompt = "";
                reasumeButton = "Zakończ Pomiar";
                HRM.SensorDataUpdated += OnDataChanged;
                HRM.Start();
            }
            OnPropertyChanged(nameof(Prompt));
            OnPropertyChanged(nameof(ReasumeButton));
            OnButtonClicked?.Invoke(null, EventArgs.Empty);
        }
        public void OnDataChanged(object sender, int args)
        {
            if (args > 0) {
            HeartBeat = args;
             results.Add(DateTime.Now.ToString("h:mm:ss tt"), HeartBeat.ToString());
            // results.Add("dupa", "dupa");
            prompt = HeartBeat.ToString() + " " + "uderzeń/min";
            OnPropertyChanged(nameof(Prompt));
            }
            
        }

        // public async void SendData(Dictionary<string, string> results) {
        //     await Network.PostData(results);
            // await Network.SendWebRequestSampleAsync();
        // }

        private string prompt;
        private string reasumeButton = "Rozpocznij Pomiar";

        public string ReasumeButton { get => reasumeButton; set => Set(ref reasumeButton, value); }

        public string Prompt { get => prompt; set => Set(ref prompt, value); }
    }
}
