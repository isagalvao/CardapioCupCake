using CardapioCupCake.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioCupCake.Core.Service
{
    public partial class ListCupCakeRepository
    {
        public ObservableCollection<CupcakeModel> Cupcakes { get; } = new ObservableCollection<CupcakeModel>();

        public ListCupCakeRepository()
        {

        }
        public void AddCupcakesCarrinho(CupcakeModel cupcake)
        {
            if (cupcake != null)
            {
                cupcake.Id = Cupcakes.Count + 1;
                Cupcakes.Add(cupcake);
            }
        }
        public List<CupcakeModel> GetAll()
        {
            try
            {
                return Cupcakes.ToList();
            }
            catch (Exception)
            {
                return new List<CupcakeModel>();
            }
        }

    }
}
