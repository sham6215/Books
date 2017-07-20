using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Ui.Services;
using Logic.Ui.Messages;
using Logic.Ui.Constants;

namespace Logic.Ui
{
    public class MessageListener
    {
        private INavigationServiceEx NavigationService { get; set; }
        private IMessenger Messanger { get; set; }
        public bool IsVisible => true;

        public MessageListener(INavigationServiceEx navigationService, IMessenger messanger)
        {
            NavigationService = navigationService;
            Messanger = messanger;

            Init();
        }

        private void Init()
        {
            if (Messanger != null)
            {
                Messanger.Register<NavigationMessage>(this, OnNavigationMessage);
            }
        }

        private void OnNavigationMessage(NavigationMessage msg)
        {
            NavigationService.NavigateTo(msg?.NavigationKey ?? NavigationKey.About);
        }



    }
}
