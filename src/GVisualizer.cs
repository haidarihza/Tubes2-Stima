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
		Node f_node = new("root", null);

        public GVisualizer(string root)
        {
            graph.AddNode(root);
        }
        private string FolderParent(string str)
        {
            string[] names = str.Split('\\');
            return String.Join("\\", names.SkipLast(1));
        }
        private string FolderName(string str)
        {
            string[] names = str.Split('\\');
            return names.Last();
        }

        public void Parse(FolderCrawler fc)
        {
            Parse(fc.f_node);         
        }
        private Microsoft.Msagl.Drawing.Color ColorNode(Node n)
        {
            Microsoft.Msagl.Drawing.Color GREEN = Microsoft.Msagl.Drawing.Color.Green;
            Microsoft.Msagl.Drawing.Color RED = Microsoft.Msagl.Drawing.Color.DarkRed;
            Microsoft.Msagl.Drawing.Color BLACK = Microsoft.Msagl.Drawing.Color.Black;

            Microsoft.Msagl.Drawing.Color color;

            if (n.found)
            {
                color = GREEN;
            }
            else
            {
                color = RED;
            }
            if (!n.tr)
            {
                color = BLACK;
            }
            graph.FindNode(n.GetName()).Attr.Color = color;
            return color;
        }

        private void RecursiveParse(Node root)
        {
            if (root.children.Count != 0)
            {
                foreach (Node c in root.children)
                {
                    graph.AddEdge(root.GetName(), c.GetName()).Attr.Color = ColorNode(c);
                    graph.FindNode(c.GetName()).LabelText = FolderName(c.GetName());
                    ColorNode(root);
                    RecursiveParse(c);
                }
            }
        }

        public void Parse(Node root)
        {
            if(root.children.Count != 0)
            {
                RecursiveParse(root.children[0]);
            }

        }

        public void Show(Panel p)
        {
            viewer.Graph = graph;
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            p.Controls.Clear();
            p.Controls.Add(viewer);
        }
    }
}
