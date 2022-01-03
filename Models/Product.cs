using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

[Serializable] 
public class Product
{                        
    public string? Name { get; set; }

    public decimal Price  { get; set; }

    public string? Description { get; set; }

    public Product () 
    {
        this.Name = "";
        this.Description = "";
        this.Price = 0.00M;

    }

    public Product(string a, string b, decimal c) 
    {
        Name = a;
        Description = b;
        Price = c;
    }

}