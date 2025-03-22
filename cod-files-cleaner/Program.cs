using System;
using System.IO;

namespace cod_files_cleaner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "COD Files Cleaner by skkuull";

            while (true)
            {
                DisplayMenu();
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    CleanCODFiles();
                }
                else if (choice == "2")
                {
                    RevertCleaning();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                }
            }
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("[ 1 ] Clean COD Files (MWR/WWII)");
            Console.WriteLine("[ 2 ] Revert Cleaning");
            Console.Write("\ncod-files-cleaner:~$ ");
        }

        static void CleanCODFiles()
        {
            if (!IsGameFolderReady())
            {
                Console.WriteLine("Please put the cod-files-cleaner.exe in your game folder\nor your game is already cleaned up.\n");
                return;
            }

            Console.WriteLine("Cleaning COD files...\n");

            CreateRequiredDirectories();

            MoveFilesToZone();

            MoveLanguageDirectories();

            Console.WriteLine("Done cleaning COD files.\n");
        }

        static bool IsGameFolderReady()
        {
            return File.Exists("h1_mp64_ship.exe") ||
                   File.Exists("h1_sp64_ship.exe") ||
                   File.Exists("s2_mp64_ship.exe") ||
                   File.Exists("s2_sp64_ship.exe");
        }

        static bool IsMWR()
        {
            return File.Exists("patch_common_mp.ff") && File.Exists("h1_mp64_ship.exe") ||
                   File.Exists("patch_common.ff") && File.Exists("h1_sp64_ship.exe");
        }

        static bool IsS2()
        {
            return File.Exists("common_mp.ff") && File.Exists("s2_mp64_ship.exe") ||
                   File.Exists("common.ff") && File.Exists("s2_sp64_ship.exe");
        }

        static void CreateRequiredDirectories()
        {
            CreateDirectoryIfNotExists(".\\zone");
            CreateDirectoryIfNotExists(".\\raw");
            CreateDirectoryIfNotExists(".\\raw\\video");
        }

        static void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        static void MoveFilesToZone()
        {
            MoveFilesByExtension("*.ff", ".\\zone");
            MoveFilesByExtension("*.bik", ".\\raw\\video");
            MoveFilesByExtension("*.pak", ".\\zone");
        }

        static void MoveFilesByExtension(string fileExtension, string targetDirectory)
        {
            var files = Directory.GetFiles("./", fileExtension);
            foreach (var file in files)
            {
                File.Move(file, Path.Combine(targetDirectory, Path.GetFileName(file)));
            }
        }

        static void MoveLanguageDirectories()
        {
            var languageDirs = new string[]
            {
                "english", "english_safe", "french", "german", "russian", "polish", "japanese_partial", "korean",
                "portuguese", "spanish", "italian", "simplified_chinese", "traditional_chinese", "spanishna"
            };

            foreach (var langDir in languageDirs)
            {
                try
                {
                    if (Directory.Exists(langDir))
                    {
                        Directory.Move(langDir, Path.Combine("zone", langDir));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error moving {langDir}: {e.Message}");
                }
            }
        }

        static void RevertCleaning()
        {
            Console.WriteLine("Reverting COD file changes...\n");

            MoveFilesBackToOriginalLocations();

            RevertLanguageDirectories();

            CleanupTempDirectories();

            Console.WriteLine("Done reverting COD cleaned files.\n");
        }

        static void MoveFilesBackToOriginalLocations()
        {
            MoveFilesBackByExtension("zone/*.ff");
            MoveFilesBackByExtension("raw/video/*.bik");
            MoveFilesBackByExtension("zone/*.pak");
        }

        static void MoveFilesBackByExtension(string filePattern)
        {
            var files = Directory.GetFiles("./", filePattern);
            foreach (var file in files)
            {
                File.Move(file, Path.Combine("./", Path.GetFileName(file)));
            }
        }

        static void RevertLanguageDirectories()
        {
            var languageDirs = new string[]
            {
                "zone\\english", "zone\\english_safe", "zone\\french", "zone\\german", "zone\\russian",
                "zone\\polish", "zone\\japanese_partial", "zone\\korean", "zone\\portuguese", "zone\\spanish",
                "zone\\italian", "zone\\simplified_chinese", "zone\\traditional_chinese", "zone\\spanishna"
            };

            foreach (var langDir in languageDirs)
            {
                try
                {
                    if (Directory.Exists(langDir))
                    {
                        var targetDir = langDir.Replace("zone\\", "./");
                        Directory.Move(langDir, targetDir);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error reverting {langDir}: {e.Message}");
                }
            }
        }

        static void CleanupTempDirectories()
        {
            try
            {
                Directory.Delete("zone", true);
                Directory.Delete("raw", true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error cleaning up temporary directories: {e.Message}");
            }
        }
    }
}
