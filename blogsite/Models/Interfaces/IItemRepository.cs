using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace blogsite.Models.Interfaces
{
    public interface IItemRepository
    {
        Task<IReadOnlyList<Item>> GetItems(long parentId);

        Task<IReadOnlyList<Folder>> GetFolders();

        void AddItem(Item item);

        Task EditItem(Item item);

        Task EditFolder(Folder folder);

        Task<Item> GetItem(long id);

        Task<Item> CreateItem(Item item);

        Task<Folder> CreateFolder(Folder folder);

        Task DeleteItem(long id);

        Task DeleteFolder(long id);
    }
}
