using CoffeeStore.Domain.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoffeeStore.BuiesnessLogic.BuisnessModels
{
    public class CustomPasswordValidator : IIdentityValidator<string>
    {
        public int RequiredLength { get; set; }
        public CustomPasswordValidator(int length) { 
            RequiredLength = length;
        
        }
        public Task<IdentityResult> ValidateAsync(string item)
        {
            if(string.IsNullOrEmpty(item) || item.Length < RequiredLength)
                return Task.FromResult(IdentityResult.Failed(String.Format("Minimal length is equal with: {0}",RequiredLength)));

            string pattern = "^[0-9]+$";
            if (!Regex.IsMatch(item, pattern))
            {
                return Task.FromResult(IdentityResult.Failed("Password should contain only digits!"));
            }
            return Task.FromResult(IdentityResult.Success);
        }
   
    }
}
