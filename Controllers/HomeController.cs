using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using aws_temp_credentials_upload.Models;
using Amazon.S3;
using Amazon.IdentityManagement;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;

namespace aws_temp_credentials_upload.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAmazonS3 _s3client;
        private readonly IAmazonIdentityManagementService _iamClient;

        private readonly IAmazonSecurityTokenService _tokenClient;

        public HomeController(
            ILogger<HomeController> logger,
            IAmazonS3 s3client,
            IAmazonIdentityManagementService iamClient,
            IAmazonSecurityTokenService tokenClient)
        {
            _logger = logger;
            _s3client = s3client;
            _iamClient = iamClient;
            _tokenClient = tokenClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await this._tokenClient.GetSessionTokenAsync(new GetSessionTokenRequest() {
                DurationSeconds = 7200
            });

            Credentials credentials = response.Credentials;
            return View(credentials);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
