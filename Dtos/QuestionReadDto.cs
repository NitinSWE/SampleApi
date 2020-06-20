namespace sampleapi.Dtos
{
    public class QuestionReadDto
    {
        public string QuestionId {get;set;}
        public string QuestionType {get;set;}
        public string QuestionTopic {get;set;}
        public string Question {get;set;}
        public string Option1 {get;set;}
        public string Option2 {get;set;}
        public string Option3 {get;set;}
        public string Option4 {get;set;}
        public string CorrectAnswer {get;set;}
        public string ScoringPoints {get;set;}
        public string DifficultyLevel {get;set;}
    }
}