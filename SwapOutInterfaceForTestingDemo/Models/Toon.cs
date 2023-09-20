using Microsoft.OpenApi.Writers;
using SwapOutInterfaceForTestingDemo.Enums;
using SwapOutInterfaceForTestingDemo.Interfaces;
using System;

namespace SwapOutInterfaceForTestingDemo.Models
{
    public class Toon : IToon
    {
        public string? Name { get; set; }
        public CasterType CasterType { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public Dictionary<SpellType, int> SpellSlots { get; internal set; } = new Dictionary<SpellType, int>();
        public int Defense { get; set; }
        public int AttackPower { get; set; }

        public Toon()
        {
            CasterType[] casters = (CasterType[])Enum.GetValues(typeof(CasterType));
            Random random = new Random();
            var caster = random.Next(0, casters.Length);

            Name = $"{random.Next(1, 40)}-{casters[caster]}";
            CasterType = casters[caster];
            Level = random.Next(1, 100);
            HitPoints = random.Next(100, 700);
            Defense = random.Next(10, 30);
            AttackPower = random.Next(31, 50);
            SpellSlots = SetSpellSlots(casters[caster]);
        }

        public int Attack(SpellType type, Spell spell)
        {
            if (CanCastSpell(type, spell))
            {
                return AttackPower;
            }

            // you tried to cast a spell you cant cast.  Lose a turn and feel shame.
            return 0;


        }

        public bool CanCastSpell(SpellType type, Spell spell)
        {
            // == "is equal"
            // =  "equals"


            //  myVar == 4  (asking)
            // myVar = 4 (telling)


            switch (type)
            {
                case SpellType.Darkness:
                    return spell == Spell.CallDarkness || spell == Spell.DispelDarkness;
                case SpellType.Light:
                    return spell == Spell.CallLight || spell == Spell.DispelLight;
                case SpellType.Water:
                    return spell == Spell.TidalWave || spell == Spell.AbsorbWater;
                case SpellType.Force:
                    return spell == Spell.PushingForce || spell == Spell.PullingForce;
                case SpellType.Illusion:
                    return spell == Spell.CallIllusion || spell == Spell.DispelIllusion;
                case SpellType.Damage:
                    return true;
                default:
                    return false;
            }

        }

        public bool Defend(int damage)
        {
            this.HitPoints -= (damage - this.Defense);

            return (this.HitPoints > 0);
        }

        public Dictionary<Spell, SpellType> KnownSpells()
        {
            var result = new Dictionary<Spell, SpellType>();

            switch (this.CasterType)
            {
                case CasterType.Necromancer:
                    result.Add(Spell.CallDarkness, SpellType.Darkness);
                    result.Add(Spell.DispelDarkness, SpellType.Darkness);
                    result.Add(Spell.DealDamage, SpellType.Damage);
                    return result;

                case CasterType.Paladin:
                    result.Add(Spell.CallLight, SpellType.Light);
                    result.Add(Spell.DispelLight, SpellType.Light);
                    result.Add(Spell.DealDamage, SpellType.Damage);
                    return result;

                case CasterType.Shaman:
                    result.Add(Spell.TidalWave, SpellType.Water);
                    result.Add(Spell.AbsorbWater, SpellType.Water);
                    result.Add(Spell.PushingForce, SpellType.Force);
                    result.Add(Spell.PullingForce, SpellType.Force);
                    result.Add(Spell.DealDamage, SpellType.Damage);
                    return result;

                case CasterType.Illusionist:
                    result.Add(Spell.CallIllusion, SpellType.Illusion);
                    result.Add(Spell.DispelIllusion, SpellType.Illusion);
                    result.Add(Spell.CallDarkness, SpellType.Darkness);
                    result.Add(Spell.DispelDarkness, SpellType.Darkness);
                    result.Add(Spell.CallLight, SpellType.Light);
                    result.Add(Spell.DispelLight, SpellType.Light);
                    return result;
                default:
                    throw new ArgumentOutOfRangeException("this type is not determined yet");
            }
        }

        public Dictionary<SpellType, int> SetSpellSlots(CasterType casterType)
        {

            var result = new Dictionary<SpellType, int>();

            switch (casterType)
            {
                case CasterType.Necromancer:
                    result.Add(SpellType.Darkness, 10);
                    break;
                case CasterType.Paladin:
                    result.Add(SpellType.Light, 10);
                    break;
                case CasterType.Shaman:
                    result.Add(SpellType.Water, 5);
                    result.Add(SpellType.Force, 5);
                    break;
                case CasterType.Illusionist:
                    result.Add(SpellType.Illusion, 5);
                    result.Add(SpellType.Darkness, 5);
                    result.Add(SpellType.Light, 5);
                    result.Add(SpellType.Force, 5);
                    break;
                default:
                    return result;

            }
            return result;
        }

        public Dictionary<SpellType, int> SpellSlotsRemaining()
        {
            throw new NotImplementedException();
        }

        Dictionary<SpellType, Spell> IToon.KnownSpells()
        {
            throw new NotImplementedException();
        }
    }
}



// list   { "bob, "paul", "Michel", "Dave" }
// array[]  { 1,2,3,4}

//dictionary<int, Toon>  {

//   key          value
//{ "Bob",        },
//{ "Paul",     "Texas"},
//{ "Michael",  "Florida"},
//{ "Beba",     "Pogroitca"},
//{ "Dave",     "Florida"},
//{ "Virginia", "Florida"}
//}

// give me all of the keys, where the value is "Florida"?




// what is the value where dictionary key == 3?


