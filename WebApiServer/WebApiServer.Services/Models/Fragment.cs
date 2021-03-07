using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class Fragment
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public byte[] FragmentData { get; set; }
    }
}