using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stima2
{
    public class FileCrawler
    {
        public List<string> results = new List<string>();
        public List<string> fs_path = new List<string>();

		public void BFS(string path, Boolean isFindAll, string search_file)
		{
			Queue<string> paths = new Queue<string>();
			paths.Enqueue(path);
			Boolean isFound = false;
			while ((paths.Count > 0) && (!isFound))
			{
				string newpath = paths.Dequeue();
				//			bfs_path.Add(newpath);
				DirectoryInfo dir = new DirectoryInfo(newpath);
				FileInfo[] files = dir.GetFiles();
				foreach (FileInfo file in files)
				{
					if (!isFound)
					{
						fs_path.Add(file.FullName);
						if (file.Name == search_file)
						{
							results.Add(file.FullName);
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
						fs_path.Add(folder);
						paths.Enqueue(folder);
					}
				}
			}
		}
		public void DFS(string path, Boolean isFindAll, string search_file)
		{
			Stack<string> paths = new Stack<string>();
			paths.Push(path);
			Boolean isFound = false;
			while ((paths.Count > 0) && (!isFound))
			{
				string newpath = paths.Pop();
				fs_path.Add(newpath);
				DirectoryInfo dir = new DirectoryInfo(newpath);
				FileInfo[] files = dir.GetFiles();
				foreach (FileInfo file in files)
				{
					if (!isFound)
					{
						fs_path.Add(file.FullName);
						if (file.Name == search_file)
						{
							results.Add(file.FullName);
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
						paths.Push(folder);
					}
				}
			}
			// Hilangin Root Path
			fs_path.RemoveAt(0);
		}

	}
}
