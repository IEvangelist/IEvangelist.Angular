using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IEvangelist.Angular.Repositories
{
    public interface IDbRepository
    {
        Task InitializeAsync();

        Task<T> GetAsync<T>(string id) where T : Document;

        Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : Document;

        Task<Document> CreateAsync<T>(T value) where T : Document;

        Task<Document[]> CreateAsync<T>(IEnumerable<T> values) where T : Document;

        Task<Document> UpdateAsync<T>(string id, T value) where T : Document;

        Task DeleteAsync(string id);
    }
}