using System;
using System.Windows.Input;

using PatientMonitorWatchApp.Mvvm;
using Tizen.Sensor;
using Xamarin.Forms;

namespace PatientMonitorWatchApp.ViewModels
{
    public class HeartbeatMonitorViewModel : BaseViewModel
    {
        Services.HeartRateMonitorService HRM = new Services.HeartRateMonitorService();
        private bool isUsed = true;
        //HeartbeatMonitorPageMoveButtonText.Text = "DUPA";
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
                HRM.SensorDataUpdated -= OnDataChanged;
                HRM.Stop();
                HRM.Dispose();
            }
                HRM.SensorDataUpdated += OnDataChanged;
                HRM.Start();
            // TODO: Insert code to handle the button clicked.
            //
            // To perform page navigation, use the GoToAsync method in Xamarin.Forms Shell API.
            // await Shell.Current.GoToAsync("newpage");
            //
            // For more details, see https://docs.microsoft.com/ko-kr/xamarin/xamarin-forms/app-fundamentals/shell/navigation
            //Services.Logger.Info($"Heart rate: Hello there");
        }
        public void OnDataChanged(object sender, int args)
        {
            
        }
    }
}
