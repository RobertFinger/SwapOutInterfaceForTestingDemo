using SwapOutInterfaceForTestingDemo.Enums;

namespace SwapOutInterfaceForTestingDemo.Interfaces
{
    public interface IToon
    {
        public Dictionary<SpellType, Spell> KnownSpells();
        public Dictionary<SpellType, int> SpellSlotsRemaining();

        public bool CanCastSpell(SpellType type, Spell spell);

        public bool Defend(int damage);
        public int Attack(SpellType type, Spell spell);

    }
}