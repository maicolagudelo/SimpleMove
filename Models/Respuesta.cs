using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMove.Models
{
    public class Respuesta
    {
        private usuarios user;
        private string mensaje;
        private string url;
        private string token;

        public usuarios obj { get => user; set => user = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public string Url { get => url; set => url = value; }
        public string Token { get => token; set => token = value; }
    }
}