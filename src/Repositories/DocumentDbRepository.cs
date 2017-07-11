using IEvangelist.Angular.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;

namespace IEvangelist.Angular.Repositories
{
    public class DocumentDbRepository : IDbRepository
    {
        private DocumentClient _client;
        private RepositorySettings _settings;
        private ILogger _logger;

        public DocumentDbRepository(
            IOptions<RepositorySettings> repositoryOptions,
            ILogger<DocumentDbRepository> logger)
        {
            _settings = repositoryOptions?.Value ?? throw new ArgumentNullException(nameof(repositoryOptions));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<T> GetAsync<T>(string id) where T : Document
        {
            try
            {
                Document document =
                    await _client.ReadDocumentAsync(_settings.GetDocumentUri(id));
                return (T)(dynamic)document;
            }
            catch (DocumentClientException e) when (e.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogError(0, e, e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetAsync<T>(
            Expression<Func<T, bool>> predicate)
            where T : Document
        {
            IDocumentQuery<T> query =
                _client.CreateDocumentQuery<T>(_settings.GetDocumentCollectionUri(),
                                               new FeedOptions { MaxItemCount = -1 })
                       .Where(predicate)
                       .AsDocumentQuery();

            var results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }

        public async Task<Document> CreateAsync<T>(T value)
            where T : Document
            => await _client.CreateDocumentAsync(_settings.GetDocumentCollectionUri(), value);

        public Task<Document[]> CreateAsync<T>(IEnumerable<T> values) where T : Document
            => Task.WhenAll(values.Select(CreateAsync));

        public async Task<Document> UpdateAsync<T>(string id, T value) 
            where T : Document
            => await _client.ReplaceDocumentAsync(_settings.GetDocumentUri(id), value);

        public Task DeleteAsync(string id)
            => _client.DeleteDocumentAsync(_settings.GetDocumentUri(id));

        public async Task InitializeAsync()
        {
            if (_settings.IsEmulatorDependent)
            {
                StartEmulatorIfNotRunning();
            }

            _client =
                new DocumentClient(new Uri(_settings.Endpoint),
                                   _settings.Key,
                                   new ConnectionPolicy { EnableEndpointDiscovery = false });

            (bool databaseCreated, bool collectionCreated)
                = await IsFirstInitializationAsync();

            if (databaseCreated && collectionCreated)
            {
                await CreateAsync(Character.Defaults);
            }
        }

        private void StartEmulatorIfNotRunning()
        {
            var emulators = Process.GetProcessesByName("DocumentDB.Emulator");
            if (emulators.Length == 0)
            {
                const string emulatorPath =
                    "C:\\Program Files\\DocumentDB Emulator\\DocumentDB.Emulator.exe";
                var emulatorProcess = new ProcessStartInfo(emulatorPath)
                {
                    LoadUserProfile = true
                };
                Process.Start(emulatorProcess);
            }            
        }

        private async Task<(bool databaseCreated, bool collectionCreated)> IsFirstInitializationAsync()
            => (await CreateDatabaseIfNotExistsAsync(), await CreateCollectionIfNotExistsAsync());

        private async Task<bool> CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await _client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(_settings.DatabaseId));
                return false;
            }
            catch (DocumentClientException e) when (e.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogError(1, e, e.Message);

                await _client.CreateDatabaseAsync(new Database { Id = _settings.DatabaseId });
                return true;
            }
        }

        private async Task<bool> CreateCollectionIfNotExistsAsync()
        {
            try
            {
                await _client.ReadDocumentCollectionAsync(
                    UriFactory.CreateDocumentCollectionUri(_settings.DatabaseId,
                                                           _settings.CollectionId));
                return false;
            }
            catch (DocumentClientException e) when (e.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogError(2, e, e.Message);

                await _client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(_settings.DatabaseId),
                        new DocumentCollection { Id = _settings.CollectionId },
                        new RequestOptions { OfferThroughput = 1000 });
                return true;
            }
        }
    }
}