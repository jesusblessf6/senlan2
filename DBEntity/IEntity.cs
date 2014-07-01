using System;
using System.Collections.Generic;

namespace DBEntity
{
    public interface IEntity
    {
        int Id { get; }

        byte[] Ver { get; }

        ICollection<string> EagerLoadProperties { get; }

        bool IsDeleted { get; }

        DateTime? Created { get; }
        DateTime? Updated { get; }
        int? CreatedBy { get; }
        int? UpdatedBy { get; }
    }
}