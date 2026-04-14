namespace UsingDelegatesAndEvents
{
    /// <summary>
    /// Represents a button that raises an event when pressed.
    /// </summary>
    /// <remarks>The Button class provides a simple mechanism for signaling when a button press occurs.
    /// Subscribers can handle the ButtonPressed event to respond to button press actions. This class is not
    /// thread-safe.</remarks>
    public class Button
    {
        /// <summary>
        /// Occurs when the button is pressed.
        /// </summary>
        public event EventHandler? ButtonPressed;

        /// <summary>
        /// Raises the button pressed event to notify subscribers that the button has been activated.
        /// </summary>
        /// <remarks>Call this method to simulate a button press and trigger any event handlers attached
        /// to the ButtonPressed event.</remarks>
        public void Press()
        {
            Console.WriteLine("Button was pressed.");
            ButtonPressed?.Invoke(this, EventArgs.Empty);
        }   
    }
}
