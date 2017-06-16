using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Ui.Services
{
    public interface INavigationServiceEx : INavigationService
    {
        /// <summary>
        /// Gets a page parameter.
        /// </summary>
        /// <value>
        /// The parameter.
        /// </value>
        object Parameter { get; }
    }
}
