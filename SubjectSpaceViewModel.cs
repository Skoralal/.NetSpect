using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Service;
using MauiApp1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    [QueryProperty("Subject", "Subject")]
    public partial class SubjectSpaceViewModel:BaseViewModel
    {
        public SubjectSpaceViewModel() 
        {
            
        }
        [ObservableProperty]
        Subject subject;
        //[ObservableProperty]
        //SubjectData subjectData;

        [RelayCommand]
        async Task GoToEditAsync(SubjectData subjectdata)
        {
            await Shell.Current.GoToAsync($"{nameof(EditSpace)}", false, new Dictionary<string, object>
        {
            {"SubjectData", subjectdata }
        });
        }

        [RelayCommand]
        public async Task<Subject> NewDataAsync(Subject OldSubjectData)
        {
            
            var subjectdata = new SubjectData();
            subjectdata.Timestamp = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm");
            subjectdata.Text = string.Empty;
            OldSubjectData.SubjectData.Add(subjectdata);
            Console.WriteLine(OldSubjectData.SubjectName);
            Console.WriteLine(OldSubjectData.SubjectData.Count);
            await GoToEditAsync(OldSubjectData.SubjectData[OldSubjectData.SubjectData.Count-1]);
            return OldSubjectData;
        }
        

    }

}


