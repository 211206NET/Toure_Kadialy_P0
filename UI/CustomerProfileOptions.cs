namespace UI;

public class CustomerProfileMenu {
    private StoreBL _bl;

    public CustomerProfileMenu(){
        _bl = new StoreBL();
    }
    public void Start(int CustomerID){
        bool Leave = false;
        while(!Leave){
            Console.WriteLine("-------Welcome to the Profile Menu-------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(1) Shopping Cart");
            Console.WriteLine("(2) Previous Orders");
            Console.WriteLine("Enter (E) to go back to the Customer Menu");
            Console.WriteLine("-----------------------------------------");

            string? choice = Console.ReadLine();

            switch (choice){
                case "1":
                    ShoppingCart kCart = new ShoppingCart();
                    kCart.Start(CustomerID);  
                    break;
                case "2":
                    CustomerOrderMenu rOrderMenu = new CustomerOrderMenu();
                    rOrderMenu.Start(CustomerID);  
                    break;
                case "E":
                    Leave = true;
                    break;
                default:
                    Console.WriteLine("Your choice was invalid. Please try again with an appropriate value!");
                    break;       
            }
        }

    }
 }