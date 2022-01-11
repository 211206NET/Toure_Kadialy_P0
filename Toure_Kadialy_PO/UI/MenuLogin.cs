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

    public class MenuLogin
    {

        CustomerBL customerBL;
        ManagerDL managerDL;
        ProductDL productDL;
      
        public void Start()
        {
            try
            {
                Console.WriteLine("Welcome to Coffee Mania");
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("Make your choice");
                    Console.WriteLine("1.) Sign up to become a member!");
                    Console.WriteLine("2.) Customer Login");
                    Console.WriteLine("3.) Manager Menu");
                    Console.WriteLine("4.) View Menu");
                    Console.WriteLine("5.) Exit!");
                    string? input = Console.ReadLine();

                    // menu options and what happens when  you select a certain input
                    switch (input)
                    {
                        case "1":
                            customerBL = new CustomerBL();
                            Console.WriteLine("Customer Name: ");
                            string? Customername = Console.ReadLine();
                            List<Customer> Customers = customerBL.GetAllCustomer();
                            bool customerDetected = false;
                            foreach (Customer Customer in Customers)
                            {
                                if (Customer.Name == Customername)
                                {
                                    Console.WriteLine("Uh Oh! It appears this Customer has already been registered!");
                                    customerDetected = true;
                                    break;
                                }
                            }

                            if (!customerDetected)
                            {
                                Console.WriteLine("Password: ");
                                string password = Console.ReadLine();

                                Customer newCustomer = new Customer
                                {
                                    Name = Customername!,
                                    Password = password!,
                                };

                                newCustomer.CustomerId = customerBL.AddCustomer(newCustomer);
                                CustomerMenu newMenu = new CustomerMenu(newCustomer);
                                newMenu.Start();
                            }

                            break;
                        case "2":
                            customerBL = new CustomerBL();
                            Console.WriteLine("What is your Customer name?");
                            string? grabCustomerName = Console.ReadLine();
                            List<Customer> currCustomers = customerBL.GetAllCustomer();
                            bool Detected = false;
                            Customer currCustomer = new Customer();
                            foreach (Customer customer in currCustomers)
                            {
                                if (customer.Name == grabCustomerName)
                                {
                                    Detected = true;
                                    currCustomer = customer;
                                }
                            }
                            //If the current Customername is not Detected in the DB
                            if (Detected == false)
                            {
                                Console.WriteLine("Im sorry, this Customer's name has not been Detected!");
                            }
                            else
                            {
                                Console.WriteLine("Password");
                                string? getPass = Console.ReadLine();
                                //checks to see if you input the correct password
                                if (getPass == currCustomer.Password)
                                {
                                    Console.WriteLine("Login successful! One moment please...");
                                    Console.WriteLine("Welcome " + currCustomer.Name);
                                    Console.Clear();
                                    //Initialization of the Customer's Menu
                                    CustomerMenu customersMenu = new CustomerMenu(currCustomer);
                                    customersMenu.Start();
                                }
                                else
                                {
                                    Console.WriteLine("Wrong password!");
                                }
                            }
                            break;
                        case "3":
                            managerDL = new ManagerDL();
                            Console.WriteLine("Please enter the Manager code or name to continue.");
                            string? name = ValidateData.ValidateString(Console.ReadLine());
                            Console.Write("\nEnter password: ");
                            string managerPassword = ValidateData.ValidateString(Console.ReadLine());
                            bool isManagerExists = managerDL.IsManagerExists(name, managerPassword);

                            if (isManagerExists)
                            {
                                Console.WriteLine("Welcome to your manager account.");
                                //Opens up the manager's menu
                                ManagerMenu manager = new ManagerMenu();
                                manager.Start();
                            }
                            else
                            {
                                Console.WriteLine("Thats not the correct code!");
                            }
                            break;
                        case "4":
                            productDL = new ProductDL();
                            Console.WriteLine("You chose " + input);
                            Console.WriteLine("Here is our menu.");
                            foreach (Product product in productDL.GetAllProducts())
                                Console.WriteLine($"Name: {product.Name}              Description: {product.Description}");

                            break;
                        case "5":
                            exit = true;
                            break;

                        // anything that falls outside of the valid inputs will remind the customer that the input they used was not valid
                        default:
                            Console.WriteLine("That is not a valid input! Try again.");
                            break;
                    }
                }
            }
            catch (Exception exp)
            {

                Log.Error("Error MenuLogin: " + exp.Message);
            }
        }

    }
}

