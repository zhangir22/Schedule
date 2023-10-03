using Schedule.Models;
using Schedule.Models.Interface;
using Schedule.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Schedule.View
{
    /// <summary>
    /// Логика взаимодействия для CaseCreate.xaml
    /// </summary>
    public partial class CaseCreate : Window
    {
        ICaseRedactService _caseService;
        public CaseCreate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Refresh()
        {
            TextBoxNameCase.Text = string.Empty;
            TextBoxDescriptionCase.Text = string.Empty;
         

        }
        private void Complete_Click(object sender, RoutedEventArgs e)
        {
            _caseService = new CaseRedact();
            Case newCase = new Case();
            newCase.NameCase = TextBoxNameCase.Text;
            newCase.DescriptionCase = TextBoxDescriptionCase.Text;
            newCase.StartTime = Convert.ToDateTime(TextBoxStartTime.Text);
            newCase.EndTime = Convert.ToDateTime(TextBoxEndTime.Text);
            newCase.Duratation = (newCase.EndTime - newCase.StartTime).TotalHours;
            if(newCase.Duratation > 0)
            {
                newCase.Pending = true;
                newCase.Completed = false;
                newCase.Jeopardy = false;
            }
            if(newCase.Duratation <= 0)
            {
                newCase.Pending = false;
                newCase.Completed = false;
                newCase.Jeopardy = true;
            }
            _caseService.AddCase(newCase);
            
            Close();
        }
    }
}
