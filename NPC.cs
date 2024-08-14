namespace TheWar
{
    public class NPC
    {
        public string Name;
        public int Health;
        public int Armor;
        public int Damage;
        public bool IsDead;

        public NPC(string name ,int health, int armor, int damage, bool death)
        {
            IsDead = death;
            Name = name;
            Health = health;
            Armor = armor;
            Damage = damage;
        }
        public virtual void Attack(NPC newNpc)
        {
            newNpc.Health = newNpc.Health + newNpc.Armor - Damage;
            newNpc.Armor = 0;
        }

        public virtual void Death()
        {
            IsDead = true;
        }
    }
}