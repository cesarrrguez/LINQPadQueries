<Query Kind="Program" />

// Aggregation:
// ---------------------------------
// Description: 'has-a' relationship
// ---------------------------------
// UML: Customer <> ----- Order
// ---------------------------------

void Main()
{
	Customer customer1 = new Customer();
	customer1.AddItemToOrder();
	customer1.AddItemToOrder();
	customer1.Dump();

	Order order = new Order();
	order.AddItem();
	order.AddItem();
	Customer customer2 = new Customer(order);
	customer2.Dump();
	
	Customer customer3 = new Customer();
	customer3.Dump();
}

public class Order
{
	private int _items;
	
	public void AddItem()
    {
        _items += 1;
    }
	
	public int GetItems()
    {
        return _items;
    }
}

public class Customer  
{
	private Order _order;
	
	public Customer()  
	{  
		_order = new Order();
	}
	
	public Customer(Order order)  
	{  
		_order = order;
	}
	
	public void SetOrder(Order order)
    {
        _order = order;
    }
	
	public void AddItemToOrder()
    {
        _order.AddItem();
    }
	
	public int GetItems()
	{
		return _order.GetItems();
	}
	
	public override string ToString() => $" Customer. Items: {GetItems()}";
}
