using Microsoft.AspNetCore.Http;
using PAESP.DTOS;
using PAESP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Clases
{
    public class Utils
    {
        
    }
    public static class Consecutivos
    {

        public static string ConsecutivoByCodigo(int Min, string codigo, Configuraciones config)
        {         
            string str = "";
            int Consecutivo = 0;            
            Consecutivo = int.Parse(config.Valor);
            str = config.Valor.PadLeft(Min - (codigo.Length + 2), '0');
            str = codigo + DateTime.Now.Year.ToString().Substring(2, 2) + str;
            config.Valor = (Consecutivo + 1).ToString();          
            return str;
        }

    }
}
