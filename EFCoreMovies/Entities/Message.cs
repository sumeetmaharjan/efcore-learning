namespace EFCoreMovies.Entities;

public class Message
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid SenderId { get; set; }
    public Person Sender { get; set; }
    public Guid ReceiverId { get; set; }
    public Person Receiver { get; set; }
}

// Look in Person Entity as this Entity has 2 Reference of Person. It need to use InverseProperty to Help EF understand the relation. Can be achieved using FluentAPI