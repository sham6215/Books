using Logic.Ui.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Ui.Pages
{
    public class AboutPageViewModel : ViewModelBaseEx
    {
        public AboutPageViewModel()
        {
            Init();
        }

        public void Init()
        {
            if (IsInDesignMode || IsInDesignModeStatic)
            {
                WindowTitle = "About Page (Design)";
            } else
            {
                WindowTitle = "About Page";
            }
        }
    }

    
}
