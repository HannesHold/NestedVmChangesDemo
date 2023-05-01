using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using NestedVmChangesDemo.Messages;

namespace NestedVmChangesDemo.ViewModels
{
    public partial class VmNestedData : ObservableObject
    {
        #region Properties

        [ObservableProperty]       
        private string _name;

        [ObservableProperty]
        private int _age;

        #endregion

        #region Methods

        partial void OnNameChanged(string value)
        {
            WeakReferenceMessenger.Default.Send(new NestedDataChangedMessage(this));
        }

        partial void OnAgeChanged(int value)
        {
            WeakReferenceMessenger.Default.Send(new NestedDataChangedMessage(this));
        }

        #endregion
    }
}
