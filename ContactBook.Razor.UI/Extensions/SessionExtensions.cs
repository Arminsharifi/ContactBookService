using Newtonsoft.Json;

namespace ContactBook.Razor.UI.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string Key, object value)
        {
            session.SetString(Key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session, string Key)
        {
            string Json = session.GetString(Key);
            if (string.IsNullOrWhiteSpace(Json))
            {
                return default(T);
            }
            else return JsonConvert.DeserializeObject<T>(Json);
        }
    }
}
