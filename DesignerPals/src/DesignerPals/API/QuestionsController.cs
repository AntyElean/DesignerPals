using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DesignerPals.Data;
using Microsoft.EntityFrameworkCore;
using DesignerPals.Models;
using DesignerPals.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DesignerPals.API
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {
        private QuestionServices _questionServices;

        public QuestionsController(QuestionServices questionServices)
        {
            _questionServices = questionServices;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Q> Get()
        {
            return _questionServices.ListByQ();
        }

        //get by question
       
    }
}
