namespace UI;

public class MenuLogin {
    private TBBL _bl;
    

    public LoginMenu(TBBL bl){
        _bl = bl;
    }
    public void Start(){
        Console.WriteLine("Welcome to Coffee Mania");
        bool exit = false;
        while(!exit){
                Console.WriteLine("Make your choice");
                Console.WriteLine("1.) Sign up to become a member!");
                Console.WriteLine("2.) Customer Login");
                Console.WriteLine("3.) Manager Menu");
                Console.WriteLine("4.) View Candy Menu");
                Console.WriteLine("5.) Exit!");
            string? input = Console.ReadLine();

            // menu options and what happens when  you select a certain input
            switch (input){
                case "1":
                    Console.WriteLine("Customername: ");
                    string? Customername = Console.ReadLine();
                    List<Customer> Customers = _bl.GetAllCustomer();
                    bool customerDetected = false;
                    foreach(Customer Customer in Customers){
                        if (Customer.Customername == Customername){
                            Console.WriteLine("Uh Oh! It appears this Customer has already been registered!");
                            customerDetected = true;
                            break;
                        }
                    }
                    //grabs new ID for the customer
                    bool noAvail = !Customer.All();
                    //grabs new customer ID between 1 and 10,000
                    Random rnd = new Random();
                    int ID = rnd.Next(10000);
                    ///If the Customer isn't Detected, instantiate a new Customer
                    if (!customerDetected){
                        Console.WriteLine("Password: ");
                        string? password = Console.ReadLine();

                        Customer newCustomer = new Customer{
                            ID = ID!,
                            Customername = Customername!,
                            Password = password!,
                            };

                        _bl.AddCustomer(newCustomer);
                        CustomerMenu newMenu = new CustomerMenu();
                        //ID is the Customer's ID
                        newMenu.Start(ID);   
                    }

                    break;
                case "2":
                    Console.WriteLine("What is your Customer name?");
                    string? grabCustomerName = Console.ReadLine();
                    List<Customer> currCustomers = _bl.GetAllCustomer();
                    bool Detected = false;
                    Customer currCustomer = new Customer();
                    foreach(Customer Customer in currCustomers){
                        if (Customer.Customername == grabCustomerName){
                            Detected = true;
                            currCustomer = Customer;
                            }
                        }
                    //If the current Customername is not Detected in the DB
                    if (Detected == false){
                        Console.WriteLine("Im sorry, this Customer's name has not been Detected!");
                    }
                    else{
                        Console.WriteLine("Password");
                        string? getPass = Console.ReadLine();
                        //checks to see if you input the correct password
                        if (getPass == currCustomer.Password){
                            Console.WriteLine("Login successful! One moment please...");
                            Console.WriteLine("Welcome " + Customername);
                            console.Clear();
                            //Initialization of the Customer's Menu
                            CustomerMenu customersMenu = new CustomerMenu();
                            customersMenu.Start((int)currCustomer.ID!);        
                        }
                        else{
                            Console.WriteLine("Wrong password!");
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("Please enter the Manager code to continue.");
                    string? managerInput = Console.ReadLine();
                    if (managerInput == "27"){
                        Console.WriteLine("Welcome to your manager account.");
                        //Opens up the manager's menu
                        ManagerMenu manager = new ManagerMenu();
                        manager.Start();
                    }
                    else{
                        Console.WriteLine("Thats not the correct code!");
                    }
                    break;
                case "4":
                    Console.WriteLine("You chose " + input);
                    Console.WriteLine("Here is our menu of delicious Coffee.");
                    string[] Products = { "1.) Mocha", "2.) Hazelnut", "3.) French Vanilla", "4.) Pumpkin Spice", "5.) Black Coffee", "6.) Espresso", "7.) Cappuccino", "8.) Caramel" };
                    List<string> ProductsList = new List<string>();

                    ProductsList.AddRange(Products);
                    foreach (string Item in Products)
                    {
                        Console.WriteLine(Item);
                        
                    }
                    Console.WriteLine("Which coffee flavoring would you like?");
                    int CustomerChoice = int.Parse(Console.ReadLine());

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
}