using RaheemRestaurant.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RaheemRestaurant.DataLayer
{
    //Author By: Mohammad Raja

    // Define a class named 'Repository' that provides methods for data persistence in the form of JSON files.
    public class Repository
    {
        // Method to write user data to a JSON file on the user's desktop in a designated folder path.
        public static void WriteDataToJsonFile(ObservableCollection<Users> users, string fileName)
        {
            // Set the folder path to a specific directory on the Desktop, using nested folders under 'RaheemRestaurant'.
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "RaheemRestaurant//RaheemRestaurant//Resources//Raw");

            // Combine the directory and file name to create a full path to where the JSON file will be saved.
            string fullPath = Path.Combine(folderPath, fileName);

            // Output the full file path to the debug console for verification and debugging purposes.
            Debug.WriteLine(fullPath);

            // Open the file at the specified path for writing, creating it if it does not already exist.
            using (FileStream fileStream = File.OpenWrite(fullPath))
            {
                // Serialize the ObservableCollection of Users to the open file stream using JSON format.
                JsonSerializer.Serialize(fileStream, users);

                // Close the file stream explicitly after serialization is complete.
                fileStream.Close();
            }
        }

        // Method to read user data from a JSON file and return it as an ObservableCollection of Users.
        public static ObservableCollection<Users> LoaddataFromResources(string fileName)
        {
            // Open the file specified by fileName asynchronously and retrieve the result synchronously.
            using var stream = FileSystem.OpenAppPackageFileAsync(fileName).Result;

            // Deserialize the JSON data from the stream into an ObservableCollection of Users.
            ObservableCollection<Users>? users = JsonSerializer.Deserialize<ObservableCollection<Users>>(stream);

            // Return the deserialized collection of users.
            return users;
        }
    }
}