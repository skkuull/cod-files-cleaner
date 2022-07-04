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
            if (!File.Exists("patch_common_mp.ff") && !File.Exists("h1_mp64_ship.exe") || !File.Exists("patch_common.ff") && !File.Exists("h1_sp64_ship.exe"))
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
                Directory.Move("english\\", "zone\\english");
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
