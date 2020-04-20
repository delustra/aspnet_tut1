using System;
using System.ComponentModel.DataAnnotations;

namespace aspnet_tut1.Models
{
    public class DetailedLeaveTypeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? DateCreated { get; set; }

        [Required]
        [Range(1, 25, ErrorMessage = "Enter days between 1 and 25")]
        [Display(Name = "Default Number of Days")]
        public int DefaultDays { get; set; } = 1;
        public int NumberOfDays { get; set; }
    }
   
}
