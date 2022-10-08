using System;
using System.Windows.Input;

using PatientMonitorWatchApp.Mvvm;

using Xamarin.Forms;

namespace PatientMonitorWatchApp.ViewModels
{
    public class HeartbeatMonitorViewModel : BaseViewModel
    {
        public HeartbeatMonitorViewModel()
        {
            ClickButtonCommand = new Command(() => ClickButton());
        }

        public ICommand ClickButtonCommand { get; private set; }

        // Called when the button is clicked.
        private void ClickButton()
        {
            // TODO: Insert code to handle the button clicked.
            //
            // To perform page navigation, use the GoToAsync method in Xamarin.Forms Shell API.
            // await Shell.Current.GoToAsync("newpage");
            //
            // For more details, see https://docs.microsoft.com/ko-kr/xamarin/xamarin-forms/app-fundamentals/shell/navigation
        }
    }
}
