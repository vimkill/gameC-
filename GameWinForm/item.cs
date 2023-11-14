using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWinForm
{
    public interface IItem
    {
        string GetName { get; }
        string GetImage { get; }
        int maxCount { get; }
        int Count { get; set; }

    }

    public class Weapon : IItem
    {
        private Tuple<int, int> damage;
        private int manaCost;
        private int staminaCost;
        private string name;
        private string image;
        private int count;
        public string GetName { get => name; }
        public string GetImage { get => image; }
        public int maxCount { get => 1; }
        public int Count { get => 1; set => count = 1; }

        public int GetManaCost => manaCost;

        public int GetStaminaCost => staminaCost;

        public Weapon(string name, string image, int minDamage, int maxDamage, int costStamina, int costMana)
        {
            this.name = name;
            this.image = image;
            this.damage = new Tuple<int, int>(minDamage, maxDamage);
            this.staminaCost = costStamina;
            this.manaCost = costMana;

        }
        public Weapon(Weapon weapon)
        {
            name = weapon.GetName;
            image = weapon.GetImage;
            damage = weapon.damage;
            manaCost = weapon.manaCost;
            staminaCost = weapon.staminaCost;
        }

        public int GetDamage()
        {
            var random = new Random();
            return random.Next(damage.Item1, damage.Item2);
        }

        public string GetStringDemage()
        {
            return $"{damage.Item1} - {damage.Item2}";
        }
    }

    public class Potion : IItem
    {
        private Dictionary<string, int> Restoring = new Dictionary<string, int>();
        private string name;
        private string image;
        private int count;

        public Dictionary<string, int> GetRestoring => Restoring;
        public string GetName { get => name; }
        public string GetImage { get => image; }
        public int maxCount { get => 99; }
        public int Count { get => count; set => count = value; }

        public Potion(string name, string image, int hpRegen,
            int mpRegen, int spRegen)
        {
            this.name = name;
            this.image = image;
            Restoring.Add("hpRegen", hpRegen);
            Restoring.Add("mpRegen", mpRegen);
            Restoring.Add("spRegen", spRegen);
            Count = 1;
        }

        public Potion(Potion potion)
        {
            //var potion = Invenory.AllItem[namePotion] as Potion;
            name = potion.GetName;
            image = potion.GetImage;
            Restoring = potion.Restoring;
            Count = 1;
        }

        public Dictionary<string, int> HealPlayer()
        {
            Count--;
            return Restoring;
        }

    }

    public class Tool : IItem
    {
        private string name;
        private string image;
        public string GetName { get => name; }
        public string GetImage { get => image; }

        public int maxCount => 1;

        public int Count { get => 1; set => throw new NotImplementedException(); }
        private int strength; 
    }

    public class Consumables : IItem
    {
        private string name;
        private string image;
        public string GetName { get => name; }
        public string GetImage { get => image; }

        public int maxCount => throw new NotImplementedException();

        public int Count { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    //public class Material : IItem
    //{
    //    public string GetName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //    public string GetImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    //    public int maxCount => throw new NotImplementedException();

    //    public int Count { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //}

    public class Armor : IItem
    {
        private string name;
        private string image;
        public string GetName { get => name; }
        public string GetImage { get => image; }

        public int maxCount => throw new NotImplementedException();

        public int Count { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class Accessories : IItem
    {
        private string name;
        private string image;
        public string GetName { get => name; }
        public string GetImage { get => image; }

        public int maxCount => throw new NotImplementedException();

        public int Count { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class Invenory
    {
        public static Dictionary<string, IItem> AllItem;
        public int length => invetory.Count;
        private int maxLenght;
        private Dictionary<string, IItem> invetory;


        public Invenory(int maxLenght = 25)
        {
            invetory = new Dictionary<string, IItem>();
            this.maxLenght = maxLenght;
        }

        public void raise(int raiseMaxCount)
        {
            maxLenght += raiseMaxCount;
        }

        public void RemoveItem(string itemName)
        {
            if (invetory[itemName].Count == 0)
                invetory.Remove(itemName);
        }

        public void DeleteItem(string itemName)
        {
            invetory.Remove(itemName);
        }

        public Dictionary<string, IItem> allInventory => invetory;

        public List<IItem> GetWeaponForInventory()
        {
            var items = new List<IItem>();
            foreach (var item in invetory)
            {
                if (item.Value.GetType() == typeof(Weapon))
                {
                    items.Add(item.Value);
                }
            }
            return items;
        }

        public List<IItem> GetPotionForInventory()
        {
            var items = new List<IItem>();
            foreach (var item in invetory)
            {
                if (item.Value.GetType() == typeof(Potion))
                {
                    items.Add(item.Value);
                }
            }
            return items;
        }


        public void AddItemInventory(string nameItem, int count)
        {
            if (Invenory.AllItem.ContainsKey(nameItem))
            {
                IItem item;
                switch (Invenory.AllItem[nameItem])
                {
                    case Weapon weapon:
                        item = new Weapon(Invenory.AllItem[nameItem] as Weapon);
                        break;

                    case Potion potion:
                        item = new Potion(Invenory.AllItem[nameItem] as Potion);
                        break;

                    default:
                        item = null;
                        break;
                }
                item.Count = count;

                if (invetory.ContainsKey(item.GetName))
                {
                    invetory[item.GetName].Count += count;
                }
                else
                {
                    if (length + 1 <= maxLenght)
                    {
                        invetory.Add(item.GetName, item);
                    }
                    else throw new NotImplementedException(); //потом буду предлогать выкинуть что-то или не брать предмет
                }
            }
        }

        public static void LoadAllItem()
        {
            AllItem = new Dictionary<string, IItem>();
            var pathItemTxt = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "AllItem.txt");
            using (var reader = new StreamReader(pathItemTxt))
            {
                string item;

                while ((item = reader.ReadLine()) != null)
                {
                    var parseItem = item.Split(';');
                    switch (parseItem[0])
                    {
                        case "Weapon":
                            AllItem.Add(parseItem[1], 
                                new Weapon(parseItem[1], parseItem[2],
                                    int.Parse(parseItem[3]), int.Parse(parseItem[4]), int.Parse(parseItem[5]), int.Parse(parseItem[6])));
                            break;
                        case "Potion":
                            AllItem.Add(parseItem[1],
                                new Potion(parseItem[1], parseItem[2],
                                    int.Parse(parseItem[3]), int.Parse(parseItem[4]), int.Parse(parseItem[5])));
                            break;
                    }
                }
            }
        }
    }
}
