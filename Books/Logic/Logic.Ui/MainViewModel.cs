using Logic.Ui.Base;

namespace Logic.Ui.ViewModel
{
    using Constants;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using Messages;

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
    public class MainViewModel : ViewModelBaseEx
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
    }
}