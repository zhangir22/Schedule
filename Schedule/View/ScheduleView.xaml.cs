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
using Schedule.Models.Interface;
using Schedule.Models.Service;

namespace Schedule.View
{
    /// <summary>
    /// Логика взаимодействия для ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : Window
    {
        private ICaseService _caseService;
        private ICaseRedactService _redactService;
        private StackPanel GetViewStackPanel()
        {
            Style stackPanelStyle = new Style();
            stackPanelStyle.Setters.Add(new Setter(StackPanel.BackgroundProperty, Brushes.Transparent));
            StackPanel stackPanel = new StackPanel(); 
            stackPanel.Style = stackPanelStyle;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            stackPanel.VerticalAlignment = VerticalAlignment.Center;
            return stackPanel;
        }

        private TextBlock GetViewTextBlock()
        {
            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.TextAlignment = TextAlignment.Center;
            return tb;

        }

        private List<StackPanel> BuildList(IEnumerable<Case> cases)
        {
            List<StackPanel> stackPanels = new List<StackPanel>();
         
            
            foreach (var item in cases)
            {
                var box = GetViewStackPanel();
                var title = GetViewTextBlock();
                var description = GetViewTextBlock();
                var duratation = GetViewTextBlock();
                title.Text = item.NameCase;
                title.FontSize = 23;
                description.Text = item.DescriptionCase;
                duratation.Text = item.Duratation.ToString();
                box.Children.Add(title);
                box.Children.Add(description);
                box.Children.Add(duratation);
                stackPanels.Add(box);
            }
       
            return stackPanels;
        }
        private void ShowInfoState() 
        {
            CompletedView.Text = _caseService.GetCountCompleted().ToString();
            PendingView.Text = _caseService.GetCountPending().ToString();
            JeopardyView.Text = _caseService.GetCountJeopardy().ToString();
        }
        private void AddCasesToList()
        {
            List<Case> cases = _caseService.GetCases().Where(c => c.Pending == true).ToList();
           
            var lst = BuildList(cases);
            foreach (var item in lst)
            {
                ListData.Items.Add(item);
            }
        }
        public ScheduleView()
        {
            InitializeComponent();
            _caseService = new CaseService();
            ShowInfoState();
            AddCasesToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CaseCreate window = new CaseCreate();
            window.ShowDialog();
            Close();
        }
 
        private void DeleteItemInList()
        {
            ListData.Items.Remove(ListData.SelectedItem);
        }
        private void CompleteCaseButton_Click(object sender, RoutedEventArgs e)
        {
            StackPanel data = (StackPanel)ListData.SelectedItem;
            var nameOfCase = (TextBlock)data.Children[0];
            var descriptionOfCase = (TextBlock)data.Children[1];
            Case completedCase = _caseService.GetCases().FirstOrDefault(u => u.NameCase == nameOfCase.Text.ToString() && u.DescriptionCase == descriptionOfCase.Text.ToString());
            if(completedCase != null)
            {
                completedCase.Completed = true;
                completedCase.Pending = false;
                completedCase.Jeopardy = false;
                _redactService = new CaseRedact();
                _redactService.EditCase(completedCase.Id, completedCase);
                DeleteItemInList();
            }
        }
    }
}