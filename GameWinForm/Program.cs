using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWinForm
{
    static internal class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SoftwareUtilities.LoadAllData();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var game = new Gameplay();
            var startGame = new Form1(game);
            game.StartGame = startGame;
            Application.Run(startGame);
        }
    }

    public class Gameplay
    {
        public static Form FightMenu; 
        public Player ActivePlayer;
        public Monster ActiveMonster;
        public Form StartGame;

        public Gameplay()
        {
            ActivePlayer = new Player();
            ActivePlayer.CurrentLocation = LocationGame.AllLocation[0];
            ActivePlayer.inventory.AddItemInventory("Медный кинжал", 1);
            ActivePlayer.inventory.AddItemInventory("Деревянный посох", 1);
            ActivePlayer.inventory.AddItemInventory("Малое лечебное зелье", 3);
            ActivePlayer.inventory.AddItemInventory("Малое зелье маны",3);
            ActivePlayer.inventory.AddItemInventory("Малое зелье стамины", 3);
            ActivePlayer.inventory.AddItemInventory("Великий том мудрости", 1);
        }

        public static void fight(Gameplay game)
        {
            FightMenu = new Form2(game);

            while (game.ActivePlayer.GetHp() > 0
                && game.ActiveMonster.GetHp > 0)
            {
                FightMenu.ShowDialog();
                game.ActivePlayer.Damage(game.ActiveMonster.GetDamage());
                game.ActivePlayer.Restoring();
            }
            if (game.ActiveMonster.GetHp <= 0)
            {
                game.ActivePlayer.AddExpPlayer(game.ActiveMonster.GetExpDrop);
                var drop = game.ActiveMonster.DropItemMonster();
                if (drop.length != 0)
                {
                    var startGame = game.StartGame as Form1;
                    startGame.StartGiveItem(drop); 
                }
            }
        }
    }

    public static class SoftwareUtilities
    {
        public static Image NameToImage(string nameImage, int pictureWidth, int pictureHeight)
        {
            var folderPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "img");
            var pathImage = Path.Combine(folderPath, nameImage);
            return Image.FromFile(pathImage).GetThumbnailImage(pictureWidth, pictureHeight, null, IntPtr.Zero);
        }

        public static Image NameToImage(string nameImage, int pictureSize)
        {
            var folderPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "img");
            var pathImage = Path.Combine(folderPath, nameImage);
            return Image.FromFile(pathImage).GetThumbnailImage(pictureSize, pictureSize, null, IntPtr.Zero);
        }

        public static void LoadAllData()
        {
            Invenory.LoadAllItem();
            Spell.LoadAllSpell();
            Monster.LoadAllMonster();
            LocationGame.LoadAllLocation();
        }
    }
}
