using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class ImageTool
{

    const int ImageMinimumBytes = 512;

    /// <summary>
    /// Check Form File(image) 
    /// </summary>
    /// <param name="file">From File Image</param>
    /// <returns>
    ///Valid Image = True
    /// </returns>
    public async Task<bool> CheckFormImageAsync(IFormFile file)
    {
        return await Task.Run(() =>
        {
            //Check Image Meme Type 
            string contentType = file.ContentType.ToLower();
            if (contentType != "image/jpg" &&
                            contentType != "image/jpeg" &&
                            contentType != "image/pjpeg" &&
                            contentType != "image/gif" &&
                            contentType != "image/x-png" &&
                            contentType != "image/png")
            {
                return false;
            }

            //Check Image Extention 
            string extention = Path.GetExtension(file.FileName);
            if (extention != ".jpg" && extention != ".png" && extention != ".gif" && extention != ".jpeg")
                return false;

            //Attemped To Read File And Check The First Bytes
            try
            {
                if (!file.OpenReadStream().CanRead)
                    return false;
                if (file.Length < ImageMinimumBytes)
                    return false;

                byte[] buffer = new byte[512];
                file.OpenReadStream().Read(buffer, 0, 512);
                string content = Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }


            }
            catch
            {
                return false;
            }

            //  Try to instantiate new Bitmap, if .NET will throw exception
            //  we can assume that it's not a valid image

            try
            {
                using (var bitmap = new Bitmap(file.OpenReadStream()))
                {
                }
            }
            catch
            {
                return false;
            }

            return true;
        });
    }


}