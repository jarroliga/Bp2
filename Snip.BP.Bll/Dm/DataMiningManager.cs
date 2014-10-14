using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Snip.BP.BO;
using Snip.BP.BO.Enums;
using Snip.BP.BO.Bp;
using Snip.BP.BO.Dm;
using Snip.BP.Dal;
using Snip.BP.Dal.Bp;
using Snip.BP.Dal.Dm;
using Snip.BP.Validation;

namespace Snip.BP.Bll.Dm
{
    [DataObjectAttribute()]
    public static class DataMiningManager
    {
        public static PipEstructuraFinanciamientoCollection PipEstructuraFinanciamientoGetList(FormatoNumero formato)
        {
            return PipEstructuraFinanciamientoGetList(-1, FormatoNumero.Unidades);
        }
        public static PipEstructuraFinanciamientoCollection PipEstructuraFinanciamientoGetList(int anio, FormatoNumero formato)
        {
            return PipEstructuraFinanciamientoDB.GetList(anio, (int)formato);
        }
        public static PipAnualCollection PipAnualGetList(int anioIni, int anioFin, FormatoNumero formato)
        {
            return PipAnualDB.GetList(anioIni, anioFin, (int)formato);
        }
        public static PipAnualCollection PipAnualGetList(int anioFin, FormatoNumero formato)
        {
            return PipAnualGetList(-1, anioFin, formato);
        }
        public static PipAnualCollection PipAnualGetList(FormatoNumero formato)
        {
            return PipAnualGetList(-1, DateTime.Today.Year, formato);
        }
        public static PipDistribucionByEntidadCollection PipDistribucionByEntidadGetList(int anio, FormatoNumero formato)
        {
            PipDistribucionByEntidadCollection pip = new PipDistribucionByEntidadCollection();
            pip = PipDistribucionByEntidadDB.GetList(anio, (int)formato);

            //if (pip != null)
            //{
            //    decimal totalPip = pip.Sum(x => x.Programado);

            //    var totales = (from p in pip
            //                   group p by p.IdTipoEntidad into g
            //                   select new { TotalProg = g.Sum(p => p.Programado), TotalEjec = g.Sum(p => p.Ejecutado) }).ToList();

            //    decimal totalProgGob = totales[0].TotalProg;
            //    decimal totalEjecGob = totales[0].TotalEjec;
            //    decimal totalProgEnt = totales[1].TotalProg;
            //    decimal totalEjecEnt = totales[1].TotalEjec;

            //    decimal porcGob = decimal.Round((totalProgGob / totalPip) * 100, 1);
            //    decimal porcEntes = decimal.Round((totalProgEnt / totalPip) * 100, 1);

            //}

            return pip;
        }
        public static PipInstitucion PipInstitucionGetItem(int codInstitucion, int anio, FormatoNumero formato)
        {
            return PipInstitucionDB.GetItem(codInstitucion, anio, (int)formato);
        }
        public static PipInstitucionCollection PipInstitucionGetList(int codInstitucion, FormatoNumero formato)
        {
            return PipInstitucionDB.GetList(codInstitucion, (int)formato);
        }
        public static PipInstitucionCollection PipInstitucionGetListByAnio(int anio, FormatoNumero formato)
        {
            return PipInstitucionDB.GetListByAnio(anio, (int)formato);
        }
        public static PipInstitucionEntidad PipInstitucionEntidadGetItem(int codInstitucion, int idTipoEntidad, int anio, FormatoNumero formato)
        {
            return PipInstitucionEntidadDB.GetItem(codInstitucion, idTipoEntidad, anio, (int)formato);
        }
        public static PipInstitucionEntidadCollection PipInstitucionEntidadGetList(int codInstitucion, int idTipoEntidad, FormatoNumero formato)
        {
            return PipInstitucionEntidadDB.GetList(codInstitucion, idTipoEntidad, (int)formato);
        }

    }
}
