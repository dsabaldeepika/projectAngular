using Microsoft.WindowsAzure.StorageClient;
using SampleApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace JRDEV2.Web.Controllers
{
    [Authorize]
    public class FilesController : ApiController
    {
        public Task<FileDetails> Post()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var multipartStreamProvider = new AzureBlobStorageMultipartProvider(BlobHelper.GetWebApiContainer());
            return Request.Content.ReadAsMultipartAsync<AzureBlobStorageMultipartProvider>(multipartStreamProvider).ContinueWith<FileDetails>(t =>
            {
                if (t.IsFaulted)
                {
                    throw t.Exception;
                }

                AzureBlobStorageMultipartProvider provider = t.Result;
                return provider.Files.FirstOrDefault();
            });
        }

        public IEnumerable<FileDetails> Get()
        {
            CloudBlobContainer container = BlobHelper.GetWebApiContainer();
            foreach (CloudBlockBlob blob in container.ListBlobs())
            {
                yield return new FileDetails
                {
                    Name = blob.Name,
                    Size = blob.Properties.Length,
                    ContentType = blob.Properties.ContentType,
                    Location = blob.Uri.AbsoluteUri
                };
            }
        }
    }

    public class FileDetails
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string ContentType { get; set; }
        public string Location { get; set; }
    }
}
