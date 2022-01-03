using System.Collections;

namespace UI;
public class ShoppingCart {
    private StoreBL _bl;
    private CustomerBL _tbbl;
    public ShoppingCart(){
        _bl = new StoreBL();
        IRepo repo = new CustomerRepo();
        _tbbl = new CustomerBL(repo);
    }
    public void Start(int CustomerID){
        bool exit = false;
        while(!exit){
            CustomerRepo currCustomer = _tbbl.getCustomerWithID(CustomerID);
            if(currCustomer.ClearShoppingCart == null){
                currCustomer.ShoppingCart = new List<ProductOrder>();

            }
            List<ProductOrder> allProductOrders = currCustomer.ShoppingCart!;
            int i = 0;
            decimal storeTotalPrice = 0;
            Console.WriteLine("_Shopping Cart_");
                foreach(ProductOrder prodOrder in allProductOrders!){
                    Console.WriteLine($"[{i}]  {prodOrder.ItemName} | Quantity: {prodOrder.Quantity}\n     Total Price: ${prodOrder.TotalPrice} ");
                    shopTotalPrice += prodOrder.TotalPrice!;
                    i++;
                }
                    if (i == 0){
                        Console.WriteLine("... Shopping Cart is empty!");
                    }
                    else{
                        Console.WriteLine("====================");
                        Console.WriteLine("Total Amount: ${shopTotalPrice}");
                        
                    }
            string? input = Console.ReadLine();
            int prodOrderIndex;
            //Delete a product order
            if (input == "d"){  
                int j = 0;
                //Checks if shopping cart is empty
                if (i == 0){
                    Console.WriteLine("\nThere are no items to delete!");
                }
                //Print list of products to delete from
                else{
                    foreach(ProductOrder prodOrder in allProductOrders){
                        Console.WriteLine($"[{j}]  {prodOrder.ItemName}");
                        j++;
                    }
                    string? indexSelection = Console.ReadLine();
                    if(!int.TryParse(indexSelection, out prodOrderIndex)){
                        Console.WriteLine("\nPlease select a valid input!");
                    }
                    //Valid index found to delete the product
                    else {
                        if (prodOrderIndex >= 0 && prodOrderIndex < allProductOrders.Count){

                            //Gets the current product order, storeID, productID, and product by product order index
                            ProductOrder prodOrder = allProductOrders[prodOrderIndex];
                            int storeID = (int)prodOrder.storeID!;
                            int sProdID = (int)prodOrder.productID!;
                            Product productSelected = _bl.GetProductByID(storeID, sProdID);
                            //Calculating the new quantity
                            int prodOrderQuantity = (int)allProductOrders[prodOrderIndex].Quantity!;
                            int prodQuantity = (int)productSelected.Quantity!;
                            int newProdQuantity = (prodQuantity! + prodOrderQuantity!);
                            //Puts the correct amount of stock back in the store
                            _bl.EditProduct(storeID, sProdID, productSelected.Description!, productSelected.Price!, newProdQuantity);
                            //Calls the business logic of deleting a product order from the shopping cart by both indices
                            _tbbl.DeleteProductOrder(currCustomer, prodOrderIndex);
                        }
                        else{
                            Console.WriteLine("\nPlease select an index within range!");
                            }
                        }
                }
            }
            //checkout for each product corresponding to the Customer's orders and each store's orders
            else if (input == "c"){
                if(currCustomer.FinishedOrders == null) {
                    currCustomer.FinishedOrders = new List<StoreOrder>();
                    }
                if (allProductOrders.Count == 0){
                    Console.WriteLine("\nYou have no items to checkout!");
                }
                //Orders found to place
                else{
                    Console.WriteLine("\nReady to place your order? [y/n]");
                    string? inputyesno = Console.ReadLine();
                    if (inputYes/No == "y"){

                        //get new store Order id between 1 and 1,000,000
                        Random rnd = new Random();
                        int id = rnd.Next(1000000);
                        //Make new list of product orders to add to the Customer store order and calculate total
                        decimal CustomerProdOrdersTotal = 0;
                        List<ProductOrder> CustomerProductOrders = new List<ProductOrder>();
                        foreach(ProductOrder checkoutProduct in allProductOrders){
                            CustomerProdOrdersTotal += checkoutProduct.TotalPrice!;
                            CustomerProductOrders.Add(checkoutProduct);
                        } 
                        string currTime = DateTime.Now.ToString();
                        double currTimeSeconds = DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds;
                        StoreOrder CustomerStoreOrder = new StoreOrder{
                            ID = id!,
                            CustomerID = currCustomer.ID,
                            referenceID = currCustomer.ID,
                            TotalAmount = CustomerProdOrdersTotal!,
                            Date = currTime!,
                            DateSeconds = currTimeSeconds!,
                            Orders = CustomerProductOrders,
                            };
                        //Adds to current Customer's store order list
                        _tbbl.AddCustomerStoreOrder(currCustomer, CustomerStoreOrder);
                        //Get each corresponding store from each product's ID and add to a dictionary
                        Dictionary<int, List<ProductOrder>> storeOrdersToPlace = new Dictionary<int,List<ProductOrder>>();
                        foreach(ProductOrder prodOrder in allProductOrders){
                            //Getting the ID of the current store from the product id's string id code
                            int currStoreID = (int)prodOrder.storeID!;
                            if (storeOrdersToPlace.ContainsKey(currStoreID)){
                                storeOrdersToPlace[currStoreID].Add(prodOrder);
                                }
                            //If there is no key found
                            else{
                                List<ProductOrder> listP = new List<ProductOrder>();
                                listP.Add(prodOrder);
                                //Assigns the initial first item to a new dictionary key (by store index, list of product orders)
                                storeOrdersToPlace.Add(currStoreID, listP);
                            }
                        }
                        //Iterate over dictionary with store indexes and corresponding product
                        List<Store> allStores = _bl.GetAllStores();
                        foreach(KeyValuePair<int, List<ProductOrder>> kv in storeOrdersToPlace){
                            //Get the store index from the current store ID [kv.Key]
                            int storeIndex =  _bl.GetStoreIndexByID(kv.Key);
                            if(allStores[storeIndex].AllOrders == null) {
                                allStores[storeIndex].AllOrders = new List<StoreOrder>();
                                }   
                            //get new store Order id between 1 and 1,000,000
                            int sid = rnd.Next(1000000);
                            //counting total order value for list of product orders
                            decimal StoreOrderTotalValue = 0;
                            foreach(ProductOrder pOrd in kv.Value){
                                StoreOrderTotalValue += pOrd.TotalPrice!;
                            }
                            StoreOrder storeOrderToAdd = new StoreOrder{
                                ID = sid!,
                                CustomerID = currCustomer.ID!,
                                referenceID = kv.Key,
                                TotalAmount = StoreOrderTotalValue!,
                                Date = currTime!,
                                DateSeconds = currTimeSeconds!,
                                Orders = kv.Value
                            };
                            //Adds store order to current selected store
                            //kv.key is the store's ID
                            _bl.AddStoreOrder(kv.Key, storeOrderToAdd);
                        }
                        //Empty current Customer's shopping cart
                        _tbbl.ClearShoppingCart(currCustomer);
                    }
                }
            }
        }
    }
}