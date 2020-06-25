using System.Collections.Generic;
using sampleapi.Models;

namespace sampleapi.Dtos
{
    public class TestReadDto
    {
        public TestReadDto()
        {
            this.Questions = new List<QuestionBank>();
        }
        public string id { get; set; }
        public string TestName { get; set; }
        public string TestPurpose { get; set; }
        public string TestDuration { get; set; }
        public List<QuestionBank> Questions { get; set; } 
    }
}