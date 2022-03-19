using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stima2
{
    public class Node
    {
        string name;
        public List<Node> children = new();
        private Node? parent;
        public Boolean tr = true;
        public Boolean found = false;

        public Node(string n, Node? p)
        {
            name = n;
            parent = p;
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
        public List<string> ParseFolderName(string baseName, string n)
        {
            string path = FolderParent(n);
            //string name = FolderName(n);
            if(path == baseName)
            {
                List<string> list = new List<string>{path, n};
                return list;
            } else
            {
                List<string> list = ParseFolderName(baseName, path);
                list.Add(n);
                return list;
            }

        }
        public Node AddFolderNode(string n)
        {
            if(children.Count == 0)
            {
                return AddChildren(n);
            } else
            {
                string r_path = children[0].name;
                List<string> list = ParseFolderName(r_path, n);
                Node tmp = this;
                foreach (string name in list)
                {
                    tmp = tmp.GetChild(name);
                }
                return tmp;
            }
        }
        public Node AddChildren(string n)
        {
            Node c = new(n, this);
            children.Add(c);
            return c;
        }
        public Node? GetParent()
        {
            return parent;
        }
        public string GetName()
        {
            return name;
        }
        public Node GetChild(string n)
        {
            foreach(Node c in children)
            {
                if(c.GetName() == n)
                {
                    return c;
                }
            }
            return AddChildren(n);
        }
        public void SetFound()
        {
            found = true;
            if(parent != null)
            {
                parent.SetFound();
            }
        }
        private List<string> recToString(Node c, int level, List<string> res)
        {
            //res += String.Concat(Enumerable.Repeat(" ", level * 5)) + c.name +"\n";
            res.Add(String.Format("{0}{1}, checked = {2}, match = {3}",
                String.Concat(Enumerable.Repeat(" ", level * 5)),
                c.name,
                c.tr,
                c.found));
            
            if(c.children.Count != 0)
            {
                foreach (Node child in c.children)
                {
                    res = recToString(child, level + 1, res);
                }
            }
            return res;
        }
        public string toString()
        {
            List<string> res = new List<string>();
            return String.Join("\n", recToString(this, 0, res));
        }

        public Node toRoot()
        {
            if(parent == null)
            {
                return this;
            } else
            {
                return this.parent.toRoot();
            }
        }
    }
}
