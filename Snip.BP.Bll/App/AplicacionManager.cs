using System;
using System.Collections.Generic;
using System.ComponentModel;

using Snip.BP.BO.App;
using Snip.BP.Dal.App;
using Snip.BP.Validation;

namespace Snip.BP.Bll.App
{
    public static class AplicacionManager
    {
        public static Aplicacion GetItem(int codigo)
        {
            Aplicacion aplicacion = new Aplicacion();

            aplicacion = AplicacionDB.GetItem(codigo);

            return aplicacion;
        }

        public static AplicacionCollection GetList()
        {
            AplicacionCollection aplicaciones = new AplicacionCollection();

            aplicaciones = AplicacionDB.GetList();

            return aplicaciones;
        }
        public static int Save(Aplicacion aplicacion)
        {
            if (!aplicacion.Validate())
			{
				throw new InvalidSaveOperationException("No se puede salvar un registro inválido. Asegurese de que los valores sean los correctos.");
			}
			aplicacion.Codigo = AplicacionDB.Save(aplicacion);
            return aplicacion.Codigo;
        }
        public static bool Delete(Aplicacion aplicacion)
        {
            return AplicacionDB.Delete(aplicacion.Codigo);
        }
        public static Parametro ParametroGetItem(int codigo)
        {
            return ParametroDB.GetItem(codigo);
        }
        public static Parametro ParametroGetItemById(string id)
        {
            return ParametroDB.GetItemById(id);
        }
        public static string ParametroGetValueById(string id)
        {
            Parametro par = new Parametro();
            string valor = null;

            par = ParametroDB.GetItemById(id);

            if (par != null)
            {
                valor = par.ValorParametro;
            }
            return valor;

        }
    }
}
