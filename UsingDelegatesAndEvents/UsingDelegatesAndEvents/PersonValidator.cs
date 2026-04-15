using System.Diagnostics.CodeAnalysis;

namespace UsingDelegatesAndEvents
{
    /// <summary>
    /// Provides functionality to define and apply validation rules to Person instances.
    /// </summary>
    /// <remarks>PersonValidator enables the composition of multiple validation rules for Person objects.
    /// Rules can be added using AddRule, and validation is performed by calling Validate. This class is sealed and not
    /// intended for inheritance.</remarks>
    public sealed class PersonValidator
    {
        /// <summary>
        /// Represents a method that validates a Person instance and returns an error message if validation fails.
        /// </summary>
        /// <remarks>Use this delegate to define custom validation rules for Person objects. Multiple
        /// rules can be combined to perform comprehensive validation.</remarks>
        /// <param name="person">The Person instance to validate. Cannot be null.</param>
        /// <returns>A string containing the validation error message if validation fails; otherwise, null if the Person is
        /// valid.</returns>
        public delegate string? PersonValidatorRule(Person person);

        // Internal list to store the validation rules added to this validator instance.
        private readonly List<PersonValidatorRule> _rules = [];

        /// <summary>
        /// Adds a validation rule to the current validator instance.
        /// </summary>
        /// <remarks>This method enables fluent chaining of multiple rule additions.</remarks>
        /// <param name="rule">The validation rule to add. Cannot be null.</param>
        /// <returns>The current <see cref="PersonValidator"/> instance with the added rule.</returns>
        public PersonValidator AddRule(PersonValidatorRule rule)
        {
            ArgumentNullException.ThrowIfNull(rule);
            _rules.Add(rule);
            return this;
        }

        /// <summary>
        /// Validates the specified person against all configured validation rules.
        /// </summary>
        /// <remarks>If validation fails, the <paramref name="errors"/> parameter will contain one or more
        /// error messages describing the validation issues. If validation succeeds, <paramref name="errors"/> will be
        /// <see langword="null"/>.</remarks>
        /// <param name="person">The person to validate. Cannot be null.</param>
        /// <param name="errors">When this method returns <see langword="false"/>, contains a list of validation error messages; otherwise,
        /// <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if the person passes all validation rules; otherwise, <see langword="false"/>.</returns>
        public bool Validate(Person person, [NotNullWhen(returnValue: false)] out List<string>? errors)
        {
            ArgumentNullException.ThrowIfNull(person);

            errors = [];

            foreach (var rule in _rules)
            {
                var error = rule(person);

                if (!string.IsNullOrWhiteSpace(error))
                {
                    errors ??= [];
                    errors.Add(error);
                }
            }

            return errors.Count == 0;
        }
    }
}
