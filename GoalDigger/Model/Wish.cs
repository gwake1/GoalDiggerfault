using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalDigger.Model
{
    public class Wish: INotifyPropertyChanged
    {
        public string WishId { get; set; }
        public string Name {get; set;}
        public string Date {get; set;}
        public int Price {get; set;}
        public int WishGroup { get; set; }

    public Wish() 
    {
    //Do Something
    }

    public Wish(string WishName, string WishDate, int WishPrice)
    {
        this.Name = WishName;
        this.Date = WishDate;
        this.Price = WishPrice;
    }
    public event PropertyChangedEventHandler PropertyChanged;
    }
}
