﻿namespace NetGroupInventory.Domain.Entities
{
    public interface ITraceEntity
    {
        string CreatedBy { get; set; }
        DateTimeOffset CreatedDateTime { get; set; }
        string ModifiedBy { get; set; }
        DateTimeOffset? ModifiedDateTime { get; set; }
    }
}
