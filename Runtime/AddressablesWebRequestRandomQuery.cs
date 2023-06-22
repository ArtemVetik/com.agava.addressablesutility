using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.AddressableAssets;
using UnityEngine;
#if UNITY_WEBGL && !UNITY_EDITOR
using UnityEngine.Scripting;

[assembly: AlwaysLinkAssembly]
#endif
namespace Agava.AddressablesUtility
{
    internal static class AddressablesWebRequestRandomQuery
    {
        private static readonly string RequestUrlPattern = "^.*\\.(hash|json)$";
        private static readonly string QueryFormat = "?random={0}";
        private static readonly int QueryValueLength = 10;

#if UNITY_WEBGL && !UNITY_EDITOR
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
#endif
        private static void Initialize()
        {
#if USE_WEB_REQUEST_OVERRIDE
            Addressables.WebRequestOverride += AppendQuery;
#endif
        }

        private static void AppendQuery(UnityWebRequest request)
        {
            if (Regex.IsMatch(request.url, RequestUrlPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase) == false)
                return;

            request.url += string.Format(QueryFormat, RandomNumber(QueryValueLength));
        }

        private static string RandomNumber(int length)
        {
            var result = string.Empty;

            for (int i = 0; i < length; i++)
                result += Random.Range(0, 10);

            return result;
        }
    }
}