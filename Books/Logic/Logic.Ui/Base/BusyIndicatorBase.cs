using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace Logic.Ui.Base
{
    class BusyIndicatorBase : IBusyIndicator
    {
        public RelayCommand BusyCancelCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Visibility BusyCancelVisibility { get; set; }

        public string BusyContent { get; set; }

        public Visibility BusyContentVisibility { get; set; }

        public int BusyProgressMaximum { get; set; }

        public int BusyProgressValue { get; set; }

        public Visibility BusyProgressVisibility { get; set; }

        public string BusyTitle { get; set; }

        public Visibility BusyTitleVisibility { get; set; }

        public bool IsBusy { get; set; }
    }
}
