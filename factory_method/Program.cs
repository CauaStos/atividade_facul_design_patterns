namespace FactoryMethod;

public interface INotification
{
    void Send();
}

public sealed class EmailNotification : INotification
{
    public void Send()
    {
        Console.WriteLine("Enviando notificacao via email...");
    }
}

public sealed class SmsNotification : INotification
{
    public void Send()
    {
        Console.WriteLine("Enviando notificacao via SMS...");
    }
}

public abstract class NotificationCreator
{
    public abstract INotification CreateNotification();

    public void Notify()
    {
        INotification notification = CreateNotification();
        notification.Send();
    }
}

public sealed class EmailNotificationCreator : NotificationCreator
{
    public override INotification CreateNotification()
    {
        return new EmailNotification();
    }
}

public sealed class SmsNotificationCreator : NotificationCreator
{
    public override INotification CreateNotification()
    {
        return new SmsNotification();
    }
}

internal static class Program
{
    private static void Main(string[] args)
    {
        string option = args.FirstOrDefault() ?? AskNotificationType();
        NotificationCreator creator = CreateCreator(option);

        Console.WriteLine("====================================");
        creator.Notify();
        Console.WriteLine("====================================");
    }

    private static string AskNotificationType()
    {
        string? option;

        do
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Qual tipo de notificacao voce deseja?");
            Console.WriteLine("M = Email");
            Console.WriteLine("S = SMS");
            option = Console.ReadLine();
        } while (!IsValidOption(option));

        return option!;
    }

    private static NotificationCreator CreateCreator(string option)
    {
        return option.Trim().ToUpperInvariant() switch
        {
            "M" or "EMAIL" => new EmailNotificationCreator(),
            "S" or "SMS" => new SmsNotificationCreator(),
            _ => throw new ArgumentException("Use M/EMAIL ou S/SMS para escolher a notificacao.")
        };
    }

    private static bool IsValidOption(string? option)
    {
        if (string.IsNullOrWhiteSpace(option))
        {
            return false;
        }

        string normalized = option.Trim().ToUpperInvariant();
        return normalized is "M" or "EMAIL" or "S" or "SMS";
    }
}
