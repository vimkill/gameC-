using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWinForm
{
    public class Monster
    {
        public static Dictionary<string, Monster> AllMonster;
        private string name;
        private string image;
        private int hp;
        private int expDrop;
        private Tuple<int, int> damage;
        private Dictionary<string, int[]> itemСhanceFallingOut;

        public string GetName => name;
        public string GetImage => image;
        public int GetHp => hp; 
        public int GetExpDrop => expDrop;

        public Monster(string name, string image, int hp,
            int minDamage, int maxDamage, int expDrop, string itemСhanceFallingOutRaw)
        {
            itemСhanceFallingOut = new Dictionary<string, int[]>();
            this.name = name;
            this.image = image;
            this.hp = hp;
            this.expDrop = expDrop;
            damage = new Tuple<int, int>(minDamage, maxDamage);
            ParseItemDrop(itemСhanceFallingOutRaw);
        }

        public Monster(Monster monster)
        {
            this.itemСhanceFallingOut = monster.itemСhanceFallingOut;
            this.name = monster.name;
            this.image = monster.image;
            this.hp = monster.hp;
            this.expDrop = monster.expDrop;
            this.damage= monster.damage;
        }

        private void ParseItemDrop(string parseLine)
        {
            var SplitLine = parseLine.Split(':');
            for (var i = 0; i < SplitLine.Length; i += 3)
            {
                itemСhanceFallingOut.Add(
                    SplitLine[i], new[]
                    {
                        int.Parse(SplitLine[i + 1]),
                        int.Parse(SplitLine[i + 2])
                    });
            }
        }

        public int GetDamage()
        {
            var random = new Random(1);
            return random.Next(damage.Item1, damage.Item2);
        }

        public void GetDamage(int damage)
        {
            hp-=damage;
        }

        public static void LoadAllMonster()
        {
            AllMonster = new Dictionary<string, Monster>();
            var pathItemTxt = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "AllMonster.txt");
            using (var reader = new StreamReader(pathItemTxt))
            {
                string monster;

                while ((monster = reader.ReadLine()) != null)
                {
                    var parseMoster = monster.Split(';');
                    AllMonster.Add(parseMoster[0], new Monster(parseMoster[0], parseMoster[1],
                        int.Parse(parseMoster[2]), int.Parse(parseMoster[3]), int.Parse(parseMoster[4]),
                        int.Parse(parseMoster[5]), parseMoster[6]));
                }
            }
        }

        public Invenory DropItemMonster()
        {
            var items = new Invenory(10);
            var rand = new Random();
            foreach (var item in itemСhanceFallingOut)
            {
                if (rand.Next(1,99) <= item.Value[1])
                {
                    items.AddItemInventory(item.Key, rand.Next(1, item.Value[0]));
                }
            }
            return items;
        }
    }
}
