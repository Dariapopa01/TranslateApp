using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
    public class TranslationRequest
    {
        public string Text { get; set; }
        public string TargetLanguage { get; set; }
        public string SourceLanguage { get; set; }
    }
}