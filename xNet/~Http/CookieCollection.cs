using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace xNet
{
    public class CookieCollection
    {
        public List<Cookie> Cookies { get; set; } = new List<Cookie>();
        public int Count => Cookies.Count;
        /// <summary>
        /// Возвращает или задает значение, указывающие, закрыты ли куки для редактирования
        /// </summary>
        /// <value>Значение по умолчанию — <see langword="false"/>.</value>
        public bool IsLocked { get; set; }

        public bool Contains(string name)
        {
            return Cookies.Where(a => a.Name == name).FirstOrDefault() != null;
        }
        public void Remove(string name)
        {
            Cookies.RemoveAll(a => a.Name == name);
        }

        public string GetHeaders(string domain)
        {
            var strBuilder = new StringBuilder();

            Func<Cookie, bool> func = (c) =>
               {
                   if (c.Domain == domain)
                       return true;
                   if (string.IsNullOrWhiteSpace(c.Domain))
                       return true;
                   if (c.Domain[0] == '.')
                   {
                       var dm = c.Domain.TrimStart('.');
                       if (domain.Contains(dm))
                           return true;
                   }
                   return false;

               };

            foreach (var cookie in Cookies.Where(func))
            {

                strBuilder.AppendFormat("{0}={1}; ", cookie.Name, cookie.Value);
            }

            if (strBuilder.Length > 0)
            {
                strBuilder.Remove(strBuilder.Length - 2, 2);
            }

            return strBuilder.ToString();
        }

        public void SetCookie(Cookie cookie)
        {

            Cookies.Add(cookie);
        }
        
    }
}
