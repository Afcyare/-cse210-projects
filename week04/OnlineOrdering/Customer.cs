public class Customer
{
    // Private fields
    private string _customerName;
    private Address _address;

    // Constructor requires essential data
    public Customer(string name, Address address)
    {
        _customerName = name;
        _address = address;
    }

    // Public getters
    public string GetName() => _customerName;

    public bool IsInUSA() => _address.IsInUSA();

    public string GetShippingAddress() => _address.GetFullAddress();


}