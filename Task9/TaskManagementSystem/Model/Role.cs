using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Model
{
    public class Role
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
