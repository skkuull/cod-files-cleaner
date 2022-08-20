using System;
using System.IO;

namespace mwr_files_cleaner
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "MWR Files cleaner by skkuull";

        Main:
            Console.WriteLine("[ 1 ] Clean MWR Files");
            Console.WriteLine("[ 2 ] Revert Cleaning");
            Console.Write("\nmwr-files-cleaner:~$ ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                string ffExt = "*.ff";

                string bikExt = "*.bik";

                string pakExt = "*.pak";

                string[] ffs = Directory.GetFiles("./", ffExt);

                string[] biks = Directory.GetFiles("./", bikExt);

                string[] paks = Directory.GetFiles("./", pakExt);


                if (!File.Exists("patch_common_mp.ff") && !File.Exists("h1_mp64_ship.exe") || !File.Exists("patch_common.ff") && !File.Exists("h1_sp64_ship.exe"))
                {
                    Console.WriteLine("Please put the mwr-files-cleaner.exe in your game folder\nor your game is already cleaned up.\n");
                    goto Main;
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

                Console.WriteLine("Done Cleaning MWR files.\n");

                goto Main;
            }
            else if (choice == "2")
            {
                string ffExt = "zone/*.ff";

                string bikExt = "raw/video/*.bik";

                string pakExt = "zone/*.pak";

                string[] ffs = Directory.GetFiles("./", ffExt);

                string[] biks = Directory.GetFiles("./", bikExt);

                string[] paks = Directory.GetFiles("./", pakExt);

                foreach (var ff in ffs)
                {
                    File.Move(ff, Path.Combine("./", Path.GetFileName(ff)));
                }

                foreach (var bik in biks)
                {
                    File.Move(bik, Path.Combine("./", Path.GetFileName(bik)));
                }

                foreach (var pak in paks)
                {
                    File.Move(pak, Path.Combine("./", Path.GetFileName(pak)));
                }

                try
                {
                    if (Directory.Exists("zone\\english"))
                    {
                        Directory.Move("zone\\english", "./english");
                    }
                    else if (Directory.Exists("zone\\english_safe"))
                    {
                        Directory.Move("zone\\english_safe", "./english_safe"); // arabic
                    }
                    else if (Directory.Exists("french"))
                    {
                        Directory.Move("zone\\french", "./french");
                    }
                    else if (Directory.Exists("german"))
                    {
                        Directory.Move("zone\\german", "./german");
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

                // Cleanup
                File.Delete("zone");
                File.Delete("raw/video");
                File.Delete("raw");
                
                Console.WriteLine("Done Reverting MWR cleaned files.\n");

                goto Main;
            }
            else
            {
                goto Main;
            }
        }
    }
}
