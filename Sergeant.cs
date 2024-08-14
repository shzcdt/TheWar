using System;

namespace TheWar
{
    public class Sergeant : NPC
    {
        public Sergeant(string name ,int health, int armor, int damage, bool death) : base(name ,health, armor, damage, death)
        {
            IsDead = death;
            Name = name;
            Health = health;
            Armor = armor;
            Damage = damage;
        }
        
        public override void Attack(NPC newNpc)
        {
            Random rnd = new Random();
            Damage *= rnd.Next(1, 3);
            newNpc.Health = newNpc.Health + newNpc.Armor - Damage;
            newNpc.Armor = 0;
        }
        
        public override void Death()
        {
            IsDead = true;
        }
    }
}