using Flow.Launcher.Plugin;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Flow.Launcher.Plugin.AnimeSearch
{
    public class AnimeSearch : IPlugin
    {
        private PluginInitContext _context;

        public void Init(PluginInitContext context)
        {
            _context = context;
        }

        public List<Result> Query(Query query)
        {
            var result = new Result
            {
                Title = "Anime/Manga",
                SubTitle = $"Query: {query.Search}",
                Action = c =>
                {
                    _context.API.ShowMsg("Test");
                    return true;
                }
            };
            return new List<Result> { result };
        }
    }
}