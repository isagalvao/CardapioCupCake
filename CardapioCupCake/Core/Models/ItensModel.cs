using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioCupCake.Core.Models
{
    public class ItensModel
    {
        public CupcakeModel Item { get; set; } // Usa seu modelo Cupcake
        public int Quantity { get; set; }

        // Propriedade para o total do item
        public double TotalPrice => Quantity * Item.Price;

        // Propriedades formatadas para exibição no XAML
        public string DisplayName => $"{Quantity}x {Item.Name}";
        // Usamos "N2" ou "C" para formatação de moeda, mas mantendo a string aqui
        public string DisplayTotal => TotalPrice.ToString("C2");
    }
}
