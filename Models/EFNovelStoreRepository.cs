using NovelStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovelStore.Models
{
    public class EFNovelStoreRepository : INovelStoreRepository
    {
        private NovelStoreDbContext context;
        public EFNovelStoreRepository(NovelStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Novel> Novels => context.Novels;
        public void CreateNovel(Novel b)
        {
            context.Add(b);
            context.SaveChanges();
        }
        public void DeleteNovel(Novel b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
        public void SaveNovel(Novel b)
        {
            context.SaveChanges();
        }
    }
}
