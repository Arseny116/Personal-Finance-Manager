using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace Users.Domain.ValueObject
{
    /// <summary>
    /// record - сравнивает по значениям полей
    /// record - не изменяемый тип (immutable)
    /// </summary>
    public class Email
    {
        public string Value { get; }
        private Email(string value) => Value = value;

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Failure<Email>("Email cannot be empty");

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))//проверка на корректность email
            {
                return Result.Failure<Email>("Invalid email format");
            }
            return Result.Success(new Email(email));
        }
    }
}
