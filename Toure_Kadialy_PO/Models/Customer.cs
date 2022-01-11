 using System;
 using System.Collections.Generic;
 using System.ComponentModel;
 using System.Data;
 using System.Text;
 using System.IO;
 using Toure_Kadialy_P0.Models;


/// <summary>
/// .net that im calling to use for the createuser function
/// create a class with the information of the users
/// </summary>


namespace Toure_Kadialy_P0.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string Password { get; set; }
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
        public override string ToString()
        {
            return $" ID: {this.CustomerId};\n Name: {this.Name};\nAge: {this.Age};\n City: {this.city};\n State: {this.state}";
        }
        public bool IsValidPassword()
        {
            if (this.Password.Length > 0)
                return true;
            else
                return false;
        }


    }
}

    
     
