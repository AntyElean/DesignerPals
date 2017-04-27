using System.Collections.Generic;
using DesignerPals.Models;

namespace DesignerPals.Infrastructure
{
    public interface IRepository
    {
        void CreateQ(Q qtoCreate);
        void DeleteQ(int id);
        void Dispose();
        Q FindQ(int id);
        IList<Q> ListQ();
        void UpdateQ(Q qtoUpdate);
    }
}