using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioCupCake.Core.Models
{
    public class ItensModel
    {
        public CupcakeModel Item { get; set; } 
        public int Quantity { get; set; }

        public double TotalPrice => Quantity * Item.Price;

        public string DisplayName => $"{Quantity}x {Item.Name}";
        public string DisplayTotal => TotalPrice.ToString("C2");
    }
}
