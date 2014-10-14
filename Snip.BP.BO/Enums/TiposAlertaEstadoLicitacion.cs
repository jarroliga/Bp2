using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snip.BP.BO.Enums
{
    public enum TiposAlertaEstadoLicitacion
    {
        SinCronograma = 1,
        CronogramaIncompleto,
        SinObrasAsociadas,
        ObrasSinProgramación,
        ObrasConProgramacionIncompleta,
        ObrasSinAsignacion
    }
}
