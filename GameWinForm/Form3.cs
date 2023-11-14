using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.ComponentModel.Design;

namespace GameWinForm
{
    public partial class Form3 : Form
    {
        private Gameplay game;
        private List<Spell> availableSpell;

        public Form3(Gameplay game)
        {
            this.game = game;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (availableSpell[e.RowIndex].GetCostLearning <= game.ActivePlayer.GetSkillPoint)
            {
                game.ActivePlayer.BuySpell(availableSpell[e.RowIndex]);
            }
            else
            {
                Waring.Visible = true;
            }
            dataGridView1.Rows.Clear();
            ShopOn();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Waring.Visible = false;
            Waring.Font = new Font(Waring.Font.FontFamily, 24f, FontStyle.Regular);
            Waring.ForeColor = Color.Red;
            Waring.Text = "У вас не достаточно очков что бы это купить";
            Waring.TextAlign = ContentAlignment.MiddleCenter;
            label1.TextAlign = ContentAlignment.MiddleLeft;
            dataGridView1.AllowUserToAddRows = false;
            // Фон
            BackgroundImage = SoftwareUtilities
                .NameToImage("spell_shop_background.png", 1280, 720);
            // Создаем столбцы
            var costBuySpellColumn = new DataGridViewTextBoxColumn();
            var iconColumn = new DataGridViewImageColumn();
            var nameColumn = new DataGridViewTextBoxColumn();
            var typeColumn = new DataGridViewTextBoxColumn();
            var manaCostColumn = new DataGridViewTextBoxColumn();

            // Устанавливаем свойства столбцов
            costBuySpellColumn.HeaderText = "Стоимость";
            iconColumn.HeaderText = "Иконка";
            nameColumn.HeaderText = "Название";
            typeColumn.HeaderText = "Тип"; // их два защитные те что делают щит и атакующие
            manaCostColumn.HeaderText = "Расход маны";

            // Добавляем столбцы в DataGridView1
            dataGridView1.Columns.Add(costBuySpellColumn);
            dataGridView1.Columns.Add(iconColumn);
            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(typeColumn);
            dataGridView1.Columns.Add(manaCostColumn);

            //размер заготовленной картинки
            var imageSize = 64;

            // настройка размеров таблицы
            dataGridView1.RowTemplate.Height = imageSize;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].Width = imageSize;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ShopOn();
        }

        private void ShopOn()
        {
            availableSpell = new List<Spell>();
            label1.Text = $"У вас сейчас {game.ActivePlayer.GetSkillPoint} очков изучения";
            var imageSize = 64;
            var allSpell = Spell.AllSpell;
            foreach (var spell in allSpell)
            {
                if (!game.ActivePlayer.Spells.ContainsKey(spell.Value.GetName)
                    && (spell.Value.GetNecessaryStudy[0] == "-"
                    || spell.Value.GetNecessaryStudy.All(spellName => game.ActivePlayer.Spells.ContainsKey(spellName))))
                {
                    var openSpell = spell.Value;
                    availableSpell.Add(openSpell);
                    var image = SoftwareUtilities
                .NameToImage(openSpell.GetImage, imageSize);
                    dataGridView1.Rows.Add(openSpell.GetCostLearning,
                        image, openSpell.GetName, openSpell.GetTypeSpell,
                        openSpell.GetManaCost);
                }
            }
        }

        private void ExitShop_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Waring_Click(object sender, EventArgs e)
        {
            Waring.Visible = false;
        }
    }
}
