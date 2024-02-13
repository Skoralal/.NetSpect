using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.ViewModel;

namespace MauiApp1.Views;

public partial class SubjectSpace : ContentPage
{
	

	public SubjectSpace(SubjectSpaceViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}