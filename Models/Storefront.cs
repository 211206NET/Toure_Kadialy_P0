namespace Models;
public class Storefront
{

public class Store {
    
    public Store(){}

    public int? ID { get; set; }

    public string? Name { get; set;}

    public string? Address{ get; set;}

    public string? City { get; set; }
    
    public string? State { get; set; }

    public List<Product>? Products { get; set; }

    public List<StoreOrder>? AllOrders { get; set; }

    public override string ToString(){
        return ($"Store: {this.Name}\n    City: {this.City}, State: {this.State}\n    Address: {this.Address}");
    }


    
    
    public List<Product> ProductList  { get; set; }
    public List<Product> ShoppingCart { get; set; }

    }

}

