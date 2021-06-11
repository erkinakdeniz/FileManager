using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_FormApp
{
   public interface IFile<T>
    {
        List<T> AddFiles(IFormFile[] files, string folderPath, bool isRandomFileName = true);
        List<T> AddFile(IFormFile file, string path, bool isRandomFileName = true);
        Task<List<T>> AddFilestoAsync(IFormFile[] files, string path, bool isRandomFileName = true);
        void UpdateFile(IFormFile file, string updateFilePath);
        void DeleteFile(string filePath);
        void DeleteFiles(string[] filePath);
        void DeleteDirectory(string directoryPath);

    }
}
