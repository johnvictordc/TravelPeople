using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Llama.Helpers
{
    /// <summary>
    /// Description of Helpers.
    /// </summary>
    public static class StringHelpers
    {
        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
        }

        public static string SpecialToUnderscore(string s)
        {
            return Regex.Replace(s, "[^a-zA-Z0-9_]+", "_");
        }

        public static string GetAlias(int count, string name)
        {
            if (count > 0)
            {
                return (StringHelpers.SpecialToUnderscore(name) + "_" + count.ToString()).ToLower();
            }
            else
            {
                return (StringHelpers.SpecialToUnderscore(name)).ToLower();
            }
        }

        /// <summary>
        /// Truncate a text based on the length
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Ellipsis(string text = "", int length = 300)
        {
            text = StripTagsRegex(text);
            if (text.Length > length)
            {
                return text.Substring(0, length) + "...";
            }
            else
            {
                return text;
            }
        }

        public static string StripTagsRegex(string source = "")
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }

        public static string StripVowels(string word)
        {
            string vowels = "AEIOU";
            return new string(word.ToUpper().Where(c => !vowels.Contains(c)).ToArray());
        }

        public static string StripSpaces(string word)
        {
            return word.Replace(" ", "").Trim();
        }

        public static string PageTitle(string name)
        {
            return UppercaseFirst("Magsaysay Careers | " + name.ToUpper().Replace("CONTROLLER", ""));
        }

        public static string URL(string url, string baseUrl)
        {
            Uri _base = new Uri(baseUrl);
            return new Uri(_base, url).ToString();
        }

        public static string TagToEntities(string markup)
        {
            return markup.Replace("<", "&lt;").Replace(">", "&gt;");
        }

        public static string Upper(string s)
        {
            if (s != null)
            {
                return s.ToUpper();
            }
            else
            {
                return "";
            }
        }
    }
}
