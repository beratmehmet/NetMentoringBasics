using OOPFundamentals.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace OOPFundamentals
{
    public static class DocumentCash
    {
        private static MemoryCache _cache = new MemoryCache("FileCache");

        public static object GetItem(int id)
        {
            var items = _cache.Where(x => x.Key.Contains(id.ToString()));
            return _cache.GetValues(from kvp in items select kvp.Key);
        }

        public static bool AddItem(string id, Document document, CacheItemPolicy cacheItemPolicy)
        {
            CacheItem cacheItem = new CacheItem(id.ToString(), document);
            return _cache.Add(cacheItem, cacheItemPolicy);
        }

        public static bool IsCached(int id)
        { 
            return _cache.Any(x => x.Key.Contains(id.ToString()));
        }

    }
}
