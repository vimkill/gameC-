using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWinForm
{
    public partial class Form1 : Form
    {
        private Gameplay game;
        private Invenory drop;

        public Form1(Gameplay game)
        {
            this.game = game;
            InitializeComponent();
            CloseItemDrop.Visible = false;
            ItemDropMob.Visible = false;
            KillLog.Visible = false;
            DropItemMonsterBG.Visible = false;
        }

        public void StartGiveItem(Invenory items)
        {
            KillLog.Text = $"Вы убили {game.ActiveMonster.GetName}\n" +
                $"с него выпали сдедующие предметы\n" +
                $"при нажатие на предмет вы его выкините и он не будет подобран";
            KillLog.TextAlign = ContentAlignment.MiddleCenter;
            //размер заготовленной картинки
            var imageSize = 64;
            drop = items;
            foreach (var item in items.allInventory)
            {
                var image = SoftwareUtilities
                .NameToImage(item.Value.GetImage, imageSize);
                ItemDropMob.Rows.Add(image, item.Value.GetName, item.Value.Count);
            }
            CloseItemDrop.Visible = true;
            ItemDropMob.Visible = true;
            KillLog.Visible = true;
            DropItemMonsterBG.Visible = true;
            FightMonster.Visible = false;
            ShopSpell.Visible = false;
            ChangeLocation.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e) // сражение
        {
            game.ActiveMonster = game.ActivePlayer.CurrentLocation.GetMonster();
            Gameplay.fight(game);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackgroundImage = SoftwareUtilities
                .NameToImage(game.ActivePlayer.CurrentLocation.GetImgBackgroundLocation, 1280, 720);
            // Создаем столбцы
            var iconColumn = new DataGridViewImageColumn();
            var nameColumn = new DataGridViewTextBoxColumn();
            var countColumn = new DataGridViewTextBoxColumn();

            // Устанавливаем свойства столбцов
            iconColumn.HeaderText = "Иконка";
            nameColumn.HeaderText = "Название";
            countColumn.HeaderText = "Количество";

            // Добавляем столбцы в DataGridView1
            ItemDropMob.Columns.Add(iconColumn);
            ItemDropMob.Columns.Add(nameColumn);
            ItemDropMob.Columns.Add(countColumn);

            //размер заготовленной картинки
            var imageSize = 64;

            // настройка размеров таблицы
            ItemDropMob.RowTemplate.Height = imageSize;
            ItemDropMob.Columns[0].Width = imageSize;
            ItemDropMob.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ItemDropMob.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void смена_окации_Click(object sender, EventArgs e)
        {
            var changeLocation = new Form4(game);
            changeLocation.ShowDialog();
        }

        private void CloseItemDrop_Click(object sender, EventArgs e)
        {
            foreach (var item in drop.allInventory)
            {
                game.ActivePlayer.inventory.AddItemInventory(item.Key, item.Value.Count);
            }
            CloseItemDrop.Visible = false;
            ItemDropMob.Visible = false;
            KillLog.Visible = false;
            DropItemMonsterBG.Visible = false;
            ItemDropMob.Rows.Clear();
            FightMonster.Visible = true;
            ShopSpell.Visible = true;
            ChangeLocation.Visible = true;
        }

        private void ItemDropMob_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var nameItem = ItemDropMob.Rows[e.RowIndex].Cells[1].ToString();
            ItemDropMob.Rows.RemoveAt(e.RowIndex);
            drop.DeleteItem(nameItem);
        }

        private void KillLog_Click(object sender, EventArgs e)
        {
            
        }

        private void DropItemMonsterBG_Click(object sender, EventArgs e)
        {

        }

        private void ShopSpell_Click(object sender, EventArgs e)
        {
            var f3 = new Form3(game);
            f3.ShowDialog();
        }
    }
}
