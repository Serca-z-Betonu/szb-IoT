using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tizen.Sensor;

namespace PatientMonitorWatchApp.Services
{
    public class HeartRateMonitorService : IDisposable
    {
        private HeartRateMonitor _sensor;

        private bool _disposed = false;
        public event EventHandler<int> SensorDataUpdated;
        public event EventHandler SensorNotSupported;
        public event EventHandler SensorNotAuthorized;

        /// <summary>
        /// Initializes the sensor
        /// </summary>
        /// <exception cref="NotSupportedException">The device does not support the sensor</exception>
        /// <exception cref="UnauthorizedAccessException">The user does not grant your app access to sensors</exception>
        public HeartRateMonitorService()
        {
            try
            {
                _sensor = new HeartRateMonitor();
                _sensor.DataUpdated += OnSensorDataUpdated;
                _sensor.PausePolicy = SensorPausePolicy.None;
                 _sensor.Interval = 1000;
            }
            catch (NotSupportedException)
            {
                SensorNotSupported?.Invoke(this, EventArgs.Empty);
            }
            catch (UnauthorizedAccessException)
            {
                SensorNotAuthorized?.Invoke(this, EventArgs.Empty);
            }
        }

        ~HeartRateMonitorService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Starts the sensor to receive sensor data
        /// </summary>
        public void Start()
        {
            _sensor.Start();
        }

        /// <summary>
        /// Stops receiving sensor data
        /// </summary>
        /// <remarks>
        /// Reduce battery drain by stopping the sensor when it is not needed
        /// </remarks>
        public void Stop()
        {
            _sensor.Stop();
        }

        /// <summary>
        /// Releases all resources used by the current instance
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the current instance
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _sensor.DataUpdated -= OnSensorDataUpdated;
                    _sensor.Dispose();
                }

                _sensor = null;
                _disposed = true;
            }
        }

        /// <summary>
        /// Called when the heart rate has changed
        /// </summary>
        private void OnSensorDataUpdated(object sender, HeartRateMonitorDataUpdatedEventArgs e)
        {
            SensorDataUpdated?.Invoke(this, e.HeartRate);
            Logger.Info($"Heart rate: {e.HeartRate}");
        }
    }
}
