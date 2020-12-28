using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Alkemy.Models.ViewModels
{
    public class TeacherViewModel
    {

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "DNI")]
        public int Dni { get; set; }

    }

    public class EditTeacherViewModel
    {

        public int Teacher_Id { get; set; }
        
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        
        [Display(Name = "DNI")]
        public int Dni { get; set; }

    }

}