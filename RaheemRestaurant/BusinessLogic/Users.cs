using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Mohammad Raja

namespace RaheemRestaurant.BusinessLogic
{
    // Define a class named 'Users' to manage user information and authentication.
    public class Users
    {
        // Dictionary to hold usernames and their corresponding unique IDs.
        private Dictionary<string, int> _userIds = new Dictionary<string, int>();

        // Private fields to store user details.
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _username;
        private string _password;
        private string _phoneNumber;

        // Public properties for getting and setting user email.
        public string Email { get { return _email; } set { _email = value; } }

        // Public properties for getting and setting user first name.
        public string FirstName { get { return _firstName; } set { _firstName = value; } }

        // Public properties for getting and setting user last name.
        public string LastName { get { return _lastName; } set { _lastName = value; } }

        // Read-only property to access the dictionary of user IDs.
        public Dictionary<string, int> UserIDs
        {
            get { return _userIds; }
        }

        // Property for managing usernames. Ensures uniqueness within the system.
        public string UserName
        {
            get { return _username; }
            set
            {
                if (_userIds.ContainsKey(value))
                {
                    throw new ArgumentException("Username already exists."); // Ensure unique username.
                }
                else
                {
                    _username = value;
                    _id = GenerateUniqueId(); // Generate a unique ID for the new user.
                    _userIds.Add(_username, _id); // Add new username and ID to dictionary.
                }
            }
        }

        // Public property for accessing and setting the user's ID.
        public int ID { get { return _id; } set { _id = value; } }

        // Public property for getting and setting the user's password.
        public string Password { get { return _password; } set { _password = value; } }

        // Public property for getting and setting the user's phone number.
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }

        // Private method to generate a unique identifier for a new user.
        private int GenerateUniqueId()
        {
            return _userIds.Count + 1; // Simple unique ID generator based on the count of the dictionary.
        }

        // Default constructor for the Users class.
        public Users() { }

        // Constructor for initializing a new user with all fields.
        public Users(string firstName, string lastName, string userName, string password, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName; // This will also handle ID generation.
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        // Public methods below are simple getters and setters.
        // They provide access to user information and allow setting new values.

        public string GetPhoneNumber() { return PhoneNumber; }
        public string GetFirstName() { return FirstName; }
        public string GetLastName() { return LastName; }
        public string GetUserName() { return UserName; }
        public string GetPassword() { return Password; }
        public string GetEmail() { return Email; }

        public void SetFirstName(string firstName) { FirstName = firstName; }
        public void SetLastName(string lastName) { LastName = lastName; }
        public void SetUserName(string userName) { UserName = userName; }
        public void SetPassword(string password) { Password = password; }
        public void SetEmail(string email) { Email = email; }
        public void SetphoneNumber(string phoneNumber) { PhoneNumber = phoneNumber; }
    }
}