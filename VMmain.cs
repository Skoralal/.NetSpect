using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Service;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Views;
namespace MauiApp1.ViewModel
{
    public partial class VMmain : BaseViewModel
    {
        Back Back;
        public ObservableCollection<Subject> Subjects { get; } = new();

        public VMmain(Back Back)
        {
            Title = "Subjects";
            this.Back = Back;
        }
        [RelayCommand]
        async Task OpenWorkspaceAsync(Subject subject)
        {
            await Shell.Current.GoToAsync($"{nameof(SubjectSpace)}", false, new Dictionary<string, object>
            {
                {"Subject", subject }
            });
        }
        [RelayCommand]
        async Task GetSubjectsAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var subjects = await Back.GetSubjects();
                if (Subjects.Count != 0)
                
                    Subjects.Clear();
                    foreach (var subject in subjects) 
                        Subjects.Add(subject);
                
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("aboba",ex.Message, "ok");
            }
            IsBusy = false;
            Loaded = true;
            Notloaded = false;
        }

        [RelayCommand]
        async Task StoreSubjectsAsync(ObservableCollection<Subject> subjects)
        {
            Back.StoreSubjects(subjects);
        }
        
    }
}
