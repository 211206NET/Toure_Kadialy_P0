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
    public class ManagerMenu
    {
        private CustomerBL _tbbl;
        private ProductDL productDL;
        private StoreBL storeBL;
        /// <summary>
        /// initialize Data Access layer 
        /// in constructor.
        /// </summary>
        public ManagerMenu()
        {
            productDL = new ProductDL();
            storeBL = new StoreBL();
            _tbbl = new CustomerBL();
        }
        /// <summary>
        /// Start method to show menu unit user
        /// hits or enter exit command.
        /// Add Product:
        /// 1- First show list of products 
        /// 2- Then ask for new product details
        /// 3- save to database show success message.
        /// Add Store:
        /// 1- Show all available stores in DB
        /// 2- Ask for new store details and save to DB.
        /// Update Inventory:
        /// 1- Show list of stores 
        /// 2- select store then show available 
        /// products in that. then user will choose 
        /// product to product updates it's stock value.
        /// </summary>
        public void Start()
        {
            
            bool exit = false;
            try
            {
                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("------------------Manager Menu------------------");
                    Console.WriteLine($"What would you like to do?");
                    Console.WriteLine("(1) Add Product");
                    Console.WriteLine("(2) Add Store");
                    Console.WriteLine("(3) Update Inventory");
                    Console.WriteLine("(4) View Store Inventory");
                    Console.WriteLine("(5) Order History");
                    Console.WriteLine("(6) List Customers");

                    // Console.WriteLine("(5) Place Order");
                    Console.WriteLine("Enter (E) to go back to the Login Menu");
                    Console.WriteLine("---------------------------------------");

                    string? inputSelection = Console.ReadLine();

                    switch (inputSelection)
                    {

                        case "1":
                            Console.WriteLine("--------------- List Of Products --------------");
                            ConsoleTable.From<Product>(productDL.GetAllProducts()).Write(Format.Alternative);
                            Product product = new Product();
                            Console.Write("Enter product name: ");
                            product.Name = ValidateData.ValidateString(Console.ReadLine());
                            Console.Write("Description: ");
                            product.Description = ValidateData.ValidateString(Console.ReadLine());
                            Console.Write("Price: ");
                            product.Price = ValidateData.ValidateDecimal(Console.ReadLine());
                            Console.Write("Quantity on hand: ");
                            product.Qty = ValidateData.ValidateInteger(Console.ReadLine());
                            ConsoleTable.From<Store>(storeBL.GetAllStores()).Write(Format.Alternative);
                            Console.Write("Store ID: ");
                            product.Location = ValidateData.ValidateInteger(Console.ReadLine());
                            productDL.AddProduct(product);
                            Console.WriteLine("Product added successfully!");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine("--------------- List Of Stores --------------");
                            ConsoleTable.From<Store>(storeBL.GetAllStores()).Write(Format.Alternative);
                            Store store = new Store();
                            Console.Write("Store Name: ");
                            store.Name = ValidateData.ValidateString(Console.ReadLine());
                            Console.Write("Address   : ");
                            store.Address = ValidateData.ValidateString(Console.ReadLine());
                            Console.Write("City      : ");
                            store.City = ValidateData.ValidateString(Console.ReadLine());
                            Console.Write("State     : ");
                            store.State = ValidateData.ValidateString(Console.ReadLine());
                            storeBL.AddStore(store);
                            Console.WriteLine("Store added successfully!");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        case "3":
                            Console.WriteLine("--------------- List Of Stores --------------");
                            List<Store> stores = storeBL.GetAllStores();
                            ConsoleTable.From<Store>(storeBL.GetAllStores()).Write(Format.Alternative);
                            if (stores.Count > 0)
                            {
                                Console.WriteLine("Enter store ID to view Inventory");
                                int storeId = ValidateData.ValidateInteger(Console.ReadLine());
                                while (!stores.Exists(x => x.ID == storeId))
                                {
                                    Console.WriteLine("Store not found");
                                    storeId = ValidateData.ValidateInteger(Console.ReadLine());
                                }
                                //Get Store based on storeId
                                Store foundStore = stores.FirstOrDefault(x => x.ID == storeId);
                                Console.WriteLine($"--------------- Products In Store: {foundStore.Name}--------------");
                                List<Product> products = productDL.GetStoreProdcuts(foundStore.ID);
                                ConsoleTable.From<Product>(products).Write(Format.Alternative);
                                if (products.Count > 0)
                                {
                                    Console.WriteLine("Enter Product ID to update Inventory");
                                    int prodId = ValidateData.ValidateInteger(Console.ReadLine());
                                    while (!products.Exists(x => x.ID == prodId))
                                    {
                                        Console.WriteLine("Product not found");
                                        prodId = ValidateData.ValidateInteger(Console.ReadLine());
                                    }
                                    Console.Write("Enter Quantity to add: ");
                                    int qty = ValidateData.ValidateInteger(Console.ReadLine());
                                    Product productToUpdate = products.FirstOrDefault(x => x.ID == prodId);
                                    productDL.UpdateProductInventory(productToUpdate, qty);
                                    Console.WriteLine("Product inventory updated successfully!");
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Oops! Store is empty.");
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadKey();
                                }
                            }

                            break;
                        case "4":
                            Console.WriteLine("--------------- List Of Stores --------------");
                            stores = storeBL.GetAllStores();
                            ConsoleTable.From<Store>(storeBL.GetAllStores()).Write(Format.Alternative);
                            if (stores.Count > 0)
                            {
                                Console.WriteLine("Enter store ID to view Store Inventory");
                                int storeId = ValidateData.ValidateInteger(Console.ReadLine());
                                while (!stores.Exists(x => x.ID == storeId))
                                {
                                    Console.WriteLine("Store not found");
                                    storeId = ValidateData.ValidateInteger(Console.ReadLine());
                                }
                                //Get Store based on storeId
                                Store foundStore = stores.FirstOrDefault(x => x.ID == storeId);
                                Console.WriteLine($"--------------- Inventory Of Store: {foundStore.Name}--------------");
                                List<Product> products = productDL.GetStoreProdcuts(foundStore.ID);
                                ConsoleTable.From<Product>(products).Write(Format.Alternative);
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Oops! no store available.");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                            }

                            break;
                        case "5":
                            OrderHistoryMenu orderHistoryMenu = new OrderHistoryMenu();
                            orderHistoryMenu.Start();
                            break;

                        case "6":
                            Console.WriteLine("--------------- List Of Customers --------------");
                            List<Customer> customers = _tbbl.GetAllCustomer();
                            ConsoleTable.From<Customer>(customers).Write(Format.Alternative);
                            if (customers.Count > 0)
                            {
                                Console.WriteLine("Enter Customer ID to view Orders");
                                int custId = ValidateData.ValidateInteger(Console.ReadLine());
                                while (!customers.Exists(x => x.CustomerId == custId))
                                {
                                    Console.WriteLine("Customer not found");
                                    custId = ValidateData.ValidateInteger(Console.ReadLine());
                                }
                                //Get Customer based on custId
                                Customer foundCustomer = customers.FirstOrDefault(x => x.CustomerId == custId);
                                if (foundCustomer != null)
                                {
                                    Console.WriteLine($"--------------- Orders Of Customer: {foundCustomer.Name}--------------");
                                    orderHistoryMenu = new OrderHistoryMenu(foundCustomer);
                                    orderHistoryMenu.Start();

                                }
                                else
                                {
                                    Console.Write("Customer not available.");
                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Oops! no customer available.");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                            }
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
            catch (Exception exp)
            {

                Log.Error("Error Manager Menu: " + exp.Message);
            }

        }
    }
}

