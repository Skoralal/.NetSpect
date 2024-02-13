using MauiApp1.ViewModel;
using MauiApp1.Service;
namespace MauiApp1.Views;

public partial class Home : ContentPage
{
	public Home(VMmain viewmodel)
	{
		InitializeComponent();
        BindingContext = viewmodel;
	}
}