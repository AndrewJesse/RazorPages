using System.ComponentModel.DataAnnotations;

namespace RazorPagesPizza.Models;

public class Pizza
{
    // This property allows access to the Id field of a Pizza object, which is used to uniquely identify it in the database.
    public int Id { get; set; }

    // The Name property represents the name of the pizza and is required.
    [Required]
    public string? Name { get; set; }
    // The Size property represents the size of the pizza and is defined by the PizzaSize enumeration.
    public PizzaSize Size { get; set; }

    // The IsGlutenFree property indicates whether the pizza is gluten-free or not.
    public bool IsGlutenFree { get; set; }

    // The IsVegetarian property indicates whether the pizza is vegetarian or not.
    public bool IsVegetarian { get; set; }

    // The Price property represents the price of the pizza and is validated to be within the range of 0.01 to 9999.99.
    [Range(0.01, 9999.99)]
    public decimal Price { get; set; }

}
// This is an enumeration type that defines the possible sizes of a pizza.
// The available sizes are small, medium, and large.
public enum PizzaSize { Small, Medium, Large }