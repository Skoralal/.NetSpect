namespace MauiApp1.Views;

using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.ViewModel;

public partial class EditSpace : ContentPage
{
    public EditSpace(EditSpaceViewModel editSpaceViewModel)
	{
		InitializeComponent();
		BindingContext = editSpaceViewModel;

    }
	
}