using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeInTheDatabase.IProviders;
using TreeInTheDatabase.Models;

namespace TreeInTheDatabase.Providers
{
    public class NodesProvider : INodesProvider
    {
        private readonly PostgresContext _context;
        public NodesProvider(PostgresContext context)
        {
            _context = context;
        }
        public async Task RemoveAsync(Node node)
        {
            _context.Nodes.Remove(node);
            await _context.SaveChangesAsync();
        }
        public async Task InsertAsync(Node node)
        {
            await _context.Nodes.AddAsync(node);
            await _context.ChangesNodes.AddAsync(new ChangesNode
            {
                DateChanges = DateTime.Now,
                Node = node,
                Parameters = node.Parameters
            });
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Node node)
        {
            _context.Nodes.Update(node);
            await _context.ChangesNodes.AddAsync(new ChangesNode
            {
                DateChanges = DateTime.Now,
                Node = node,
                Parameters = node.Parameters
            });
            await _context.SaveChangesAsync();
        }

        public IQueryable<Node> GetNodes()
        {
            return _context.Nodes.AsQueryable();
        }
    }
}
