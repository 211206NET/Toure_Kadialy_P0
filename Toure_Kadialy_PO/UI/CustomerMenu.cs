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
    public class CustomerMenu
    {
        //private StoreBL _bl;
        private CustomerBL _tbbl;
        private Customer customer;
        public CustomerMenu(Customer customer)
        {
            this.customer = customer;
            _tbbl = new CustomerBL();
        }
        public void Start()
        {
          
            bool exit = false;
            try
            {
                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("------------------Customer Menu------------------");
                    Console.WriteLine($"What would you like to do {customer.Name}?");
                    Console.WriteLine("(1) View Profile");
                    Console.WriteLine("(2) Place Order");
                    Console.WriteLine("(3) View Cart");
                    Console.WriteLine("(4) Order History");
                    // Console.WriteLine("(5) Place Order");
                    Console.WriteLine("Enter (E) to go back to the Login Menu");
                    Console.WriteLine("---------------------------------------");

                    string? inputSelection = Console.ReadLine();

                    switch (inputSelection)
                    {
                        case "1":
                            Console.WriteLine(customer.ToString());
                            Console.WriteLine("Do you want to edit your Profile[Y/N]?");
                            if(Console.ReadLine()=="Y")
                            {
                                Customer custToUpdate = new Customer();
                                Console.Write("Enter your name: ");
                                customer.Name = ValidateData.ValidateString(Console.ReadLine());
                                Console.Write("Enter your age: ");
                                customer.Age = ValidateData.ValidateInteger(Console.ReadLine());
                                Console.Write("Enter your city: ");
                                customer.city = ValidateData.ValidateString(Console.ReadLine());
                                Console.Write("Enter your state: ");
                                customer.state = ValidateData.ValidateString(Console.ReadLine());
                                _tbbl.UpdateCustomer(custToUpdate, customer.CustomerId);
                            }

                            Console.WriteLine("Press any key to go back;");
                            Console.ReadKey();
                            break;
                        case "2":
                            OrderMenu menu = new OrderMenu(customer);
                            menu.Start();
                            break;
                        case "3":
                            CartMenu cartMenu = new CartMenu(customer);
                            cartMenu.Start();
                            break;
                        case "4":
                            OrderHistoryMenu historyMenu = new OrderHistoryMenu(customer);
                            historyMenu.Start();
                            break;
                        case "E":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("It appears you've entered an invalid input!");
                            break;
                    }
                }
            }
            catch(Exception exp)
            {
                Log.Error("Error CustomerMenu: " + exp.Message);
            }

        }
    }
}
