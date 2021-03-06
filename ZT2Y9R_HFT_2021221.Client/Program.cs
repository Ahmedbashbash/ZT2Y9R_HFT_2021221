using ConsoleTools;
using System;
using ZT2Y9R_HFT_2021221.Models;


namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            RestService rest = new RestService("http://localhost:5555");

            var Club = new ConsoleMenu()
                .Add("Create Club", () => CreateClub(rest))                
                .Add("Get Club", () => GetClub(rest))               
                .Add("Go back to the previes menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = " --> ";
                    config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
                });



            var Coach = new ConsoleMenu()
                .Add("Add Coach", () => CreateCoach(rest))
                .Add("Get Coach", () => GetCoach(rest))
                .Add("Go back to the previes menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = " --> ";
                    config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
                });



            var Player = new ConsoleMenu()
                .Add("Add Player", () => CreatePlayer(rest))
                .Add("Get Player", () => GetPlayer(rest))
                .Add("Go back to the previes menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = " --> ";
                    config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
                });



            var BusinessManager = new ConsoleMenu()
                .Add("Add Business Manager", () => CreateBusinessManager(rest))
                .Add("Get Business Manager", () => GetBusinessManager(rest))
                .Add("Go back to the previes menu", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = " --> ";
                    config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
                });




            var crud = new ConsoleMenu()
               .Add("Club", () => Club.Show())
               .Add("Player", ()=> Player.Show())
               .Add("Coach",()=>Coach.Show())
               .Add("Business Manager", ()=> BusinessManager.Show())

               .Add("Go back to previous menu", ConsoleMenu.Close)
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
               });




            var menu = new ConsoleMenu()
                 .Add("CRUD METHODS", () => crud.Show())
                 .Add("Exit from the application", ConsoleMenu.Close)
                 .Configure(config =>
                 {
                     config.Selector = "--> ";
                     config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
                     config.EnableFilter = true;
                     config.Title = "Main menu";
                     //config.EnableWriteTitle = true;
                     config.EnableBreadcrumb = true;
                 });
            menu.Show();
        }

        private static void CreateClub(RestService rest)
        {
            Console.WriteLine(".....Creating new club.....");
            Console.WriteLine("\n Give the name of club");
            string name = Console.ReadLine();
            Console.WriteLine("\n Give the Number Of Trophies");
            int NumberOfTrophies = int.Parse(Console.ReadLine());
            rest.Post(new Clubs
            {
                Name = name,
                NumberOfTrophies = NumberOfTrophies
            }, "club");
            Console.WriteLine("Club is created");
            Console.ReadKey();
        }
        private static void GetClub(RestService rest)
        {
            try
            {
                Console.WriteLine(".....List all clubs.....");
                var serv = rest.Get<Clubs>("Club");
                serv.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine("\n Press enter to search");
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        private static void CreatePlayer(RestService rest)
        {
            Console.WriteLine(".....Adding new player.....");
            Console.WriteLine("\n Give the name of player");
            string name = Console.ReadLine();
            Console.WriteLine("\n Give the age of the player");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("\n Give the position of player");
            string position = Console.ReadLine();
            Console.WriteLine("\n Give the salary of the player");
            int salary = int.Parse(Console.ReadLine());
            Console.WriteLine("\n what is the id of the player's club");
            int ClubId = int.Parse(Console.ReadLine());
            Console.WriteLine("\n what is the id of the player's business manager");
            int BusinessManagersId = int.Parse(Console.ReadLine());
            rest.Post(new Players
            {
                Name = name,
                age = age,
                Position =position,
                PlayerSalary= salary,
                BusinessManagersId= BusinessManagersId,
                ClubId= ClubId
                
            }, "player"); 
            Console.WriteLine("Player is added");
            Console.ReadKey();
        }
        private static void GetPlayer(RestService rest)
        {
            try
            {
                Console.WriteLine(".....List all players.....");
                var serv = rest.Get<Players>("Player");
                serv.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine("\n Press enter to search");
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        private static void CreateBusinessManager(RestService rest)
        {
            Console.WriteLine(".....Adding new business manager.....");
            Console.WriteLine("\n Give the name of business manager");
            string name = Console.ReadLine();
            Console.WriteLine("\n Give the age of the business manager");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("\n Give the salary of the business manager");
            int salary = int.Parse(Console.ReadLine());
            rest.Post(new BusinessManagers
            {
                name = name,
                age = age,
                salary = salary

            }, "Business Manager");
            Console.WriteLine("Business manager is added");
            Console.ReadKey();
        }

        private static void GetBusinessManager(RestService rest)
        {
            try
            {
                Console.WriteLine(".....List all Business Managers.....");
                var serv = rest.Get<BusinessManagers>("Business Manager");
                serv.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine("\n Press enter to search");
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        private static void CreateCoach(RestService rest)
        {
            Console.WriteLine(".....Adding new Coach.....");
            Console.WriteLine("\n Give the name of Coach");
            string name = Console.ReadLine();
            Console.WriteLine("\n Give the age of the Coach");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("\n Give the salary of the Coach");
            int salary = int.Parse(Console.ReadLine());
            Console.WriteLine("\n what is the id of the Coach's club");
            int ClubId = int.Parse(Console.ReadLine());
            rest.Post(new Coaches
            {
                Name = name,
                age = age,
                CoachSalary = salary,
                ClubId=ClubId,
                CoachHireDate= DateTime.Today

            }, "Coach");
            Console.WriteLine("Coach is added");
            Console.ReadKey();
        }

        private static void GetCoach(RestService rest)
        {
            try
            {
                Console.WriteLine(".....List all Coaches.....");
                var serv = rest.Get<Coaches>("Coach");
                serv.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine("\n Press enter to search");
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
    }
}
