using Discord;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudp
{
    class Program
    {

        static DiscordClient dc = new DiscordClient();
        static List<string[]> WorkingTokens = new List<string[]>();
        static List<Action> tryit = new List<Action>();
        static UserReportIdentification identify = new UserReportIdentification();
        static string logo = @"

 _____ _                 _       
/  __ \ |               | |      
| /  \/ | ___  _   _  __| |_ __  
| |   | |/ _ \| | | |/ _` | '_ \ 
| \__/\ | (_) | |_| | (_| | |_) |
 \____/_|\___/ \__,_|\__,_| .__/ 
                          | |    
                          |_|    
";
        static void Main(string[] args)
        {

            Console.Title = "CLOUDP | arsh#5295";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(logo);
            Console.WriteLine("\n> [1] Token Checker");

            string input = Console.ReadLine();


            switch (input)
            {

                case "1":
                    Checker();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine(logo);
                    Console.WriteLine("\n>> Select one of choices!");
                    System.Threading.Thread.Sleep(3000);
                    Main(null);
                    break;
            }


        }


        static void Checker()
        {


            Console.Clear();
            Console.WriteLine(logo + "\n\n> [\\] Input File Path\n");



            string file = Console.ReadLine();

            if (!file.EndsWith(".txt")) { Console.WriteLine(">> TXT file needed."); System.Threading.Thread.Sleep(3000); Checker(); }


            string[] lines = File.ReadAllLines(file);


            Console.Clear();
            Console.WriteLine(logo);

            int tkcount = 0;
            foreach (var tkcountw in lines)
            {
                tkcount++;
            }

            Console.WriteLine($"[>] Found - {tkcount}\n\n");

            int ok = 0;
            int bad = 0;

            try { File.Delete("C:\\Users\\{Environment.UserName}\\Desktop\\working.txt"); } catch { }

            for (var i = 0; i < lines.Length; i++)
            {

                var token = lines[i];


                try
                {

                    dc.Token = token;
                    Console.Title = "User |" + dc.GetClientUser().ToString();

                    ok++;

                    string[] token_arry = new string[] { token };
                    WorkingTokens.Add(token_arry);


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"> Working | {token} | {dc.User.Username}");

                }

                catch (Exception)
                {

                    bad++;
                    Console.Title = "User | Invalid";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"> Invalid | {token}");

                }

            }

            bool ass = ok < 1;

            string worktxt = $"C:\\Users\\{Environment.UserName}\\Desktop\\working.txt";
            foreach (var workintoken in WorkingTokens)
            {
                File.WriteAllLines(worktxt, workintoken);
            }


            Console.WriteLine($"\n\n>> Working - {ok}");
            Console.WriteLine($">> Invalid - {bad}");

            if (ok < 1) { try { File.Delete("C:\\Users\\{Environment.UserName}\\Desktop\\working.txt"); } catch { } } else { Console.WriteLine($"[>] Working tokens has saved to | Desktop\\working.txt"); }

            Console.ReadKey();
            Environment.Exit(0);

        }


        static Random _R = new Random();
        static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(_R.Next(v.Length));
        }

    }
}
