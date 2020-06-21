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
        public static lexer_201700317 lexer = new lexer_201700317();
        public static sintactico_201700317 sint = new sintactico_201700317();

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
            parse_to_end(editor.Text);

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
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "sqle files (*.sqle)|*.sqle";
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

                    //parse to end

                    //Console.WriteLine(Path.GetFileName(filePath));

                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void parse_to_end(String text_input)
        {
            lst.limpia_todo();
            lexer.analizador(text_input+" ");
            //await
            lst.print_lst();
            sint.start_x();
            lst.render_tokens();
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

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file_name.Equals("Default"))
            {
                //ask for file name and route
                SaveFileDialog savefile = new SaveFileDialog();
                // set a default file name
                savefile.FileName = "new_file.catm";
                // set filters - this can be done in properties as well
                savefile.Filter = "catm files (*.catm)|*.catm";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(savefile.FileName))
                    {
                        file_name = savefile.FileName;
                        fileN.Text = file_name;
                        sw.WriteLine(editor.Text);
                    }
                        
                }
            }
            else
            {
                //only rewrite
                Encoding ascii = Encoding.ASCII;
                StreamWriter bw;
                try
                {
                    bw = new StreamWriter(new FileStream(file_name, FileMode.Create), ascii);
                    bw.WriteLine(editor.Text);
                }
                catch (IOException e2)
                {
                    Console.WriteLine(e2.Message + "\n error.");
                    return;
                }
                bw.Close();
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = "new_file.catm";
            // set filters - this can be done in properties as well
            savefile.Filter = "catm files (*.catm)|*.catm";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                {
                    file_name = savefile.FileName;
                    fileN.Text = file_name;
                    sw.WriteLine(editor.Text);
                }

            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
