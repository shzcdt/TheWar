using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace TheWar
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Private privateV = new Private("Private V", 10, 10, 15,  false);
            Sergeant sergeantS = new Sergeant("Sergeant S", 10, 10, 15, false);
            Major majorM = new Major("Major M", 10, 10, 15, false);
            Colonel colonelG = new Colonel("Colonel G", 10, 10, 15, false);

            NPC NpcInList;
            // Creating a troop selection list
            List<NPC> npc = new List<NPC>();
            npc.Add(privateV);
            npc.Add(sergeantS);
            npc.Add(majorM);
            npc.Add(colonelG);

            
            List<NPC> armyPlayer = new List<NPC>();
            List<NPC> armyOpponent = new List<NPC>();
            Player player = new Player(armyPlayer, npc);
            Opponent opponent = new Opponent(armyOpponent, npc);
            
            int NumberOfWarsPlayer;
            int NumberOfWarsOpponent;

            Random rnd = new Random();
            
            Console.WriteLine("Player1 Choose the number of warriors in the platoon: ");
            NumberOfWarsPlayer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Player2 Choose the number of warriors in the platoon: ");
            NumberOfWarsOpponent = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("For Player1: ////////////");
            for (int i = 0; i < npc.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {npc[i].Name}");
            }
            int numberOfWarsPlayer = NumberOfWarsPlayer;
            Console.WriteLine("Choose your warriors from the list");
            for (int i = 0; i < NumberOfWarsPlayer + 1; i++)
            {
                Console.WriteLine($"Remaining seats ({numberOfWarsPlayer})");
                if (player.Army.Count != 0)
                {
                    Console.WriteLine($"Selected wars: ");
                    for (int id = 0; id < player.Army.Count; id++)
                    {
                        Console.WriteLine($"{id + 1}) {player.Army[id].Name}");
                    }
                    Console.WriteLine();
                }
                numberOfWarsPlayer--;
                if (i  != NumberOfWarsPlayer)
                {
                    int idWarrior = Convert.ToInt32(Console.ReadLine());
                    player.ChoiceWarrior(idWarrior);
                }
            }
            
            Console.WriteLine("For Player2: ////////////");
            for (int i = 0; i < npc.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {npc[i].Name}");
            }
            Console.WriteLine("Choose your warriors from the list");
            int numberOfWarsOpponent = NumberOfWarsOpponent;
            for (int i = 0; i < NumberOfWarsOpponent + 1; i++)
            {
                Console.WriteLine($"Remaining seats ({numberOfWarsOpponent})");
                if (opponent.Army.Count != 0)
                {
                    Console.WriteLine($"Selected wars: ");
                    for (int id = 0; id < opponent.Army.Count; id++)
                    {
                        Console.WriteLine($"{id + 1}) {opponent.Army[id].Name}");
                    }
                    Console.WriteLine();
                }
                numberOfWarsOpponent--;
                if (i  != NumberOfWarsOpponent)
                {
                    int idWarrior = Convert.ToInt32(Console.ReadLine());
                    opponent.ChoiceWarrior(idWarrior);
                }
            }
            
            int countOfWarsPlayer = player.Army.Count;
            int countOfWarsOpponent = opponent.Army.Count;
            
            int index = 0;
            int motion = 1;
            while (player.Army.Count != 0 & opponent.Army.Count != 0) 
            {
                Console.WriteLine($"motion ({motion})");
                if (player.Army[index].Name == "Major M")
                {
                    if (player.Army[index].IsDead == true)
                    {
                        int RandomWarrior1;
                        int RandomWarrior2;
                        do
                        {
                            RandomWarrior1 = rnd.Next(0, countOfWarsOpponent);
                            RandomWarrior2 = rnd.Next(0, countOfWarsOpponent);
                        } while (RandomWarrior1 == RandomWarrior2 || opponent.Army[RandomWarrior1].IsDead == true || opponent.Army[RandomWarrior2].IsDead == true);

                        int rndId;
                        do
                        {
                            rndId = rnd.Next(0, player.Army.Count);
                        } while (index == rndId || player.Army[rndId].IsDead == true);
                        
                        player.Army[rndId].Attack(opponent.Army[RandomWarrior1]); 
                        player.Army[rndId].Attack(opponent.Army[RandomWarrior2]);
                        
                        Console.WriteLine($"Attacks [Player] ({player.Army[rndId].Name}) XP:({player.Army[rndId].Health}) AR:({player.Army[rndId].Armor}) Damage:({player.Army[rndId].Damage})");
                        
                        if (opponent.Army[RandomWarrior1].Health <= 0)
                        {
                            Console.WriteLine($"Death ({opponent.Army[RandomWarrior1].Name}) XP:({opponent.Army[RandomWarrior1].Health}) AR:({opponent.Army[RandomWarrior1].Armor}) Damage:({opponent.Army[RandomWarrior1].Damage})");
                            opponent.Army[RandomWarrior1].Death();
                        }
                        else
                        {
                            Console.WriteLine($"Received ({opponent.Army[RandomWarrior1].Name}) XP:({opponent.Army[RandomWarrior1].Health}) AR:({opponent.Army[RandomWarrior1].Armor}) Damage:({opponent.Army[RandomWarrior1].Damage})");
                        }
                        if (opponent.Army[RandomWarrior2].Health <= 0)
                        {
                            Console.WriteLine($"Death ({opponent.Army[RandomWarrior2].Name}) XP:({opponent.Army[RandomWarrior2].Health}) AR:({opponent.Army[RandomWarrior2].Armor}) Damage:({opponent.Army[RandomWarrior2].Damage})");
                            opponent.Army[RandomWarrior2].Death();
                        }
                        else
                        {
                            Console.WriteLine($"Received ({opponent.Army[RandomWarrior2].Name}) XP:({opponent.Army[RandomWarrior2].Health}) AR:({opponent.Army[RandomWarrior2].Armor}) Damage:({opponent.Army[RandomWarrior2].Damage})");
                        }
                    }
                    else
                    {
                        int RandomWarrior1;
                        int RandomWarrior2;
                        do
                        {
                            RandomWarrior1 = rnd.Next(0, countOfWarsOpponent);
                            RandomWarrior2 = rnd.Next(0, countOfWarsOpponent);
                        } while (RandomWarrior1 == RandomWarrior2 || opponent.Army[RandomWarrior1].IsDead == true || opponent.Army[RandomWarrior2].IsDead == true);

                        player.Army[index].Attack(opponent.Army[RandomWarrior1]);
                        player.Army[index].Attack(opponent.Army[RandomWarrior2]);

                        Console.WriteLine(
                            $"Attacks [Player] ({player.Army[index].Name}) XP:({player.Army[index].Health}) AR:({player.Army[index].Armor}) Damage:({player.Army[index].Damage})");

                        if (opponent.Army[RandomWarrior1].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({opponent.Army[RandomWarrior1].Name}) XP:({opponent.Army[RandomWarrior1].Health}) AR:({opponent.Army[RandomWarrior1].Armor}) Damage:({opponent.Army[RandomWarrior1].Damage})");
                            opponent.Army[RandomWarrior1].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({opponent.Army[RandomWarrior1].Name}) XP:({opponent.Army[RandomWarrior1].Health}) AR:({opponent.Army[RandomWarrior1].Armor}) Damage:({opponent.Army[RandomWarrior1].Damage})");
                        }

                        if (opponent.Army[RandomWarrior2].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({opponent.Army[RandomWarrior2].Name}) XP:({opponent.Army[RandomWarrior2].Health}) AR:({opponent.Army[RandomWarrior2].Armor}) Damage:({opponent.Army[RandomWarrior2].Damage})");
                            opponent.Army[RandomWarrior2].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({opponent.Army[RandomWarrior2].Name}) XP:({opponent.Army[RandomWarrior2].Health}) AR:({opponent.Army[RandomWarrior2].Armor}) Damage:({opponent.Army[RandomWarrior2].Damage})");
                        }
                    }

                }
                else if (player.Army[index].Name == "Colonel G")
                {
                    if (player.Army[index].IsDead == true)
                    {
                        int RandomWarrior1;
                        int RandomWarrior2;
                        do
                        {
                            RandomWarrior1 = rnd.Next(0, countOfWarsOpponent);
                            RandomWarrior2 = rnd.Next(0, countOfWarsOpponent);
                        } while (RandomWarrior1 == RandomWarrior2 || opponent.Army[RandomWarrior1].IsDead == true || opponent.Army[RandomWarrior2].IsDead == true);

                        int RandomChance = rnd.Next(1, 3);
                        int rndId;
                        do
                        {
                            rndId = rnd.Next(0, player.Army.Count);
                        } while (index == rndId || player.Army[rndId].IsDead == true);

                        player.Army[rndId].Attack(opponent.Army[RandomWarrior1]);
                        player.Army[rndId].Attack(opponent.Army[RandomWarrior2]);

                        Console.WriteLine(
                            $"Attacks [Player] ({player.Army[rndId].Name}) XP:({player.Army[rndId].Health}) AR:({player.Army[rndId].Armor}) Damage:({player.Army[rndId].Damage})");

                        if (RandomChance == 1)
                        {
                            player.Army[rndId].Attack(opponent.Army[RandomWarrior1]);
                        }
                        else
                        {
                            player.Army[rndId].Attack(opponent.Army[RandomWarrior2]);
                        }

                        if (opponent.Army[RandomWarrior1].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({opponent.Army[RandomWarrior1].Name}) XP:({opponent.Army[RandomWarrior1].Health}) AR:({opponent.Army[RandomWarrior1].Armor}) Damage:({opponent.Army[RandomWarrior1].Damage})");
                            opponent.Army[RandomWarrior1].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({opponent.Army[RandomWarrior1].Name}) XP:({opponent.Army[RandomWarrior1].Health}) AR:({opponent.Army[RandomWarrior1].Armor}) Damage:({opponent.Army[RandomWarrior1].Damage})");
                        }

                        if (opponent.Army[RandomWarrior2].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({opponent.Army[RandomWarrior2].Name}) XP:({opponent.Army[RandomWarrior2].Health}) AR:({opponent.Army[RandomWarrior2].Armor}) Damage:({opponent.Army[RandomWarrior2].Damage})");
                            opponent.Army[RandomWarrior2].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({opponent.Army[RandomWarrior2].Name}) XP:({opponent.Army[RandomWarrior2].Health}) AR:({opponent.Army[RandomWarrior2].Armor}) Damage:({opponent.Army[RandomWarrior2].Damage})");
                        }
                    }
                    else
                    {
                        int RandomWarrior1;
                        int RandomWarrior2;
                        do
                        {
                            RandomWarrior1 = rnd.Next(0, countOfWarsOpponent);
                            RandomWarrior2 = rnd.Next(0, countOfWarsOpponent);
                        } while (RandomWarrior1 == RandomWarrior2 || opponent.Army[RandomWarrior1].IsDead == true || opponent.Army[RandomWarrior2].IsDead == true);

                        int RandomChance = rnd.Next(1, 3);
                       
                        player.Army[index].Attack(opponent.Army[RandomWarrior1]);    
                        player.Army[index].Attack(opponent.Army[RandomWarrior2]);
                        
                        Console.WriteLine($"Attacks [Player] ({player.Army[index].Name}) XP:({player.Army[index].Health}) AR:({player.Army[index].Armor}) Damage:({player.Army[index].Damage})");
                        
                        if (RandomChance == 1)
                        {
                            player.Army[index].Attack(opponent.Army[RandomWarrior1]); 
                        }
                        else
                        {
                            player.Army[index].Attack(opponent.Army[RandomWarrior2]);
                        }
                        
                        if (opponent.Army[RandomWarrior1].Health <= 0)
                        {
                            Console.WriteLine($"Death ({opponent.Army[RandomWarrior1].Name}) XP:({opponent.Army[RandomWarrior1].Health}) AR:({opponent.Army[RandomWarrior1].Armor}) Damage:({opponent.Army[RandomWarrior1].Damage})");
                            opponent.Army[RandomWarrior1].Death();
                        }
                        else
                        {
                            Console.WriteLine($"Received ({opponent.Army[RandomWarrior1].Name}) XP:({opponent.Army[RandomWarrior1].Health}) AR:({opponent.Army[RandomWarrior1].Armor}) Damage:({opponent.Army[RandomWarrior1].Damage})");
                        }
                        if (opponent.Army[RandomWarrior2].Health <= 0)
                        {
                            Console.WriteLine($"Death ({opponent.Army[RandomWarrior2].Name}) XP:({opponent.Army[RandomWarrior2].Health}) AR:({opponent.Army[RandomWarrior2].Armor}) Damage:({opponent.Army[RandomWarrior2].Damage})");
                            opponent.Army[RandomWarrior2].Death();
                        }
                        else
                        {
                            Console.WriteLine($"Received ({opponent.Army[RandomWarrior2].Name}) XP:({opponent.Army[RandomWarrior2].Health}) AR:({opponent.Army[RandomWarrior2].Armor}) Damage:({opponent.Army[RandomWarrior2].Damage})");
                        }
                    }

                }
                else
                {
                    if (player.Army[index].IsDead == true)
                    {
                        int RandomWarrior;
                        do
                        {
                            RandomWarrior = rnd.Next(0, countOfWarsOpponent);
                        } while (opponent.Army[RandomWarrior].IsDead == true);
                        int rndId;
                        do
                        {
                            rndId = rnd.Next(0, player.Army.Count);
                        } while (index == rndId || player.Army[rndId].IsDead == true);

                        player.Army[rndId].Attack(opponent.Army[RandomWarrior]);

                        Console.WriteLine(
                            $"Attacks [Player] ({player.Army[rndId].Name}) XP:({player.Army[rndId].Health}) AR:({player.Army[rndId].Armor}) Damage:({player.Army[rndId].Damage})");

                        if (opponent.Army[RandomWarrior].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({opponent.Army[RandomWarrior].Name}) XP:({opponent.Army[RandomWarrior].Health}) AR:({opponent.Army[RandomWarrior].Armor}) Damage:({opponent.Army[RandomWarrior].Damage})");
                            opponent.Army[RandomWarrior].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({opponent.Army[RandomWarrior].Name}) XP:({opponent.Army[RandomWarrior].Health}) AR:({opponent.Army[RandomWarrior].Armor}) Damage:({opponent.Army[RandomWarrior].Damage})");
                        }
                    }
                    else
                    {
                        int RandomWarrior;
                        do
                        {
                            RandomWarrior = rnd.Next(0, countOfWarsOpponent);
                        } while (opponent.Army[RandomWarrior].IsDead == true);
                        
                        player.Army[index].Attack(opponent.Army[RandomWarrior]);
                    
                        Console.WriteLine(
                            $"Attacks [Player] ({player.Army[index].Name}) XP:({player.Army[index].Health}) AR:({player.Army[index].Armor}) Damage:({player.Army[index].Damage})");

                        if (opponent.Army[RandomWarrior].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({opponent.Army[RandomWarrior].Name}) XP:({opponent.Army[RandomWarrior].Health}) AR:({opponent.Army[RandomWarrior].Armor}) Damage:({opponent.Army[RandomWarrior].Damage})");
                            opponent.Army[RandomWarrior].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({opponent.Army[RandomWarrior].Name}) XP:({opponent.Army[RandomWarrior].Health}) AR:({opponent.Army[RandomWarrior].Armor}) Damage:({opponent.Army[RandomWarrior].Damage})");
                        }
                    }
                }
               
                if (opponent.Army[index].Name == "Major M")
                {
                    if (opponent.Army[index].IsDead == true)
                    {
                        int RandomWarrior1;
                        int RandomWarrior2;
                        do
                        {
                            RandomWarrior1 = rnd.Next(0, countOfWarsPlayer);
                            RandomWarrior2 = rnd.Next(0, countOfWarsPlayer);
                        } while (RandomWarrior2 == RandomWarrior1 || player.Army[RandomWarrior1].IsDead == true || player.Army[RandomWarrior2].IsDead == true );
                        int rndId;
                        do
                        {
                            rndId = rnd.Next(0, opponent.Army.Count);
                        } while (index == rndId || opponent.Army[rndId].IsDead == true);

                        opponent.Army[rndId].Attack(player.Army[RandomWarrior1]);
                        opponent.Army[rndId].Attack(player.Army[RandomWarrior2]);
                        Console.WriteLine(
                            $"Attacks [Opponent] ({opponent.Army[rndId].Name}) XP:({opponent.Army[rndId].Health}) AR:({opponent.Army[rndId].Armor}) Damage:({opponent.Army[rndId].Damage})");
                        if (player.Army[RandomWarrior1].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({player.Army[RandomWarrior1].Name}) XP:({player.Army[RandomWarrior1].Health}) AR:({player.Army[RandomWarrior1].Armor}) Damage:({player.Army[RandomWarrior1].Damage})");
                            player.Army[RandomWarrior1].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({player.Army[RandomWarrior1].Name}) XP:({player.Army[RandomWarrior1].Health}) AR:({player.Army[RandomWarrior1].Armor}) Damage:({player.Army[RandomWarrior1].Damage})");
                        }

                        if (player.Army[RandomWarrior2].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({player.Army[RandomWarrior2].Name}) XP:({player.Army[RandomWarrior2].Health}) AR:({player.Army[RandomWarrior2].Armor}) Damage:({player.Army[RandomWarrior2].Damage})");
                            player.Army[RandomWarrior2].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({player.Army[RandomWarrior2].Name}) XP:({player.Army[RandomWarrior2].Health}) AR:({player.Army[RandomWarrior2].Armor}) Damage:({player.Army[RandomWarrior2].Damage})");
                        }
                    }
                    else
                    {
                        int RandomWarrior1;
                        int RandomWarrior2;
                        do
                        {
                            RandomWarrior1 = rnd.Next(0, countOfWarsPlayer );
                            RandomWarrior2 = rnd.Next(0, countOfWarsPlayer );
                        } while (RandomWarrior2 == RandomWarrior1 || player.Army[RandomWarrior1].IsDead == true || player.Army[RandomWarrior2].IsDead == true);

                        opponent.Army[index].Attack(player.Army[RandomWarrior1]);
                        opponent.Army[index].Attack(player.Army[RandomWarrior2]);
                        Console.WriteLine(
                            $"Attacks [Opponent] ({opponent.Army[index].Name}) XP:({opponent.Army[index].Health}) AR:({opponent.Army[index].Armor}) Damage:({opponent.Army[index].Damage})");
                        if (player.Army[RandomWarrior1].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({player.Army[RandomWarrior1].Name}) XP:({player.Army[RandomWarrior1].Health}) AR:({player.Army[RandomWarrior1].Armor}) Damage:({player.Army[RandomWarrior1].Damage})");
                            player.Army[RandomWarrior1].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({player.Army[RandomWarrior1].Name}) XP:({player.Army[RandomWarrior1].Health}) AR:({player.Army[RandomWarrior1].Armor}) Damage:({player.Army[RandomWarrior1].Damage})");
                        }

                        if (player.Army[RandomWarrior2].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({player.Army[RandomWarrior2].Name}) XP:({player.Army[RandomWarrior2].Health}) AR:({player.Army[RandomWarrior2].Armor}) Damage:({player.Army[RandomWarrior2].Damage})");
                            player.Army[RandomWarrior2].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({player.Army[RandomWarrior2].Name}) XP:({player.Army[RandomWarrior2].Health}) AR:({player.Army[RandomWarrior2].Armor}) Damage:({player.Army[RandomWarrior2].Damage})");
                        }
                    }
                }
                
                else if (opponent.Army[index].Name == "Colonel G")
                {
                    if (opponent.Army[index].IsDead == true)
                    {
                        int RandomWarrior1;
                        int RandomWarrior2;
                        do
                        {
                            RandomWarrior1 = rnd.Next(0, countOfWarsPlayer);
                            RandomWarrior2 = rnd.Next(0, countOfWarsPlayer);
                        } while (RandomWarrior2 == RandomWarrior1 || player.Army[RandomWarrior1].IsDead == true || player.Army[RandomWarrior2].IsDead == true);

                        int RandomChance = rnd.Next(1, 3);
                        int rndId;
                        do
                        {
                            rndId = rnd.Next(0, opponent.Army.Count);
                        } while (index == rndId || opponent.Army[rndId].IsDead == true);

                        opponent.Army[rndId].Attack(player.Army[RandomWarrior1]);
                        opponent.Army[rndId].Attack(player.Army[RandomWarrior2]);

                        Console.WriteLine(
                            $"Attacks [Opponent] ({opponent.Army[rndId].Name}) XP:({opponent.Army[rndId].Health}) AR:({opponent.Army[rndId].Armor}) Damage:({opponent.Army[rndId].Damage})");

                        if (RandomChance == 1)
                        {
                            opponent.Army[rndId].Attack(player.Army[RandomWarrior1]);
                        }
                        else
                        {
                            opponent.Army[rndId].Attack(player.Army[RandomWarrior2]);
                        }

                        if (player.Army[RandomWarrior1].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({player.Army[RandomWarrior1].Name}) XP:({player.Army[RandomWarrior1].Health}) AR:({player.Army[RandomWarrior1].Armor}) Damage:({player.Army[RandomWarrior1].Damage})");
                            player.Army[RandomWarrior1].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({player.Army[RandomWarrior1].Name}) XP:({player.Army[RandomWarrior1].Health}) AR:({player.Army[RandomWarrior1].Armor}) Damage:({player.Army[RandomWarrior1].Damage})");
                        }

                        if (player.Army[RandomWarrior2].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({player.Army[RandomWarrior2].Name}) XP:({player.Army[RandomWarrior2].Health}) AR:({player.Army[RandomWarrior2].Armor}) Damage:({player.Army[RandomWarrior2].Damage})");
                            player.Army[RandomWarrior2].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({player.Army[RandomWarrior2].Name}) XP:({player.Army[RandomWarrior2].Health}) AR:({player.Army[RandomWarrior2].Armor}) Damage:({player.Army[RandomWarrior2].Damage})");
                        }
                    }
                    else
                    {
                        int RandomWarrior1;
                        int RandomWarrior2;
                        do
                        {
                            RandomWarrior1 = rnd.Next(0, countOfWarsPlayer);
                            RandomWarrior2 = rnd.Next(0, countOfWarsPlayer);
                        } while (RandomWarrior2 == RandomWarrior1 || player.Army[RandomWarrior1].IsDead == true || player.Army[RandomWarrior2].IsDead == true);

                        int RandomChance = rnd.Next(1, 3);

                        opponent.Army[index].Attack(player.Army[RandomWarrior1]);
                        opponent.Army[index].Attack(player.Army[RandomWarrior2]);

                        Console.WriteLine(
                            $"Attacks [Opponent] ({opponent.Army[index].Name}) XP:({opponent.Army[index].Health}) AR:({opponent.Army[index].Armor}) Damage:({opponent.Army[index].Damage})");

                        if (RandomChance == 1)
                        {
                            opponent.Army[index].Attack(player.Army[RandomWarrior1]);
                        }
                        else
                        {
                            opponent.Army[index].Attack(player.Army[RandomWarrior2]);
                        }

                        if (player.Army[RandomWarrior1].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({player.Army[RandomWarrior1].Name}) XP:({player.Army[RandomWarrior1].Health}) AR:({player.Army[RandomWarrior1].Armor}) Damage:({player.Army[RandomWarrior1].Damage})");
                            player.Army[RandomWarrior1].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({player.Army[RandomWarrior1].Name}) XP:({player.Army[RandomWarrior1].Health}) AR:({player.Army[RandomWarrior1].Armor}) Damage:({player.Army[RandomWarrior1].Damage})");
                        }

                        if (player.Army[RandomWarrior2].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({player.Army[RandomWarrior2].Name}) XP:({player.Army[RandomWarrior2].Health}) AR:({player.Army[RandomWarrior2].Armor}) Damage:({player.Army[RandomWarrior2].Damage})");
                            player.Army[RandomWarrior2].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({player.Army[RandomWarrior2].Name}) XP:({player.Army[RandomWarrior2].Health}) AR:({player.Army[RandomWarrior2].Armor}) Damage:({player.Army[RandomWarrior2].Damage})");
                        }
                    }
                }
                else
                {
                    if (opponent.Army[index].IsDead == true)
                    {
                        int RandomWarrioR;
                        do
                        {
                            RandomWarrioR = rnd.Next(0, countOfWarsPlayer);
                        } while (opponent.Army[RandomWarrioR].IsDead == true);
                        int rndId;
                        do
                        {
                            rndId = rnd.Next(0, opponent.Army.Count);
                        } while (index == rndId || opponent.Army[rndId].IsDead == true);
                        opponent.Army[rndId].Attack(player.Army[RandomWarrioR]);

                        Console.WriteLine(
                            $"Attacks [Opponent] ({opponent.Army[rndId].Name}) XP:({opponent.Army[rndId].Health}) AR:({opponent.Army[rndId].Armor}) Damage:({opponent.Army[rndId].Damage})");

                        if (player.Army[RandomWarrioR].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({player.Army[RandomWarrioR].Name}) XP:({player.Army[RandomWarrioR].Health}) AR:({player.Army[RandomWarrioR].Armor}) Damage:({player.Army[RandomWarrioR].Damage})");
                            player.Army[RandomWarrioR].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({player.Army[RandomWarrioR].Name}) XP:({player.Army[RandomWarrioR].Health}) AR:({player.Army[RandomWarrioR].Armor}) Damage:({player.Army[RandomWarrioR].Damage})");
                        }
                    }
                    else
                    {
                        int RandomWarrioR;
                        do
                        {
                            RandomWarrioR = rnd.Next(0, countOfWarsPlayer);
                        } while (opponent.Army[RandomWarrioR].IsDead == true);
                        opponent.Army[index].Attack(player.Army[RandomWarrioR]);

                        Console.WriteLine(
                            $"Attacks [Opponent] ({opponent.Army[index].Name}) XP:({opponent.Army[index].Health}) AR:({opponent.Army[index].Armor}) Damage:({opponent.Army[index].Damage})");

                        if (player.Army[RandomWarrioR].Health <= 0)
                        {
                            Console.WriteLine(
                                $"Death ({player.Army[RandomWarrioR].Name}) XP:({player.Army[RandomWarrioR].Health}) AR:({player.Army[RandomWarrioR].Armor}) Damage:({player.Army[RandomWarrioR].Damage})");
                            player.Army[RandomWarrioR].Death();
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Received ({player.Army[RandomWarrioR].Name}) XP:({player.Army[RandomWarrioR].Health}) AR:({player.Army[RandomWarrioR].Armor}) Damage:({player.Army[RandomWarrioR].Damage})");
                        }
                    }
                }
                Console.WriteLine($"Wars after this move ");
                Console.WriteLine("////////////////////////////////////////////////////");
                Console.WriteLine("Player: ");
                for (int id = 0; id < player.Army.Count; id++)
                {
                    if (player.Army[id].IsDead != true)
                    {
                        Console.WriteLine($"{id + 1}) {player.Army[id].Name}");
                    }
                }
                Console.WriteLine("////////////////////////////////////////////////////");
                Console.WriteLine("Opponent: ");
                for (int id = 0; id < opponent.Army.Count; id++)
                {
                    if (opponent.Army[id].IsDead != true)
                    {
                        Console.WriteLine($"{id + 1}) {opponent.Army[id].Name}");
                    }
                }
                Console.WriteLine("////////////////////////////////////////////////////");
                int MinCount;
                MinCount = Math.Min(player.Army.Count, opponent.Army.Count);
                index = rnd.Next(0, MinCount); 
                motion++;
            }
            
        }
    }
}