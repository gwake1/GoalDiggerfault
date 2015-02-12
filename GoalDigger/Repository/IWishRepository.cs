using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GoalDigger.Model;

namespace GoalDigger.Repository
{
    public interface IWishRepository
    {
        int GetCount();
        void Add(Wish W); //
        void Delete(Wish W); //
        void Clear(); //
        IEnumerable<Wish> PastEvents(); //
        int CalculateMonth(Wish W); //
        IEnumerable<Wish> All(); //
        Wish GetById(int id); //
        Wish GetByDate(string date); //
        IQueryable<Wish> SearchFor(Expression<Func<Wish, bool>> predicate);
    }
}
