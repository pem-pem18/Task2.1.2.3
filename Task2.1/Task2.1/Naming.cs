﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Task2._1
{
    public partial class Naming : Form
    {
        public Naming()
        {
            InitializeComponent();
        }

        private void NewBaseNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string ForbAbc = "/\\:*?«<>|"; // набор запрещенных символов для имени базы

            if (ForbAbc.Contains(Char.Parse(e.KeyChar.ToString())))
            {
                e.Handled = true;
                MessageBox.Show("Недопустимое значение в имени файла.", "Ошибка");
            }
        }

        // клик по кнопке <создать пустую базу с указанным в NewBaseNameBox именем>
        private void CreateBaseButton_Click(object sender, EventArgs e)
        {
            if (NewBaseNameBox.Text.Contains('/') ||
                NewBaseNameBox.Text.Contains('\\') ||
                NewBaseNameBox.Text.Contains(':') ||
                NewBaseNameBox.Text.Contains('*') ||
                NewBaseNameBox.Text.Contains('?') ||
                NewBaseNameBox.Text.Contains('«') ||
                NewBaseNameBox.Text.Contains('<') ||
                NewBaseNameBox.Text.Contains('>') ||
                NewBaseNameBox.Text.Contains('|'))
            {
                MessageBox.Show("Недопустимое значение в имени файла.", "Ошибка");
            }
            else if (!MainMenu.BasesNames.Contains(NewBaseNameBox.Text + ".xml"))
            {
                //File.Create(MainMenu.BasesDirectory + NewBaseNameBox.Text + ".xml");
                MainMenu.FileName = NewBaseNameBox.Text;
                //var myFile = File.Create(MainMenu.BasesDirectory + NewBaseNameBox.Text + ".xml");
                //myFile.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("База с таким именем уже существует.", "Ошибка");
            }
        }
    }
}
