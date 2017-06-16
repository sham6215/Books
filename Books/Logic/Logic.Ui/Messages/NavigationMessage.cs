using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Ui.Messages
{
    public class NavigationMessage
    {
        /// <summary>
        /// Use a value from Constants.NavigationKey class
        /// </summary>
        public string NavigationKey { get; set; }
        /// <summary>
        /// The parameter is passed into handling class
        /// </summary>
        public object Parameter { get; set; }

        public NavigationMessage(string navigationKey, object parameter = null)
        {
            NavigationKey = navigationKey;
            Parameter = parameter;
        }
    }
}
