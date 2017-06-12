using OCS_Support_Helper.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OCS_Support_Helper.Model
{
    public class Customer : IDataErrorInfo
    {
        #region Creation
        protected Customer()
        { }

        public static Customer CreateNewCustomer()
        {
            return new Customer();
        }
        public static Customer CreateCustomer(string firstName, string lastName, string email, bool isCompany, double totalSales)
        {
            return new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                IsCompany = isCompany,
                TotalSales = totalSales
            };
        }
        #endregion

        #region State Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsCompany { get; set; }
        public string Email { get; set; }
        public double TotalSales { get; set; }

        #endregion

        #region IDataErrorInfo Members
        public string this[string columnName] => throw new NotImplementedException();

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

       

        string IDataErrorInfo.Error { get { return null; } }
        #endregion

        #region Validation
        string ValidateFirstName()
        {
            if(IsStringMissing(this.FirstName))
            {
                return Strings.Customer_Error_MissingFirstName;
            }
            return null;
        }
        string ValidateLastName()
        {
            if(IsStringMissing(this.LastName))
            {
                return Strings.Customer_Error_MissingLastName;
            }
            return null;
        }
        string ValidateEmail()
        {
            if(IsStringMissing(this.Email))
            {
                return Strings.Customer_Error_MissingEmail;
            }
            else if(!IsValidEmailAddress(this.Email))
            {
                return Strings.Customer_Error_InvalidEmail;
            }
            return null;
        }
        static readonly string[] ValidatedProperties =
        {
            "Email","FirstName","LastName"
        };
        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;
                return
                    true;
            }
        }
        static bool IsStringMissing(string value)
        {
            return String.IsNullOrEmpty(value) || value.Trim() == String.Empty;
        }
        static bool IsValidEmailAddress(string email)
        {
            if (IsStringMissing(email))
                return false;

            // This regex pattern came from: http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        private string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;
            string error = null;
            switch(propertyName)
            {
                case "Email":
                    error = this.ValidateEmail();
                    break;
                case "FirstName":
                    error = this.ValidateFirstName();
                    break;
                case "LastName":
                    error = this.ValidateLastName();
                    break;
                default:
                    Debug.Fail("Unexpected property being validated on Customer: " + propertyName);
                    break;
            }
            return error;
        }
        #endregion
    }
}
