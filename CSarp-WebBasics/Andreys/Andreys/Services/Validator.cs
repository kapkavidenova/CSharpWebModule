﻿using Andreys.Models.Products;
using Andreys.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using static Andreys.Data.DataConstants;

namespace Andreys.Services
{
    public class Validator : IValidator
    {
      
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UserMinUsername || model.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserMinUsername} and {DefaultMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < UserMinPassword || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {DefaultMaxLength} characters long.");
            }

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }


        public ICollection<string> ValidateProduct(ProductAddViewModel model)
        {
            var errors = new List<string>();

            //if (model.Name == null)
            //{
            //    errors.Add($"Product ID cannot be empty.");
            //}

            if (model.Description.Length> DescriptionMaxLength)
            {
                errors.Add($"Description '{model.Description}' is not valid. It must have less than {DescriptionMaxLength} characters.");
            }

            if (model.Price<0)
            {
                errors.Add("The price can not be negative.");
            }

            return errors;
        }
    
    }
}
