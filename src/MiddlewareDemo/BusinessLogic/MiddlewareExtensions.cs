using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace MiddlewareDemo.BusinessLogic
{
    public static class MiddlewareExtensions
    {
        public static void GetGalleryImage(this IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.StartsWith("/Gallery/GetGalleryImage"))
                {
                    var id = context.Request.Path.Value.Substring(context.Request.Path.Value.LastIndexOf("/") + 1);
                    var filePath = env.ContentRootPath + @"\wwwroot\images\" + id;
                    var byteArray = WriteImage(filePath);
                    await context.Response.Body.WriteAsync(byteArray, 0, byteArray.Length);
                }
                else
                {
                    await next();
                }
            });
        }

        private static byte[] WriteImage(string filePath)
        {
            var b = BusinessMethods.ResizeBitmap(filePath, new Size { Width = 200, Height = 200 });
            return BusinessMethods.ToByteArray(b, ImageFormat.Jpeg);
        }
    }
}
