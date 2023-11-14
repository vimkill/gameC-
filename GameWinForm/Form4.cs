using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWinForm
{
    public partial class Form4 : Form
    {
        private Gameplay game;
        private List<LocationGame> location;
        public Form4(Gameplay game)
        {
            this.game = game;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Создаем столбцы
            var iconColumn = new DataGridViewImageColumn();
            var nameColumn = new DataGridViewTextBoxColumn();

            // Устанавливаем свойства столбцов
            iconColumn.HeaderText = "Иконка";
            nameColumn.HeaderText = "Название";

            // Добавляем столбцы в DataGridView1
            dataGridPotion.Columns.Add(iconColumn);
            dataGridPotion.Columns.Add(nameColumn);

            // Размер заготовленной картинки
            var imageSize = 64;

            // Настройка размеров таблицы
            dataGridPotion.RowTemplate.Height = imageSize;
            dataGridPotion.Columns[0].Width = imageSize;
            dataGridPotion.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            location = LocationGame.AllLocation;

            foreach (var item in location)
            {
                //var folderPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "img");
                //var pathImage = Path.Combine(folderPath, item.Lo);
                var image = SoftwareUtilities.NameToImage(item.GetImgLocation, imageSize);
                dataGridPotion.Rows.Add(image, item.GetLocationName);
            }
        }

        private void dataGridPotion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            game.ActivePlayer.CurrentLocation = location[e.ColumnIndex];
            Close();
        }
    }
}
