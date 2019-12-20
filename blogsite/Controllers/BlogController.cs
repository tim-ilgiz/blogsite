using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using blogsite.Models;
using blogsite.Models.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace blogsite.Controllers
{
    [Route("api/Repository")]
    public class BlogController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private IWebHostEnvironment _webHostEnvironment;

        public BlogController(IItemRepository itemRepository, IWebHostEnvironment webHostEnvironment)
        {
            this._itemRepository = itemRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ActionResult> Index()
        {
            var items = await _itemRepository.GetItems(7);

            return View(items);
        }

        [HttpGet]
        public async Task<IEnumerable<Folder>> Get()
        {
            return await _itemRepository.GetFolders();
        }

        [HttpGet]
        [Route(nameof(GetItemsForThisParent))]
        public async Task<IEnumerable<Item>> GetItemsForThisParent(long parentId)
        {
            return await _itemRepository.GetItems(parentId);
        }

        [HttpGet]
        [Route(nameof(SaveImage))]
        public string SaveImage()
        {
            var image = Path.Combine(_webHostEnvironment.ContentRootPath, "images/cat.jpg");
            var imageToBase = Convert.ToBase64String(System.IO.File.ReadAllBytes(image));

            return imageToBase;
        }


        [HttpPost]
        [Produces("application/json")]
        [Route(nameof(OnAddItem))]
        public async Task<Item> OnAddItem([FromBody] Item item) {
            var jsonItem = await _itemRepository.CreateItem(item);

            return jsonItem;
        }

        [HttpDelete]
        [Route(nameof(OnDeleteItem))]
        public async Task OnDeleteItem(long id)
        {
            await _itemRepository.DeleteItem(id);
        }

        [HttpPost]
        [Route(nameof(OnEditItem))]
        public async Task OnEditItem(Item item)
        {
            try
            {
                await _itemRepository.EditItem(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
