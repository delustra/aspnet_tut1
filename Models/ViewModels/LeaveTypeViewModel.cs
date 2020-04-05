using System;
using System.ComponentModel.DataAnnotations;

namespace aspnet_tut1.Models
{
    public class DetailedLeaveTypeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class CreateLeaveTypeViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
