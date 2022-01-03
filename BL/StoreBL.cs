namespace BL;

public class StoreBL {
    private StoreRepo _dl;

    public StoreBL() {
        _dl = new StoreRepo();
    }
    /// <summary>
    /// adds product to the stores inventory
    /// </summary>
    /// <param name="storeID"></param>
    /// <param name="productToAdd"></param>
    public void AddProduct(int storeID, Product productToAdd){
        _dl.AddProduct(storeID, productToAdd);
    }
    /// <summary>
    /// deletes product from inventory
    /// </summary>
    /// <param name="storeID"></param>
    /// <param name="prodIndex"></param>
    public void RemoveProduct(int storeID, int prodIndex)
    {
        _dl.RemoveProduct(storeID, prodIndex);
    }
    /// <summary>
    /// edits product you select in the store
    /// </summary>
    /// <param name="prodIndex"></param>
    /// <param name="description"></param>
    /// <param name="price"></param>
    /// <param name="quantity"></param>
    public void EditProduct(int prodIndex, string description, decimal price, int quantity){
        _dl.EditProduct(prodIndex, description, price, quantity);
    }
    public void AddStoreOrder(int storeID, StoreOrder storeOrderToAdd){
        _dl.AddStoreOrder(storeID, storeOrderToAdd);
    }
}

