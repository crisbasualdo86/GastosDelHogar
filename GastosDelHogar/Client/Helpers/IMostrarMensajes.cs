using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GastosDelHogar.Client.Helpers
{
    public interface IMostrarMensajes
    {
        Task<bool> MostrarMensajeConfirmacion(string mensaje);
        Task MostrarMensajeError(string mensaje);
        Task MostrarMensajeExitoso(string mensaje);
    }
}
