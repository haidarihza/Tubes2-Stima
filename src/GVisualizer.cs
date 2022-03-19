using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stima2
{
    internal class GVisualizer
    {
        // Viewer Object
        Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new();
        // Graph Object
        Microsoft.Msagl.Drawing.Graph graph = new();

        public GVisualizer(string root)
        {
            graph.AddNode(root);
        }
        public void AddSearchEntry(string str)
        {
            string[] names = str.Split('\\');
            string path = String.Join("\\", names.SkipLast(1));
            string name = names.Last();
            graph.AddEdge(path, str);
            graph.FindNode(str).LabelText = name;
        }

        public void Show()
        {
            Form f = new();
            viewer.Graph = graph;

            f.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            f.Controls.Add(viewer);
            f.ResumeLayout();

            f.ShowDialog();
        }
    }
}
