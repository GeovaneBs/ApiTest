using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Drawing;

using WebAPITestSetup.Entities;
using WebAPITestSetup.Models;

namespace WebAPITestSetup.Controllers
{
    [Route("api/installer")]
    public class InstallerPropertiesController : Controller
    {

        public static List<InstallerProperties> MyProperty { get; set; } = new List<InstallerProperties>
        {
            new InstallerProperties
            {
                GUID = "4CA14D76-BD7A-4380-AB13-20EA8E3F7DB9",
                Install = 0,
                User = "geovane.silva@ndd.tech"
            },
            new InstallerProperties
            {
                GUID = "4CA14D76-BD7A-4380-AB13-20EA8E3F7D10",
                Install = 1,
                User = "geovane.brandao@ndd.tech"
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MyProperty);
        }

        [HttpPost]
        public IActionResult Post([FromBody] InstallerPropertiesModel model)
        {
            var novoInstaller = new InstallerProperties
            {
                GUID = model.GUID,
                User = model.User,
                Install = model.Install,
            };

            if (novoInstaller.Install > 0)
            {
                return Unauthorized("Não pode instalar");
            }

            MyProperty.Add(novoInstaller);

            return CreatedAtAction(
                 nameof(Get),
                 new { model.Install },
                 model
                 );
        }


        [HttpGet("{guid}")]
        public IActionResult GetById(string guid)
        {
            var x = MyProperty.SingleOrDefault(x => x.GUID == guid);

            if (x == null)
            {
                return NotFound("Não achou");
            }
            
            var newInstaller = new InstallerProperties(
                x.User,
                x.GUID,
                x.Install
                );

            if (newInstaller.Install > 0 )
            {
                return Unauthorized("Não pode instalar");
            }


            return Ok(newInstaller);
        }

        // PUT api/cars/1
        [HttpPut("{guid}/{install}")]
        public IActionResult Put(string guid, int install)
        {
            // SE A ATUALIZAÇÃO FUNCIONAR, RETORNA 204 NOCONTENT
            // SE DADOS DE ENTRADA ESTIVEREM INCORRETOS, RETORNA 400 BAD REQUEST
            // SE NÃO RETORNA NOTFOUND 404

            var x = MyProperty.SingleOrDefault(x => x.GUID == guid);

            if (x == null)
            {
                return NotFound("Não achou");
            }

            x.Install = install; 

            return NoContent();
        }
    }
}
