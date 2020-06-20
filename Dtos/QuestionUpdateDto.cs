using System.ComponentModel.DataAnnotations;

namespace sampleapi.Dtos
{
    public class QuestionUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string QuestionType {get;set;}

        [Required]
        [MaxLength(100)]
        public string QuestionTopic {get;set;}

        [Required]
        [MaxLength(500)]
        public string Question {get;set;}

        [Required]
        [MaxLength(500)]
        public string Option1 {get;set;}

        [Required]
        [MaxLength(500)]
        public string Option2 {get;set;}

        [Required]
        [MaxLength(500)]
        public string Option3 {get;set;}

        [Required]
        [MaxLength(500)]
        public string Option4 {get;set;}

        [Required]
        [MaxLength(500)]
        public string CorrectAnswer {get;set;}

        [Required]
        [MaxLength(500)]
        public string ScoringPoints {get;set;}

        [Required]
        [MaxLength(10)]
        public string DifficultyLevel {get;set;}

    }
}