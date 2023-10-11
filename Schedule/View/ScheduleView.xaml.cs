using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Schedule.Models;
using Bitlush;
using Schedule.Models.Interfaces;
using Schedule.Models.Service;

namespace Schedule.View
{
    /// <summary>
    /// Логика взаимодействия для ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : Window
    {
        readonly IPanelService _panelService = new PanelService();
 
        private void FillAlllBoxes()
        {
            var data = _panelService.GetDataViewBox();
            _panelService.FillAllStateBlocks(CompletedView,PendingView,JeopardyView);
            foreach (var item in data)
            {
                box.Children.Add(item);
            }

        }
        public ScheduleView()
        {
            InitializeComponent();

            CurrentDate.Content = DateTime.Now.ToString("MMM hh-ddd");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FillAlllBoxes();
        }
    }
}