using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EchoLinkDataModel.Models
{
    public class Adress
    {
        public int ID { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string City { get; set; } 
        [ForeignKey("User")]
        public int UserID { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
