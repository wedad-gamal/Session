namespace MVC.Presentation.Utilies;

public static class DocumentSettings
{
    public static async Task<string> UploadFile(IFormFile file, string folderName)
    {
        var fileName = Path.GetFileName(file.FileName);
        var filePath = Path.Combine("wwwroot", folderName, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return filePath.Substring(8);
    }

    public static async Task DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
            File.Delete(filePath);
    }
}
