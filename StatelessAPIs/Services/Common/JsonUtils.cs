using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace StatelessAPIs.Services.Common
{
    public static class JsonUtils
    {
        private static void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

        public static T Convert<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });
        }

    }
}
