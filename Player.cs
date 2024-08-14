using System.Collections.Generic;
using System.Diagnostics;

namespace TheWar
{
    public class Player
    {
        public List<NPC> Army;
        public List<NPC> ListOfClasses;
        
        public Player(List<NPC> army, List<NPC> listOfClasses)
        {
            Army = army;
            ListOfClasses = listOfClasses;
        }

        public void ChoiceWarrior(int idWarrior)
        {
            // NPC newSoldier = new NPC(ListOfClasses[idWarrior - 1].Name, ListOfClasses[idWarrior - 1].Health, ListOfClasses[idWarrior - 1].Armor, ListOfClasses[idWarrior - 1].Damage);
            // Army.Add(newSoldier);
            
            if (ListOfClasses[idWarrior - 1].Name == "Private V")
            {
                Private privateV = new Private(ListOfClasses[idWarrior - 1].Name, ListOfClasses[idWarrior - 1].Health, ListOfClasses[idWarrior - 1].Armor, ListOfClasses[idWarrior - 1].Damage, false);
                Army.Add(privateV);
            }
            else if (ListOfClasses[idWarrior - 1].Name == "Sergeant S")
            {
                Sergeant sergeantS = new Sergeant(ListOfClasses[idWarrior - 1].Name, ListOfClasses[idWarrior - 1].Health, ListOfClasses[idWarrior - 1].Armor, ListOfClasses[idWarrior - 1].Damage, false);
                Army.Add(sergeantS);
            }
            else if (ListOfClasses[idWarrior - 1].Name == "Major M")
            {
                Major majorM = new Major(ListOfClasses[idWarrior - 1].Name, ListOfClasses[idWarrior - 1].Health, ListOfClasses[idWarrior - 1].Armor, ListOfClasses[idWarrior - 1].Damage, false);
                Army.Add(majorM);
            }
            else if (ListOfClasses[idWarrior - 1].Name == "Colonel G")
            {
                Colonel colonelG = new Colonel(ListOfClasses[idWarrior - 1].Name, ListOfClasses[idWarrior - 1].Health, ListOfClasses[idWarrior - 1].Armor, ListOfClasses[idWarrior - 1].Damage, false);
                Army.Add(colonelG);
            }
        }
    }
}