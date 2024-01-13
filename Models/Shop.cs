using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediiApp.Models
{
    public class Shop
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string ShopName { get; set; }

        public string Address { get; set; }

        public string ShopDetails
        {
            get { return ShopName + "\n" + Address; }
        }

        [OneToMany]
        public List<ShopList> ShopLists { get; set; } = new List<ShopList>();
    }

}
