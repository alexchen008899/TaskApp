using NYU.Windows.UserControls;
using NYU.Windows.ViewModels;
using System;
using System.Windows.Controls;

namespace NYU.Windows.Factories;

public class TodoUserControlFactory
{
    public static UserControl CreateUserControl(ITodoViewModel viewModel)
    {
        UserControl control = viewModel switch
        {
            BugViewModel => new BugControl(viewModel),
            FeatureViewModel => new FeatureControl(viewModel),
            _ => throw new NotImplementedException()
        };

        return control;
    }
}
