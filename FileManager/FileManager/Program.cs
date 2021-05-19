using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            /* GetDirectoriesWithFiles(@"C:\"); */ // I don't know why the exception is being thrown, even though I have handled it 
            TakeCommand(); // It works
        }
        static void TakeCommand()
        {
            string currentPath = @"C:\";
            Regex goToTheFolder = new Regex(@"cd \w+");
            Regex goToThePreviousFolder = new Regex(@"cd \.\.");
            Regex endTheSession = new Regex(@"exit");
            Regex openTheFile = new Regex(@"open \w+");
            Console.WriteLine("cd FilePath, cd .., exit, open fileName");
            while (true)
            {
                string command = Console.ReadLine();

                if (goToTheFolder.IsMatch(command))
                {
                   currentPath = GoToTheFolder(command);
                    continue;
    
            } else if (goToThePreviousFolder.IsMatch(command))
                {
                    currentPath = GoToThePreviousFolder(currentPath);
                    Console.WriteLine($"Previous folder is: {currentPath}");
                    continue;

                }
                
                else if (openTheFile.IsMatch(command))
                {
                    OpenTheFile(command);
                    continue;
                }
                else if (endTheSession.IsMatch(command))
                {
                    break;

                }
            }
        }
        static string GoToTheFolder(string command)
        {
            string folder = command.Remove(0, 3);
            Console.WriteLine(folder);
            string path = "";
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(folder);
            DirectoryInfo[] directoriesInDir = hdDirectoryInWhichToSearch.GetDirectories();
            foreach (DirectoryInfo foundFile in directoriesInDir)
            {
                path = foundFile.FullName;
                GetDirectoriesWithFiles(path);
            }
            return path;      
        }
        static string GoToThePreviousFolder(string currentPath)
        {
            if (currentPath == @"C:\")
            {
                Console.WriteLine("You are in root directory");
                return currentPath;
            }
            string previousFolderPath = "";
            char[] arr = currentPath.ToCharArray();
            for (int i = currentPath.Length-1; i > 0; i--)
            {
                if (arr[i] == '\\')
                {
                    int lengthOfCurrentFolder = currentPath.Length - 1 - i;
                    Console.WriteLine(currentPath.Length - 1 - i);
                    Console.WriteLine(currentPath.Length);
                    previousFolderPath = currentPath.Remove(i, lengthOfCurrentFolder);
                    break;
                }
            
            }
            
            return previousFolderPath;
        }
        static void OpenTheFile(string filePath)
        {
            string fileName = filePath.Remove(0, 5);
            Regex reg = new Regex(@"\w+\.txt");
            if (reg.IsMatch(filePath) && File.Exists(fileName))
            {  
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                    Console.WriteLine(line);
            }
            else
            {
                Console.WriteLine(fileName);
                byte[] fileBytes = File.ReadAllBytes(fileName);
                StringBuilder sb = new StringBuilder();

                foreach (byte b in fileBytes)
                {
                    sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
                }

               Console.WriteLine(sb.ToString());

            }

        }
        static void GetDirectoriesWithFiles(string driveName)
        {
              
                var dirs = GetAllDirectories(driveName);
                foreach (var directory in dirs)
                {
                     Console.WriteLine(directory);
                if (Directory.Exists(directory))
                {
                    var st = GetAllFiles(directory);

                    if (st != null)
                    {
                        foreach (var file in st)
                        {

                            Console.WriteLine(file);
                        }
                    }
                }
                }
            
        }
        static IEnumerable<String> GetAllFiles(string path)
        {
            return System.IO.Directory.EnumerateFiles(path).Union(
                System.IO.Directory.EnumerateDirectories(path).SelectMany(d =>
                {
                    try
                    {
                        return GetAllFiles(d);
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        Console.WriteLine($"Acces is denied {e.Message}");    //Handle the exception, but it still alive
                        return Enumerable.Empty<String>();
                    }
                }));
        }
        static IEnumerable<String> GetAllDirectories(string path)
        {
            return System.IO.Directory.EnumerateDirectories(path).Union(
                System.IO.Directory.EnumerateDirectories(path).SelectMany(d =>
                {
                    try
                    {
                        return GetAllDirectories(d);
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        Console.WriteLine($"Acces is denied {e.Message}");
                        return Enumerable.Empty<String>();
                    }
                }));
        }
    }

}
