using Common.Dto;
using Service.Services;

public class ImageUploadService
{
    public string UploadImage(string base64Image, string folderPath, string fileExtension)
    {
        string fileName = $"{Guid.NewGuid()}.{fileExtension}";
        var filePath = Path.Combine(folderPath, fileName);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        byte[] imageBytes = Convert.FromBase64String(base64Image);
        System.IO.File.WriteAllBytes(filePath, imageBytes);

        return filePath;
    }

    //public string EncodeImageToBase64(string imagePath)
    //{
    //    try
    //    {
    //        byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
    //        return Convert.ToBase64String(imageBytes);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error encoding image: {ex.Message}");
    //        return null;
    //    }



    //}
}
