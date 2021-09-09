using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilaController : ControllerBase
    {
        public IBusControl _busControl;
        public FilaController(IBusControl busControl)
        {
            _busControl = busControl;
        }

        [HttpPost]
        public async Task FilaPostAsync(DadosFila dadosFila)
        {
            await _busControl.Publish(dadosFila);
        }
    }
}