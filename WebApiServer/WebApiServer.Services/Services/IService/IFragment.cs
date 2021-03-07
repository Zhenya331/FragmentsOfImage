using Server.Models;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Services.IService
{
    public interface IFragments
    {
        IEnumerable<Fragment> GetFragments(Image image, int rows, int columns);
    }
}
