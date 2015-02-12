using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GoalDigger.Model;

namespace GoalDigger
{
    public class WishContext: DbContext
    {
        public DbSet<Wish> Wishes { get; set; }
    }
}
