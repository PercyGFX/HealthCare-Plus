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


    ///////////////////////////// Add doctor validations ///////////////////////////////////

    public class AddPatientValidations
    {
        public static bool IsValidField(string fieldValue)
        {
            return !string.IsNullOrWhiteSpace(fieldValue);
        }

        public static bool IsValidFormFields(string name, string age, string address, string phone, string bloodType, string description)
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
            else if (!IsValidField(address))
            {
                MessageBox.Show("Enter a valid address.", "Error");
                return false;
            }
            else if (!IsValidField(phone))
            {
                MessageBox.Show("Enter a valid phone number.", "Error");
                return false;
            }
            else if (!IsValidField(bloodType))
            {
                MessageBox.Show("Enter a valid blood type.", "Error");
                return false;
            }
            else if (!IsValidField(description))
            {
                MessageBox.Show("Enter a valid description.", "Error");
                return false;
            }

            return true;
        }
    }

    //////////////////////// Add appoinemnt validations ///////////////////////////////////
    ///
    public class AddAppointmentValidations
    {
        public static bool IsValidComboBoxSelection(ComboBox comboBox)
        {
            return comboBox.SelectedIndex != -1; // Check if a valid item is selected
        }

        public static bool IsValidDate(DateTimePicker dateTimePicker)
        {
            // Check if a valid date is selected (not the default value)
            return dateTimePicker.Value != dateTimePicker.MinDate;
        }

        public static bool IsValidField(string fieldValue)
        {
            return !string.IsNullOrWhiteSpace(fieldValue);
        }

        public static bool IsValidFormFields(ComboBox combopatient, ComboBox combodoctor, DateTimePicker date, string txtcost, string rtextdescription)
        {
            if (!IsValidComboBoxSelection(combopatient))
            {
                MessageBox.Show("Select a patient.", "Error");
                return false;
            }
            else if (!IsValidComboBoxSelection(combodoctor))
            {
                MessageBox.Show("Select a doctor.", "Error");
                return false;
            }
            else if (!IsValidDate(date))
            {
                MessageBox.Show("Select a valid date.", "Error");
                return false;
            }

            else if (!IsValidField(txtcost))
            {
                MessageBox.Show("Enter a valid cost.", "Error");
                return false;
            }
            else if (!IsValidField(rtextdescription))
            {
                MessageBox.Show("Enter a valid description.", "Error");
                return false;
            }

            return true;
        }
    }

    //////////////////////////////// room allowcation validations ////////////////////////////////
    ///
    public class RoomAllowcations
    {
        public static bool IsValidComboBoxSelection(ComboBox comboBox)
        {
            return comboBox.SelectedIndex != -1; // Check if a valid item is selected
        }

        public static bool IsValidDate(DateTimePicker dateTimePicker)
        {
            // Check if a valid date is selected (not the default value)
            return dateTimePicker.Value != dateTimePicker.MinDate;
        }

        public static bool IsValidField(string fieldValue)
        {
            return !string.IsNullOrWhiteSpace(fieldValue);
        }

        public static bool IsValidFormFields(ComboBox combopatient, ComboBox combodoctor, DateTimePicker date, string txtcost)
        {
            if (!IsValidComboBoxSelection(combopatient))
            {
                MessageBox.Show("Select a patient.", "Error");
                return false;
            }
            else if (!IsValidComboBoxSelection(combodoctor))
            {
                MessageBox.Show("Select a Room.", "Error");
                return false;
            }
            else if (!IsValidDate(date))
            {
                MessageBox.Show("Select a valid date.", "Error");
                return false;
            }
            else if (!IsValidField(txtcost))
            {
                MessageBox.Show("Enter a valid cost.", "Error");
                return false;
            }

            return true;
        }
    }

    ////////////////////////// add medications validations ////////////////////////
    ///

    public class AddMedicationValidations
    {

        public static bool IsValidComboBoxSelection(ComboBox comboBox)
        {
            return comboBox.SelectedIndex != -1; // Check if a valid item is selected
        }

        public static bool IsValidDate(DateTimePicker dateTimePicker)
        {
            // Check if a valid date is selected (not the default value)
            return dateTimePicker.Value != dateTimePicker.MinDate;
        }

        public static bool IsValidField(string fieldValue)
        {
            return !string.IsNullOrWhiteSpace(fieldValue);
        }


        public static bool IsValidFormFields(ComboBox combopatient, string txtmedication, DateTimePicker date, string txtcost, string rtextdescription)
        {
            if (!IsValidComboBoxSelection(combopatient))
            {
                MessageBox.Show("Select a patient.", "Error");
                return false;
            }

            else if (!IsValidField(txtmedication))
            {
                MessageBox.Show("Enter a valid Meication.", "Error");
                return false;
            }

            else if (!IsValidDate(date))
            {
                MessageBox.Show("Select a valid date.", "Error");
                return false;
            }
            else if (!IsValidField(txtcost))
            {
                MessageBox.Show("Enter a valid cost.", "Error");
                return false;
            }

            else if (!IsValidField(rtextdescription))
            {
                MessageBox.Show("Enter a valid description.", "Error");
                return false;
            }

            return true;
        }

    }

}
