using CommunityToolkit.Mvvm.Messaging.Messages;
using NestedVmChangesDemo.ViewModels;

namespace NestedVmChangesDemo.Messages
{
    public class NestedDataChangedMessage : ValueChangedMessage<VmNestedData>
    {
        public NestedDataChangedMessage(VmNestedData nestedData) : base(nestedData)
        {
        }
    }
}
