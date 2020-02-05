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

namespace ProyectoFicheros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textDirectory.Text = Directory.GetCurrentDirectory();

        }

        //listar carpetas y ficheros del directorio
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            String ErrorMessage = null;
            String NewPath = " NewPath holds the path the user has entered.";
            NewPath = textDirectory.Text;
            try
            {
                Directory.SetCurrentDirectory(NewPath);
            }
            catch (DirectoryNotFoundException f)
            {
                ErrorMessage = "You must enter a valid path. If trying to access a different drive, remember to include the drive letter.";
            }
            catch
            {
                ErrorMessage = "You must enter a path.";
            }
            finally
            {//' Display the error message only if one exists.
                if(ErrorMessage != null) 
                    MessageBox.Show(ErrorMessage);
            }

            string sourceDirectory = NewPath; 
            var txtFiles = Directory.EnumerateFiles(sourceDirectory);
            var dirFiles = Directory.EnumerateDirectories(sourceDirectory);
            
            
            foreach (string currentFile in dirFiles)
            {
                string fileName = currentFile.Substring(sourceDirectory.Length + 1);
                listBox1.Items.Add(fileName);
            }

            foreach (string currentFile in txtFiles) { 
                string fileName = currentFile.Substring(sourceDirectory.Length + 1); 
                listBox1.Items.Add(fileName); 
            }
            
        }

        //crear fichero o carpeta
        private void button2_Click(object sender, EventArgs e)
        {

           
            String archivoNombre;
            archivoNombre = textBox2.Text;
            if (radioButton1.Checked)
            {
                try
                {
                    using (FileStream fs = File.Create(archivoNombre))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes("");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }

                }
                catch (Exception ex)
                {

                }
            }
            else if(radioButton2.Checked)
            {
                DirectoryInfo di = Directory.CreateDirectory(archivoNombre);
            }

        }

        //eliminar 
        private void button3_Click(object sender, EventArgs e)
        {


            try
            {
                String path = textDirectory.Text;
                String path2 = textBox2.Text;

                if (radioButton2.Checked)
                {
                    if (Directory.Exists(path2))
                    {
                        Directory.Delete(path2, true);
                    }


                }
                else if (radioButton1.Checked)
                {

                    if (File.Exists(path2))
                    {
                        File.Delete(path2);
                    }

                }
            }
            catch (Exception)
            {
               
            }

        }
        //renombrar o mover
        private void button4_Click(object sender, EventArgs e)
        {



            try
            {
                String path = textDirectory.Text;
                String path2 = textBox2.Text;


                if (radioButton2.Checked)
                {
                    if (!Directory.Exists(path2))
                    {
                        Directory.Move(path, path2);
                    }


                }
                else if (radioButton1.Checked)
                {

                    if (!File.Exists(path2))
                    {
                        File.Move(path, path2);
                    }

                }
            }
            catch (Exception)
            {
              
            }





        }
        //visualizar fichero
        private void button5_Click(object sender, EventArgs e)
        {
            int i = 0;
            String line;
            String name = listBox1.SelectedItem.ToString();

            richTextBox1.Text = File.ReadAllText(name);
        }

        //modfich
        private void button6_Click(object sender, EventArgs e)
        {
            File.WriteAllText(listBox1.SelectedItem.ToString(), richTextBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
