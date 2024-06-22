using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Data;
using TasksAPI.Models;

namespace TasksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class APIController(DataContext db) : ControllerBase
    {
        private readonly DataContext _db = db;

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Blob blob) // ye Post method hamara IActionResult hi hoga kunki jab ye return karenge file/jab ham post karenge apni file hamari db me, IActionResult Task return Karta hai par Task kuch return nahi karta isliye hamne yahan Task ka use kia
        {//here our img is uploaded on azure acc using Azure.Storage.Blobs. <- commened item not posible to navigate show a error msg can't navigate to under in caret
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=blobstoragephotos;AccountKey=dNLv0NmhMFHm7BzBoWljQcxaMq6CohmQBU6k3G3uQjrSKEeiBDFCDi0LY9+qwJGo1eLNl+NiQg3J+AStxsBisg==;EndpointSuffix=core.windows.net";
            string containerName = "blobphotos"; // hamare azure acc me mul container hone ke karan hamein yahan apna container specify karna padta hai
            BlobContainerClient containerClient = new(connectionString, containerName);// BlobContainerClient class is contain connectionString and containerName just like SqlConnection class of ADO.NET for using creating constr and also use communicate purpose
            BlobClient blobClient = containerClient.GetBlobClient(blob.BlobImage.FileName); // GetBlobClient used for getting Blob Client with its file name, here our BlobClient is CategoryImage that's it simple
            MemoryStream ms = new(); // jo img file ham apne computer se pick karte hain us img ko hamein apne MemoryStream me save karna hota hai by coping our img file into MemoryStream simple
            await blob.BlobImage.CopyToAsync(ms); // yhan hamne apni img file ko MemoryStream me copy kar diya
            ms.Position = 0; // hamein yahan MemoryStream ki position dekhni hogi bydefault same container ke ander 0 position par honi chaiye hamri imgs saari ki saari
            await blobClient.UploadAsync(ms);
            blob.BlobImagePath = blobClient.Uri.AbsoluteUri; // for getting absolte Uri from blobClient and saving also only pick just uploaded uri only every time bec just i uploaded so na //hamara path hamein db me save karna hai jo ki hamesha file upload karne ke baad banta hai
            await _db.Blobs.AddAsync(blob); // For Image Url Saving in DB Code
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created); // when we Post data to Web Server we req to use 201 Status Code
        }
    }
}
