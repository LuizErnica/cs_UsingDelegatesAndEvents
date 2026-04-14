using System.Diagnostics.CodeAnalysis;

namespace UsingDelegatesAndEvents
{
    public sealed class PersonValidator
    {
        public delegate string? PersonValidatorRule(Person person);

        private readonly List<PersonValidatorRule> _rules = [];

        public PersonValidator AddRule(PersonValidatorRule rule)
        {
            ArgumentNullException.ThrowIfNull(rule);
            _rules.Add(rule);
            return this;
        }

        public bool Validate(Person person, [NotNullWhen(returnValue: false)] out List<string>? errors)
        {
            ArgumentNullException.ThrowIfNull(person);

            errors = new List<string>();

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
