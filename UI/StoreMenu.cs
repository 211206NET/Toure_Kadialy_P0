using System.Globalization;

namespace UI;
public class StoreMenu {
    private StoreBL _bl;
    private  CustomerBL _tbbl;

    public ShoppingStoreMenu(){
        _bl = new StoreBL();
        IRepo repo = new CustomerRepo();
        _tbbl = new CustomerBL(repo);
    }
    public void Start(int storeID, int CustomerID){
        bool checkers = false;
        while (!checkers){
            //locate our current products list
            
            List<Product> ProductsList = currStore.Products!;
            Customer currCustomer = _tbbl.grabcurrentCustomerwithID(CustomerID);

            //If the products list hasn't been initialized or is blank
            if(ProductsList == null || ProductsList.Count == 0){
                Console.WriteLine("No products found!");
                checkers = true;
                }
            else{
            int i = 0;
            Console.WriteLine("-----All Products-----");

            //go over each product
            foreach(Product prod in ProductsList){
                Console.WriteLine($"[{i}]  {prod.Name} | ${prod.Price} || Quantity: {prod.Quantity}     {prod.Description}");
                i++;
            }
            Console.WriteLine("Select the product's index to make a purchase.");
            Console.WriteLine("Or enter (E) to go back to the the list of available products!");
            Console.WriteLine("----------------------------------------------------");
            string? inputChoice = Console.ReadLine();
            int prodIndex = 0;
            //Return to the Product Menu
            if (inputChoice == "E"){
                checkers = true;
                }
            else {
                if(!int.TryParse(inputChoice, out prodIndex)){
                    Console.WriteLine("Please select an appropriate input!");
                }
                //checkers index found to edit a product
                else{
                    //Check if index is in range
                    if (prodIndex >= 0 && prodIndex < ProductsList.Count){
                        int prodIDSelected = (int)ProductsList[prodIndex!].ID!;
                        //Get product to make a purchase
                        Product selectedProduct = _bl.GetProductWithID(storeID, prodIDSelected);

                        Console.WriteLine($"How many {selectedProduct.Name}s would you like to order?");
                        enterAmount:
                        string? CustomerInput = Console.ReadLine();
                        int CustomerInt;
                        if(!int.TryParse(CustomerInput, out CustomerInt!)){
                            Console.WriteLine("Please enter an appropriate input:");
                            goto enterAmount;
                        }
                        else{
                            int prodQuantity = (int)selectedProduct.Quantity!;
                            if(prodQuantity == 0){
                                Console.WriteLine("Sorry, we are out of stock of this item!");
                            }
                            else if(CustomerInt > prodQuantity){
                                Console.WriteLine($"You may only purchase up to {prodQuantity} {selectedProduct.Name} Please enter an appropriate amount:");
                                goto enterAmount;
                            }
                            else if (CustomerInt <= 0){
                                Console.WriteLine("Sorry! You need to enter an amount greater than 0:");
                                goto enterAmount;
                            }
                            else{
                                //Get total quantity and price of current product
                                decimal prodPrice = (decimal)selectedProduct.Price!;
                                int newQuantity = prodQuantity - CustomerInt;
                                //Updates quantity remaining of the product
                                _bl.EditProduct(storeID, prodIDSelected, selectedProduct.Description!, selectedProduct.Price!, newQuantity);
                                //get new product id between 1 and 10,000
                                Random rnd = new Random();
                                int id = rnd.Next(10000);
                                ProductOrder currOrder = new ProductOrder{
                                        ID = id!,
                                        CustomerID = CustomerID,
                                        storeID = storeID,
                                        productID = selectedProduct.ID,
                                        ItemName = selectedProduct.Name!,
                                        TotalPrice = (CustomerInt * prodPrice),
                                        Quantity = CustomerInt!,
                                    };
                                //Add product order to Customer's shopping cart
                                _tbbl.AddProductOrder(currCustomer, currOrder);
                            }
                        }
                    }
                    //Integer out of range of the product list's index
                    else{
                        Console.WriteLine("Please select an index within range!");
                    }
                }
            }
        }
    }
}
}   