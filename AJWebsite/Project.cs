using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AJWebsite
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [DisplayName("Client")]
        public int ClientId { get; set; }

        [DisplayName("Type of Work")]
        public string TypeOfWork { get; set; }

        public double Cost { get; set; }

        public DateTime Date { get; set; }

        public string Duration { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        [MaxLength(2)]
        public string State { get; set; }

        [MaxLength(5)]
        public string Zip { get; set; }
        
    }
}