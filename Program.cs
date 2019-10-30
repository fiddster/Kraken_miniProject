using System;
using static System.Console;
using Kraken_WeaponSystem.Models;
using System.Collections.Generic;
using System.Threading;
using Kraken_WeaponSystem.Data;
using System.Linq;

namespace Kraken_WeaponSystem
{
    class Program
    {
        //TODO LOAD FROM DATABASE
        static KrakenContext context = new KrakenContext();

        static void Main(string[] args)
        {
            var shouldNotExit = true;
            while (shouldNotExit)
            {

                WriteLine("1. Add target");
                WriteLine("2. List targets");
                WriteLine("3. Attack targets");
                WriteLine("4. Exit");

                ConsoleKeyInfo keyPressed = ReadKey(true);
                Clear();
                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1: //Add target
                    case ConsoleKey.NumPad1:
                        {

                            //public Target(string name, string description, int x, int y, int z)
                            Write("Name: ");
                            string name = ReadLine();

                            Write("Description: ");
                            string description = ReadLine();

                            Write("Coordinate x: ");
                            int x = int.Parse(ReadLine());
                            Write("Coordinate y: ");
                            int y = int.Parse(ReadLine());
                            Write("Coordinate z: ");
                            int z = int.Parse(ReadLine());

                            context.Target.Add(new Target(name, description, x, y, z));
                            context.SaveChanges();
                            
                            Clear();
                            WriteLine("Target was added");
                            Thread.Sleep(1500);
                        }
                        break;

                    case ConsoleKey.D2: //List targets
                    case ConsoleKey.NumPad2:
                        {
                            PrintAllTargets();
                        }
                        break;

                    case ConsoleKey.D3: //Attack targets
                    case ConsoleKey.NumPad3:
                        {
                            AttackAllTargets();
                        }
                        break;

                    case ConsoleKey.D4: //Exit program
                    case ConsoleKey.NumPad4:
                        {
                            shouldNotExit = false;
                        }
                        break;
                }
                Clear();
            }
        }

        private static void AttackTarget(Target target, Random random)
        {
            
            int hit = random.Next(1, 11);
            
            if (!target.Status)
            {
                if (5 <= hit)
                {
                    target.Hit();
                }
                else
                {
                    target.Miss();
                }
            }
            
        }

        private static void AttackAllTargets()
        {
            List<Target> targets = FetchAllTargets();
            Random random = new Random();

            foreach (Target target in targets)
            {
                if (target.Status) continue;

                AttackTarget(target, random);

                string report = target.Status ? $"{target.Name} was destroyed" : $"{target.Name} was missed";

                WriteLine(report);
            }

            WriteLine("");
            WriteLine("<Press any key to continue>");
            ReadKey(true);

            context.SaveChanges();
        }

        private static void PrintAllTargets()
        {
            WriteLine("Name".PadRight(15) + "Status".PadRight(15) + "Attacked at");
            WriteLine("".PadRight(40,'='));

            List<Target> targetList = FetchAllTargets();

            foreach (Target target in targetList)
            {
                string status = target.Status ? "Destroyed" : "Intact";

                if(target.AttackedAt != null)
                {
                    WriteLine($"{target.Name}".PadRight(15) + $"{status}".PadRight(15) + $"{target.AttackedAt}");
                }
                else
                {
                    WriteLine($"{target.Name}".PadRight(15) + $"{status}".PadRight(15) + "Attack not initiated");
                }
            }

            WriteLine("");
            WriteLine("<Press any key to continue>");
            ReadKey(true);
        }

        private static  List<Target> FetchAllTargets()
        {
            return context.Target.ToList();
        }
    }
}
