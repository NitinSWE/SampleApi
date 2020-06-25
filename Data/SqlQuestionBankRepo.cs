using System;
using System.Collections.Generic;
using System.Linq;
using sampleapi.Models;

namespace sampleapi.Data
{
    public class SqlQuestionBankRepo : IQuestionBankRepo
    {
        private readonly TestContext _context;

        public SqlQuestionBankRepo(TestContext context)
        {
            _context = context;
        }

        public void CreateQuestions(QuestionBank questionBank)
        {
            if(questionBank == null){
                throw new ArgumentNullException(nameof(questionBank));
            }
            _context.Questions.Add(questionBank);
        }

        /*public void CreateQuestion(QuestionBank questionBank)
{
   if(questionBank == null){
       throw new ArgumentNullException(nameof(questionBank));
   }
   _context.Questions.Add(questionBank);
}*/

        public void DeleteQuestion(QuestionBank questionBank)
        {
            if(questionBank == null){
                throw new ArgumentNullException(nameof(questionBank));
            }
            _context.Questions.Remove(questionBank);
        }

        /*public IEnumerable<QuestionBank> GetAllQuestions()
        {
            //return _context.Questions.;
            return _context.Questions.ToList();
        }*/

        public QuestionBank GetQuestionById(string id)
        {
            return _context.Questions.FirstOrDefault(p=> p.QuestionId == id);//lambda expression to fetch data by ID
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateQuestion(QuestionBank questionBank)
        {
            //nothing
        }
    }
}