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
        public Info AddFile(IFormFile file, string path, bool isRandomFileName = true)
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

                using (var stream = new FileStream(folderPath + @"\" + newFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                myInfo.FileName = newFileName;
                myInfo.FolderPath = folderPath;
                myInfo.FullFolderPath = IsPath + @"\" + newFileName;
                myInfo.CreationTimeUtc = fileInfo.CreationTimeUtc;
                myInfo.Exist = fileInfo.Exists;
                


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
               
            }

            return myInfo;
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
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                foreach (var deleteFilePath in filePath)
                {
                    if (File.Exists(deleteFilePath))
                    {
                       
                        File.Delete(deleteFilePath);
                    }
                }
            }
        }
        public async Task<Info> AddImageandThumbAsync(IFormFile file, string path,int thumbWidth=250,int thumbHeight=250, string
predecessorName="250x250")
        {
            var fileInfo = new FileInfo(file.FileName);
            var newFileName = $@"{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";
            string filePath = path + newFileName;
            string newPath = $@"{Environment.CurrentDirectory}\wwwroot\{filePath}";
            Info myinfo = new Info();
            if (file.Length > 0 && !File.Exists(newPath))
            {
                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                
                myinfo.FileDirectory = PerformImageResize(newPath, thumbWidth, thumbHeight, path, predecessorName).FileDirectory;
                myinfo.FileName = newFileName;
                myinfo.CreationTimeUtc = fileInfo.CreationTimeUtc;
                myinfo.Exist = fileInfo.Exists;
                myinfo.FullFolderPath = newPath;
                myinfo.Lenght = fileInfo.Length;
               
            }
            
            return myinfo;
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
        /// <summary>  
        /// Save image as jpeg  
        /// </summary>  
        /// <param name="path">path where to save</param>  
        /// <param name="img">image to save</param>  
        public static void SaveJpeg(string path, Image img)
        {
            var qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            var jpegCodec = GetEncoderInfo("image/jpeg");

            var encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(path, jpegCodec, encoderParams);

        }
        /// <summary>  
        /// Save image  
        /// </summary>  
        /// <param name="path">path where to save</param>  
        /// <param name="img">image to save</param>  
        /// <param name="imageCodecInfo">codec info</param>  
        public static void Save(string path, Image img, ImageCodecInfo imageCodecInfo)
        {
            var qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);

            var encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(path, imageCodecInfo, encoderParams);
        }
        /// <summary>  
        /// get codec info by mime type  
        /// </summary>  
        /// <param name="mimeType"></param>  
        /// <returns></returns>  
        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            return ImageCodecInfo.GetImageEncoders().FirstOrDefault(t => t.MimeType == mimeType);
        }
        /// <summary>  
        /// resize an image and maintain aspect ratio  
        /// </summary>  
        /// <param name="image">image to resize</param>  
        /// <param name="newWidth">desired width</param>  
        /// <param name="maxHeight">max height</param>  
        /// <param name="onlyResizeIfWider">if image width is smaller than newWidth use image width</param>  
        /// <returns>resized image</returns>  
        public static Image Resize(Image image, int newWidth, int maxHeight, bool onlyResizeIfWider)
        {
            if (onlyResizeIfWider && image.Width <= newWidth) newWidth = image.Width;

            var newHeight = image.Height * newWidth / image.Width;
            if (newHeight > maxHeight)
            {
                // Resize with height instead  
                newWidth = image.Width * maxHeight / image.Height;
                newHeight = maxHeight;
            }

            var res = new Bitmap(newWidth, newHeight);

            using (var graphic = Graphics.FromImage(res))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return res;
        }
        /// <summary>  
        /// Crop an image   
        /// </summary>  
        /// <param name="img">image to crop</param>  
        /// <param name="cropArea">rectangle to crop</param>  
        /// <returns>resulting image</returns>  
        public static Image Crop(Image img, Rectangle cropArea)
        {
            var bmpImage = new Bitmap(img);
            var bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            return bmpCrop;
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        //The actual converting function  
        public static string GetImage(object img)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
        }
        /// <summary>  
        /// Image Resize  
        /// </summary>  
        /// <param name="dbPath">value to keep in database </param>  
        /// <param name="pFilePath">file path</param>  
        /// <param name="pWidth">resize width</param>  
        /// <param name="pHeight">resize height</param> 
        /// <param name="pre_ad">predecessor name</param> 
        /// <returns>resulting image</returns>  
        public static Info PerformImageResize(string pFilePath, int pWidth, int pHeight, string dbPath, string pre_ad)
        {
            string[] parts = pFilePath.Split(@"\");
            string path = "";
            for (int i = 0; i < parts.Length - 1; i++)
            {
                path += parts[i] + @"\";
            }
            string fileName = parts[parts.Length - 1];
            System.Drawing.Image imgBef;
            imgBef = System.Drawing.Image.FromFile(pFilePath);


            System.Drawing.Image _imgR;
            _imgR = Resize(imgBef, pWidth, pHeight, true);



            string newFileName = pre_ad + fileName;
            //Save JPEG  
            SaveJpeg(path + newFileName, _imgR);
            Info myinfo = new Info();
            myinfo.FileDirectory= dbPath + newFileName;
            return myinfo;

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
