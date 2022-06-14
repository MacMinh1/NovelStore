using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovelStore.Models
{
    public class MyCart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Novel novel, int quantity)
        {
            CartLine line = Lines
            .Where(b => b.Novel.NovelId == novel.NovelId)
            .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Novel = novel,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Novel novel) =>
        Lines.RemoveAll(l => l.Novel.NovelId == novel.NovelId);
        public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.Novel.Price * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Novel Novel{ get; set; }
        public int Quantity { get; set; }
    }
}