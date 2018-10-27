using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopCritter.Models
{
    public class WindowFrame
    {
        public IntPtr Handel { get; set; }
        public string Title { get; set; }
        public int Left { get; set; }
        public int Right { get;set; }
        public int Top { get; set; }
        public int Bottom { get; set; }

    }
}
