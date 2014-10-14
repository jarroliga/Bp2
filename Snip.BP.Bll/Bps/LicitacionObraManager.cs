using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Snip.BP.BO;
using Snip.BP.BO.Bps;
using Snip.BP.Dal;
using Snip.BP.Dal.Bps;
using Snip.BP.Validation;

namespace Snip.BP.Bll.Bps
{
    public static class LicitacionObraManager
    {
        public static LicitacionObra GetItem(int codLicitacion, int codObra)
        {
            LicitacionObra licObra = new LicitacionObra();
            licObra = LicitacionObraDB.GetItem(codLicitacion, codObra);

            return licObra;
        }
        
        public static LicitacionObraCollection GetList(int codLicitacion)
        {
            LicitacionObraCollection obras = new LicitacionObraCollection();
            obras = LicitacionObraDB.GetList(codLicitacion);
            return obras;
        }
        
        public static int Save(LicitacionObra licitacionObra)
        {
            return LicitacionObraDB.Save(licitacionObra);
        }
        public static bool Remove(LicitacionObra licitacionObra)
        {
            return LicitacionObraDB.Delete(licitacionObra);
        }
        #region Metodos Programacion de Obras

        //public static LicitacionObraProgramacion GetItemProgramacion(int codLicitacion, int codObra, int anio)
        //{
        //    return LicitacionObraProgramacionDB.GetItem(codLicitacion, codObra, anio);
        //}
        //public static int SaveProgramacion(LicitacionObraProgramacion programacion)
        //{
        //    return LicitacionObraProgramacionDB.Save(programacion);
        //}

        #endregion 

        #region Metodos Reprogramacion de Obras

        public static LicitacionObraReprogramacion ReprogramacionGetItem(int codLicitacion, int codObra, int codReprogramacion)
        {
            return LicitacionObraReprogramacionDB.GetItem(codLicitacion, codObra, codReprogramacion);
        }
        public static LicitacionObraReprogramacionCollection ReprogramacionGetList(int codLicitacion, int codReprogramacion)
        {
            return LicitacionObraReprogramacionDB.GetList(codLicitacion, codReprogramacion);
        }
        public static int ReprogramacionSave(LicitacionObraReprogramacion obraReprogramada)
        {
            return LicitacionObraReprogramacionDB.Save(obraReprogramada);
        }

        #endregion
    }
}
