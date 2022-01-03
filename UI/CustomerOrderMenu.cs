namespace UI;

public class CustomerOrderMenu {
    private StoreBL _bl;
    private CustomerBL _tbbl;

    public CustomerOrderMenu(){
        _bl = new StoreBL();
        IRepo repo = new CustomerRepo();
        _tbbl = new CustomerBL(repo);
    }
    public void Start(int CustomerID){
        bool exit = false;
        Customer currCustomer = _tbbl.grabcurrentCustomerwithID(CustomerID);
        List<StoreOrder> finishedOrders = currCustomer.FinishedOrders!;
        bool TimeSort = false;
        bool CostSort = false;
        while(!exit){
            if(finishedOrders == null || finishedOrders.Count == 0){
                Console.WriteLine("No Ordersare available for viewing at this time!");
                exit = true;
                }
            else{
            Console.WriteLine("-------------------Orders------------------");
            foreach(StoreOrder storeorder in finishedOrders){
                Console.WriteLine($"\n{storeorder.Date}");
                Console.WriteLine("|-------------------------------------------|");
                foreach(ProductOrder pOrder in storeorder.Orders!){
                    Console.WriteLine($"| {pOrder.ItemName} | Qty: {pOrder.Quantity} || ${pOrder.TotalPrice}");
                }
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($" Total Price: ${storeorder.TotalAmount}");
            }
            if(!TimeSort){
                Console.WriteLine("\nEnter (S) to to organize your orders by most recent");
            }
            else{
                Console.WriteLine("\nEnter (S) to to organize your orders by first ordered");
            }
            if(CostSort){
                Console.WriteLine(" Enter (C) to organize orders by most expensive");
            }
            else{
                Console.WriteLine(" Enter (C) to organize orders by least expensive");
            }
            Console.WriteLine("    Enter (E) to go back to the Profile Menu");
            Console.WriteLine("----------------------------------------------");

            string? input = Console.ReadLine();

            switch (input){
                case "E":
                    exit = true;
                    break;
                case "S":
                    //Sorts the orders in most recent first
                    if (!TimeSort){
                        TimeSort = true;
                        finishedOrders.Sort((x, y) => y.DateSeconds.CompareTo(x.DateSeconds));
                    }
                    //Sorts the orders by last ordered first
                    else{
                        TimeSort = false;
                        finishedOrders.Sort((x, y) => x.DateSeconds.CompareTo(y.DateSeconds));
                    }
                    break;
                case "C":
                    //Sorts the orders in most expensive first
                    if (!CostSort){
                        CostSort = true;
                        finishedOrders.Sort((x, y) => x.TotalAmount.CompareTo(y.TotalAmount));
                    }
                    //Sorts the orders by least expensive first
                    else{
                        CostSort = false;
                        finishedOrders.Sort((x, y) => y.TotalAmount.CompareTo(x.TotalAmount));
                    }
                    break;
                default:
                    Console.WriteLine("\nI did not expect that command! Please try again with a valid input.");
                    break;       
            }
        }
        }
    }
 }