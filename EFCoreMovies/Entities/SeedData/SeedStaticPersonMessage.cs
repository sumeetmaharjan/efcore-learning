using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Entities.SeedData;

public static class SeedStaticPersonMessage
{
    public static void SeedPersonMessage(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasData(Mahendra(), Sumitra());
        modelBuilder.Entity<Message>().HasData(MessagesOne(), MessagesTwo(), MessagesThree(), MessagesFour());
    }

    private static Person Mahendra()
    {
        return new Person() { Id = Guid.Parse("4fb60000-a64a-9828-5ee7-08dab177526c"), Name = "Mahendra" };
    }

    private static Person Sumitra()
    {
        return new Person() { Id = Guid.Parse("4fb60000-a64a-9828-06dd-08dab177526d"), Name = "Sumitra" };
    }

    private static Message MessagesOne()
    {
        return new Message()
        {
            Id = Guid.Parse("4fb60000-a64a-9828-cda3-08dab1786aea"),
            Content = "Hi, Mahendra",
            SenderId = Sumitra().Id,
            ReceiverId = Mahendra().Id
        };
    }

    private static Message MessagesTwo()
    {
        return new Message()
        {
            Id = Guid.Parse("4fb60000-a64a-9828-0d98-08dab1786aeb"),
            Content = "Hello, Sumitra",
            SenderId = Mahendra().Id,
            ReceiverId = Sumitra().Id
        };
    }

    private static Message MessagesThree()
    {
        return new Message()
        {
            Id = Guid.Parse("4fb60000-a64a-9828-1eb5-08dab1786aeb"),
            Content = "K cha? Sanchai Chau?",
            SenderId = Mahendra().Id,
            ReceiverId = Sumitra().Id
        };
    }

    private static Message MessagesFour()
    {
        return new Message()
        {
            Id = Guid.Parse("4fb60000-a64a-9828-24a2-08dab1786aeb"),
            Content = "Umm Thik cha. Hajur Ko?",
            SenderId = Sumitra().Id,
            ReceiverId = Mahendra().Id
        };
    }
}