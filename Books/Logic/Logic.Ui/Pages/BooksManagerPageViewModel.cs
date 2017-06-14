using Logic.Ui.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Ui.Pages
{
    public class BooksManagerPageViewModel : ViewModelBaseEx
    {
        public BooksManagerPageViewModel()
        {
            Init();
        }

        public void Init()
        {
            if (IsInDesignMode || IsInDesignModeStatic)
            {
                WindowTitle = "Books Manager Page (Design)";
            }
            else
            {
                WindowTitle = "Books Manager Page";
            }
        }
    }
}
