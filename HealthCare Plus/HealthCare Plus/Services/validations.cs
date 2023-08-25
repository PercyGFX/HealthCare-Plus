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
        private static bool IsValidField(string fieldValue)
        {
            return !string.IsNullOrWhiteSpace(fieldValue);
        }

        public static bool IsValidRegistration(string name, string address, string phone, string email, string username, string password)
        {
            if (!IsValidField(name))
            {
                ShowErrorMessage("name");
                return false;
            }
            else if (!IsValidField(address))
            {
                ShowErrorMessage("address");
                return false;
            }
            else if (!IsValidField(phone))
            {
                ShowErrorMessage("phone number");
                return false;
            }
            else if (!IsValidField(email))
            {
                ShowErrorMessage("email");
                return false;
            }
            else if (!IsValidField(username))
            {
                ShowErrorMessage("username");
                return false;
            }
            else if (!IsValidField(password))
            {
                ShowErrorMessage("password");
                return false;
            }

            return true;
        }

        private static void ShowErrorMessage(string fieldName)
        {
            MessageBox.Show($"Enter a valid {fieldName}.", "Error");
        }
    }

    ///////////////////////////// Add doctor validations ///////////////////////////////////

    public class AddDoctorValidations
    {
        public static bool IsValidField(string fieldValue)
        {
            return !string.IsNullOrWhiteSpace(fieldValue);
        }

        public static bool IsValidFormFields(string name, string age, string location, string phone, string email, string specialized, string qualifications)
        {
            if (!IsValidField(name))
            {
                MessageBox.Show("Enter a valid name.", "Error");
                return false;
            }
            else if (!IsValidField(age))
            {
                MessageBox.Show("Enter a valid age.", "Error");
                return false;
            }
            else if (!IsValidField(location))
            {
                MessageBox.Show("Enter a valid location.", "Error");
                return false;
            }
            else if (!IsValidField(phone))
            {
                MessageBox.Show("Enter a valid phone number.", "Error");
                return false;
            }
            else if (!IsValidField(email))
            {
                MessageBox.Show("Enter a valid email.", "Error");
                return false;
            }
            else if (!IsValidField(specialized))
            {
                MessageBox.Show("Enter a valid specialization.", "Error");
                return false;
            }
            else if (!IsValidField(qualifications))
            {
                MessageBox.Show("Enter valid qualifications.", "Error");
                return false;
            }

            return true;
        }
    }



}
