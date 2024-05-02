using ImpresoraServidor.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace ImpresoraServidor.Controllers
{
    [ApiController]
    [Route("Ticket")]
    public class Ticket : ControllerBase
    {
       

        [HttpPost]
        [Route("AddHeaderLine")]
        public dynamic AddHeaderLine()
        {
            

            DatosTicket dt = new DatosTicket
            {
                headerLines1 = "Direccion"


            };

            dt.PrintTicket("Microsoft Print to PDF");

            return  JsonSerializer.Serialize(Request.Body);

        }

        [HttpGet]
        [Route("GetHeaderLine")]
        public dynamic getHeaderLine()
        {
            DatosTicket dt = new DatosTicket();

            return dt.headerLines1;
        }

    }
}
