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

namespace proyecto1
{
    public partial class principal : Form
    {
        public static listas lst = new listas();
        private string file_name = "Default";

        public principal()
        {
            InitializeComponent();
            fileN.Text = file_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //link to the other class
            logChanges.Text = "s";

        }

        private void colorear()
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorear();
        }

        private void cargarTablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //shit here we go again
            //here we load the table data
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open my extension .catm
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "catm files (*.catm)|*.catm";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    editor.Text = fileContent;
                    fileN.Text = filePath;
                    file_name = filePath;

                    //Console.WriteLine(Path.GetFileName(filePath));

                }
            }
        }
    }
}
