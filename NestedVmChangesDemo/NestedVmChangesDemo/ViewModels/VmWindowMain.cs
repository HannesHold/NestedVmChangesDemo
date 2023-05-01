using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using NestedVmChangesDemo.Messages;

namespace NestedVmChangesDemo.ViewModels
{
    public partial class VmWindowMain : ObservableRecipient
    {
        #region Constructors

        public VmWindowMain()
        {
            RegisterMessages();
        }

        #endregion

        #region Methods

        // See: https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/messenger
        private void RegisterMessages()
        {
            WeakReferenceMessenger.Default.Register<NestedDataChangedMessage>(this, (r, m) =>
            {
                // Handle the message here, with r being the recipient and m being the
                // input message. Using the recipient passed as input makes it so that
                // the lambda expression doesn't capture "this", improving performance.
                System.Diagnostics.Debug.WriteLine("Run Received Message()");
                MyCommand.NotifyCanExecuteChanged();
            });
        }

        #endregion

        #region Properties

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(MyCommand))]
        private string _title = "PhD";

        public VmNestedData NestedData { get; set; } = new();

        #endregion

        #region Commands

        #region MyCommand

        [RelayCommand(CanExecute = nameof(CanExecuteMy))]
        private void My()
        {
            // Do some stuff
            System.Diagnostics.Debug.WriteLine("Run My()");
        }

        private bool CanExecuteMy()
        {
            System.Diagnostics.Debug.WriteLine("Run CanExecuteMy()");

            // Determine if stuff can be done. (Enabled disables button on its own)
            return !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(NestedData.Name) && NestedData.Age > 18;
        }

        #endregion

        #endregion
    }
}
