using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Tekno.UTILITY
{
    public class ImageUploader
    {


        public static string UploadImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                var uniqueName = Guid.NewGuid();
                //~/Content/Images=> ~ işaretini kaldırıyoruz.
                serverPath = serverPath.Replace("~", string.Empty);

                //denemeGorsel.JPG
                //090235d7-ed6c-4aa0-8f09-d0a5df311f5f.JPG
                /*
             */

                var fileArray = file.FileName.Split('.');
                /*
             [0]=>denemeGorsel
             [1]=>JPG
             */

                string extension = fileArray[fileArray.Length - 1].ToLower();

                var fileName = uniqueName + "." + extension;

                if (extension == "jpg" || extension == "jpeg" || extension == "png" || extension == "gif")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "1";
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }
                else
                {
                    return "2";
                }


            }
            else
            {
                return "0";
            }
        }


    }
}
