using CSharpFunctionalExtensions;

namespace Users.Domain.ValueObject
{
    /// <summary>
    /// Реализовать Value Object абстракцию
    /// </summary>
    public class Password
    {
        public string Value { get; }
        private Password(string value) => Value = value;

        public static Result<Password> Create(string val)
        {
            // Реализовать логику валидации пароля
            return Result.Success(new Password(val));
        }

    }
}
