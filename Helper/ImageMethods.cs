namespace AspDotNetMVC.Helper
{
    public class ImageMethods
    {
        public static string AddFile(IWebHostEnvironment AppEnvironment, IFormFile uploadedFile)
        {
            string ImgName = "defailt.jpg";

            if (uploadedFile != null)
            {
                string fileName = uploadedFile.FileName;
                string path = AppEnvironment.WebRootPath;
                string extension = Path.GetExtension(fileName);
                string name = Path.GetFileNameWithoutExtension(fileName);

                string uniqName = Guid.NewGuid().ToString();

                ImgName = $"{name}_{uniqName}{extension}";

                string pathToImg = Path.Combine(path, "image", ImgName);

                using (var fs = new FileStream(pathToImg, FileMode.Create))
                {
                    uploadedFile.CopyTo(fs);
                }
            }

            return ImgName;
        }
    }
}
