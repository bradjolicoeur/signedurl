using Amazon.S3;
using Amazon.S3.Model;
using example.signedurl.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace example.signedurl.Services
{
    public class GetPresignedUrl : IGetPresignedUrl
    {
        private const string Filename = "uploadme.txt";

        private readonly IAmazonS3 _client;
        private readonly LocalstackSettings _settings;

        public GetPresignedUrl(IAmazonS3 client, LocalstackSettings settings)
        {
            _client = client;
            _settings = settings;
        }

        public async Task<string> Execute()
        {
            //make sure the queue exists
            await _client.EnsureBucketExistsAsync(_settings.Bucket);

            var result = _client.GetPreSignedURL(new GetPreSignedUrlRequest
            {
                BucketName = _settings.Bucket,
                Key = Filename,
                Expires = DateTime.Now.AddMinutes(1),
                Protocol = Protocol.HTTP
            });

            return result;

        }
    }


}
