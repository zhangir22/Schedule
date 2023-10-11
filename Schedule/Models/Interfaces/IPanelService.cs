using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Schedule.Models.Interfaces
{
    public interface IPanelService
    {
        TextBlock GetTextBlock(string txt);
        WrapPanel GetWrapPanel();
        List<WrapPanel> GetDataViewBox();
        void FillAllStateBlocks(TextBlock completedBlock, TextBlock pendingBlock, TextBlock jeopardyBlock);
    }
}
