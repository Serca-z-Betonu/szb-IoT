using System;
using System.Windows.Input;

using PatientMonitorWatchApp.Mvvm;
using PatientMonitorWatchApp.Resources;

using Tizen.Wearable.CircularUI.Forms;

using Xamarin.Forms;

namespace PatientMonitorWatchApp.ViewModels
{
    public partial class RandomHealthInfoViewModel : BaseViewModel
    {
        public RandomHealthInfoViewModel()
        {
            ShowInformationPopupCommand = new Command(() => ShowInformationPopup());
        }

        public ICommand ShowInformationPopupCommand { get; private set; }

        // InformationPopup contains a text and a bottom button.
        // Note that if text and icon are set to at the same time on the bottom button, they are overlaid.
        private void ShowInformationPopup()
        {
            var informationPopup = new InformationPopup()
            {
                Text = AppResources.RandomHealthInfoPagePopupText,
                IsProgressRunning = true
            };

            informationPopup.BackButtonPressed += (s, e) =>
            {
                informationPopup.Dismiss();
                informationPopup = null;
            };

            informationPopup.BottomButton = new MenuItem()
            {
                Text = AppResources.RandomHealthInfoPageOkButtonText,
                Command = new Command(() =>
                {
                    informationPopup?.Dismiss();
                    informationPopup = null;
                })
            };

            informationPopup.Show();
        }
    }
}
