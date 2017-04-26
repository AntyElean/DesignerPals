using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DesignerPals.Infrastructure.GenericRepository;

namespace DesignerPals.Services
{
    public class QuestionServices
    {
        private IGenericRepository _repo;

        public QuestionServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IList<Q> ListByQ()
        {

        }
    }
}
