using CommunityToolkit.Mvvm.Messaging.Messages;
using NYU.Domain;

namespace NYU.Windows.Messages;

public class TodoDeletedMessage : ValueChangedMessage<Todo>
{
    public TodoDeletedMessage(Todo value) : base(value)
    {
    }
}