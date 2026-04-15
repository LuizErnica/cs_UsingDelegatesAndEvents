namespace UsingDelegatesAndEvents;

/// <summary>
/// Represents a person with a name, email address, and age.
/// </summary>
/// <param name="Name">The name of the person. This value can be null if the name is unknown.</param>
/// <param name="Email">The email address of the person. Cannot be null or empty.</param>
/// <param name="Age">The age of the person, in years. Must be greater than or equal to 0.</param>
public record Person(string? Name, string Email, int Age);
