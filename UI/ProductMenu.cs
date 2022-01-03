namespace UI;
public class ProductMenu {
    private StoreBL _bl;

    public ProductMenu(StoreBL bl){
        _bl = bl;
    }
    public void Start(int storeID){
        bool checker = false;
        while (!checker){
            //Find our current products list
            Storefront currStore = _bl.GetStoreByID(storeID);

            List<Product> ProductsList = currStore.Products!;
            if(ProductsList == null || ProductsList.Count == 0){
                Console.WriteLine("\nNo products found!");
                checker = true;
                }
            else{
            Console.WriteLine("-----All Products-----");
            int i = 0;
            //Iterate and go over each product
            foreach(Product prod in ProductsList){
                Console.WriteLine($"[{i}]  {prod.Name} | ${prod.Price} || Quantity: {prod.Quantity}\n     {prod.Description}");
                i++;
            }
            Console.WriteLine("Pick the product's index to edit it.");
            Console.WriteLine("Enter the (D) key to Delete an item by its index.");
            Console.WriteLine("Or enter (E) to go back to the Store Menu.");
            Console.WriteLine("-------------------------------------------");
            string? Option = Console.ReadLine();
            int prodIndex;

            if (Option == "E"){
                checker = true;
                }
            //Optionion to delete a product by index
            else if(Option == "D"){
                int k = 0;
                foreach(Product prod in ProductsList){
                    Console.WriteLine($"[{k}]  {prod.Name}");
                    k++;
                }
                string? indexOption = Console.ReadLine();
                if(!int.TryParse(indexOption, out prodIndex)){
                    Console.WriteLine("Please choose a checker input!");
                }
                //checker index found to delete the product
                else {
                    if (prodIndex >= 0 && prodIndex < ProductsList.Count){
                        //get current product id
                        int prodID = (int)allStores[currStoreIndex].Products![prodIndex].ID!;
                        //Calls the business logic of deleting a product by both indices
                        _bl.DeleteProduct(storeID, prodID);

                    }
                    else{
                        Console.WriteLine("Please choose an index within range!");
                        }
                }
            }
            else {
                if(!int.TryParse(Option, out prodIndex)){
                    Console.WriteLine("Please choose a checker input!");
                }
                //checker index found to edit a product
                else{
                    //Check if index is in range
                    if (prodIndex >= 0 && prodIndex < ProductsList.Count){
                        //get current product ID
                        int prodID = (int)allStores[currStoreIndex].Products![prodIndex].ID!;
                        //Get our current product 
                        Product currProduct = _bl.GetProductByID(storeID, prodID);
                        Console.WriteLine($"\n{currProduct.Name}\nEdit Description: ");
                        string? newDescription = Console.ReadLine();
                        //Loops back up if input checkeration fails
                        newP:
                        Console.WriteLine("Price: ");
                        string? price = Console.ReadLine();
                        decimal newPrice;
                        if (!(decimal.TryParse(price, out newPrice))){
                            //If we get a blank string, we will be using the previous quantity in the noAvail function
                            if(price != ""){
                            Console.WriteLine("Price must be a Decimal value.");
                            goto newP;
                            }
                        }
                        newQ:
                        Console.WriteLine("Quantity: ");
                        string? quantity = Console.ReadLine();
                        int newQuantity;
                        if (!(int.TryParse(quantity, out newQuantity))){
                            //If we get a blank string, we will be using the previous quantity in the noAvail function
                            if(quantity != ""){
                            Console.WriteLine("Quantity must be an integer.");
                            goto newQ;
                            }
                        }
                        //If the input from the user is blank, keep the current product's information
                        newDescription = noAvail(currProduct, "D", newDescription!);
                        newPrice = decimal.Parse(noAvail(currProduct, "P", price!));
                        newQuantity = int.Parse(noAvail(currProduct, "Q", quantity!));
                        //Calls the Business Logic of editing the product
                        //Checks if newprice and newquantity are respectively floats and ints
                        try {
                            _bl.EditProduct(storeID, prodID, newDescription, newPrice, newQuantity);
                            Console.WriteLine("\nYour product has been edited successfully!");
                        }
                        //Checks for if quantity and price are above 0
                        catch(InputCheckerException ex){
                            Console.WriteLine(ex.Message);
                            //If the Price is wrong
                            if (ex.Message.Substring(0, 1) == "Z"){
                                goto newP;
                            }
                            //If the Quantity is wrong
                            else{
                                goto newQ;
                            }
                        }
                    }
                    //Index out of range
                    else{
                        Console.WriteLine("\nPlease Option an index within range!");
                    }                        
                }  
            }
        }
    }
    }

        /// <summary>
        /// Takes in a string of text and determines if it is empty or not. If empty, replace the
        /// text with the current Products text for that paramater of the product
        /// </summary>
        /// <param name="currProduct">Current product</param>
        /// <param name="Describer">d for Description, p for Price, q for Quantity</param>
        /// <param name="input">Empty string or updated paramater for the Product</param>
        public string noAvail(Product currProduct, string Describer, string input){
            //If the string isn't empty, return that same string
            if (input != ""){
                return input;
                }
            //If the string is empty, keep the old values of the Product
            else {
                //Description denoted by beginning letter of each paramater in product
                if (Describer == "D"){
                    return currProduct.Description!;
                }
                else if (Describer == "P"){
                    return currProduct.Price!.ToString()!;
                }
                else if (Describer == "Q"){
                    return currProduct.Quantity!.ToString()!;
                }
                else {
                    return "";
                }
            }       
            }       
}