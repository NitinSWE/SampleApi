using System;
using System.Collections.Generic;
using System.Linq;
using sampleapi.Models;

namespace sampleapi.Data
{
    public class SqlTestRepo : IfcTestRepo
    {
        //Inject Context class to fetch data from database
        private readonly TestContext _context;
        public SqlTestRepo(TestContext context)
        {
            _context = context;
        }

        public void CreateTest(Test test)
        {
            if(test == null){
                throw new ArgumentNullException(nameof(test));
            }
            _context.Tests.Add(test);
        }

        public void DeleteTest(Test test)
        {
            if(test == null){
                throw new ArgumentNullException(nameof(test));
            }
            //Delete All the Questions of the Test
            foreach(var question in _context.Questions.Where(o=>o.TestId == test.id ))
                _context.Questions.Remove(question);

            SaveChanges();
            //Delete Test
            _context.Tests.Remove(test);
        }

        public IEnumerable<Test> GetAllTests()
        {
            return _context.Tests.ToList();
        }

        public Test GetTestById(string id)
        {
            //Get All the Questions of the TestId
            /*********DOUBT************/
            var questionList = new List<QuestionBank>();
            foreach(var question in _context.Questions.Where(o => o.TestId == id ))
                questionList.Add(question);
            //Get Test For the TESTId
            var testData =  _context.Tests.FirstOrDefault(p=> p.id == id);//lambda expression to fetch data by ID
            //testData.Questions = questionList;
            return testData;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTest(Test test)
        {
            //nothing
        }
    }
}