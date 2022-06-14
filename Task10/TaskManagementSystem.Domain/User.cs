using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManagementSystem.Domain
{
    public class User
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string FullName { get; set; }

        [Required]
        public int RoleID { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string Password { get; set; }
    }
}
