using System.Collections.Generic;
using sampleapi.Models;

namespace sampleapi.Data
{
    public interface IfcTestRepo
    {
        bool SaveChanges();
        //Get All test
        IEnumerable<Test> GetAllTests();

        //Get test by Id
        Test GetTestById(string id);
        void CreateTest(Test test);
        void UpdateTest(Test test);
        void DeleteTest(Test test);
    }
}