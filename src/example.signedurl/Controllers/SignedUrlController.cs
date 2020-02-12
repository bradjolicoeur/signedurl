using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using example.signedurl.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace example.signedurl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignedUrlController : ControllerBase
    {
        private readonly IGetPresignedUrl _getPresignedUrl;
        private readonly IUploadFile _uploadFile;

        public SignedUrlController(IUploadFile uploadFile, IGetPresignedUrl getPresignedUrl)
        {
            _getPresignedUrl = getPresignedUrl;
            _uploadFile = uploadFile;
        }

        [HttpGet]
        [Route("createfile")]
        public async Task<string> CreateFile()
        {
            return await _uploadFile.Execute();
        }

        [HttpGet]
        [Route("geturl")]
        public async Task<string> GetUrl()
        {
            return await _getPresignedUrl.Execute();
        }
    }
}