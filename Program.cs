using System;
using System.IO;
public class Program
{
	static void Main(string[] args)
	{
		Program searching = new Program();
	}
	public Program()
	{
		string path = @"D:\Kuliah";     //Contoh, nanti sesuaikan input
		string cari = "16621279_2021-10-08-180805.zip";     //Contoh, nanti sesuaikan input
		BFS(path, false, cari);
		DFS(path, false, cari);
	}

	static void BFS(string path, Boolean isFindAll, string search_file)
	{
		Queue<string> paths = new Queue<string>();
		List<string> results = new List<string>();
		List<string> bfs_path = new List<string>();
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
					bfs_path.Add(file.FullName);
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
					bfs_path.Add(folder);
					paths.Enqueue(folder);
				}
			}
		}
	}

	static void DFS(string path, Boolean isFindAll, string search_file)
	{
		Stack<string> paths = new Stack<string>();
		List<string> results = new List<string>();
		List<string> bfs_path = new List<string>();
		paths.Push(path);
		Boolean isFound = false;
		while ((paths.Count > 0) && (!isFound))
		{
			string newpath = paths.Pop();
			bfs_path.Add(newpath);
			DirectoryInfo dir = new DirectoryInfo(newpath);
			FileInfo[] files = dir.GetFiles();
			foreach (FileInfo file in files)
			{
				if (!isFound)
				{
					bfs_path.Add(file.FullName);
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
		foreach (string res in results)
		{
			Console.WriteLine(res);
		}
		foreach (string bfspath in bfs_path)
		{
			Console.WriteLine(bfspath);
		}

	}
}
