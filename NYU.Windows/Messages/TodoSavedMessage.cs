using CommunityToolkit.Mvvm.Messaging.Messages;
using NYU.Domain;

namespace NYU.Windows.Messages;

public class TodoSavedMessage : ValueChangedMessage<Todo>
{
    public TodoSavedMessage(Todo value) : base(value)
    {
    }
}
