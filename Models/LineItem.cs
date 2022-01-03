using Models;


public class LineItem
{
    private int productId;

    public LineItem(int productId)
    {
        this.productId = productId;
    }

    public Product? Item { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
}