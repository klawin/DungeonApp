using DungeonLibrary;
using OpponentLibrary;
using System;
using System.Threading;

namespace Dungeon
{
    class Charmed
    {
        static void Main(string[] args)
        {
            Console.Title = "~~~CHARMED~~~";
            Console.WriteLine("Welcome to the Halliwell Manor! Can you keep up with the Charmed Ones?\n");

            Console.WriteLine("Create your player");
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine().ToUpper();
            Console.Clear();
            Console.WriteLine($"Welcome to the Halliwell Manor, {playerName}!\n");
            
            CreatureType creatureType = new CreatureType();

            bool exit = false;
            do//PLAYER CHOOSES CREATURE TYPE
            {
                Console.WriteLine("Choose a creature type:\n" +
                    "1) Witch\n" + 
                    "2) Demon\n");
                    
                ConsoleKey userChoice = Console.ReadKey(true).Key;

                Console.Clear();

                switch (userChoice)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        creatureType = CreatureType.Witch;
                        exit = true;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        creatureType = CreatureType.Demon;
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please use a number to select a menu item.\n");
                        break;
                }
            } while (!exit);

            #region Special Attacks
            //TODO fix attack mechanism so player can choose which special attack they'd like to use.

            Attack[] specialAttack = new Attack[4];
            specialAttack[0] = new Attack("Strike", 5, 10, 10, true);
            specialAttack[1] = new Attack("Molecular Combustion", 10, 25, 40, true);
            specialAttack[2] = new Attack("Fireball", 10, 35, 25, false);

            #endregion
            Attack playerAttack = specialAttack[0];

            Player player = new Player(playerName, 75, 20, 100, 100, creatureType, playerAttack);
            int score = 0;

            exit = false;
            do
            {
                Console.WriteLine(GetScene());
                              
                #region Demons/Warlocks
                
                Demon demon = new Demon();

                Demon belthazor = new Demon("Belthazor", 50, 50, 50, 10, 5, 15, "Beware of this Demonic Soldier of Fortune. Both powerful and dangerous, he has destroyed countless witches, \ninnocents, and demons.\n", true);

                Demon barbas = new Demon("Barbas", 50, 50, 50, 10, 5, 15, "The Demon of Fear... uses your greatest fears against you, a master of illusion!\n", true);

                Demon zankou = new Demon("Zankou", 50, 50, 50, 10, 5, 15, "An ancient and extremely powerful demon... a threat to all things Good and feared even by his own kind.\n", true);

                Demon banshee = new Demon("Banshee", 50, 50, 45, 5, 1, 10, "A rare breed of demon... armed with a deafening high-pitched scream and stiletto sharp claws.\n", true);

                Demon shax = new Demon("Shax", 50, 50, 45, 5, 3, 10, "The Source of all Evil's personal demonic assassin... Beware his powerful manipulation of the wind!\n", true);

                Warlock warlock = new Warlock();

                Warlock hannahWebster = new Warlock("Hannah Webster", 45, 45, 45, 5, 1, 10, "Rex Buckland's evil office assistant!\n", true);

                Warlock anton = new Warlock("Anton", 45, 45, 45, 5, 1, 10, "A powerful warlock from the past.\n", true);

                Warlock rexBuckland = new Warlock("Rex Buckland", 45, 45, 45, 5, 1, 10, "Peru's boss at Buckland Auction House, sent by the Source of all Evil to destroy the Charmed Ones.\n", true);

                Opponent[] opponents = { demon, demon, demon, warlock, warlock, warlock, belthazor, barbas, zankou, banshee, shax, hannahWebster, anton, rexBuckland };

                Random rand = new Random();
                int randomNumber = rand.Next(opponents.Length);

                Opponent opponent = opponents[randomNumber];

                Console.WriteLine("\nHere you encounter " + opponent.Name + "!\n");

                Console.WriteLine(opponent.Description);

                Thread.Sleep(500);

                #endregion

                bool reload = false;
                do
                {
                    #region menu

                    Console.WriteLine("\nPlease choose an action:\n\n" +
                        "A) Attack\n" +
                        "C) Change Power\n" +
                        "R) Run\n" +
                        "P) Player Stats\n" +
                        "O) Opponent Stats\n" +
                        "X) Exit Game");
                    ConsoleKey userInput = Console.ReadKey(true).Key;

                    Console.Clear();

                    switch (userInput)
                    {
                        case ConsoleKey.A://Attack - TODO if a player wins
                            Combat.DoBattle(player, opponent);
                            if (opponent.Life <= 0)//Opponent Dies
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You killed {0}!\n", opponent.Name);
                                Console.ResetColor();
                                score++;

                                #region loot menu
                                Console.WriteLine("Please choose an option: \n\n" +
                                    "1) +5 hp\n" +
                                    "2) extra point\n");
                                ConsoleKey loot = Console.ReadKey(true).Key;
                                switch (loot)
                                {
                                    case ConsoleKey.D1:
                                    case ConsoleKey.NumPad1:
                                        player.Life += 5;
                                        break;
                                    case ConsoleKey.D2:
                                    case ConsoleKey.NumPad2:
                                        score++;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid input... no loot for you");
                                        break;
                                }
                                Console.WriteLine("Life: " + player.Life + "/" + player.MaxLife);
                                Console.WriteLine("Score: " + score + "\n");
                                Console.WriteLine("Press ENTER to continue");
                                Console.ReadLine();
                                #endregion

                                Console.Clear();
                                reload = true;
                            }
                            break;
                        case ConsoleKey.C://Change Power
                            Console.WriteLine("Choose a new attack:\n" +
                                "1) Strike!\n" +
                                "2) Blow it up!\n" +
                                "3) Throw fireball!\n");
                            ConsoleKey power = Console.ReadKey(true).Key;
                            switch (power)
                            {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                    playerAttack = specialAttack[0];
                                    Console.Clear();
                                    Console.WriteLine("Equipped Power: Strike");
                                    Combat.DoBattle(player, opponent);
                                    if (opponent.Life <= 0)//Opponent Dies
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("You killed {0}!\n", opponent.Name);
                                        Console.ResetColor();
                                        score++;

                                        #region loot menu
                                        Console.WriteLine("Please choose an option: \n\n" +
                                            "1) +5 hp\n" +
                                            "2) extra point\n");
                                        ConsoleKey loot = Console.ReadKey(true).Key;
                                        switch (loot)
                                        {
                                            case ConsoleKey.D1:
                                            case ConsoleKey.NumPad1:
                                                player.Life += 5;
                                                break;
                                            case ConsoleKey.D2:
                                            case ConsoleKey.NumPad2:
                                                score++;
                                                break;
                                            default:
                                                Console.WriteLine("Invalid input... no loot for you");
                                                break;
                                        }
                                        Console.WriteLine("Life: " + player.Life + "/" + player.MaxLife);
                                        Console.WriteLine("Score: " + score + "\n");
                                        Console.WriteLine("Press ENTER to continue");
                                        Console.ReadLine();
                                        #endregion

                                        Console.Clear();
                                        reload = true;
                                    }
                                    break;
                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    playerAttack = specialAttack[1];
                                    Console.Clear();
                                    Console.WriteLine("Equipped Power: Molecular Combustion");
                                    Combat.DoBattle(player, opponent);
                                    if (opponent.Life <= 0)//Opponent Dies
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("You killed {0}!\n", opponent.Name);
                                        Console.ResetColor();
                                        score++;

                                        #region loot menu
                                        Console.WriteLine("Please choose an option: \n\n" +
                                            "1) +5 hp\n" +
                                            "2) extra point\n");
                                        ConsoleKey loot = Console.ReadKey(true).Key;
                                        switch (loot)
                                        {
                                            case ConsoleKey.D1:
                                            case ConsoleKey.NumPad1:
                                                player.Life += 5;
                                                break;
                                            case ConsoleKey.D2:
                                            case ConsoleKey.NumPad2:
                                                score++;
                                                break;
                                            default:
                                                Console.WriteLine("Invalid input... no loot for you");
                                                break;
                                        }
                                        Console.WriteLine("Life: " + player.Life + "/" + player.MaxLife);
                                        Console.WriteLine("Score: " + score + "\n");
                                        Console.WriteLine("Press ENTER to continue");
                                        Console.ReadLine();
                                        #endregion

                                        Console.Clear();
                                        reload = true;
                                    }
                                    break;
                                case ConsoleKey.D3:
                                case ConsoleKey.NumPad3:
                                    playerAttack = specialAttack[2];
                                    Console.Clear();
                                    Console.WriteLine("Equipped Power: Fireball");
                                    Combat.DoBattle(player, opponent);
                                    if (opponent.Life <= 0)//Opponent Dies
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("You killed {0}!\n", opponent.Name);
                                        Console.ResetColor();
                                        score++;

                                        #region loot menu
                                        Console.WriteLine("Please choose an option: \n\n" +
                                            "1) +5 hp\n" +
                                            "2) extra point\n");
                                        ConsoleKey loot = Console.ReadKey(true).Key;
                                        switch (loot)
                                        {
                                            case ConsoleKey.D1:
                                            case ConsoleKey.NumPad1:
                                                player.Life += 5;
                                                break;
                                            case ConsoleKey.D2:
                                            case ConsoleKey.NumPad2:
                                                score++;
                                                break;
                                            default:
                                                Console.WriteLine("Invalid input... no loot for you");
                                                break;
                                        }
                                        Console.WriteLine("Life: " + player.Life + "/" + player.MaxLife);
                                        Console.WriteLine("Score: " + score + "\n");
                                        Console.WriteLine("Press ENTER to continue");
                                        Console.ReadLine();
                                        #endregion

                                        Console.Clear();
                                        reload = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            Console.WriteLine();
                            break;
                        case ConsoleKey.R://Run Away
                            Console.WriteLine("Hurry! Run!\n");
                            Console.WriteLine($"{opponent.Name} attacks you as you flee!\n");
                            Combat.DoAttack(opponent, player);//Attack of opportunity
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            Console.Clear();
                            reload = true;
                            break;
                        case ConsoleKey.P://Player Stats
                            Console.WriteLine("Player Info\n");
                            Console.WriteLine(player);
                            Console.WriteLine("Score: " + score + "\n");
                            break;
                        case ConsoleKey.O://Opponent Stats
                            Console.WriteLine("Opponent Info");
                            Console.WriteLine(opponent);
                            break;
                        case ConsoleKey.E:
                        case ConsoleKey.X:
                            Console.WriteLine("Game over. You failed to keep up with the Halliwell sisters.");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid input. Try again.");
                            break;
                    }
                    #endregion

                    if (player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("~~~YOU ARE DEAD~~~");
                        Console.ResetColor();
                        exit = true;
                    }
                } while (!reload && !exit);
            } while (!exit);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You defeated " + score + " opponent" + ((score == 1)? "!" : "s!"));

        }//end Main()

        private static string GetScene()
        {
            string[] scenes =
            {
                "You enter the underworld ... a wave of darkness overcomes you. What is that?!",
                "You enter the Magical Forest ... what was that over there in the trees?!",
                "Incoming!!! Someone's about to attack the Manor!",
                "An attack at P3?! C'mon now!!",
                "You arrive at Buckland Auction House.... Who do we have here?",
                "Welcome to the Bay Mirror! Look out there's someone following you!",
                "You get to the top of the Golden Gate Bridge! Think you're safe? Think again!",
                "What are we doing at the Mausoleum? You know this is where Cole and his crew like to hang out!",
                "Welcome to Quake! How may I - wait a minute... AHHHHH!"
            };
            Random random = new Random();

            int indexNbr = random.Next(scenes.Length);

            string scene = scenes[indexNbr];

            return scene;
        }

    }//end class
}//end namespace
