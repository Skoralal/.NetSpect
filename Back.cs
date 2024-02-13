using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace MauiApp1.Service
{
    public class Back
    {
        List<Subject> subjects = new();
        public async Task<List<Subject>> GetSubjects()
        {
            

            
            string contents = File.ReadAllText($"{Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments).AbsoluteFile.Path}/NewMap.json");
            if ( contents.Length <3)
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("Map.json");
                using var reader = new StreamReader(stream);
                contents = reader.ReadToEnd();
            }
            //var  contents = File.ReadAllText(@"C:\prog_questionmark\!c#\NewMap.json");
            subjects = JsonSerializer.Deserialize<List<Subject>>(contents);
            return subjects;
        }

        public async void StoreSubjects(ObservableCollection<Subject> subjects)
        {
            string serializedSubjects = JsonSerializer.Serialize(subjects);
            var filename = FileSystem.Current.CacheDirectory;
            var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);
            File.WriteAllText($"{docsDirectory.AbsoluteFile.Path}/NewMap.json", serializedSubjects);
            Console.WriteLine(serializedSubjects);
            //var fullPath = Path.Combine(@"/data/user/0/com.companyname.mauiapp1/Data", "NewMap.json");
            //File.WriteAllText(fullPath, serializedSubjects);
            //Console.WriteLine(fullPath);
            //File.WriteAllText(@"C:\prog_questionmark\!c#\NewMap.json", serializedSubjects);
            Console.WriteLine(serializedSubjects);

            // start

            using var resourceStream = await FileSystem.OpenAppPackageFileAsync("serviceacc-413604-c52e711bcf31.json");

            try
            {
                string credcontents = File.ReadAllText($"{Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments).AbsoluteFile.Path}/serviceacc-413604-c52e711bcf31.json");
            }
            catch
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("serviceacc-413604-c52e711bcf31.json");
                using var reader = new StreamReader(stream);
                string credcontents = reader.ReadToEnd();
                File.WriteAllText($"{docsDirectory.AbsoluteFile.Path}/serviceacc-413604-c52e711bcf31.json", credcontents);
            }
            //
            
            //


            //string absolutePath = (resourceStream as FileStream).Name;

            var filePath = $"{docsDirectory.AbsoluteFile.Path}/NewMap.json";
            var apicredentialspath = $"{docsDirectory.AbsoluteFile.Path}/serviceacc-413604-c52e711bcf31.json";
            var credentialsapi = GoogleCredential.FromFile(apicredentialspath).CreateScoped(DriveService.ScopeConstants.Drive);
            var service = new DriveService(new BaseClientService.Initializer() { HttpClientInitializer = credentialsapi });
            var serviceemail = "tinslave@serviceacc-413604.iam.gserviceaccount.com";
            var folderid = "1Lz_tGNwv1v_cYHJH7JHfey3z17hDreSg";
            var mapid = "1h3bKPl5oyS8vTVXvwbnSEsKJah2y_40n";
            //var filemetadata = new Google.Apis.Drive.v3.Data.File()
            //{
            //    Name = "NewMap.json",
            //    Parents = new List<string>() { folderid }
            //};
            var updatedfilemetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = "Map.json",
            };

            //var requset = service.Files.List();
            //var results1 = await requset.ExecuteAsync();
            //foreach (var file in results1.Files)
            //{
            //    if (file.Name == "NewMap.json")
            //    {
            //        service.Files.Delete(file.Id);
            //    }
            //    Console.WriteLine($"{file.Name} - {file.MimeType} - {file.Id}");
            //}

            //await using (var fsSource = new FileStream(path: $"{docsDirectory.AbsoluteFile.Path}/NewMap.json", FileMode.Open, FileAccess.Read))
            //{
            //    var request = service.Files.Create(filemetadata, fsSource, "application/json");
            //    request.Fields = "*";
            //    var results = await request.UploadAsync(CancellationToken.None);
            //    if (results.Status == Google.Apis.Upload.UploadStatus.Failed)
            //    {
            //        Console.WriteLine(results.Exception.Message);
            //    }
            //    Console.WriteLine(request.ResponseBody.Id);
            //    var uploadedfileid = request.ResponseBody.Id;
            //    var uploadedfile = await service.Files.Get(uploadedfileid).ExecuteAsync();
            //    Console.WriteLine(uploadedfile.Name);
            //}

            await using (var uploadStream = new FileStream(path: $"{docsDirectory.AbsoluteFile.Path}/NewMap.json", FileMode.Open, FileAccess.Read))
            {
                var updateRequest = service.Files.Update(updatedfilemetadata, mapid, uploadStream, "application/json");
                var results = await updateRequest.UploadAsync(CancellationToken.None);
                if (results.Status == Google.Apis.Upload.UploadStatus.Failed)
                {
                    Console.WriteLine(results.Exception.Message);
                }
            }

            // file with given id is not found -- var mapid = "3NZY2bsd1ttRbidLiyo8SJV4SHxsvpKh9M";

            return;
        }


    }
}
