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

        private void RecursiveParse(Node root)
        {
            if (root.children.Count != 0)
            {
                Microsoft.Msagl.Drawing.Color GREEN = Microsoft.Msagl.Drawing.Color.Green;
                Microsoft.Msagl.Drawing.Color RED = Microsoft.Msagl.Drawing.Color.DarkRed;
                Microsoft.Msagl.Drawing.Color BLACK = Microsoft.Msagl.Drawing.Color.Black;

                Microsoft.Msagl.Drawing.Color color;

                foreach (Node c in root.children)
                {
                    if (c.found)
                    {
                        color = GREEN;
                    }
                    else
                    {
                        color = RED;
                    }
                    if (!c.tr)
                    {
                        color = BLACK;
                    }
                    graph.AddEdge(root.GetName(), c.GetName()).Attr.Color = color;
                    graph.FindNode(c.GetName()).LabelText = FolderName(c.GetName());
                    graph.FindNode(c.GetName()).Attr.Color = color;
                    if (root.found)
                    {
                        graph.FindNode(root.GetName()).Attr.Color = GREEN;
                    }
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
