using Logic.Ui.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Threading;

namespace Logic.Ui.Messages
{
    class BusyIndicatorShowMessage
    {
        public IBusyIndicator BusyIndicator { get; set; }
        /// <summary>
        /// Can be used when BusyCancel button is clicked
        /// </summary>
        public CancellationTokenSource Canceller { get; set; }
    }

    class BusyIndicatorUpdateMessage
    {
        public IBusyIndicator BusyIndicator { get; set; }
    }

    class BusyIndicatorHideMessage
    {
    }
}
