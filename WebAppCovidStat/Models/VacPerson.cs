//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppCovidStat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class VacPerson
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Names are required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Names are required")]
        public string LastName { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Dates are required")]
        public System.DateTime Birthday { get; set; }

        public string City { get; set; }

        [Display(Name = "Day Of Vaccination")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Dates are required")]
        public System.DateTime DayOfVaccination { get; set; }

        [Required(ErrorMessage = "Vaccine name is required")]
        public string Vaccine { get; set; }

        [Display(Name = "Vaccine Dose")]
        [Required(ErrorMessage = "Vaccine dose n. is required")]
        public int VaccineDose { get; set; }
    }
}
