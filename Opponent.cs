using System.Collections.Generic;

namespace TheWar
{
    public class Opponent
    {
        public List<NPC> Army;
        public List<NPC> ListOfClasses;
        public Opponent(List<NPC> army,List<NPC> listOfClasses)
        {
            Army = army;
            ListOfClasses = listOfClasses;
        }
        
        public void ChoiceWarrior(int idWarrior)
        {
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