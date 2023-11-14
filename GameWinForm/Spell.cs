using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWinForm
{
    public class Spell:IItem
    {
        public static Dictionary<string, Spell> AllSpell;

        private string name;
        private string image;
        private string typeSpell;
        private int manacost;
        private int magicArmor;
        private int costLearning;
        private Tuple<int,int> damage;
        private List<string> necessaryStudy;

        
        public string GetName => name;
        public string GetImage => image;
        public string GetTypeSpell => typeSpell;
        public int GetCostLearning => costLearning;
        public int GetManaCost => manacost;
        public int GetMagicArmor => magicArmor;
        public List<string> GetNecessaryStudy => necessaryStudy;

        public int maxCount => 1;

        public int Count { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Spell(Spell spell)
        {
            image = spell.image;
            name = spell.name;
            manacost = spell.manacost;
            magicArmor = spell.magicArmor;
        }

        public Spell(string name, string image, int minDamage, int maxDamage, int manacost, int costLearning, string needLearnSpell)
        {
            this.name = name;
            this.image = image;
            damage = new Tuple<int,int>(minDamage, maxDamage);
            typeSpell = "Атакующие";
            this.manacost = manacost;
            this.costLearning = costLearning;
            ParseLearnSpell(needLearnSpell);
        }

        public Spell(string name, string image, int armor, int manacost, int costLearning, string needLearnSpell)
        {
            this.name = name;
            this.image = image;
            this.magicArmor = armor;
            typeSpell = "Защитное";
            this.manacost = manacost;
            this.costLearning = costLearning;
            ParseLearnSpell(needLearnSpell);
        }

        public int GetDamage()
        {
            var rand = new Random();
            return rand.Next(damage.Item1, damage.Item2);
        }

        public string GetStringDemage()
        {
            return $"{damage.Item1} - {damage.Item2}";
        }

        public static void LoadAllSpell()
        {
            AllSpell= new Dictionary<string, Spell>();
            var pathItemTxt = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "AllSpell.txt");
            using (var reader = new StreamReader(pathItemTxt))
            {
                string spell;

                while ((spell = reader.ReadLine()) != null)
                {
                    var parseSpell = spell.Split(';');
                    switch (parseSpell[0])
                    {
                        case "Attack":
                            AllSpell.Add(parseSpell[1],
                                new Spell(parseSpell[1], parseSpell[2],
                                    int.Parse(parseSpell[3]), int.Parse(parseSpell[4]), int.Parse(parseSpell[5]), int.Parse(parseSpell[6]), parseSpell[7]));
                            break;
                        case "Defense":
                            AllSpell.Add(parseSpell[1],
                                new Spell(parseSpell[1], parseSpell[2],
                                    int.Parse(parseSpell[3]), int.Parse(parseSpell[4]), int.Parse(parseSpell[5]), parseSpell[6]));
                            break;
                    }
                }
            }
        }

        private void ParseLearnSpell(string parseLine)
        {
            necessaryStudy = new List<string>();
            var splitLine = parseLine.Split(',');
            foreach (var spellName in splitLine)
            {
                necessaryStudy.Add(spellName);
            }
        }
    }
}
