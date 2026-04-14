# UsingDelegatesAndEvents

Simple .NET console sample demonstrating the use of delegates and events in C#.

## Project

This project shows how to: 
- Declare and use a delegate (`Notifier`) to call methods with the same signature.
- Compose a multicast delegate (add multiple handlers to a delegate instance).
- Provide a basic `event` member on a `Button` class (placeholder for event wiring).

The sample is intentionally small and educational — no external dependencies or runtime services are required.

## Requirements

- .NET 10 SDK
- C# 14.0
- Visual Studio 2026 (or `dotnet` CLI)

## Files of interest

- `Program.cs` - Creates a `ShowMessage` instance, builds a `Notifier` delegate, demonstrates multicast delegates and invokes them.
- `ShowMessage.cs` - Implements `ShowMessageOnScreen` and `SendMessageByEmail` methods. The latter is a console simulation of email sending.
- `Button.cs` - Contains a `Button` class with an `event EventHandler? ButtonPressed;` (placeholder to illustrate event declaration).

## Concepts demonstrated

- Delegate declaration: `public delegate void Notifier(string message);`
- Assigning an instance method to a delegate and invoking it.
- Multicast delegates (`notifier += messenger.SendMessageByEmail;`) — multiple methods invoked by a single delegate invocation.
- Basic event declaration on a class (`event EventHandler? ButtonPressed`).

## Build and run

From the project directory (where the `.csproj` is located):

Using the `dotnet` CLI:

```
dotnet build
dotnet run
```

Or open the project in Visual Studio and run the project (F5 or Ctrl+F5).

## Expected behavior / sample output

When you run the application you will see prompts to press a key. The program will:
1. Create a delegate that points to `ShowMessage.ShowMessageOnScreen` and invoke it to print a message to the console.
2. Add `ShowMessage.SendMessageByEmail` to the delegate (multicast) and invoke it again so both handlers run (screen output and simulated email output).

Example output (condensed):

```
Press any key to create the delegate...

[Message on Screen]: Hello, this is a message displayed on the screen!

Press any key to change the delegate to send an email...

[Message on Screen]: Hello, this is a new important message!

[Message Sent by Email (Simulation)]: Hello, this is a new important message!
```

## Notes

- `SendMessageByEmail` only simulates sending an email by writing to the console.
- `Button` class contains an event declaration but no raising logic — it can be extended to demonstrate subscribing and raising events.

License: see repository root (if present).