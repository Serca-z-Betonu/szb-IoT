﻿using System;

using PatientMonitorWatchApp.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace PatientMonitorWatchApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            // The app has to request the permission to obtain the location information
            RequestPermissionLocationAsync();

            // The app has to request the permission to access sensors
            RequestPermissionSensorAsync();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        /// <summary>
        /// The app has to request the permission to obtain the location information.
        /// </summary>
        private async void RequestPermissionLocationAsync()
        {
            var response = await PrivacyPermissionService.RequestAsync(PrivacyPrivilege.Location);
            if (response == PrivacyPermissionStatus.Granted)
            {
                // TODO: The permission was granted
            }
            else
            {
                // TODO: The user denied the permission
            }
        }

        /// <summary>
        /// The app has to request the permission to access sensors.
        /// </summary>
        private async void RequestPermissionSensorAsync()
        {
            var response = await PrivacyPermissionService.RequestAsync(PrivacyPrivilege.HealthInfo);
            if (response == PrivacyPermissionStatus.Granted)
            {
                // TODO: The permission was granted
            }
            else
            {
                // TODO: The user denied the permission
            }
        }
    }
}
