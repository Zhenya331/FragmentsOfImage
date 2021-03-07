using Server.Services.IService;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Server.Controllers
{
    public class ImageController : ApiController
    {
        public IFragments Fragments { get; set; }

        public ImageController(IFragments _Fragments)
        {
            Fragments = _Fragments;
        }

        public async Task<IHttpActionResult> Post(int rows, int columns)
        {
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            byte[] fileArray = await provider.Contents[0].ReadAsByteArrayAsync();

            var img = Image.FromStream(new MemoryStream(fileArray));

            var result = await Task.Run(() => Fragments.GetFragments(img, rows, columns));

            return Ok(result);
        }
    }
}