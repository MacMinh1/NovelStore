using System.Linq;

namespace NovelStore.Models
{
    public interface INovelStoreRepository
    {
        IQueryable<Novel> Novels { get; }
        void SaveNovel(Novel b);
        void CreateNovel(Novel b);
        void DeleteNovel(Novel b);
    }
}
