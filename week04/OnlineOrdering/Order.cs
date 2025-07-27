public class Order
{
    public List<Product> _products = new List<Product>();
    public Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product) => _products.Add(product);


    public double CalculateTototalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.CalculateTotalCost();
        }
        total += _customer.IsInUSA() ? 5 : 35;

        return total;
    }

    public string PackingLabel()
    {
        string label = "Product Label:\n";
        foreach (Product product in _products)
        {
            label += $"- {product.GetProductName()} (ID: {product.GetProduct_Id()})\n";
        }
        return label;
    }

    public string ShippingLabel()
    {
        return $"Shipping To:\n{_customer.GetName()}\n{_customer.GetShippingAddress()}";        
    }
}