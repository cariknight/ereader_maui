using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ereader.Models
{
    public class ReadingSettings
    {
        public double FontSize { get; set; } = 18;
        public double LineSpacing { get; set; } = 1.5;
        public double MarginTop { get; set; } = 24;
        public double MarginBottom { get; set; } = 24;
        public double MarginLeft { get; set; } = 24;
        public double MarginRight { get; set; } = 24;
        public string FontFamily { get; set; } = "OpenSans";
        public string Theme { get; set; } = "Light";
        public double Brightness { get; set; } = 1.0;
    }
}
