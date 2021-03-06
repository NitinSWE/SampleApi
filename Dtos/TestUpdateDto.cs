using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using sampleapi.Models;

namespace sampleapi.Dtos
{
    public class TestUpdateDto
    {
        public TestUpdateDto()
        {
            this.Questions = new List<QuestionBank>();
        }
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