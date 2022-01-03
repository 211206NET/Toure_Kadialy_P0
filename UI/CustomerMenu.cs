namespace UI;

public class CustomerMenu {
    private StoreBL _bl;
    private CustomerBL _tbbl;

    public CustomerMenu(){
        _bl = new StoreBL();
        IRepo repo = new CustomerRepo();
        _tbbl = new CustomerBL(repo);
    }
    public void Start(int CustomerID){
        bool exit = false;
        Customer currCustomer =  _tbbl.GetCurrentCustomerByID(CustomerID);
        while(!exit){
            Console.WriteLine("------------------Customer Menu------------------");
            Console.WriteLine($"What would you like to do {currCustomer.Customername}?");
            Console.WriteLine("(1) View Profile");
            Console.WriteLine("Enter (E) to go back to the Login Menu");
            Console.WriteLine("---------------------------------------");

            string? inputSelection = Console.ReadLine();

            switch (inputSelection){
                case "1": 
                    CustomerProfileMenu turnMenu = new CustomerProfileMenu();
                    turnMenu.Start(CustomerID);  
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
    }