using System.ComponentModel.DataAnnotations;

namespace SubscriptionAPITest.Models;

public class Person
{
    [Key]
    public int PersonId { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    [EmailAddress] public string Email { get; set; } = null!;
    
    [Range(1, 100)]
    public int Age { get; set; }
    
    // Navigation
    public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}