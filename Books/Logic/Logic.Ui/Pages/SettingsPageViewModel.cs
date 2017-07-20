using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Logic.Ui.Base;
using Logic.Ui.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic.Ui.Pages
{
    public class SettingsPageViewModel : ViewModelBaseEx
    {
        public SettingsPageViewModel()
        {
            Init();
        }

        public void Init()
        {
            if (IsInDesignMode || IsInDesignModeStatic)
            {
                WindowTitle = "Settings Page (Design)";
            }
            else
            {
                WindowTitle = "Settings Page";
            }
        }

        private RelayCommand _longOperationCommand;

        public string OperationLabelContent { get; set; }

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand LongOperationCommand
        {
            get
            {
                return _longOperationCommand
                    ?? (_longOperationCommand = new RelayCommand(
                    () =>
                    {
                        OperationLabelContent = "Start";
                        Task.Run(() => { LongOperation(); })
                        .ContinueWith((task) => {
                            if (task.IsCompleted)
                                OperationLabelContent = "Complete: " + task.Status.ToString();
                            else if (task.IsCanceled)
                                OperationLabelContent = "Cancelled: " + task.Status.ToString();
                            else
                                OperationLabelContent = "Failed: " + task.Status.ToString();
                            Messenger.Default.Send<BusyIndicatorHideMessage>(new BusyIndicatorHideMessage());
                        });
                    }));
            }
        }

        private void LongOperation()
        {
            CancellationTokenSource ts = new CancellationTokenSource();

            BusyIndicatorShowMessage startMessage = new BusyIndicatorShowMessage() {
                BusyIndicator = new BusyIndicatorBase() {
                    BusyCancelVisibility = System.Windows.Visibility.Visible,
                    BusyContent = "Settings Page Progress: ",
                    BusyContentVisibility = System.Windows.Visibility.Visible,
                    BusyProgressMaximum = 100,
                    BusyProgressValue = 0,
                    BusyProgressVisibility = System.Windows.Visibility.Visible,
                    BusyTitle = " Wait for Settings",
                    BusyTitleVisibility = System.Windows.Visibility.Visible,
                    IsBusy = true
                },
                Canceller = ts
            };

            Messenger.Default.Send<BusyIndicatorShowMessage>(startMessage);
            for (int i = 0; i < 100; ++i)
            {
                ts.Token.ThrowIfCancellationRequested();
                Thread.Sleep(20);
                Messenger.Default.Send<BusyIndicatorUpdateMessage>(new BusyIndicatorUpdateMessage());
            }
        }
    }
}
