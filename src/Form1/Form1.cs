using System.Diagnostics;

namespace Stima2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            FolderCrawler fc = new FolderCrawler();
            Stopwatch sw = new Stopwatch();

            sw.Start();
            if (radioButton1.Checked)
            {
                fc.BFS(textBox1.Text, checkBox1.Checked, textBox2.Text);
            } else
            {
                fc.DFS(textBox1.Text, checkBox1.Checked, textBox2.Text);
            }
            sw.Stop();

            progressBar1.Value = 0;
            progressBar1.Maximum = fc.fs_path.Count;

            GVisualizer GV = new GVisualizer(textBox1.Text);
            GV.Parse(fc);
            // Not Traversed Path
            GV.Show(panel1);
            textBox3.Text = String.Format("{0}ms", sw.ElapsedMilliseconds);
            //richTextBox1.Text = fc.f_node.toString();
            richTextBox1.Text = String.Join("\n", fc.fs_path);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}