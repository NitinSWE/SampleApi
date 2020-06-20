using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sampleapi.Models
{
    public class Test
    {
        public Test()
        {
            this.Questions = new List<QuestionBank>();
        }
        [Key]
        public string id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string TestName { get; set; }

        [Required]
        [MaxLength(250)]
        public string TestPurpose { get; set; }

        [Required]
        [MaxLength(50)]
        public string TestDuration { get; set; }

        public List<QuestionBank> Questions { get; set; }
    }
}