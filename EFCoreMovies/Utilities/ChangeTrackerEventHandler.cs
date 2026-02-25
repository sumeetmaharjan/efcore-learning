using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCoreMovies.Utilities;

public interface IChangeTrackerEventHandler
{
    void TrackedHandler(object sender, EntityTrackedEventArgs args);
    void StateChangedHandler(object sender, EntityStateChangedEventArgs args);
    void SavingChangesHandler(object sender, SavingChangesEventArgs args);
    void SavedChangesHandler(object sender, SavedChangesEventArgs args);
    void SaveChangedFailedHandler(object sender, SaveChangesFailedEventArgs args);
}

public class ChangeTrackerEventHandler(ILogger<ChangeTrackerEventHandler> logger) : IChangeTrackerEventHandler
{
    public void TrackedHandler(object sender, EntityTrackedEventArgs args)
    {
        var message = $"Entity: {args.Entry.Entity}, state: {args.Entry.State}";
        logger.LogInformation(message);
    }

    public void StateChangedHandler(object sender, EntityStateChangedEventArgs args)
    {
        var message = $"Entity: {args.Entry.Entity}, old state: {args.OldState}, new state: {args.NewState}";
        logger.LogInformation(message);
    }

    public void SavingChangesHandler(object sender, SavingChangesEventArgs args)
    {
        var entities = ((ApplicationDbContext)sender).ChangeTracker.Entries();
        foreach (var entry in entities)
        {
            var message = $"Entity: {entry.Entity} it's going to be {entry.State}";
            logger.LogInformation(message);
        }
    }

    public void SavedChangesHandler(object sender, SavedChangesEventArgs args)
    {
        var message = $"We processed {args.EntitiesSavedCount} entities";
        logger.LogInformation(message);
    }

    public void SaveChangedFailedHandler(object sender, SaveChangesFailedEventArgs args)
    {
        logger.LogError(args.Exception.ToString(), "Error saving changes");
    }
}