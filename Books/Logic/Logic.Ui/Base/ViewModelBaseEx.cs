using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Ui.Base
{
    public class ViewModelBaseEx : ViewModelBase
    {
        public string WindowTitle { get; protected set; }
    }
}
