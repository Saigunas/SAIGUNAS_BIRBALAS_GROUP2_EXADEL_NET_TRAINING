using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain
{
    public class UserDto
    {
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string Password { get; set; }
    }
}
