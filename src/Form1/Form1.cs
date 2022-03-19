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

            FileCrawler fc = new FileCrawler();
            if (radioButton1.Checked)
            {
                fc.BFS(textBox1.Text, checkBox1.Checked, textBox2.Text);
            } else
            {
                fc.DFS(textBox1.Text, checkBox1.Checked, textBox2.Text);
            }

            progressBar1.Value = 0;
            progressBar1.Maximum = fc.results.Count + fc.bfs_path.Count;

            GVisualizer GV = new GVisualizer(textBox1.Text);
            foreach (string res in fc.results)
            {
                //label1.Text = (progressBar1.Value / progressBar1.Maximum).ToString();
                progressBar1.Value += 1;
                label1.Text = String.Format("{0:0.00}%", 100.0 * progressBar1.Value / progressBar1.Maximum);
            }
            foreach (string ph in fc.bfs_path)
            {
                GV.AddSearchEntry(ph);
                progressBar1.Value += 1;
                label1.Text = String.Format("{0:0.00}%", 100.0 * progressBar1.Value / progressBar1.Maximum);
            }
            panel1.Controls.Clear();
            GV.Show(panel1);
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