using Amazon.S3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace example.signedurl.Factory
{
    public static class LocalstackS3ClientFactory 
    {

        public static IAmazonS3 CreateClient(LocalstackSettings settings)
        {
            // Localstack service S3 URL
            var client = new AmazonS3Client(new AmazonS3Config
            {
                ServiceURL = settings.ServiceUrl,
                // Localstack supports HTTP only
                UseHttp = true,
                // Force bucket name go *after* hostname 
                ForcePathStyle = true,
                // Use proxy to force aws client calls to localstack
                ProxyHost = settings.ProxyHostname,
                ProxyPort = settings.ProxyPort,
            });

            return client;
        }
    }
}
