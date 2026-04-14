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

            Console.WriteLine("\nPress any key to simulate a button being pressed...");
            Console.ReadKey(true);

            var button = new Button(); // Create an instance of the Button class
            button.ButtonPressed += (sender, e) => Console.WriteLine("[Listener 1]: Button was pressed! Event triggered."); // Subscribe to the ButtonPressed event with a lambda expression
            button.ButtonPressed += (sender, e) => Console.WriteLine("[Listener 2]: Button was pressed! Event triggered."); // Subscribe to the ButtonPressed event with another lambda expression
            button.ButtonPressed += ShowLogMessage; // Subscribe to the ButtonPressed event with a method that logs a message

            button.Press(); // Simulate pressing the button, which will trigger the ButtonPressed event and call all subscribed event handlers
        }

        /// <summary>
        /// Handles a log message event when a button is pressed.
        /// </summary>
        /// <param name="sender">The source of the event, typically the button that was pressed.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
        static void ShowLogMessage(object? sender, EventArgs e)
        {
            Console.WriteLine("[Log Message]: Button pressed was logged.");
        }
    }
}
