using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Mohammad Raja

namespace RaheemRestaurant.BusinessLogic
{
    public class Users
    {
        private Dictionary<string, int> _userIds = new Dictionary<string, int>();

        private int _id;

        private string _firstName;

        private string _lastName;

        private string _email;

        private string _username;

        private string _password;

        private string _phoneNumber;

        public string Email { get { return _email; } set {
                {
                    _email = value;
                }
            } 
        } 

        public string FirstName { get { return _firstName; } set { _firstName = value; } }

        public string LastName {  get { return _lastName; } set { _lastName = value; } }

        public Dictionary<string, int> UserIDs
        {
            get { return _userIds; }
        }

        public string UserName 
            { 
                get 
                    { 
                        return _username; 
                    } 
                set 
                    {


                 if (_userIds.ContainsKey(value))
                {
                    throw new ArgumentException("Username already exists.");
                }
                else
                {
                    _username = value;
                    _id = GenerateUniqueId();
                    _userIds.Add(_username, _id);
                }
                _username = value;
            }
        }

        public int ID { get { return _id; } }

        public string Password { get { return _password; } set { _password = value; } }

        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } } 
        private int GenerateUniqueId()
        {
            // Generate a unique ID (for simplicity, using the current count of the dictionary)
            return _userIds.Count + 1;
        }
       
        public Users() { }

        public Users( string firstName, string lastName, string userName, string password , string email , string phoneNumber) 
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
    
        }


        public string GetPhoneNumber() 
            {
                return PhoneNumber;
            }


        public string GetFirstName()
            {
                return FirstName;
            }

        public string GetLastName()
            {
                return LastName; 
            }

        public string GetUserName() 
            {
                return UserName;
            }

        public string GetPassword()
            {
                return Password;
            }

        public string GetEmail() 
            {
                return Email;
            }

        public void SetFirstName(string firstName)
            {
                FirstName = firstName; 
            }

        public void SetLastName(string lastName) 
            { 
                LastName = lastName; 
            }

        public void SetUserName (string userName)
            {
                UserName = userName;
            }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetEmail(string email)
        {
            Email =  email;
        }

        public void SetphoneNumber(string phoneNumber) 
        {
            PhoneNumber = phoneNumber;
        }



    }
}
