using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toure_Kadialy_P0.BL;
using Toure_Kadialy_P0.Models;

namespace Toure_Kadialy_P0.UI
{
    public class StoreMenu
    {

        private StoreBL _storeBl;
        private ProductBL _productBl;
        private Customer customer;
        public StoreMenu(Customer customer)
        {
            _storeBl = new StoreBL();
            _productBl = new ProductBL();
            this.customer = customer;
        }

        public void Start()
        {
            bool exit = false;
            int storeId;
            while (!exit)
            {
                Console.Clear();
                try
                {
                    //print all store on screen
                    foreach (Store store in _storeBl.GetAllStores())
                        Console.WriteLine($"{store.ID}) {store.Name}");

                    //Get into specific store by entering ID.
                    Console.WriteLine("\nEnter ID to go into Store");

                    Console.WriteLine("Enter (E) to go back;");
                    Console.WriteLine("---------------------------------------");

                    string? inputSelection = Console.ReadLine();

                    if (inputSelection.Equals("E"))
                        exit = true;
                    else if (int.TryParse(inputSelection, out storeId))
                    {
                        StoreProdcuctMenu menu = new StoreProdcuctMenu(customer);
                        menu.Start(storeId);
                        exit = true;
                    }
                }
                catch (Exception exp)
                {
                    Log.Error("Error StoreMenu: " + exp.Message);
                }



            }

        }
    }
}
