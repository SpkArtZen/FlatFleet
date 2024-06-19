using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatFleet.Models
{

    public class FileItem
    {
        public string? Title { get; set; }
     
        // In Bytes
        public long Size { get; set; }

        public string GetFormatedSize()
        {
            double sizeInKilobytes = Size / 1024.0;
            double sizeInMegabytes = sizeInKilobytes / 1024.0;

            sizeInKilobytes = Math.Round(sizeInKilobytes, 1);
            sizeInMegabytes = Math.Round(sizeInMegabytes, 2);

            bool displayInKilobytes = sizeInKilobytes < 100;

            return $"{ (displayInKilobytes ? sizeInKilobytes : sizeInMegabytes) } { (displayInKilobytes ? "KB" : "MB") }";
        }
    }
}
