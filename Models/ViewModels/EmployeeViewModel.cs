using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace aspnet_tut1.Models
    {
    public class EmployeeViewModel

    {
        public string Id { get; set;}
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string TaxId { get; set; }
        [Display(Name = "Birthday")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
    }

}

