using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using sampleapi.Data;
using sampleapi.Dtos;
using sampleapi.Models;

namespace sampleapi.Controllers
{
    [Route("api/Questions")]
    [ApiController]
    public class QuestionBankController : ControllerBase
    {
        private readonly IQuestionBankRepo _repository;
        private readonly IMapper _mapper;

        public QuestionBankController(IQuestionBankRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*[HttpGet]
        public ActionResult <IEnumerable<QuestionReadDto>> GetAllQuestions(){
            var questionItems = _repository.GetAllQuestions();
            return Ok(_mapper.Map<IEnumerable<QuestionReadDto>>(questionItems)); // Can be added more http control
        }*/

        //Get api/Questions/{id}
        [HttpGet("{id}",Name="GetQuestionById")]
        public ActionResult <QuestionBank> GetQuestionById(string id){
            var questionItem = _repository.GetQuestionById(id);
            if(questionItem != null){
                //return Ok(_mapper.Map<TestReadDto>(questionItem));
                return Ok(questionItem);
            }
            return NotFound();
        }

        //PUT api/Questions/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTest(string id,QuestionUpdateDto questionUpdateDto){
            var questionModelFromRepo = _repository.GetQuestionById(id);
            if(questionModelFromRepo == null){
                return NotFound();
            }
            //source =>target
            _mapper.Map(questionUpdateDto,questionModelFromRepo);
            _repository.UpdateQuestion(questionModelFromRepo);
            _repository.SaveChanges();

            return NoContent(); // status 204
        }

        //DELETE api/Questions/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteQuestion(string id){
            var questionModelFromRepo = _repository.GetQuestionById(id);
            if(questionModelFromRepo == null){
                return NotFound();
            }

            _repository.DeleteQuestion(questionModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}