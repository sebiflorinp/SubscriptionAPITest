using System.ComponentModel.DataAnnotations;

namespace SubscriptionAPITest.Models;

public class Subscription
{
    [Key]
    public int SubscriptionId { get; set; }
    
    public string? Name { get; set; }
    
    [Range(0, 9999.99)]
    public decimal Price { get; set; }

    public DateTime SubscribedOn { get; set; } = DateTime.Now;
    
    // Navigation
    public int PersonId { get; set; }

    public Person Person { get; set; } = null!;
}