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
    using AOP;
    using GalaSoft.MvvmLight.Messaging;

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
        /// 
        [Logged]
        public MainViewModel()
        {
            Init();
        }

        private void Init()
        {
            if (IsInDesignMode || IsInDesignModeStatic)
            {
                WindowTitle = "Books Application (Design)";
            }
            else
            {
                WindowTitle = "Books Application";
            }

            InitMessanger();

            IsBusy = false;
            BusyContent = "Busy Content";
            BusyContentVisibility = Visibility.Visible;
            BusyTitle = "Wait please...";
            BusyTitleVisibility = Visibility.Visible;
            BusyCancelVisibility = Visibility.Visible;
            BusyProgressVisibility = Visibility.Visible;
            BusyProgressValue = 0;
            BusyProgressMaximum = 100;
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
                        int i = new Random().Next() % 3;
                        string page = string.Empty;
                        switch (i)
                        {
                            case 0:
                                page = NavigationKey.About;
                                break;
                            case 1:
                                page = NavigationKey.BooksManager;
                                break;
                            default:
                                page = NavigationKey.Settings;
                                break;
                        }

                        MessengerInstance.Send(new NavigationMessage(page));
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

        /// <summary>
        /// Gets the BuisyCommand.
        /// </summary>
        private RelayCommand _buisyCommand;
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

        private CancellationTokenSource _canceller;
        private CancellationTokenSource _Canceller {
            get {
                return _canceller;
            }
            set {
                if (_canceller != null)
                    _canceller.Cancel();
                _canceller = value;
            }
        }

        #region IBusyIndicator implementation //////////////////////////

        public bool IsBusy { get; set; }

        public string BusyTitle { get; set; }

        public Visibility BusyTitleVisibility { get; set; }

        public string BusyContent { get; set; }

        public Visibility BusyContentVisibility { get; set; }

        public int BusyProgressValue { get; set; }
        public int BusyProgressMaximum { get; set; }

        public Visibility BusyProgressVisibility { get; set; }

        public Visibility BusyCancelVisibility { get; set; }

        private RelayCommand _busyCancelCommand;
        public RelayCommand BusyCancelCommand
        {
            get
            {
                return _busyCancelCommand
                    ?? (_busyCancelCommand = new RelayCommand(
                    () =>
                    {
                        IsBusy = false;
                        _Canceller?.Cancel();
                        _Canceller = null;
                    }));
            }
        }

        #endregion IBusyIndicator implementation //////////////////////////


        #region Messanger
        private void InitMessanger()
        {
            Messenger.Default.Register<BusyIndicatorShowMessage>(this, OnBusyIndicatorShowMessage);
            Messenger.Default.Register<BusyIndicatorUpdateMessage>(this, OnBusyIndicatorUpdateMessage);
            Messenger.Default.Register<BusyIndicatorHideMessage>(this, OnBusyIndicatorHideMessage);
        }

        private void OnBusyIndicatorHideMessage(BusyIndicatorHideMessage obj)
        {
            IsBusy = false;
            _Canceller?.Cancel();
            _Canceller = null;
        }

        private void OnBusyIndicatorUpdateMessage(BusyIndicatorUpdateMessage obj)
        {
            BusyProgressValue += 1;
        }

        private void OnBusyIndicatorShowMessage(BusyIndicatorShowMessage obj)
        {
            IsBusy = true;
            if (obj.Canceller != null)
                _Canceller = obj.Canceller;
        }
        #endregion Messanger
    }
}