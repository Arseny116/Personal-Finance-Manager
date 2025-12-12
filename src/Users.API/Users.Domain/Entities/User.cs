using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using Users.Domain.ValueObject;
namespace Users.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public  Password password { get;  set; }
 

        public Email Email { get;  set; }
        public bool IsActive { get;  set; }

        public DateTime? UpdatedAt { get;  set; }
        public DateTime CreatedAt { get;  set; }

        /// <summary>
        /// Инкапсулируем создание класса:
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="CreatedAt"></param>
        private User(Guid id, string firstName, string lastName, Email email, DateTime createdAt)
        {
            Id = Id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedAt = createdAt;
        }


        /// <summary>
        /// Реализуется фабричный метод
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static  Result<User> Create(string firstName, string lastName, Email email )
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return Result.Failure<User>("First name cannot be empty");

            if (firstName.Length < 2 || firstName.Length > 50)
                return Result.Failure<User>("First name must be between 2 and 50 characters");

            if (!Regex.IsMatch(firstName, @"^[a-zA-Zа-яА-ЯёЁ\s\-]+$"))
                return Result.Failure<User>("First name can only contain letters, spaces and hyphens");

           
            if (string.IsNullOrWhiteSpace(lastName))
                return Result.Failure<User>("Last name cannot be empty");

            if (lastName.Length < 2 || lastName.Length > 50)
                return Result.Failure<User>("Last name must be between 2 and 50 characters");

            if (!Regex.IsMatch(lastName, @"^[a-zA-Zа-яА-ЯёЁ\s\-]+$"))
                return Result.Failure<User>("Last name can only contain letters, spaces and hyphens");


            var forbiddenNames = new[] { "admin", "root", "superuser" };
            if (forbiddenNames.Contains(firstName.ToLower()) ||
                forbiddenNames.Contains(lastName.ToLower()))
                return Result.Failure<User>("This name is not allowed");

            User user = new User(Guid.NewGuid(), firstName, lastName, email, DateTime.UtcNow)
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };  

            return Result.Success(user);
        }
        public Result UpdateName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return Result.Failure("First name cannot be empty");

            if (string.IsNullOrWhiteSpace(lastName))
                return Result.Failure("Last name cannot be empty");

     
            if (firstName == FirstName && lastName == LastName)
                return Result.Failure("Name has not changed");

            FirstName = firstName.Trim();//Trim удаляет пробелы в начале и конце строки
            LastName = lastName.Trim();
            UpdatedAt = DateTime.UtcNow;

            return Result.Success("Name is change !");
        }


        public Result ChangeEmail(string newEmail)
        {
            var emailResult = Email.Create(newEmail);
            if (emailResult.IsFailure)
                return Result.Failure(emailResult.Error);

            //Старый email и новый email совпадают
            if (Email.Value == newEmail)
                return Result.Failure("Email has not changed");

            Email = emailResult.Value;
            UpdatedAt = DateTime.UtcNow;
            return Result.Success();
        }

        /// <summary>
        /// Типо отключает пользователя
        /// </summary>
        public void Deactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }


        /// <summary>
        /// Типо включает пользователя
        /// </summary>
        public void Activate()
        {
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
