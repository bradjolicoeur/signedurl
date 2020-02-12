using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using example.signedurl.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace example.signedurl.Services
{
    public class UploadFile : IUploadFile
    {
        private const string Filename = "uploadme.txt";

        private readonly IAmazonS3 _client;
        private readonly LocalstackSettings _settings;

        public UploadFile(IAmazonS3 client, LocalstackSettings settings)
        {
            _client = client;
            _settings = settings;
        }

        public async Task<string> Execute()
        {
            //make sure the queue exists
            await _client.EnsureBucketExistsAsync(_settings.Bucket);

            using var transferUtility = new TransferUtility(_client);
            using var sr = new StreamReader(Filename);
            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = sr.BaseStream,
                ContentType = "content/text",
                BucketName = _settings.Bucket,
                Key = Filename,
                TagSet = new List<Tag>
                        {
                            new Tag { Key = "key1", Value = "value1" },
                            new Tag { Key = "key2", Value = "value2" }
                        }
            };

            await transferUtility.UploadAsync(uploadRequest);

            return "uploaded";
        }
    }
}
