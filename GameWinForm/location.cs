using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameWinForm
{
    public class LocationGame
    {
        public static List<LocationGame> AllLocation = new List<LocationGame>();

        private string locationName;
        private string imgLocation;
        private string imgBackgroundLocation;
        private Dictionary<string, int> monsters;


        public string GetLocationName { get => locationName; }
        public string GetImgLocation { get => imgLocation; }
        
        public string GetImgBackgroundLocation {  get => imgBackgroundLocation; }

        public LocationGame(string locationName, string imgLocation, string imgBackgroundLocation, Dictionary<string, int> stringMonsters)
        {
            this.locationName = locationName;
            this.imgLocation = imgLocation;
            this.imgBackgroundLocation = imgBackgroundLocation;
            monsters = stringMonsters;
        }

        public Monster GetMonster()
        {
            var rand = new Random();
            var choice = rand.Next(0, 100);
            var selectedMonster = "None";
            foreach (var monster in monsters)
            {
                if (monster.Value > choice)
                {
                    break;
                }
                else
                {
                    selectedMonster = monster.Key;
                }
            }
            return new Monster(Monster.AllMonster[selectedMonster]);
        }

        public static void LoadAllLocation()
        {
            var pathItemTxt = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "AllLocation.txt");

            using (var reader = new StreamReader(pathItemTxt))
            {
                string item;

                while ((item = reader.ReadLine()) != null)
                {
                    var monster = new Dictionary<string, int>();
                    var parseItem = item.Split(';');
                    var monsterLiveLocation = new List<string>();
                    var chanceMonster = 0;
                    var monsterParse = parseItem[3].Split(':');
                    for (var i = 0; i < monsterParse.Length; i += 2)
                    {
                        monster.Add(monsterParse[i], chanceMonster);
                        chanceMonster = int.Parse(monsterParse[i + 1]);
                    }
                    AllLocation.Add(new LocationGame(parseItem[0], parseItem[1], parseItem[2], monster));
                }
            }
        }
    }
}
