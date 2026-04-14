namespace UsingDelegatesAndEvents
{
    public delegate void Notifier(string message);

    internal class Program
    {
        static void Main()
        {
            var messenger = new ShowMessage();

            Console.WriteLine("Press any key to create the delegate...");
            Console.ReadKey(true);

            // Create a delegate instance and assign the method to it
            Notifier notifier = messenger.ShowMessageOnScreen;

            // Invoke the delegate to display the message on the screen
            notifier("Hello, this is a message displayed on the screen!");

            Console.WriteLine("\nPress any key to change the delegate to send an email...");
            Console.ReadKey(true);

            // Change the delegate to point to the method that simulates sending an email (Multicast delegate)
            notifier += messenger.SendMessageByEmail;

            // Invoke the delegate again to display the message on the screen and simulate sending an email
            notifier("Hello, this is a new important message!");

            Console.ReadKey(true);
        }
    }
}
