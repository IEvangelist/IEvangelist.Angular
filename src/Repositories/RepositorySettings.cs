using System;
using Microsoft.Azure.Documents.Client;

namespace IEvangelist.Angular.Repositories
{
    public class RepositorySettings
    {
        public bool IsEmulatorDependent => Endpoint?.Contains("localhost") ?? false;

        public string Endpoint { get; set; }

        public string Key { get; set; }

        public string DatabaseId { get; set; }

        public string CollectionId { get; set; }

        public Uri GetDocumentCollectionUri()
            => UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId);

        public Uri GetDocumentUri(string id)
            => UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id);
    }
}