using System;
using System.Collections.Generic;
using System.ComponentModel;

using Snip.BP.BO.App;
using Snip.BP.Dal.App;
using Snip.BP.Validation;

namespace Snip.BP.Bll.App
{
    public class OpcionManager
    {
        public static Opcion GetItem(int codigo)
        {
            Opcion opcion = new Opcion();

            opcion = OpcionDB.GetItem(codigo);

            return opcion;
        }
        //public static Opcion GetItemById(string id)
        //{
        //    return OpcionDB.GetItem(
        //}
        public static OpcionCollection GetList(int codAplicacion)
        {
            OpcionCollection opciones = new OpcionCollection();

            opciones = OpcionDB.GetList(codAplicacion);

            return opciones;
        }
    }
}
