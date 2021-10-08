using PAESP.Models;
using PAESP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAESP.Clases
{
    public static class TemplateGenerator
    {
      
        public static string GetHTMLString(string typeReport, int idRecibo)
        {
            string result = "";
            switch (typeReport)
            {
                case "PREINSCRIPCION":
                    result = ReciboPresinscripcion(idRecibo);
                    break;
            }

            return result;
        }

        public static string ReciboPresinscripcion(int idRecibo) 
        {           
            var dataRec = StaticServiceProvider.GetService<ReciboService>();

            Recibo recibo = dataRec.GetRecibo(idRecibo);

            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='container-fluid'>
                                    <div class='row'>
                                        <div class='col-lg-12'>
                                            <div class='row'>
                                                <div class='col-lg-6'>
                                                    <h2>UNIVERSIDAD POPULAR CESAR</h2>                    
                                                </div>");
            sb.AppendFormat(@"
                                                <div class='col-lg-6'>
                                                    <h2>REFERENCIA DE PAGO: <span>{0}</span></h2>
                                                </div>
                                                <div>
                                                    <h2>FECHA DE PAGO: <span>{1}</span></h2>
                                                </div>
                                            </div>  
                                            </br>
                                            <div class='header'><h1>Detalles</h1></div>
                                            <p>Nombre: <span>{2}</span></p>
                                            <p>Tipo identificacion: <span>{3}</span></p>
                                            <p>Identificacion: <span>{4}</span></p>", recibo.NroRecibo, recibo.FechaPago.ToString("dd/MM/yyyy"), recibo.Nombre, "", recibo.Identificacion);
            sb.Append(@"
                                            <table align='center'>
                                                <tr>
                                                    <th>Concepto</th>
                                                    <th>Valor</th>                                    
                                                </tr>");
            sb.AppendFormat(@"
                                                <tr>
                                                    <td>{0}</td>
                                                    <td>{1}</td>                                  
                                                 </tr>", recibo.Concepto.Descripcion, recibo.Valor.ToString("C"));
                    sb.Append(@"            
                                            </table>           
                                                </div>
                                            </div>             
                                        </div>                                                                                                      
                                    </body>
                                </html>");
            return sb.ToString();
        }
    }
}
