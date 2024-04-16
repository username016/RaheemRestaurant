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

    public class Repository
    {

        public static void WriteDataToJsonFile(ObservableCollection<Users> users, string fileName)
        {

            // Set the folder path to a specific directory on the Desktop
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "RaheemRestaurant//RaheemRestaurant//Resources//Raw");

            // Combine the directory and file name into a full path
            string fullPath = Path.Combine(folderPath, fileName);

            Debug.WriteLine(fullPath);

            // Open the file stream and serialize the ObservableCollection<User> to it
            using (FileStream fileStream = File.OpenWrite(fullPath))
            {
                JsonSerializer.Serialize(fileStream, users);
                fileStream.Close();
            }

        }

        //Read data from JSON File
        public static ObservableCollection<Users> LoaddataFromResources(string fileName)
        {
            using var stream = FileSystem.OpenAppPackageFileAsync(fileName).Result;
            ObservableCollection<Users>? users = JsonSerializer.Deserialize<ObservableCollection<Users>>(stream);

            return users;
        }

    }
}
