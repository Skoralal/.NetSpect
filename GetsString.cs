using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Service
{
    public class GetsString
    {
        List<StringSubject> stringsubjects = new();
        public async Task<List<StringSubject>> GetStrings(string mappedName)
        {
            
            using var stream = await FileSystem.OpenAppPackageFileAsync(mappedName+".json");
            using var reader = new StreamReader(stream);

            var contents = reader.ReadToEnd();

            stringsubjects = JsonSerializer.Deserialize<List<StringSubject>>(contents);
            return stringsubjects;
        }


    }
}
