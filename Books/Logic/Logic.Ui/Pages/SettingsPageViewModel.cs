using Logic.Ui.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Ui.Pages
{
    public class SettingsPageViewModel : ViewModelBaseEx
    {
        public SettingsPageViewModel()
        {
            Init();
        }

        public void Init()
        {
            if (IsInDesignMode || IsInDesignModeStatic)
            {
                WindowTitle = "Settings Page (Design)";
            }
            else
            {
                WindowTitle = "Settings Page";
            }
        }
    }
}
