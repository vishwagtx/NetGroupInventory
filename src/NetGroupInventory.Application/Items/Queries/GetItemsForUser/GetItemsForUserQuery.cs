﻿using MediatR;

namespace NetGroupInventory.Application.Items.Queries.GetItemsForUser
{
    public class GetItemsForUserQuery : IRequest<IList<ViewItemDto>>
    {
        public string Keyword { get; set; }
    }
}
