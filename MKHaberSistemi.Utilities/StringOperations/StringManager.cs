using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MKHaberSistemi.Utilities.StringOperations
{
    public class StringManager
    {
        /// <summary>
        /// String içerisindeki karakterleri seo ya uygun olarak çevirir.
        /// Örn; "Yağmur Üşür" -> "yagmur-usur"
        /// </summary>
        /// <param name="seoBaslik">Çevrilecek string</param>
        /// <returns>Çevrilen string</returns>
        public static string SeoDuzenleme(string seoBaslik)
        {
            seoBaslik = seoBaslik.Replace("ş", "s");
            seoBaslik = seoBaslik.Replace("Ş", "s");
            seoBaslik = seoBaslik.Replace("İ", "i");
            seoBaslik = seoBaslik.Replace("I", "i");
            seoBaslik = seoBaslik.Replace("ı", "i");
            seoBaslik = seoBaslik.Replace("ö", "o");
            seoBaslik = seoBaslik.Replace("Ö", "o");
            seoBaslik = seoBaslik.Replace("ü", "u");
            seoBaslik = seoBaslik.Replace("Ü", "u");
            seoBaslik = seoBaslik.Replace("Ç", "c");
            seoBaslik = seoBaslik.Replace("ç", "c");
            seoBaslik = seoBaslik.Replace("ğ", "g");
            seoBaslik = seoBaslik.Replace("Ğ", "g");
            seoBaslik = seoBaslik.Replace(" ", "-");
            seoBaslik = seoBaslik.Replace("---", "-");
            seoBaslik = seoBaslik.Replace("?", "");
            seoBaslik = seoBaslik.Replace("/", "");
            seoBaslik = seoBaslik.Replace(".", "");
            seoBaslik = seoBaslik.Replace("'", "");
            seoBaslik = seoBaslik.Replace("#", "");
            seoBaslik = seoBaslik.Replace("%", "");
            seoBaslik = seoBaslik.Replace("&", "");
            seoBaslik = seoBaslik.Replace("*", "");
            seoBaslik = seoBaslik.Replace("!", "");
            seoBaslik = seoBaslik.Replace("@", "");
            seoBaslik = seoBaslik.Replace("+", "");

            seoBaslik = seoBaslik.ToLower();
            seoBaslik = seoBaslik.Trim();

            // tüm harfleri küçült
            string encodedUrl = (seoBaslik ?? "").ToLower();

            // & ile " " yer değiştirme
            encodedUrl = Regex.Replace(encodedUrl, @"\&+", "and");

            // " " karakterlerini silme
            encodedUrl = encodedUrl.Replace("'", "");

            // geçersiz karakterleri sil
            encodedUrl = Regex.Replace(encodedUrl, @"[^a-z0-9]", "-");

            // tekrar edenleri sil
            encodedUrl = Regex.Replace(encodedUrl, @"-+", "-");

            // karakterlerin arasına tire koy
            encodedUrl = encodedUrl.Trim('-');

            return encodedUrl;
        }
    }
}
