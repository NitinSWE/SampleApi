using System.Collections.Generic;
using sampleapi.Models;

namespace sampleapi.Data
{
    public interface IQuestionBankRepo
    {
         bool SaveChanges();
        //Get All Questions
        //IEnumerable<QuestionBank> GetAllQuestions();

        //Get Question by Id
        QuestionBank GetQuestionById(string id);
        //void CreateQuestion(QuestionBank questionBank);
        void UpdateQuestion(QuestionBank questionBank);
        void CreateQuestions(QuestionBank questionBank);
        void DeleteQuestion(QuestionBank questionBank);
    }
}