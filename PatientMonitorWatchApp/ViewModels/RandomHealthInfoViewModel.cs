using System;
using System.Collections.Generic;
using System.Windows.Input;

using PatientMonitorWatchApp.Mvvm;
using PatientMonitorWatchApp.Resources;
using Tizen.System;
using Tizen.Wearable.CircularUI.Forms;

using Xamarin.Forms;

namespace PatientMonitorWatchApp.ViewModels
{
    public partial class RandomHealthInfoViewModel : BaseViewModel
    {
            List<string> tips = new List<string> {
                "Postaraj się ograniczyć palenie.",
                "Mało ruchu?\nSpróbuj wyjść na spacer.",
            "Wszystko w normie.",
            "Pamiętaj o braniu leków.",
            "Stosuj się do zaleceń\nlekarza - dbaj o twoje zdrowie.",
            };
        public RandomHealthInfoViewModel()
        {
            ShowInformationPopup();
            ShowInformationPopupCommand = new Command(() => ShowInformationPopup());
        }

        public ICommand ShowInformationPopupCommand { get; private set; }

        // InformationPopup contains a text and a bottom button.
        // Note that if text and icon are set to at the same time on the bottom button, they are overlaid.

        private string GetRandomHealthMessage()
        {
            string result;
            if (!tips.Count.Equals(0))
            {
                int index = tips.Count - 1;
                result = tips[index];
                tips.RemoveAt(index);
            } else
            {
                result = "Chwilowo brak nowych wskazówek.";
            }
            return result;
        }

        private void ShowInformationPopup()
        {
            var informationPopup = new InformationPopup()
            {
                Text = GetRandomHealthMessage(),
                IsProgressRunning = false
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
