using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWinForm
{
    public partial class Form2 : Form
    {
        private Gameplay game;
        private List<IItem> universeItems;

        public Form2(Gameplay game)
        {
            this.game = game;
            InitializeComponent();
            this.Load += new EventHandler(label1_Load);
            this.Load += new EventHandler(label2_Load);
            this.Load += new EventHandler(Universe1_Load);
            this.Load += new EventHandler(Form2_Load);
        }

        private void Universe1_Load(object sender, EventArgs e)
        {
            if (Universe1.ColumnCount == 0)
            {
            // Создаем столбцы
            var iconColumn = new DataGridViewImageColumn();
            var nameColumn = new DataGridViewTextBoxColumn();
            var countColumn = new DataGridViewTextBoxColumn();

            // Устанавливаем свойства столбцов
            iconColumn.HeaderText = "Иконка";
            nameColumn.HeaderText = "Название";
            countColumn.HeaderText = "Количество";

            // Добавляем столбцы в DataGridView1
            Universe1.Columns.Add(iconColumn);
            Universe1.Columns.Add(nameColumn);
            Universe1.Columns.Add(countColumn);

            // Размер заготовленной картинки
            var imageSize = 64;

            // Настройка размеров таблицы
            Universe1.RowTemplate.Height = imageSize;
            Universe1.Columns[0].Width = imageSize;
            Universe1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Universe1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void WeaponSelect()
        {
            OpenUniverseGrid(true);
            var imageSize = 64;
            var damageColumn = new DataGridViewTextBoxColumn();
            var manaCostColumn = new DataGridViewTextBoxColumn();
            var staminaCostColumn = new DataGridViewTextBoxColumn();
            damageColumn.HeaderText = "Урон";
            manaCostColumn.HeaderText = "Расход маны";
            staminaCostColumn.HeaderText = "Расход выносливости";
            Universe1.Columns.Add(damageColumn);
            Universe1.Columns.Add(manaCostColumn);
            Universe1.Columns.Add(staminaCostColumn);
            Universe1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Universe1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Universe1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            universeItems = game.ActivePlayer.inventory.GetWeaponForInventory();

            foreach (var Iitem in universeItems)
            {
                var item = Iitem as Weapon;
                var image = SoftwareUtilities
                    .NameToImage(item.GetImage, imageSize);
                Universe1.Rows.Add(image, item.GetName, 1, item.GetStringDemage(), item.GetManaCost, item.GetStaminaCost);
            }
        }

        private void PotionUse()
        {
            OpenUniverseGrid(true);
            var imageSize = 64;
            var healthRegenColumn = new DataGridViewTextBoxColumn();
            var manaRegenColumn = new DataGridViewTextBoxColumn();
            var staminaRegenColumn = new DataGridViewTextBoxColumn();
            healthRegenColumn.HeaderText = "Востановление Здоровья";
            manaRegenColumn.HeaderText = "Востановление маны";
            staminaRegenColumn.HeaderText = "Выстонавление выносливости";
            Universe1.Columns.Add(healthRegenColumn);
            Universe1.Columns.Add(manaRegenColumn);
            Universe1.Columns.Add(staminaRegenColumn);
            Universe1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Universe1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Universe1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            universeItems = game.ActivePlayer.inventory.GetPotionForInventory();

            foreach (var item in universeItems)
            {
                var potion = item as Potion;
                var image = SoftwareUtilities
                .NameToImage(potion.GetImage, imageSize);
                Universe1.Rows.Add(image, potion.GetName, potion.Count,
                    potion.GetRestoring["hpRegen"], potion.GetRestoring["mpRegen"], potion.GetRestoring["spRegen"]);
            }
        }

        private void SpellUse()
        {
            OpenUniverseGrid(true);
            var imageSize = 64;
            var damageColumn = new DataGridViewTextBoxColumn();
            var manaCostColumn = new DataGridViewTextBoxColumn();
            damageColumn.HeaderText = "Урон/Защита";
            manaCostColumn.HeaderText = "Расход маны";
            Universe1.Columns.Add(damageColumn);
            Universe1.Columns.Add(manaCostColumn);
            Universe1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Universe1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            universeItems = game.ActivePlayer.Spells.Values.ToList();
            if (universeItems.Count == 0)
            {
                Waring.Text = "У вас нету заклинаний";
                Waring.Visible = true;
                OpenUniverseGrid(false);
            }
            foreach (var Iitem in universeItems)
            {
                var spell = Iitem as Spell;
                var image = SoftwareUtilities
                .NameToImage(spell.GetImage, imageSize);
                Universe1.Rows.Add(image, spell.GetName, 1, spell.GetStringDemage(), spell.GetManaCost);
            }
        }

        private void OpenUniverseGrid(bool key)
        {
            Universe1.Visible = key;
            BackMainMenu.Visible = key;
            Monster.Visible = !key;
            Weapon.Visible = !key;
            Potion.Visible = !key;
            SkipMovie.Visible = !key;
            Spell.Visible = !key;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Waring.TextAlign = ContentAlignment.MiddleCenter;
            Waring.Font = new Font(Waring.Font.FontFamily, 56f, FontStyle.Regular);
            Waring.ForeColor = Color.Red;
            Universe1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Universe1.AllowUserToAddRows = false;
            OpenUniverseGrid(false);
            Waring.Visible= false;
            // кнопка возврата
            BackMainMenu.BackgroundImage = SoftwareUtilities.NameToImage("back.png", 64);
            BackMainMenu.BackColor = Color.Transparent;
            // кнопка пропуска хода
            SkipMovie.BackgroundImage = SoftwareUtilities
                .NameToImage("skip.png", 64);
            SkipMovie.BackColor = Color.Transparent;
            // фон
            BackgroundImage = SoftwareUtilities
                .NameToImage(game.ActivePlayer.CurrentLocation.GetImgBackgroundLocation, 1280, 720);
            // враг
            Monster.BackgroundImage = SoftwareUtilities
                .NameToImage(game.ActiveMonster.GetImage, 256);
            Monster.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Load(object sender, EventArgs e)
        {
            label1.Text = $"HP: {game.ActivePlayer.GetHp()}\n" +
                $"MP: {game.ActivePlayer.GetMp}\n"
                + $"SP: {game.ActivePlayer.GetSp}\n";
            label1.Text += (game.ActivePlayer.GetMagicArmor > 0) ? $"Magic armor: {game.ActivePlayer.GetMagicArmor}\n" : "";
            label1.Text += $"LVL {game.ActivePlayer.GetExp}\\{game.ActivePlayer.GetExpToLvlup}\n";
        }



        private void label2_Load(object sender, EventArgs e)
        {
            label2.Text = $"{game.ActiveMonster.GetName} \n" +
                $"HP: {game.ActiveMonster.GetHp}";
        }


        private void Weapon_Click(object sender, EventArgs e)
        {
            WeaponSelect();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Potion_Click(object sender, EventArgs e)
        {
            PotionUse();
        }

        private void DeleteColumns()
        {

            while (Universe1.ColumnCount != 3)
                Universe1.Columns.RemoveAt(3);
            Universe1.Rows.Clear();
        }

        private void Universe1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (universeItems[e.RowIndex])
            {
                case Weapon weapon:
                    weapon = universeItems[e.RowIndex] as Weapon;
                    if (weapon.GetStaminaCost <= game.ActivePlayer.GetSp && weapon.GetManaCost <= game.ActivePlayer.GetMp)
                    {
                        game.ActiveMonster.GetDamage(game.ActivePlayer.UseItem(weapon));
                        DeleteColumns();
                        Close();
                    }
                    else
                    {
                        Waring.Visible = true;
                        Waring.Text = (weapon.GetStaminaCost > game.ActivePlayer.GetSp) ? "Недостаточно стамины" : " Недостаточно маны";
                    }
                    break;
                case Potion potion:
                    potion = universeItems[e.RowIndex] as Potion;
                    game.ActivePlayer.UseItem(potion);
                    game.ActivePlayer.inventory.RemoveItem(potion.GetName);
                    DeleteColumns();
                    Close();
                    break;
                case Spell spell:
                    spell = universeItems[e.RowIndex] as Spell;
                    if (game.ActivePlayer.GetMp >= spell.GetManaCost)
                    {
                        if (spell.GetTypeSpell == "Атакующие")
                            game.ActiveMonster.GetDamage(game.ActivePlayer.UseSpell(spell));
                        else
                            game.ActivePlayer.AddMagicArmor = game.ActivePlayer.UseSpell(spell);
                        DeleteColumns();
                        Close();
                    }
                    else
                    {
                        Waring.Visible = true;
                        Waring.Text = "Недостаточно маны";
                    }
                    break;
            }

        }

        private void SkipMovie_Click(object sender, EventArgs e)
        {
            Universe1.Rows.Clear();
            Close();
        }

        private void Waring_Click(object sender, EventArgs e)
        {
            Waring.Visible = false;
        }

        private void Spell_Click(object sender, EventArgs e)
        {
            SpellUse();
        }

        private void BackMainMenu_Click(object sender, EventArgs e)
        {
            OpenUniverseGrid(false);
            Universe1.Rows.Clear();
            DeleteColumns();
        }
    }
}
