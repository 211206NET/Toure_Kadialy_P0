using ConsoleTables;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toure_Kadialy_P0.BL;
using Toure_Kadialy_P0.DL;
using Toure_Kadialy_P0.Models;

namespace Toure_Kadialy_P0.UI
{
    public class CartMenu
    {

        private StoreBL _storeBl;
        private ProductBL _productBl;
        private Customer customer;
        private CartDL _cartDL;
        public CartMenu(Customer customer)
        {
            _storeBl = new StoreBL();
            _productBl = new ProductBL();
            _cartDL = new CartDL();
            this.customer = customer;
        }

        public void Start()
        {
      
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                try
                {
                    //Get user Cart from database 
                    //Print it on Screen using console table
                    //then user has the choice to wether place
                    //and order or not.
                    List<Cart> carts = _cartDL.getCartForCustomer(customer.CustomerId);
                    ConsoleTable.From<Cart>(carts).Write(Format.Alternative);

                    Console.WriteLine("\nEnter C to Place Order");

                    Console.WriteLine("Enter (E) to go back;");
                    Console.WriteLine("---------------------------------------");

                    string? inputSelection = Console.ReadLine();

                    switch (inputSelection)
                    {
                        case "C":
                            try
                            {
                                _cartDL.CheckOut(customer, carts);
                            }
                            catch (Exception exp)
                            {
                                Log.Error("Cart Menu Checkout: " + exp.Message);
                            }
                            break;
                        case "E":
                            exit = true;
                            break;
                    }
                }
                catch (Exception exp)
                {

                    Log.Error("Error Cart Menu: " + exp.Message);
                }



            }

        }
    }
}

