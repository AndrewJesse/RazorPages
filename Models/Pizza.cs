using System.ComponentModel.DataAnnotations;

namespace RazorPagesPizza.Models;

public class Pizza
{
    public int Id { get; set; }
    // This caused a stack overflow
    // It was supposed to be in Pizza.cshtml.cs
    //public Pizza NewPizza { get; set; } = new Pizza();


    [Required]
    public string? Name { get; set; }
    public PizzaSize Size { get; set; }
    public bool IsGlutenFree { get; set; }

    [Range(0.01, 9999.99)]
    public decimal Price { get; set; }
   
}

public enum PizzaSize { Small, Medium, Large }