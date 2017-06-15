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
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

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

        private static void SetupNavigation()
        {
            var navigationService = new NavigationServiceEx();
            navigationService.Configure("LoginView", new Uri("../Views/LoginView.xaml", UriKind.Relative));
            navigationService.Configure("Notes", new Uri("../Views/NotesView.xaml", UriKind.Relative));

            SimpleIoc.Default.Register<INavigationServiceEx>(() => navigationService);
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