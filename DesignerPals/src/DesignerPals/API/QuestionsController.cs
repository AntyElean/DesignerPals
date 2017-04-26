using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DesignerPals.Data;
using Microsoft.EntityFrameworkCore;
using static DesignerPals.Infrastructure.GenericRepository;
using DesignerPals.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DesignerPals.API
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {
        private IGenericRepository _repo;

        public QuestionsController(IGenericRepository repo)
        {
            _repo = repo;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Q> Get()
        {
            return _repo.Query<Q>();
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public Q Get(int id)
        {
            return _repo.Query<Q>().FirstOrDefault(q => q.Id == id);  
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Q question)
        {
            if (question.Id == 0)
            {
                _repo.Add(question);
            }
            else
            {
                _repo.Update(question);
            }
            return Ok(question);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //get the record to delete
            var questionToDelete = _repo.Query<Q>()
                .FirstOrDefault(q => q.Id == id);
            //if not found then throw
            if (questionToDelete == null)
            {
                return HttpNotFound();
            }
            //perform the delete
            _repo.Delete<Q>(questionToDelete);
            return Ok();
        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}
