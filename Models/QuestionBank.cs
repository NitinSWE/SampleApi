using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sampleapi.Models
{
    public class QuestionBank
    {
        [Key]
        public string QuestionId {get;set;}

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

        // Foreign key 
        //[Required]
        public string TestId { get; set; } 
 
        //[ForeignKey("TestId")] 
        //public Test Tests { get; set; } 
        
         
    }
}