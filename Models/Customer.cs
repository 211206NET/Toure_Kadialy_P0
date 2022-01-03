global using System;
global using System.Collections.Generic;
global using System.ComponentModel;
global using System.Data;
global using System.Text;
global using System.IO;

/// <summary>
/// .net that im calling to use for the createuser function
/// create a class with the information of the users
/// </summary>


namespace CustomerClassLibrary;

    public class Customer
    {
        public int? CustomerId { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public List<ProductOrder>? ShoppingCart { get; set; }
        public List<StoreOrder>? FinishedOrders { get; set; }

    public Customer() 
    {
        this.Name = "";
        this.Age = 0;
        this.city = "";
        this.state = "";
        this.CustomerId = 0;
    }
    public Customer(string w, int t, string n, string l, int k)
    {
        Name = w;
        Age = t;
        city = n;
        state = l;
        CustomerId = k;
    }
    
    
    
    }
     
