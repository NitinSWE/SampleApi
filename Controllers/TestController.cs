using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using sampleapi.Data;
using sampleapi.Dtos;
using sampleapi.Models;

namespace sampleapi.Controllers
{
    //api/tests
    [Route("api/tests")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly IfcTestRepo _repository;
        private readonly IMapper _mapper;

        public TestController(IfcTestRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockTestRepo _repository = new MockTestRepo();

        //Get api/tests
        [HttpGet]
        public ActionResult <IEnumerable<TestReadDto>> GetAllTests(){
            var testItems = _repository.GetAllTests();
            return Ok(_mapper.Map<IEnumerable<TestReadDto>>(testItems)); // Can be added more http control
        }

        //Get api/tests/{id}
        [HttpGet("{id}",Name="GetTestById")]
        public ActionResult <TestReadDto> GetTestById(string id){
            var testItem = _repository.GetTestById(id);
            if(testItem != null){
                return Ok(testItem);
                //return Ok(_mapper.Map<TestReadDto>(testItem));
            }
            return NotFound();
        }

        //POST api/tests
        [HttpPost]
        public ActionResult <TestReadDto> CreateTest(TestCreateDto testCreateDto){
            var testModel = _mapper.Map<Test>(testCreateDto);
            _repository.CreateTest(testModel); //Insert data into database
            _repository.SaveChanges();  //Save the changes

            var testReadDto = _mapper.Map<TestReadDto>(testModel);

            // To show 201 status and show URI of the data in header
            return CreatedAtRoute(nameof(GetTestById),new {id = testReadDto.id},testReadDto); //Confusing ***
        }

        //PUT api/tests/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTest(string id,TestUpdateDto testUpdateDto){
            var testModelFromRepo = _repository.GetTestById(id);
            if(testModelFromRepo == null){
                return NotFound();
            }
            //source =>target
            _mapper.Map(testUpdateDto,testModelFromRepo);
            _repository.UpdateTest(testModelFromRepo);
            _repository.SaveChanges();

            return NoContent(); // status 204
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateTest(string id,JsonPatchDocument<TestUpdateDto> patchDoc){
            var testModelFromRepo = _repository.GetTestById(id);
            if(testModelFromRepo == null){
                return NotFound();
            }

            var testToPatch = _mapper.Map<TestUpdateDto>(testModelFromRepo);
            patchDoc.ApplyTo(testToPatch,ModelState);
            //Validation to check if updated
            if(!TryValidateModel(testToPatch)){
                return ValidationProblem(ModelState);
            }

            _mapper.Map(testToPatch,testModelFromRepo);
            _repository.UpdateTest(testModelFromRepo);
            _repository.SaveChanges();
            
            return NoContent();
        }

        //DELETE api/tests/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTest(string id){
            var testModelFromRepo = _repository.GetTestById(id);
            if(testModelFromRepo == null){
                return NotFound();
            }

            _repository.DeleteTest(testModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}