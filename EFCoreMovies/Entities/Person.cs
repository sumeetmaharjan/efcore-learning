using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities;

public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    [InverseProperty("Sender")]
    public List<Message> SentMessages { get; set; }
    [InverseProperty("Receiver")]
    public List<Message> ReceivedMessages { get; set; }
}

// InverseProperty is used when There are 2 or More References to Same Entity. In this case, Message is Referenced twice.