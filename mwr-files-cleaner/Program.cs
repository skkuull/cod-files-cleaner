using System;
using System.IO;

namespace mwr_files_cleaner
{
    internal class Program
    {
        public static string ffExt = "*.ff";

        public static string bikExt = "*.bik";

        public static string pakExt = "*.pak";

        public static string[] ffs = Directory.GetFiles("./", ffExt);

        public static string[] biks = Directory.GetFiles("./", bikExt);

        public static string[] paks = Directory.GetFiles("./", pakExt);

        static void Main(string[] args)
        {
            if (!File.Exists("common_mp.ff") && !File.Exists("s2_mp64_ship.exe") || !File.Exists("common.ff") && !File.Exists("s2_sp64_ship.exe"))
            {
                Console.WriteLine("Please put the mwr-files-cleaner.exe in your game folder\nor your game is already cleaned up.\n");
                Environment.Exit(0);
            }

            Console.WriteLine("Doin stuff ..\n");

            if (!Directory.Exists(".\\zone"))
            {
                Directory.CreateDirectory(".\\zone");
            }

            if (!Directory.Exists(".\\raw"))
            {
                Directory.CreateDirectory(".\\raw");
            }

            if (!Directory.Exists(".\\raw\\video"))
            {
                Directory.CreateDirectory(".\\raw\\video");
            }

            foreach (var ff in ffs)
            {
                File.Move(ff, Path.Combine("zone", Path.GetFileName(ff)));
            }

            foreach (var bik in biks)
            {
                File.Move(bik, Path.Combine("raw\\video", Path.GetFileName(bik)));
            }

            foreach (var pak in paks)
            {
                File.Move(pak, Path.Combine("zone", Path.GetFileName(pak)));
            }

            try
            {
                if (Directory.Exists("english"))
                {
                    Directory.Move("english\\", "zone\\english");
                }
                else if (Directory.Exists("english_safe"))
                {
                    Directory.Move("english_safe\\", "zone\\english_safe"); // arabic
                }
                else if (Directory.Exists("french"))
                {
                    Directory.Move("french\\", "zone\\french");
                }
                else if (Directory.Exists("german"))
                {
                    Directory.Move("german\\", "zone\\german");
                }
                else if (Directory.Exists("russian"))
                {
                    Directory.Move("russian\\", "zone\\russian");
                }
                else if (Directory.Exists("polish"))
                {
                    Directory.Move("polish\\", "zone\\polish");
                }
                else if (Directory.Exists("japanese_partial"))
                {
                    Directory.Move("japanese_partial\\", "zone\\japanese_partial");
                }
                else if (Directory.Exists("korean"))
                {
                    Directory.Move("korean\\", "zone\\korean");
                }
                else if (Directory.Exists("portuguese"))
                {
                    Directory.Move("portuguese\\", "zone\\portuguese");
                }
                else if (Directory.Exists("spanish"))
                {
                    Directory.Move("spanish\\", "zone\\spanish");
                }
                else if (Directory.Exists("italian"))
                {
                    Directory.Move("italian\\", "zone\\italian");
                }
                else if (Directory.Exists("simplified_chinese"))
                {
                    Directory.Move("simplified_chinese\\", "zone\\simplified_chinese");
                }
                else if (Directory.Exists("traditional_chinese"))
                {
                    Directory.Move("traditional_chinese\\", "zone\\traditional_chinese");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            Console.WriteLine("Done.");

            Environment.Exit(0);

            Console.ReadLine();
        }
    }
}
