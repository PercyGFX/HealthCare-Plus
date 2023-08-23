using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCare_Plus.Services
{

 
    /// ////////////////////////////////////////login validations /////////////////////////////////////////////////
   
    public class LoginValidations
    {

        // return false if username empty
        public static bool IsValidUsername(string username)
        {
            return !string.IsNullOrWhiteSpace(username);
        }

        // return false if password empty
        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password);
        }

        public static bool IsValidLogin(string username, string password)
        {
            if (!IsValidUsername(username))
            {
                // if username empty show messagebox
                MessageBox.Show("Enter a valid username.", "Error");
                return false;
            }
            else if (!IsValidPassword(password))
            {
                // if password empty show messagebox
                MessageBox.Show("Enter a valid password.", "Error");
                return false;
            }

            // return true if username & password not empty

            return true;
        }
    }


   /// /////////////////////////// registration validations ///////////////////////////////////////////////////////////////
 

    public class RegisterValidations
    {
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public static bool IsValidAddress(string address)
        {
            return !string.IsNullOrWhiteSpace(address);
        }

        public static bool IsValidPhone(string phone)
        {
            // Basic phone number format validation
            return !string.IsNullOrWhiteSpace(phone) && Regex.IsMatch(phone, @"^\d{10}$");
        }

        public static bool IsValidEmail(string email)
        {
            // Basic phone number format validation
            return !string.IsNullOrWhiteSpace(email);
        }

        

        public static bool IsValidUsername(string username)
        {
            return !string.IsNullOrWhiteSpace(username);
        }

        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password);
        }

        public static bool IsValidRegistration(string name, string address, string phone, string email, string username, string password)
        {
            if (!IsValidName(name))
            {
                MessageBox.Show("Enter a valid name.", "Error");
                return false;
            }
            else if (!IsValidAddress(address))
            {
                MessageBox.Show("Enter a valid address.", "Error");
                return false;
            }
            else if (!IsValidPhone(phone))
            {
                MessageBox.Show("Enter a valid phone number.", "Error");
                return false;
            }

            else if (!IsValidEmail(email))
            {
                MessageBox.Show("Enter a valid email.", "Error");
                return false;
            }

            else if (!IsValidUsername(username))
            {
                MessageBox.Show("Enter a valid username.", "Error");
                return false;
            }
            else if (!IsValidPassword(password))
            {
                MessageBox.Show("Enter a valid password.", "Error");
                return false;
            }

            return true;
        }
    }


}
