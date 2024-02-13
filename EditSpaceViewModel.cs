using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel

{

    [QueryProperty("SubjectData", "SubjectData")]
    public partial class EditSpaceViewModel:BaseViewModel
    {
        public EditSpaceViewModel()
        {
            
        }
        [ObservableProperty]
        SubjectData subjectData;

        [RelayCommand]
        async Task GoBackAsync()
        {

            await Shell.Current.GoToAsync("//Home");
        }

        Editor editor = new Editor { Placeholder = "Enter text"};

    }
}
