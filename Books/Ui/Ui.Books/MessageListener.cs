using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ui.Books
{
    class MessageListener
    {
        public MessageListener()
        {
            Init();
        }

        private void Init()
        {

        }


        /// <summary>
        /// This property is needed just to instantiate MessageListener in the main window xaml
        /// </summary>
        public bool BindingProperty => true;
    }
}
