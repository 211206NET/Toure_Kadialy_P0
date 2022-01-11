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
    public class OrderHistoryMenu
    {
        private OrderDL orderDL;
        private CustomerBL _tbbl;
        private Customer customer;

        /// <summary>
        /// This constructor is designed 
        /// for customer requesting to
        /// their order history.
        /// </summary>
        /// <param name="customer"></param>
        public OrderHistoryMenu(Customer customer)
        {

            CustomerRepo repo = new CustomerRepo();
            orderDL = new OrderDL();
            this.customer = customer;
            _tbbl = new CustomerBL();
        }
        /// <summary>
        /// This constructor is designed for 
        /// Manager to view all customer orders
        /// history.
        /// </summary>
        public OrderHistoryMenu()
        {

            CustomerRepo repo = new CustomerRepo();
            orderDL = new OrderDL();
            _tbbl = new CustomerBL();
        }
        public void Start()
        {
            bool Leave = false;

            try
            {
                List<OrderMaster> allOrders = customer == null ? orderDL.GetOrders() : orderDL.GetOrders(customer.CustomerId);

                while (!Leave)
                {
                    if (allOrders == null || allOrders.Count == 0)
                    {
                        Console.WriteLine("There are no Orders available for view at this time!");
                        Leave = true;
                    }
                    else
                    {
                        Console.WriteLine("----------Orders----------");
                        foreach (OrderMaster order in allOrders!)
                        {

                            Console.WriteLine($"Placed on {order.OrderDate.ToShortDateString()} by {order.CustomerName.ToUpper()} Order Amount: {order.OrderAmount}");
                            ConsoleTable.From<LineItem>(order.LineItems).Write(Format.Alternative);
                        }

                        Console.WriteLine("Enter (S) to to organize orders by most recent.");
                        Console.WriteLine("Enter (S1) to to organize orders by oldest ordered.");
                        Console.WriteLine("Enter (C) to organize orders by most expensive.");
                        Console.WriteLine("Enter (C1) to organize orders by least expensive.");

                        Console.WriteLine("Enter (E) to go back to the Store Menu");
                        Console.WriteLine("=============================================");

                        string? input = Console.ReadLine();

                        switch (input)
                        {
                            case "E":
                                Leave = true;
                                break;
                            case "S":
                                //Sorts the orders based off of recency first
                                allOrders = allOrders.OrderByDescending(x => x.OrderDate).ToList();
                                break;
                            case "S1":
                                //Sorts the orders by what you last ordered ordered first
                                allOrders = allOrders.OrderBy(x => x.OrderDate).ToList();
                                break;
                            case "C":
                                //Sorts the orders in most expensive at the top
                                allOrders = allOrders.OrderByDescending(x => x.OrderAmount).ToList();
                                break;
                            case "C1":
                                //Sorts the orders by least expensive at the top
                                allOrders = allOrders.OrderBy(x => x.OrderAmount).ToList();
                                break;
                            default:
                                Console.WriteLine("I did not expect that command! Please try again with a valid input.");
                                break;
                        }
                    }
                }
            }
            catch (Exception exp)
            {

                Log.Error("Error OrderHistoryMenu: " + exp.Message);
            }
        }
    }
}
