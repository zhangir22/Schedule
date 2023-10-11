using Schedule.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Schedule.Models.Service
{
    public class PanelService:IPanelService
    {
        readonly TreeService _treeService = new TreeService();
        private List<Case> _lstCases;
        public PanelService()
        {
            _lstCases = new CaseService().GetCases();
        }
        public TextBlock GetTextBlock(string text)
        {

            Style style = new Style(typeof(TextBlock));
            style.Setters.Add(new Setter(TextBlock.ForegroundProperty, Brushes.White));
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Style = style;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.FontSize = 22;
            return textBlock;
        }
        public WrapPanel GetWrapPanel()
        {
            WrapPanel panel = new WrapPanel();
            panel.Height = 100;
            panel.Width = 200;
            panel.VerticalAlignment = VerticalAlignment.Center;
            panel.HorizontalAlignment = HorizontalAlignment.Center;
            panel.Orientation = Orientation.Vertical;
            panel.Margin = new Thickness(25, 10, 10, 10);
            panel.Background = new SolidColorBrush(Colors.LightBlue);
            return panel;
        }
        public List<WrapPanel> GetDataViewBox()
        {
            List<WrapPanel> blocks = new List<WrapPanel>();


            foreach (var item in _treeService.GetTree(_lstCases))
            {
                WrapPanel panel = GetWrapPanel();

                TextBlock idBlock = GetTextBlock(item.Key);
                idBlock.FontSize = 11;
                idBlock.Focusable = false;
                TextBlock nameBlock = GetTextBlock(item.Value.NameCase.ToString());
                TextBlock duratationBlock = GetTextBlock(_lstCases.FirstOrDefault(u=>u.Id == item.Key).Duratation.ToString() + " h.") ;

                panel.Children.Add(idBlock);
                panel.Children.Add(nameBlock);
                panel.Children.Add(duratationBlock);
                blocks.Add(panel);
            }
            return blocks;
        }
        public void FillAllStateBlocks(TextBlock completed,TextBlock pending,TextBlock jeopardy)
        {
            completed.Text = _lstCases.Where(c => c.Completed == true).Count().ToString();
            pending.Text = _lstCases.Where(c=>c.Pending == true).Count().ToString();
            jeopardy.Text = _lstCases.Where(c=>c.Jeopardy == true).Count().ToString();
        }
    }
}
