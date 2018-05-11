using System;
using System.IO;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;

namespace LifeLike.Web.Utils
{
    public class ImageHelper
    {
        public static string GetExif(string filePath)
        {
            using (var input = File.OpenRead(filePath))
            {
                var image = new Image(input);
            }
            //Main Camera huehue
            return "Nikon D7000";
        }
        public static Result GetThumb(string filePath,string outputPath)
        {
            try
            {
                using (var input = File.OpenRead(filePath))
                {
                    using (var output = File.OpenWrite(outputPath))
                    {
                        var image = new Image(input);
                        image.Save(output);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Result.Failed;
            }            
            return Result.Success;
        }
    }

    public class Image
    {
        public Image(FileStream input)
        {
            throw new NotImplementedException();
        }

        public void Save(FileStream output)
        {
            throw new NotImplementedException();
        }
    }
}