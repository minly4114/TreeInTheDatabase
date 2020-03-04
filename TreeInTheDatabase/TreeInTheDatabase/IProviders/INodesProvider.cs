using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeInTheDatabase.Models;

namespace TreeInTheDatabase.IProviders
{
    public interface INodesProvider
    {
        IQueryable<Node> GetNodes();
        Task InsertAsync(Node node);
        Task UpdateAsync(Node node);
        Task RemoveAsync(Node node);
    }
}
