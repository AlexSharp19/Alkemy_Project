using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alkemy.Models.TableViewModels
{
    public class SubjectTableViewModel
    {
        public int Id_Subject { get; set; }
        public string Name { get; set; }

        public System.TimeSpan Start_Time { get; set; }

        public System.TimeSpan Ending_Time { get; set; }

        public string Day { get; set; }

        public string Name_Teacher { get; set; }

        public string LastName_Teacher { get; set; }

        public int Quota { get; set; }

    }
}