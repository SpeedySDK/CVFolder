using System;
using System.IO;

namespace FileTest
{
    class Program
    {
        static void Main(string[] args)
        {

            int candidateid;
            bool dir_exists;
            int i;
            string path = @"C:\Users\tiago.rsantos\Desktop\CVFolderTest\";
            int num_folders = 9999;


            Console.WriteLine("Insert Candidate ID: ");
            candidateid = Convert.ToInt32(Console.ReadLine());

            DirectoryInfo[] di = getDirectoriesName(path);

            i = di.Length-1;

            foreach (var item in di)
            {
                dir_exists = VerifyGenDir(candidateid, item.Name);
                if (dir_exists)
                {
                    MakeDir(candidateid, item.Name, path);
                    Console.WriteLine("Folder created successfully");
                    return;
                }
                
            }

            string newfoldername = MakeGenDir(di[i].Name, path, num_folders);
            MakeDir(candidateid, newfoldername, path);
            Console.WriteLine("Generic Folder and Candidate Folder created successfully");

        }

        public static DirectoryInfo[] getDirectoriesName(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            // Get a reference to each directory in that directory.
            DirectoryInfo[] diArr = di.GetDirectories();

            return diArr;
        }

        public static bool VerifyGenDir(int candidateid, string foldername)
        {
            string separator = " - ";
            string[] strlist = foldername.Split(separator);

            int min_candidateid = Convert.ToInt32(strlist[0]);
            int max_candidateid = Convert.ToInt32(strlist[1]);

            if (candidateid >= min_candidateid && candidateid <= max_candidateid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string MakeGenDir(string lastfoldername, string path, int num_folders)
        {
            string separator = " - ";
            string[] strlist = lastfoldername.Split(separator);

            int min_candidateid = Convert.ToInt32(strlist[0]);
            int max_candidateid = Convert.ToInt32(strlist[1]);

            min_candidateid = max_candidateid + 1;
            max_candidateid = min_candidateid + num_folders;

            string newfoldername = min_candidateid + " - " + max_candidateid;
            
            string newfolderpath = path + newfoldername;

            Directory.CreateDirectory(newfolderpath);

            return newfoldername;
        }

        public static void MakeDir (int candidateid, string foldername, string path)
        {
            Directory.CreateDirectory(path + foldername + @"\" + candidateid);
        }

    }
}

