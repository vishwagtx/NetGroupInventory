﻿using NetGroupInventory.Domain.Entities;
using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Application.Interfaces.Repositories
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<IList<Inventory>> GetByUserId(string userId);

        Task<IList<Inventory>> GetByKeywordAndUserId(string keyword, string userId);

        Task<Inventory> GetByIdWithDetail(int id);

        Task<IList<GroupEntity>> GetUserWiseCount();
    }
}
