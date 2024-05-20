using System;
using System.Collections.Generic;
using System.Linq;

#region Bước 1: Định nghĩa các sự kiện
public abstract class Event
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
}

public class AccountCreatedEvent : Event
{
    public Guid AccountId { get; private set; }
    public string Owner { get; private set; }

    public AccountCreatedEvent(Guid accountId, string owner)
    {
        AccountId = accountId;
        Owner = owner;
    }
}

public class MoneyDepositedEvent : Event
{
    public Guid AccountId { get; private set; }
    public decimal Amount { get; private set; }

    public MoneyDepositedEvent(Guid accountId, decimal amount)
    {
        AccountId = accountId;
        Amount = amount;
    }
}

public class MoneyWithdrawnEvent : Event
{
    public Guid AccountId { get; private set; }
    public decimal Amount { get; private set; }

    public MoneyWithdrawnEvent(Guid accountId, decimal amount)
    {
        AccountId = accountId;
        Amount = amount;
    }
}
#endregion

#region Bước 2: Định nghĩa Aggregate
public class BankAccount
{
    public Guid Id { get; private set; }
    public string Owner { get; private set; }
    public decimal Balance { get; private set; }

    private List<Event> _changes = new List<Event>();

    public BankAccount() { }

    public BankAccount(Guid id, string owner)
    {
        ApplyChange(new AccountCreatedEvent(id, owner));
    }

    public void Deposit(decimal amount)
    {
        ApplyChange(new MoneyDepositedEvent(Id, amount));
    }

    public void Withdraw(decimal amount)
    {
        ApplyChange(new MoneyWithdrawnEvent(Id, amount));
    }

    private void Apply(Event @event)
    {
        switch (@event)
        {
            case AccountCreatedEvent e:
                Id = e.AccountId;
                Owner = e.Owner;
                break;
            case MoneyDepositedEvent e:
                Balance += e.Amount;
                break;
            case MoneyWithdrawnEvent e:
                Balance -= e.Amount;
                break;
        }
    }

    private void ApplyChange(Event @event)
    {
        Apply(@event);
        _changes.Add(@event);
    }

    public IEnumerable<Event> GetUncommittedChanges() => _changes;

    public void LoadFromHistory(IEnumerable<Event> history)
    {
        foreach (var @event in history)
        {
            Apply(@event);
        }
    }
}
#endregion

#region Bước 3: Event Store (Kho lưu trữ sự kiện)
public class EventStore
{
    private readonly Dictionary<Guid, List<Event>> _store = new Dictionary<Guid, List<Event>>();

    public void SaveEvents(Guid aggregateId, IEnumerable<Event> events)
    {
        if (!_store.ContainsKey(aggregateId))
        {
            _store[aggregateId] = new List<Event>();
        }

        _store[aggregateId].AddRange(events);
    }

    public List<Event> GetEvents(Guid aggregateId)
    {
        if (_store.ContainsKey(aggregateId))
        {
            return _store[aggregateId];
        }

        return new List<Event>();
    }
}
#endregion

#region Bước 4: Sử dụng Event Sourcing trong ứng dụng
class Program
{
    static void Main()
    {
        var eventStore = new EventStore();

        // Create a new bank account
        var accountId = Guid.NewGuid();
        var account = new BankAccount(accountId, "Van Hieu");
        account.Deposit(100);
        account.Withdraw(40);

        // Save events to the event store
        eventStore.SaveEvents(accountId, account.GetUncommittedChanges());

        // Load events from the event store
        var storedEvents = eventStore.GetEvents(accountId);

        // Recreate bank account from events
        var restoredAccount = new BankAccount();
        restoredAccount.LoadFromHistory(storedEvents);

        Console.WriteLine($"Restored Account ID: {restoredAccount.Id}");
        Console.WriteLine($"Restored Account Owner: {restoredAccount.Owner}");
        Console.WriteLine($"Restored Account Balance: {restoredAccount.Balance}");
    }
}
#endregion
