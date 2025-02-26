using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0211.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string TaskName { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        [Required]
        public int CategoryId { get; set; } // Foreign Key

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public bool Completed { get; set; } = false;
    }
}
