using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoalDigger;
using System.Data.Entity;

namespace GoalDigger.Repository
{
    public class WishRepository: IWishRepository
    { 
        private WishContext _dbContext;

        public WishRepository()
        {
            _dbContext = new WishContext();
            _dbContext.Wishes.Load();
        }

        public int GetCount()
        {
            return _dbContext.Wishes.Count<Model.Wish>();
        }

        public void Add(Model.Wish W)
        {
            _dbContext.Wishes.Add(W);
            _dbContext.SaveChanges();
        }

        public void Delete(Model.Wish W)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            var a = this.All();
            _dbContext.Wishes.RemoveRange(a);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Model.Wish> PastEvents()
        {
            throw new NotImplementedException();
        }

        public int CalculateMonth(Model.Wish W)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Wish> All()
        {
            var query = from Item in _dbContext.Wishes select Item;
            return query.ToList<Model.Wish>();
        }

        public Model.Wish GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Model.Wish GetByDate(string date)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Model.Wish> SearchFor(System.Linq.Expressions.Expression<Func<Model.Wish, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public WishContext Context()
        {
            throw new NotImplementedException();
        }
    }
}
