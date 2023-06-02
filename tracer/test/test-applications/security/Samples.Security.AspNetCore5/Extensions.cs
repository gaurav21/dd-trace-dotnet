using Microsoft.Extensions.Configuration;

namespace Samples.Security
{
    public static class Extensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration) => configuration.GetConnectionString("DefaultConnection") ?? "Data Source=Data\\app.db";
    }
}
