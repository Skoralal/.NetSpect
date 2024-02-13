//using System.Collections.Specialized;
//using System.ComponentModel;

using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace MauiApp1.ViewModel;
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    bool isBusy;
    [ObservableProperty]
    string title;
    [ObservableProperty]
    bool loaded = false;

    [ObservableProperty]
    bool notloaded = true;
}
