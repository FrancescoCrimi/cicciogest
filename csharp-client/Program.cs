using IO.Swagger.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO.Swagger
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }
        public Program()
        {
            CategoriaApi cat = new CategoriaApi();
            FatturaApi fat = new FatturaApi();
            var aaa = cat.CategoriaGetCategorie();
            var fatture = fat.FatturaGetFatture();
        }
    }
}
