namespace TriatlonProject.Utilities.Extensions
{
    public static class FileExtensions
    {


      
        public static bool CheckFileSize(this IFormFile file, double size)
        {
            return file.Length / 1024 < size;
        }
        public static bool CheckContentType(this IFormFile file, string contentType)
        {
            // Null check yapalım
            if (file == null || string.IsNullOrEmpty(contentType))
            {
                return false;
            }

            return file.ContentType.Contains(contentType);
        }


        public async static Task<string>
            SaveAsync(this IFormFile file, string root)
        {
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string resultPath = Path.Combine(root, fileName);
            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }

    }
}
