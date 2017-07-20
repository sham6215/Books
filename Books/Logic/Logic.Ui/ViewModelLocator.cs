/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Ui.Books"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Logic.Ui.AOP;
using Logic.Ui.Constants;
using Logic.Ui.Pages;
using Logic.Ui.Services;
using Microsoft.Practices.ServiceLocation;
using System;

namespace Logic.Ui.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        [Logged]
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SetupNavigation();

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AboutPageViewModel>();
            SimpleIoc.Default.Register<SettingsPageViewModel>();
            SimpleIoc.Default.Register<BooksManagerPageViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public AboutPageViewModel About => ServiceLocator.Current.GetInstance<AboutPageViewModel>();
        public SettingsPageViewModel Settings => ServiceLocator.Current.GetInstance<SettingsPageViewModel>();
        public BooksManagerPageViewModel BooksManager => ServiceLocator.Current.GetInstance<BooksManagerPageViewModel>();
        public MessageListener MessageListener => ServiceLocator.Current.GetInstance<MessageListener>();

        private void SetupNavigation()
        {
            var navigationService = new NavigationServiceEx();
            navigationService.Configure(NavigationKey.About, new Uri("Pages/AboutPage.xaml", UriKind.Relative));
            navigationService.Configure(NavigationKey.Settings, new Uri("Pages/SettingsPage.xaml", UriKind.Relative));
            navigationService.Configure(NavigationKey.BooksManager, new Uri("Pages/BooksManagerPage.xaml", UriKind.Relative));

            if (!SimpleIoc.Default.IsRegistered<MessageListener>())
                SimpleIoc.Default.Register(() => new MessageListener(navigationService, Messenger.Default));
        }

        /// <summary>
        /// TODO: Investigate why do we need Cleanup()
        /// </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}