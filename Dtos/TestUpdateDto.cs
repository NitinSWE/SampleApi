using System.ComponentModel.DataAnnotations;

namespace sampleapi.Dtos
{
    public class TestUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string TestName { get; set; }

        [Required]
        [MaxLength(250)]
        public string TestPurpose { get; set; }

        [Required]
        [MaxLength(50)]
        public string TestDuration { get; set; }
    }
}