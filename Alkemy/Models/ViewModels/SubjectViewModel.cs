using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Alkemy.Models.ViewModels
{
    public class SubjectViewModel
    {
        [Required]
        [Display(Name = "Materia")]
        public string Subject_Name { get; set; }

        [Required]
        [Display(Name = "Dia")]
        public string Day { get; set; }

        [Required]
        [Display(Name = "Hora de Inicio")]
        public System.TimeSpan StartTime { get; set; }

        [Required]
        [Display(Name = "Hora de Finalizacion")]
        public System.TimeSpan EndingTime { get; set; }

        [Required]
        [Display(Name = "Id de Profesor")]
        public int Teacher_Id { get; set; }

        [Required]
        [Display(Name = "Cupos")]
        public int Quota { get; set; }

    }

    public class EditSubjectViewModel
    {

        public int Subject_Id { get; set; }

        [Required]
        [Display(Name = "Materia")]
        public string Subject_Name { get; set; }

        [Required]
        [Display(Name = "Dia")]
        public string Day { get; set; }

        [Required]
        [Display(Name = "Hora de Inicio")]
        public System.TimeSpan StartTime { get; set; }

        [Required]
        [Display(Name = "Hora de Finalizacion")]
        public System.TimeSpan EndingTime { get; set; }

        [Required]
        [Display(Name = "Id de Profesor")]
        public int Teacher_Id { get; set; }

        [Required]
        [Display(Name = "Cupos")]
        public int Quota { get; set; }

    }

}