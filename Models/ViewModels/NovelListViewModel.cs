using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovelStore.Models.ViewModels
{
    public class NovelListViewModel
    {
        public IEnumerable<Novel> Novels{ get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}