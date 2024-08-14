namespace TheWar
{
    public class Colonel : NPC
    {
        public Colonel(string name ,int health, int armor, int damage, bool death) : base(name ,health, armor, damage, death)
        {
            IsDead = death;
            Name = name;
            Health = health;
            Armor = armor;
            Damage = damage;
        }
        
        public override void Attack(NPC newNpc)
        {
            newNpc.Health = newNpc.Health + newNpc.Armor - Damage;
            newNpc.Armor = 0;
        }
        
        public override void Death()
        {
            IsDead = true;
        }
    }
}