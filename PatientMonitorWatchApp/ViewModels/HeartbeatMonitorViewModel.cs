using System;
using System.Windows.Input;

using PatientMonitorWatchApp.Mvvm;
using Xamarin.Forms;
using System.Collections.Generic;
using Tizen.System;
using Tizen.Applications;
using Tizen.Applications.Notifications;

namespace PatientMonitorWatchApp.ViewModels
{
    public class HeartbeatMonitorViewModel : BaseViewModel
    {
        //private Feedback feedback = new Feedback();
        public event EventHandler OnButtonClicked;
        //public event EventHandler<int> OnDataReceived;
        Services.HeartRateMonitorService HRM;
         Services.NetworkAccessService Network = new Services.NetworkAccessService();
        private bool isUsed = true;
        private bool isDisposed = true;
        int HeartBeat;
        Dictionary<string, string> results = new Dictionary<string, string>();
        public HeartbeatMonitorViewModel()
        {
            ClickButtonCommand = new Command(() => ClickButton());
            //feedback.Play(FeedbackType.All, pattern: "TAP");

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
                Feedback feedback = new Feedback();
            if (isUsed)
            {
                prompt = "Pomiar zakończono.";
                reasumeButton = "Rozpocznij Pomiar";
                HRM.SensorDataUpdated -= OnDataChanged;
                HRM.Stop();
                SendData(results);
                results.Clear();
                manageHRM();
            } else
            {
                //feedback.Play(FeedbackType.Sound, "Message");
                manageHRM();
                prompt = "...";
                reasumeButton = "Zakończ Pomiar";
                HRM.SensorDataUpdated += OnDataChanged;
                HRM.Start();
            }
                feedback.Play(FeedbackType.Vibration, "SoftInputPanel");
            OnPropertyChanged(nameof(Prompt));
            OnPropertyChanged(nameof(ReasumeButton));
            //OnButtonClicked?.Invoke(null, EventArgs.Empty);
        }
        public void OnDataChanged(object sender, int args)
        {
            if (args > 0) {
            HeartBeat = args;
             results.Add(DateTime.Now.ToString("h:mm:ss tt"), HeartBeat.ToString());
            prompt = HeartBeat.ToString() + " " + "uderzeń/min";
            OnPropertyChanged(nameof(Prompt));
            }
            
        }

        public void SendData(Dictionary<string, string> results)
        {
            Network.PostData(results);
            //await Network.SendWebRequestSampleAsync();
        }

        private string prompt;
        private string reasumeButton = "Rozpocznij Pomiar";

        public string ReasumeButton { get => reasumeButton; set => Set(ref reasumeButton, value); }

        public string Prompt { get => prompt; set => Set(ref prompt, value); }
    }
}
