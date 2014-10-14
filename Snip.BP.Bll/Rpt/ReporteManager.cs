using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Transactions;
using System.Data;

using Snip.BP.Dal;
using Snip.BP.Dal.Rpt;
using Snip.BP.BO.Rpt;

namespace Snip.BP.Bll.Rpt
{
    public static class ReporteManager
    {
        public static DataSet GetRptLicitaciones101(int anio, int codInstitucion, int codFiltro, int codListaFiltro)
        {
            return RptLicitacion101DB.GetList(anio, codInstitucion, codFiltro, codListaFiltro);
        }
        public static DataSet GetRptLicitaciones101(int anio, int codFiltro)
        {
            return GetRptLicitaciones101(anio, -1, codFiltro, 0);
        }
        public static List<RptLicitacion102> RptLicitacion102GetList(int anio, DateTime fechaIni, DateTime fechaFin, int codInstitucion, int codListaFiltro)
        {
            return RptLicitacion102DB.GetList(anio, fechaIni, fechaFin, codInstitucion, codListaFiltro);
        }
        public static DataSet RptLicitacion103GetList(int anio, int codInstitucion)
        {
            return RptLicitacion103DB.GetList(anio, codInstitucion);
        }
        public static DataSet RptLicitacion104GetList(int anio, int codInstitucion)
        {
            return RptLicitacion104DB.GetList(anio, codInstitucion);
        }
        public static DataSet RptLicitacion105GetList(int anio, int codInstitucion)
        {
            return RptLicitacion105DB.GetList(anio, codInstitucion);
        }
        public static DataSet RptLicitacion106GetList(int anio, int codInstitucion)
        {
            return RptLicitacion106DB.GetList(anio, codInstitucion);
        }
        public static DataSet RptLicitacion107GetList(int anio, int codInstitucion, int codListaFiltro)
        {
            return RptLicitacion107DB.GetList(anio, codInstitucion, codListaFiltro);
        }
        public static DataSet RptLicitacion108GetList(int anio, int codInstitucion, int codFiltro, int codListaFiltro)
        {
            return RptLicitacion108DB.GetList(anio, codInstitucion, codFiltro, codListaFiltro);
        }
        public static List<RptTemporal> RptTemporalGetList()
        {
            return RptTemporalDB.GetList();
        }
        public static List<RptLicitacion109> RptLicitacion109GetList(int anio, int codInstitucion, DateTime fechaIni, DateTime fechaFin)
        {
            return RptLicitacion109DB.GetList(anio, codInstitucion, fechaIni, fechaFin);
        }
    }
}
