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
    public class StoreProdcuctMenu
    {

        private StoreBL _storeBl;
        private ProductBL _productBl;
        private Customer customer;
        public StoreProdcuctMenu(Customer customer)
        {
            _storeBl = new StoreBL();
            _productBl = new ProductBL();
            this.customer = customer;
        }

        public void Start(int storeId)
        {
            bool exit = false;
            int prodId;
            int qty;
            while (!exit)
            {
                Console.Clear();


                try
                {
                    string? inputSelection;

                    //Print all products on screen.
                    Console.Clear();
                    _productBl.ShowProducts(storeId);
                    inputSelection = Console.ReadLine();
                    //Ask for choice from user

                    if (inputSelection.Equals("E"))
                        exit = true;
                    else if (inputSelection == "C")
                    {
                        CartMenu cartMenu = new CartMenu(customer);
                        cartMenu.Start();
                        exit = true;
                    }

                    else if (int.TryParse(inputSelection, out prodId))
                    {
                        Console.Write("Enter Qty:");
                        qty = ValidateData.ValidateInteger(Console.ReadLine());
                        _productBl.AddToCart(prodId, customer, qty);
                    }
                    else
                        Console.WriteLine("Invalid input");

                }
                catch(Exception exp)
                {
                    Log.Error("Error StoreProductMenu: " + exp.Message);
                }




            }
        }
    }
}
