using Logic.Ui.Base;

namespace Logic.Ui.ViewModel
{
    using Constants;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using Messages;
    using System.Threading;
    using System.Threading.Tasks;
    using System;
    using System.Windows;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBaseEx, IBusyIndicator
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode || IsInDesignModeStatic)
            {
                WindowTitle = "Books Application (Design)";
            }
            else
            {
                WindowTitle = "Books Application";
            }

            IsBusy = false;
            BusyContent = "Busy Content";
            BusyContentVisibility = Visibility.Visible;
            BusyTitle = "Wait please...";
            BusyTitleVisibility = Visibility.Visible;
            BusyCancelVisibility = Visibility.Collapsed;
            BusyProgressVisibility = Visibility.Visible;
            BusyProgressValue = 0;
            
        }

        private RelayCommand _nextCommand;

        /// <summary>
        /// Gets the NextCommand.
        /// </summary>
        public RelayCommand NextCommand
        {
            get
            {
                return _nextCommand
                    ?? (_nextCommand = new RelayCommand(
                    () =>
                    {
                        MessengerInstance.Send(new NavigationMessage(NavigationKey.About));
                    }));
            }
        }

        private RelayCommand _loadedCommand;

        /// <summary>
        /// Gets the LoadedCommand.
        /// </summary>
        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                    ?? (_loadedCommand = new RelayCommand(
                    () =>
                    {
                        MessengerInstance.Send(new NavigationMessage(NavigationKey.BooksManager));
                    }));
            }
        }

        private RelayCommand _buisyCommand;

        /// <summary>
        /// Gets the BuisyCommand.
        /// </summary>
        public RelayCommand BusyCommand
        {
            get
            {
                return _buisyCommand
                    ?? (_buisyCommand = new RelayCommand(
                    () =>
                    {
                        IsBusy = true;
                        Task.Factory.StartNew(() =>
                        {
                            for (int i = 0; i < 100; i++)
                            {
                                Thread.Sleep(50);
                                BusyContent = $"Progress: {i+1}%";
                                BusyProgressValue = i + 1;
                            }

                        }).ContinueWith((task) => { IsBusy = false; });
                    }));
            }
        }

        public bool IsBusy { get; set; }

        public string BusyTitle { get; set; }

        public Visibility BusyTitleVisibility { get; set; }

        public string BusyContent { get; set; }

        public Visibility BusyContentVisibility { get; set; }

        public int BusyProgressValue { get; set; }

        public Visibility BusyProgressVisibility { get; set; }

        public Visibility BusyCancelVisibility { get; set; }
    }
}