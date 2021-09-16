using CV19.Infrastructure.Commands;
using CV19.Models;
using CV19.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CV19.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private IEnumerable<DataPoint> _testDataPoint;
        public IEnumerable<DataPoint> TestDataPoint
        { 
            get => _testDataPoint; 
            set => Set(ref _testDataPoint, value); 
        }

        #region Заголовок окна
        private string _title = "Анализ статистики CV19";
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
            //set
            //{
            //    if (Equals(_title, value)) return;
            //    _title = value;
            //    OnPropertChanged();
            //    Set(ref _title, value);
            //}
        }
        #endregion
        #region Статус программы
        /// <summary>
        /// Статус программы
        /// </summary>
        private string _status = "Готово";
        /// <summary>
        /// Статус программы
        /// </summary>
        public string Status 
        { 
            get => _status; 
            set => Set(ref _status, value); 
        }
        #endregion
        #region Команды
        public ICommand CloseApplicationCommand { get; }
        private void OnCloseApplicationCommandExecutet(object p)
        {
            Application.Current.Shutdown();
        }
        private bool CanCloseApplicationCommandExecutet(object p) => true;


        #endregion
        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecutet, CanCloseApplicationCommandExecutet);
            var dataPoints = new List<DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x < 360; x += 0.1)
            {
                const double toRad = Math.PI / 180;
                var y = Math.Sin(2 * Math.PI * x * toRad);
                dataPoints.Add(new DataPoint { XValue = x, YValue = y });
            }
            TestDataPoint = dataPoints;
        }
    }
}
