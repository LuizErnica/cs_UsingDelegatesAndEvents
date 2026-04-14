namespace UsingDelegatesAndEvents
{
   /// <summary>
   /// Provides methods for displaying messages to the user or simulating sending messages by email.
   /// </summary>
   /// <remarks>Use this class to present messages either directly on the screen or to simulate sending them
   /// via email for demonstration or testing purposes. The class does not perform actual email delivery.</remarks>
    public class ShowMessage
    {
        /// <summary>
        /// Displays the specified message on the screen.
        /// </summary>
        /// <param name="message">The message text to display. Cannot be null.</param>
        public void ShowMessageOnScreen(string message)
        {
            Console.WriteLine($"\n[Message on Screen]: {message}");
        }

        /// <summary>
        /// Sends the specified message by email.
        /// </summary>
        /// <remarks>This method simulates sending an email by writing the message to the console. No
        /// actual email is sent.</remarks>
        /// <param name="message">The message content to send by email. Cannot be null.</param>
        public void SendMessageByEmail(string message)
        {
            Console.WriteLine($"\n[Message Sent by Email (Simulation)]: {message}");
        }
    }
}
