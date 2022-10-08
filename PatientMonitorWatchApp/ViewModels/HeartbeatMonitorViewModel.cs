using System;
using System.Windows.Input;

using PatientMonitorWatchApp.Mvvm;
using Tizen.Sensor;
using Xamarin.Forms;

namespace PatientMonitorWatchApp.ViewModels
{
    public class HeartbeatMonitorViewModel : BaseViewModel
    {

        public event EventHandler OnButtonClicked;
        public event EventHandler<int> OnDataReceived;
        Services.HeartRateMonitorService HRM = new Services.HeartRateMonitorService();
        private bool isUsed = true;
        int HeartBeat;
        public HeartbeatMonitorViewModel()
        {
            ClickButtonCommand = new Command(() => ClickButton());
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
                //HRM.Dispose();
            } else
            {
                prompt = "";
                reasumeButton = "Zakończ Pomiar";
                HRM.SensorDataUpdated += OnDataChanged;
                HRM.Start();
            }
            OnPropertyChanged(nameof(Prompt));
            OnPropertyChanged(nameof(ReasumeButton));
            // TODO: Insert code to handle the button clicked.
            //
            // To perform page navigation, use the GoToAsync method in Xamarin.Forms Shell API.
            // await Shell.Current.GoToAsync("newpage");
            //
            // For more details, see https://docs.microsoft.com/ko-kr/xamarin/xamarin-forms/app-fundamentals/shell/navigation
            //Services.Logger.Info($"Heart rate: Hello there");
            OnButtonClicked?.Invoke(null, EventArgs.Empty);
        }
        public void OnDataChanged(object sender, int args)
        {
            HeartBeat = args;
            prompt = HeartBeat.ToString() + " " + "uderzeń/min";
            OnPropertyChanged(nameof(Prompt));
            
        }

        private string prompt;
        private string reasumeButton = "Rozpocznij Pomiar";

        public string ReasumeButton { get => reasumeButton; set => Set(ref reasumeButton, value); }

        public string Prompt { get => prompt; set => Set(ref prompt, value); }
    }
}
