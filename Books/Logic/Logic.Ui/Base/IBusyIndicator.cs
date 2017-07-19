using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Logic.Ui.Base
{
    interface IBusyIndicator
    {
        bool IsBusy { get; set; }
        string BusyTitle { get; set; }
        Visibility BusyTitleVisibility { get; set; }
        string BusyContent { get; set; }
        Visibility BusyContentVisibility { get; set; }
        int BusyProgressValue { get; set; }
        Visibility BusyProgressVisibility { get; set; }
        Visibility BusyCancelVisibility { get; set; }
    }
}
