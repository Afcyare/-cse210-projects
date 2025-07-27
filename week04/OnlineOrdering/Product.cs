public class Product
{
    private string _productName;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string id, double price, int quantity)
    {
        _productName = name;
        _productId = id;
        _price = price;
        _quantity = quantity;
    }

    //public getters (controlled access)
    public string GetProductName() => _productName;
    public string GetProduct_Id() => _productId;

    // Method to calculate total cost (encapsulated behavior)
    public double CalculateTotalCost()
    {
        return _price * _quantity;
    }
}