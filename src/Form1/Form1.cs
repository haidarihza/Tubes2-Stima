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
            richTextBox1.Text = "";
            richTextBox1.Text += "Args\n";
            richTextBox1.Text += "BFS: " + radioButton1.Checked + "\n";
            richTextBox1.Text += "DFS: " + radioButton2.Checked + "\n";
            richTextBox1.Text += "Find All: " + checkBox1.Checked + "\n";
            richTextBox1.Text += "FilePath: \"" + textBox1.Text + "\"" + "\n";
            richTextBox1.Text += "FileName: \"" + textBox2.Text + "\"" + "\n";

            FileCrawler fc = new FileCrawler();
            if (radioButton1.Checked)
            {
                fc.BFS(textBox1.Text, checkBox1.Checked, textBox2.Text);
            } else
            {
                fc.DFS(textBox1.Text, checkBox1.Checked, textBox2.Text);
            }

            richTextBox1.Text += "Result:\n";
            progressBar1.Value = 0;
            progressBar1.Maximum = fc.results.Count + fc.bfs_path.Count;

            GVisualizer GV = new GVisualizer(textBox1.Text);
            foreach (string res in fc.results)
            {
                richTextBox1.Text += res + "\n";
                progressBar1.Value += 1;
            }
            richTextBox1.Text += "Path:\n";
            foreach (string ph in fc.bfs_path)
            {
                GV.AddSearchEntry(ph);
                richTextBox1.Text += ph + "\n";
                progressBar1.Value += 1;
            }
            GV.Show();
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
    }
}