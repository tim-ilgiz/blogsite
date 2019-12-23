using blogsite.Models.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace blogsite.Models
{
    public class ItemRepository : IItemRepository
    {
        private IWebHostEnvironment _webHostEnvironment;

        private readonly ApiDbContext _appDbContext;
        public static string GetPath { get; set; }

        public ItemRepository(ApiDbContext apiDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = apiDbContext;
            _webHostEnvironment = webHostEnvironment;
            GetPath = _webHostEnvironment.ContentRootPath;
        }

        private static string GetImageToBase64(long id)
        {
            var image = Path.Combine(GetPath, $"images\\imageId{id}.png");

            if (!File.Exists(image)) return "";
            return "data:image/jpeg;base64," + Convert.ToBase64String(System.IO.File.ReadAllBytes(image));
        }

        public async Task<IReadOnlyList<Item>> GetItems(long id)
        {
            var items = await _appDbContext.Items.Where(i => i.ParentId == id).Select(i => new Item
            {
                Id = i.Id,
                Name = i.Name,
                Image = GetImageToBase64(i.Id),
                LinkUrl = i.LinkUrl,
                ParentId = i.ParentId,
                Click = i.Click
            }).AsNoTracking().ToListAsync();

            return items;
        }

        public async Task<IReadOnlyList<Folder>> GetFolders()
        {
            return await _appDbContext.Folders.AsNoTracking().ToListAsync();
        }

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public async Task EditItem(Item item)
        {
            var editItem = await _appDbContext.Items.SingleAsync(i => i.Id == item.Id);

            editItem.Name = item.Name;
            editItem.LinkUrl = item.LinkUrl;
            editItem.Image = item.Image;
            editItem.Click = item.Click;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Item> CreateItem(Item item)
        {
            await _appDbContext.Items.AddAsync(item);
            await _appDbContext.SaveChangesAsync();

            return item;
        }

        public async Task DeleteItem(long id)
        {
            var removeItem = await _appDbContext.Items
                                                .AsNoTracking()
                                                .SingleAsync(i => i.Id == id);
            _appDbContext.Remove(removeItem);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Item> GetItem(long id) => await _appDbContext.Items
                                                    .SingleAsync(i => i.Id == id);
    }
}
