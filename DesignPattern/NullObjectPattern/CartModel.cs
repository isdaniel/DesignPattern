using System.Collections.Generic;

namespace NullObjectPattern
{
    public class CartModel
    {
        public int UserID { get; set; }
        public IEnumerable<Items> Items { get; set; } = new List<Items>();
    }
}