using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stima2
{
    public class FolderCrawler
    {
        public List<string> results = new List<string>();
        public List<string> fs_path = new List<string>();
		public List<string> nt_path = new List<string> { };
		public Node f_node = new("root", null);

		public void BFS(string path, Boolean isFindAll, string search_file)
		{
			Queue<string> paths = new Queue<string>();
			//Node f_node = new("root", null);
			paths.Enqueue(path);
			Boolean isFound = false;
			Node tmp;
			while ((paths.Count > 0) && (!isFound))
			{
				string newpath = paths.Dequeue();
				tmp = f_node.AddFolderNode(newpath);
				tmp.tr = true;
				fs_path.Add(newpath);
				DirectoryInfo dir = new DirectoryInfo(newpath);
				FileInfo[] files = dir.GetFiles();
				foreach (FileInfo file in files)
				{
					if (!isFound)
					{
						fs_path.Add(file.FullName);
						tmp = f_node.AddFolderNode(file.FullName);
						if (file.Name == search_file)
						{
							results.Add(file.FullName);
							tmp.SetFound();
							if (!isFindAll)
							{
								isFound = true;
							}
						}
					}
				}
				if (!isFound)
				{
					//Add subfolder from current folder
					string[] folders = Directory.GetDirectories(newpath);
					foreach (var folder in folders)
					{
						//fs_path.Add(folder);
						f_node.AddFolderNode(folder).tr = false;
						paths.Enqueue(folder);
					}
				}
			}
			// Hilangin Root Path
			fs_path.RemoveAt(0);
			// Yang di queue tapi belum di-traverse
			nt_path = paths.ToList();
		}
		public void DFS(string path, Boolean isFindAll, string search_file)
		{
			Stack<string> paths = new Stack<string>();
			//Node f_node = new("root", null);
			paths.Push(path);
			Boolean isFound = false;
			Node tmp;
			while ((paths.Count > 0) && (!isFound))
			{
				string newpath = paths.Pop();
				tmp = f_node.AddFolderNode(newpath);
				tmp.tr = true;
				fs_path.Add(newpath);
				DirectoryInfo dir = new DirectoryInfo(newpath);
				FileInfo[] files = dir.GetFiles();
				foreach (FileInfo file in files)
				{
					if (!isFound)
					{
						fs_path.Add(file.FullName);
						tmp = f_node.AddFolderNode(file.FullName);
						if (file.Name == search_file)
						{
							results.Add(file.FullName);
							tmp.SetFound();
							if (!isFindAll)
							{
								isFound = true;
							}
						}
					}
				}
				if (!isFound)
				{
					//Add subfolder from current folder
					string[] folders = Directory.GetDirectories(newpath);
					foreach (var folder in folders.Reverse())
					{
						f_node.AddFolderNode(folder).tr = false;
						paths.Push(folder);
					}
				}
			}
			// Hilangin Root Path
			fs_path.RemoveAt(0);
			// Yang di queue tapi belum di-traverse
			nt_path = paths.ToList();
		}
	}
}
