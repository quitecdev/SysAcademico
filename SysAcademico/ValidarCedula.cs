using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysAcademico
{
    public class ValidarCedula
    {
        public bool res;
        public string num_cedula;
        public string tipoDocumento;
        public ValidarCedula(string num, string tipo)
        {
            num_cedula = num;
            tipoDocumento = tipo;
        }



        public void comprobar_num()
        {
            if (tipoDocumento != "Pasaporte")
            {
                int suma = 0;
                int j = 0;
                bool a = true;
                int x = 0;
                int t = num_cedula.Length - 1;
                if (t < 9)
                {
                    res = false;
                }
                else
                {

                    for (int i = 0; i < 9; i++)
                    {
                        j = Convert.ToInt16(this.num_cedula[i].ToString());
                        if (a == true)
                        {
                            x = j * 2;
                            if (x > 9)
                            {
                                x = 1 + (x % 10);
                            }
                            a = false;
                        }
                        else
                        {
                            x = j * 1;
                            a = true;
                        }
                        suma += x;

                    }
                    x = suma % 10;
                    j = Convert.ToInt32(this.num_cedula[9].ToString());

                    if (x == 0)
                    {
                        if (x == j)
                        {
                            res = true;
                        }
                    }
                    else
                    {
                        x = (suma - x) + 10;
                        if (j == (x - suma))
                        {
                            res = true;

                        }
                        else
                        {
                            res = false;

                        }
                    }
                }
            }
        }

    }
}