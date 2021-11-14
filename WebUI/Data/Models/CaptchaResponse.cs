using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConestogaInsidersClub.Areas.Identity.Pages.Account
{
    public class CaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("error-codes")]
        public List<string> ErrorMessage { get; set; }
    }
}