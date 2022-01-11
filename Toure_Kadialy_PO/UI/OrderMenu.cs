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
    public class OrderMenu
    {
        private Customer customer;
        private StoreBL _storeBl;
        public OrderMenu()
        {

        }
        public OrderMenu(Customer customer)
        {
            this.customer = customer;
            _storeBl = new StoreBL();
        }

        public void Start()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                try
                {

                    //Choose store to in order to add item to cart.
                    Console.WriteLine("(1) Select Store");

                    Console.WriteLine("Enter (E) to go back;");
                    Console.WriteLine("---------------------------------------");

                    string? inputSelection = Console.ReadLine();

                    switch (inputSelection)
                    {
                        case "1":

                            StoreMenu menu = new StoreMenu(customer);
                            menu.Start();
                            exit = true;
                            break;
                        case "E":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("It appears you've entered an invalid input!");
                            break;
                    }
                }
                catch (Exception exp)
                {
                    Log.Error("Error OrderMenu: " + exp.Message);
                }
            }

        }
    }
}
