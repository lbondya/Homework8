using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrueFalseEditor

/* 3.
а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок (не создана база данных, 
обращение к несуществующему вопросу, открытие слишком большого файла и т.д.).
б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические» 
улучшения на свое усмотрение.
в) Добавить в приложение меню «О программе» с информацией о программе (автор, версия, авторские права и др.).*/
{
    public partial class MainForm : Form
    {

        private TrueFalseEngine database;

        public MainForm()
        {
            InitializeComponent();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalseEngine(saveFileDialog.FileName);
                database.Add("Is the Earth round?", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            }

        }
        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalseEngine(openFileDialog.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
            }
        }


        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Create new database", "Error");
                return;
            }

            try
            {
                tbQuestion.Text = database[(int)nudNumber.Value - 1].Text;
                cbTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Question doesn't exist.");
            }
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Create new database", "Message");
                return;
            }
           
            database.Add((database.Count+1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database == null) return;
            database.Remove((int)nudNumber.Value);
            nudNumber.Maximum--;
            if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;

            
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            database.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
                database[(int)nudNumber.Value - 1].TrueFalse = cbTrue.Checked;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Open or create new database.");
            }

            
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by GeekBrains support 05.12.2021", "About programm");
        }
    }
}
