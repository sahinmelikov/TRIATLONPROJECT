using Google.Cloud.Translation.V2;
using System.Threading.Tasks;

namespace TriatlonProject.Services
{
    public class TranslationService
    {
        private readonly TranslationClient _client;

        public TranslationService()
        {
            // Google Cloud Translate API anahtar dosyanızın yolunu belirtin
            _client = TranslationClient.CreateFromApiKey("AIzaSyAkyiVLsx3dzHf5zqLtxIHpMseA1Zrd7vg");
        }

        public async Task<string> TranslateTextAsync(string text, string targetLanguage)
        {
            var response = await _client.TranslateTextAsync(text, targetLanguage);
            return response.TranslatedText;
        }
    }
}
