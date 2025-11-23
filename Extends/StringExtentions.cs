using System;
using System.Text.RegularExpressions;

namespace Extends
{
    public static class StringExtentions
    {
        /// <summary>
        /// Methode d'extension du type string permettant de mettre en majuscule chaque première lettre de chaque mot et le reste du mot en minuscule
        /// </summary>
        /// <param name="str">La chaine de caractère à transformer</param>
        /// <returns>La chaine transformée</returns>
        public static string Proper(this string str)
        {
            string ret = str;
            //permet de recupéré chaque mot contenu dans la chaine "str"
            Regex rgx = new Regex(@"(\w)+");
            MatchCollection matches = rgx.Matches(str);
            foreach (var item in matches)
            {
                // permet de metre la première lettre en majuscule et le reste en minuscule
                string rpl = char.ToUpper(item.ToString()[0]) + item.ToString().Substring(1, item.ToString().Length - 1).ToLower();
                // l'utilisation de replace permet de ne pas perdre les caractère de type '-'
                ret = ret.Replace(item.ToString(), rpl);
            }

            return ret.Trim();
        }
    }
}
