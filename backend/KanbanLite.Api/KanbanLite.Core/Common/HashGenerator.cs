using System.Security.Cryptography;
using System.Text;

namespace KanbanLite.Core.Common
{
    public static class HashGenerator
    {
        public static string GetMd5Hash(string sourceString)
        {
            using var hash = MD5.Create();

            return string.Join("", hash!.ComputeHash(Encoding.UTF8.GetBytes(sourceString)).Select(b => b.ToString("x2")));
        }
    }
}
