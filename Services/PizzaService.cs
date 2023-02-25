using RazorPagesPizza.Models;

namespace RazorPagesPizza.Services;
public static class PizzaService
{
    /**
    Pizzas is a private static property of the PizzaService class that is a list of Pizza objects. 
    The static keyword means that the property belongs to the class itself and not to any instance of the class. 
    The List<Pizza> part means that the property is a list of Pizza objects. The { get; } part is a shorthand for declaring a 
    read-only property with no setter, which means that the list can be accessed from outside the class, but not modified.   */
    static List<Pizza> Pizzas { get; }

    // nextID sets the number of the next value in the pizza list that will be used to ID the next pizza when the Add(.) method is called.
    static int nextId = 3;
    static PizzaService()
    {
        // Creates two pizzas for the pizza lists
        Pizzas = new List<Pizza>
                {
                    new Pizza { Id = 1, Name = "Classic Italian", Price=20.00M, Size=PizzaSize.Large, IsGlutenFree = false, IsVegetarian = false },
                    new Pizza { Id = 2, Name = "Veggie", Price=15.00M, Size=PizzaSize.Small, IsGlutenFree = true, IsVegetarian = true }
                };
    }

    /*
    Returns a reference to the list of all pizzas. Modifying the returned list will modify the original list of pizzas.
    */
    public static List<Pizza> GetAll() => Pizzas;

    /**
    Returns the Pizza object with the specified ID, if it exists in the Pizzas list.
    If no Pizza with the specified ID is found, returns null.
    @param id The ID of the Pizza to retrieve.
    @return The Pizza object with the specified ID, or null if not found.
    ------More Info------
    This code uses the Linq FirstOrDefault method to find the first element in the Pizzas collection that matches the given condition, 
    where the Id property of the Pizza object is equal to the provided id. The p => p.Id == id part is a lambda 
    expression that defines the condition used to filter the elements in the collection.
    The lambda expression is a shorthand way of writing a function that takes an object p of type Pizza 
    as input and returns a Boolean value indicating whether the Id property of p is equal to the provided id. 
    The FirstOrDefault method then returns the first Pizza object in the collection that satisfies this condition, 
    or null if no such object is found.

    ------How a beginner would write this------
    public static Pizza? Get(int id)
    {
        foreach (var pizza in Pizzas)
        {
            if (pizza.Id == id)
            {
                return pizza;
            }
        }
        return null;
    }
    */
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    /**
    Adds the given pizza object to the list of pizzas and assigns it a unique ID.
    @param pizza: The pizza object to be added to the list.
    */
    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }
    /**
    Deletes a pizza from the collection of pizzas based on the given ID parameter.
    The method first calls the static Get() method to retrieve the pizza object with the given ID.
    If the pizza object is not found, the method returns without doing anything.
    If the pizza object is found, the method removes it from the Pizzas collection.
    */
    public static void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return;

        Pizzas.Remove(pizza);
    }
    /**
    Updates the details of a given pizza in the list of pizzas. The method takes a Pizza object as a parameter. 
    The method first finds the index of the pizza in the list of pizzas by searching for the pizza with the same ID as the given pizza using the FindIndex method.
    If the pizza is not found, the method simply returns. 
    If the pizza is found, the method updates the pizza in the list at the found index by setting it equal to the given pizza.
    */
    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }
}