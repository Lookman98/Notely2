using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notely.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please Enter Subject")]
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedDateTime { get; set; }      
        public DateTime LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
