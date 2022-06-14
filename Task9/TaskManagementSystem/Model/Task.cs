using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManagementSystem.Model
{
    public enum Statuses
    {
        NotStarted,
        Completed
    }

    public class Task
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(2000)")]
        [StringLength(2000)]
        public string Description { get; set; }

        [Required]
        public Statuses Status { get; set; }

        [Required]
        public int CreatorId { get; set; }
        public int? PerformerId { get; set; }

        [JsonIgnore]
        [ForeignKey("CreatorId")]
        //This here is confusing. If I ommit "?" SwaggerUI picks "Creator" up and tells me that it is required for me to enter it.
        //So I set Creator to as nullable, even tho CreatorId is [Required].
        public virtual User? Creator { get; set; }

        [JsonIgnore]
        [ForeignKey("PerformerId")]
        public virtual User? Performer { get; set; }
    }
}
