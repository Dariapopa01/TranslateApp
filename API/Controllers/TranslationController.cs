using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Google.Cloud.Translation.V2;
using API.Entity;


namespace API.Controllers
{   
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class TranslationController : ControllerBase
    {
         private readonly IConfiguration _configuration;

        public TranslationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("translate")]
        public async Task<IActionResult> TranslateAsync([FromBody] TranslationRequest request)
        {
            var translationClient = TranslationClient.CreateFromApiKey(_configuration["GoogleCloudTranslation:ApiKey"]);

            var response = await translationClient.TranslateTextAsync(
                request.Text,
                request.TargetLanguage,
                request.SourceLanguage
            );

            return Ok(new { Translation = response.TranslatedText });
        }
    }

    }
