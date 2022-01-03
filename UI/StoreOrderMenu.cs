namespace UI;

public class StoreOrderMenu {
    private StoreBL _bl;
    private CustomerBL _tbbl;

    public StoreOrderMenu(StoreBL bl){
        _bl = bl;
        IRepo repo = new CustomerRepo();
        _tbbl = new CustomerBL(repo);
    }
    public void Start(int storeID){
        bool Leave = false;
        Store currStore = _bl.GetStoreByID(storeID!);
        List<StoreOrder> allOrders = currStore.AllOrders!;
        bool TimeSorting = false;
        bool CostSorting = false;
        while(!Leave){
            if(allOrders == null || allOrders.Count == 0){
                Console.WriteLine("There are no Orders available for view at this time!");
                Leave = true;
                }
            else{
            Console.WriteLine("----------Orders----------");
            foreach(StoreOrder storeorder in allOrders!){
                Customer CustomerWhoOrdered = _tbbl.GetCurrentCustomerByID((int)storeorder.CustomerID!);
                Console.WriteLine($"Placed on {storeorder.Date} by {CustomerWhoOrdered.Customername}");
                Console.WriteLine("|-------------------------------------------|");
                foreach(ProductOrder prodOrder in storeorder.Orders!){
                    Console.WriteLine($"| {prodOrder.ItemName} | Qty: {prodOrder.Quantity} || ${prodOrder.TotalPrice}");
                }
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"| Total Price: ${storeorder.TotalAmount}");
            }
            if(!TimeSorting){
                Console.WriteLine("Enter (S) to to organize orders by most recent.");
            }
            else{
                Console.WriteLine("Enter (S) to to organize orders by oldest ordered.");
            }
            if(CostSorting){
                Console.WriteLine(" Enter (C) to organize orders by most expensive.");
            }
            else{
                Console.WriteLine(" Enter (C) to organize orders by least expensive.");
            }
            Console.WriteLine("Enter (E) to go back to the Store Menu");
            Console.WriteLine("=============================================");

            string? input = Console.ReadLine();

            switch (input){
                case "E":
                    Leave = true;
                    break;
                case "S":
                    //Sorts the orders based off of recency first
                    if (!TimeSorting){
                        TimeSorting = true;
                        allOrders.Sort((x, y) => y.DateSeconds.CompareTo(x.DateSeconds));
                    }
                    //Sorts the orders by what you last ordered ordered first
                    else{
                        TimeSorting = false;
                        allOrders.Sort((x, y) => x.DateSeconds.CompareTo(y.DateSeconds));
                    }
                    break;
                case "C":
                    //Sorts the orders in most expensive at the top
                    if (!CostSorting){
                        CostSorting = true;
                        allOrders.Sort((x, y) => x.TotalAmount.CompareTo(y.TotalAmount));
                    }
                    //Sorts the orders by least expensive at the top
                    else{
                        CostSorting = false;
                        allOrders.Sort((x, y) => y.TotalAmount.CompareTo(x.TotalAmount));
                    }
                    break;
                default:
                    Console.WriteLine("I did not expect that command! Please try again with a valid input.");
                    break;       
            }
        }
        }
    }
    
}