using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_Util
{
    public class FileManager : IFile<Info>
    {
        public List<Info> AddFiles(IFormFile[] files, string path, bool isRandomFileName = true)
        {
            List<Info> infos = new List<Info>();

            foreach (var file in files)
            {
                Info myInfo = new Info();
                string[] fileDirectoryArray = file.FileName.Split("/");
                string fileDirectory = "";
                fileDirectoryArray[fileDirectoryArray.Length - 1] = "";
                foreach (var item in fileDirectoryArray)
                {
                    if (item != "")
                        fileDirectory += item + @"\";
                }
                string IsPath = $@"{Environment.CurrentDirectory}\wwwroot\{path}{fileDirectory}";
                string folderPath = $@"{path}{fileDirectory}";
                if (Directory.Exists(IsPath))
                {
                    var fileInfo = new FileInfo(file.FileName);
                    var newFileName = "";
                    if (isRandomFileName)
                    {
                        newFileName = $@"{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";
                    }
                    else { newFileName = fileInfo.Name + fileInfo.Extension; }

                    using (var stream = new FileStream(IsPath + @"\" + newFileName, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    myInfo.FileName = newFileName;
                    myInfo.FolderPath = folderPath;
                    myInfo.FullFolderPath = IsPath + @"\" + newFileName;
                    myInfo.CreationTimeUtc = fileInfo.CreationTimeUtc;
                    myInfo.Exist = fileInfo.Exists;
                    infos.Add(myInfo);


                }
                else
                {
                    Directory.CreateDirectory(IsPath);
                    var fileInfo = new FileInfo(file.FileName);

                    var newFileName = "";
                    if (isRandomFileName)
                    {
                        newFileName = $@"{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";
                    }
                    else { newFileName = fileInfo.Name + fileInfo.Extension; }
                    using (var stream = new FileStream(IsPath + @"\" + newFileName, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    myInfo.FileName = newFileName;
                    myInfo.FolderPath = folderPath;
                    myInfo.FullFolderPath = IsPath + @"\" + newFileName;
                    myInfo.CreationTimeUtc = fileInfo.CreationTimeUtc;
                    myInfo.Exist = fileInfo.Exists;
                    infos.Add(myInfo);
                }
            }

            return infos;
        }
        public async Task<List<Info>> AddFilestoAsync(IFormFile[] files, string path, bool isRandomFileName = true)
        {
            List<Info> infos = new List<Info>();

            foreach (var file in files)
            {
                Info myInfo = new Info();
                string[] fileDirectoryArray = file.FileName.Split("/");
                string fileDirectory = "";
                fileDirectoryArray[fileDirectoryArray.Length - 1] = "";
                foreach (var item in fileDirectoryArray)
                {
                    if (item != "")
                        fileDirectory += item + @"\";
                }
                string IsPath = $@"{Environment.CurrentDirectory}\wwwroot\{path}{fileDirectory}";
                string folderPath = $@"{path}{fileDirectory}";
                if (Directory.Exists(IsPath))
                {
                    var fileInfo = new FileInfo(file.FileName);
                    var newFileName = "";
                    if (isRandomFileName)
                    {
                        newFileName = $@"{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";
                    }
                    else { newFileName = fileInfo.Name + fileInfo.Extension; }

                    using (var stream = new FileStream(IsPath + @"\" + newFileName, FileMode.Create))
                    {
                       await file.CopyToAsync(stream);
                    }
                    myInfo.FileName = newFileName;
                    myInfo.FolderPath = folderPath;
                    myInfo.FullFolderPath = IsPath + @"\" + newFileName;
                    myInfo.CreationTimeUtc = fileInfo.CreationTimeUtc;
                    myInfo.Exist = fileInfo.Exists;
                    infos.Add(myInfo);


                }
                else
                {
                    Directory.CreateDirectory(IsPath);
                    var fileInfo = new FileInfo(file.FileName);

                    var newFileName = "";
                    if (isRandomFileName)
                    {
                        newFileName = $@"{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";
                    }
                    else { newFileName = fileInfo.Name + fileInfo.Extension; }
                    using (var stream = new FileStream(IsPath + @"\" + newFileName, FileMode.Create))
                    {
                       await file.CopyToAsync(stream);
                    }
                    myInfo.FileName = newFileName;
                    myInfo.FolderPath = folderPath;
                    myInfo.FullFolderPath = IsPath + @"\" + newFileName;
                    myInfo.CreationTimeUtc = fileInfo.CreationTimeUtc;
                    myInfo.Exist = fileInfo.Exists;
                    infos.Add(myInfo);
                }
            }

            return infos;
        }
        public List<Info> AddFile(IFormFile file, string path, bool isRandomFileName = true)
        {
            List<Info> infos = new List<Info>();

            Info myInfo = new Info();
            string[] fileDirectoryArray = file.FileName.Split("/");
            string fileDirectory = "";
            fileDirectoryArray[fileDirectoryArray.Length - 1] = "";
            foreach (var item in fileDirectoryArray)
            {
                if (item != "")
                    fileDirectory += item + @"\";
            }
            string IsPath = $@"{Environment.CurrentDirectory}\wwwroot\{path}{fileDirectory}";
            string folderPath = $@"{path}{fileDirectory}";
            if (Directory.Exists(IsPath))
            {
                var fileInfo = new FileInfo(file.FileName);
                var newFileName = "";
                if (isRandomFileName)
                {
                    newFileName = $@"{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";
                }
                else { newFileName = fileInfo.Name + fileInfo.Extension; }

                using (var stream = new FileStream(folderPath + @"\" + newFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                myInfo.FileName = newFileName;
                myInfo.FolderPath = folderPath;
                myInfo.FullFolderPath = IsPath + @"\" + newFileName;
                myInfo.CreationTimeUtc = fileInfo.CreationTimeUtc;
                myInfo.Exist = fileInfo.Exists;
                infos.Add(myInfo);


            }
            else
            {
                Directory.CreateDirectory(IsPath);
                var fileInfo = new FileInfo(file.FileName);

                var newFileName = "";
                if (isRandomFileName)
                {
                    newFileName = $@"{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";
                }
                else { newFileName = fileInfo.Name + fileInfo.Extension; }
                using (var stream = new FileStream(folderPath + @"\" + newFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                myInfo.FileName = newFileName;
                myInfo.FolderPath = folderPath;
                myInfo.FullFolderPath = IsPath + @"\" + newFileName;
                myInfo.CreationTimeUtc = fileInfo.CreationTimeUtc;
                myInfo.Exist = fileInfo.Exists;
                infos.Add(myInfo);
            }

            return infos;
        }
        public void DeleteDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                string[] files = Directory.GetFiles(directoryPath);
                string[] dirs = Directory.GetDirectories(directoryPath);

                foreach (string file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                foreach (string dir in dirs)
                {
                    DeleteDirectory(dir);
                }

                Directory.Delete(directoryPath, false);
            }
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                File.Delete(filePath);
            }
        }

        public void DeleteFiles(string[] filePath)
        {
            if (filePath.Length > 0)
            {
                foreach (var deleteFilePath in filePath)
                {
                    if (File.Exists(deleteFilePath))
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        File.Delete(deleteFilePath);
                    }
                }
            }
        }

        public void UpdateFile(IFormFile file, string updateFilePath)
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            if (updateFilePath.Length > 0)

                using (var stream = new FileStream(updateFilePath, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(stream);

                }
        }


    }
   public class Info
    {
       public string FolderPath { get; set; }
        public string FullFolderPath { get; set; }
        public string FileDirectory { get; set; }
        public string FullName { get; set; }
        public string FileName { get; set; }
        public long Lenght { get; set; }
        public bool Exist { get; set; }
        public DateTime CreationTimeUtc { get; set; }
    }
}
