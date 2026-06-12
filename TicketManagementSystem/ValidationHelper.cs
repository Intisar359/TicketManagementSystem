using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem
{
    public static class ValidationHelper
    {
       
        public static bool IsValidEmail(string email)
        {
            try
            {
               
                email = email.ToLower();

                
                var mailAddress = new MailAddress(email);
                return true; 
            }
            catch
            {
                return false; 
            }
        }

        
        public static bool IsValidPassword(string password)
        {
            
            if (password.Length < 8)
                return false;

            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit))
                return false;

            return true;
        }

        
        public static bool IsValidUsername(string username)
        {
            
            if (string.IsNullOrWhiteSpace(username) || username.Contains(" "))
                return false;

            
            if (username.Length < 8)
                return false;

            
            bool containsNumber = username.Any(ch => Char.IsDigit(ch));

            if (/*!containsSpecialCharacter ||*/ !containsNumber)
                return false;

            return true;
        }
    }
}


