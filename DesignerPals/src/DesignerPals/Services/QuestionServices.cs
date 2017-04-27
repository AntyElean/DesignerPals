using DesignerPals.Infrastructure;
using DesignerPals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DesignerPals.Services
{
    public class QuestionServices
    {
        private QRepository _repo;

        public QuestionServices(QRepository repo)
        {
            _repo = repo;
        }

        public IList<Q> ListByQ()
        {
            return (from q in _repo.ListQ() select q).ToList();
        }
    }
}
