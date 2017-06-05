using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Ui.BaseTypes
{
    public class BaseViewModel : ViewModelBase
    {
        #region Properties
        public string WindowTitle { get; protected set; }
        #endregion

        public BaseViewModel()
        {
            if (!IsInDesignModeStatic && !IsInDesignMode)
            {
                //DispatcherHelper.Initialize();
            }
        }
    }
}
