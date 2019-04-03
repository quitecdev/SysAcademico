using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CAS_ADMIN.Models
{
    public class Helper
    {

        public string CrearAlfaNumerico(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }
    }
}