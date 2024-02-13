using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class SubjectData
    {
        public string Timestamp { get; set; }
        public string Text { get; set; }
    }
    public class Subject
    {
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }
        public List<SubjectData> SubjectData { get; set; }
    }
}
