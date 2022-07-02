using Flow.Launcher.Plugin;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JikanDotNet;

namespace Flow.Launcher.Plugin.AnimeSearch
{
    public class AnimeSearch : IPlugin
    {
        private PluginInitContext _context;
        public IJikan jikan;
        public void Init(PluginInitContext context)
        {
            _context = context;
            jikan = new Jikan();
        }

        public List<Result> Query(Query query)
        {
            var result = new Result
            {
                Title = "Anime/Manga",
                SubTitle = $"Query: {query.Search}",
                Action = c =>
                {
                    var searchResults = jikan.SearchAnimeAsync(query.Search);
                    foreach (var searchResult in searchResults.Result.Data)
                    {
                        _context.API.ShowMsg(searchResult.Title);
                    }
                    return true;
                }
            };
            return new List<Result> { result };
        }
    }
}