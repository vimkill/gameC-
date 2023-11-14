using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static GameWinForm.Weapon;

namespace GameWinForm
{
    public class Player
    {
        private int hp;
        private int mp;
        private int sp;
        private int exp;
        private int evasion;
        private int intimidation;
        private int maxhp;
        private int maxmp;
        private int maxsp;
        private int manaregen;
        private int staminaRegen;
        private int hpregen;
        private int lvl;
        private int skillPoint;
        private int exlvlup;
        private int magicArmor;
        public Invenory inventory;
        public LocationGame CurrentLocation;
        public Dictionary<string, IItem> Spells;

        public int GetMp => mp; 
        public int GetSp => sp;
        public int GetMagicArmor => magicArmor;
        public int Getlvl => lvl;
        public int GetExp => exp;
        public int GetExpToLvlup => exlvlup;
        public int GetSkillPoint => skillPoint;
        public int AddMagicArmor { set => magicArmor += value; }

        public Player(int hp = 100, int mp = 100, int sp = 100, int exp = 0,
            int evasion = 0, int intimidation = 5, int maxhp = 100, int maxmp = 100, int maxsp = 100,
            int manaRegen = 5, int staminaRegen = 10, int hpRegen = 0,
            int lvl = 0, int skillPoint = 5, int exlvlup = 100, int magicArmor = 0)
        {
            this.hp = hp;
            this.mp = mp;
            this.sp = sp;
            this.exp = exp;
            this.evasion = evasion;
            this.intimidation = intimidation;
            this.maxhp = maxhp;
            this.maxmp = maxmp;
            this.maxsp = maxsp;
            this.manaregen = manaRegen;
            this.staminaRegen = staminaRegen;
            this.hpregen = hpRegen;
            this.lvl = lvl;
            this.skillPoint = skillPoint;
            this.exlvlup = exlvlup;
            this.magicArmor = magicArmor;
            inventory = new Invenory();
            Spells = new Dictionary<string, IItem>();
        }

        public void CheckLvlUp()
        {
            while (exp >= exlvlup)
            {
                LvlUp();
            }
        }

        public int GetHp()
        {
            if (hp <= 0)
            {
                throw new Exception("Hi's dead");
            }
            return hp;
        }

        public void Damage(int damage)
        {
            if (magicArmor > 0)
                magicArmor-= damage;
            else
                hp-= damage;
        }

        public void AddExpPlayer(int add)
        {
            exp += add;
            CheckLvlUp();
        }

        public void Restoring()
        {
            hp = Math.Min(hp + hpregen, maxhp);
            mp = Math.Min(mp + manaregen, maxmp);
            sp = Math.Min(sp + staminaRegen, maxsp);
        }

        public void UseItem(Potion potion)
        {
            var heal = potion.HealPlayer();
            hp = Math.Min(hp + heal["hpRegen"], maxhp);
            mp = Math.Min(mp + heal["mpRegen"], maxmp);
            sp = Math.Min(sp + heal["spRegen"], maxsp);
        }

        public int UseItem(Weapon weapon)
        {
            var rand = new Random();
            sp -= rand.Next((int)(weapon.GetStaminaCost * 0.9), weapon.GetStaminaCost);
            mp -= rand.Next((int)(weapon.GetManaCost * 0.9), weapon.GetManaCost);
            return weapon.GetDamage();
        }

        public int UseSpell(Spell spell)
        {
            var rand = new Random();
            mp -= rand.Next((int)(spell.GetManaCost * 0.9), spell.GetManaCost);
            return (spell.GetTypeSpell == "Атакующие") ? spell.GetDamage() : spell.GetMagicArmor;
        }

        public void BuySpell(Spell spell)
        {
            skillPoint -= spell.GetCostLearning;
            Spells.Add(spell.GetName, spell);
        }

        private void LvlUp()
        {
            lvl++;
            exp -= exlvlup;
            exlvlup = (int)(exlvlup * Math.Pow(1.01, lvl-1));
            maxhp = maxhp * (int)(Math.Pow(1.02,lvl));
            maxmp = maxmp * (int)(Math.Pow(1.01, lvl));
            maxsp = maxsp * (int)(Math.Pow(1.01, lvl));
            skillPoint += lvl;
        }
    }
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void TestLvlUpSystem()
        {
            var player = new Player();
            player.AddExpPlayer(100);
            Assert.AreEqual(player.Getlvl, 1);
            player.AddExpPlayer(101);
            Assert.AreEqual(player.Getlvl, 2);
            player.AddExpPlayer(103);
            Assert.AreEqual(player.Getlvl, 3);
            player.AddExpPlayer(106);
            Assert.AreEqual(player.Getlvl, 4);
            player.AddExpPlayer(110);
            Assert.AreEqual(player.Getlvl, 5);
            player.AddExpPlayer(115);
            Assert.AreEqual(player.Getlvl, 6);
            player.AddExpPlayer(122);
            Assert.AreEqual(player.Getlvl, 7);
            player.AddExpPlayer(130);
            Assert.AreEqual(player.Getlvl, 8);
            player.AddExpPlayer(140);
            Assert.AreEqual(player.Getlvl, 9);
            player.AddExpPlayer(153);
            Assert.AreEqual(player.Getlvl, 10);
        }
    }

    [TestFixture]
    public class InventoryTestSystem
    {
        [Test]
        public void TestAddItem()
        {
            var player = new Player();
            Invenory.LoadAllItem();
            player.inventory.AddItemInventory("Медный кинжал", 1);
            Assert.AreEqual(1, 1);
        }
    }
}
