using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Snip.BP.BO.App;
using Snip.BP.Dal.App;
using Snip.BP.Validation;

namespace Snip.BP.Bll.App
{
    public static class PerfilManager
    {
        public static Perfil GetItem(int codigo)
        {
            return GetItem(codigo, false, false, -1, false);
        }
        public static Perfil GetItemWithOpciones(int codigo)
        {
            return GetItem(codigo, true, false, -1, false);
        }
        public static Perfil GetItem(int codigo, bool getOpciones, bool getEstados, int codTarea, bool getTransiciones)
        {
            Perfil perfil = new Perfil();

            perfil = PerfilDB.GetItem(codigo);

            if (perfil != null)
            {
                if (getOpciones)
                {
                    OpcionCollection opciones = new OpcionCollection();

                    opciones = OpcionDB.GetListByPerfil(codigo);

                    perfil.Opciones = opciones;
                }
                if (getEstados)
                {
                    EstadoCollection estados = new EstadoCollection();

                    estados = EstadoDB.GetListByPerfil(codTarea, codigo);
                }
            }
            return perfil;
        }
        public static PerfilCollection GetList(int codAplicacion)
        {
            PerfilCollection perfiles = new PerfilCollection();

            perfiles = PerfilDB.GetList(codAplicacion);

            return perfiles;
        }
        public static bool ValidateEstado(int codPerfil, int codTarea, int codEstadoActual)
        {
            PerfilEstado estado = new PerfilEstado();
            
            estado = PerfilEstadoDB.GetItem(codPerfil, codEstadoActual);
            
            bool hasPermission = false;
            
            if (estado != null)
            {
                hasPermission = true;
            }
            return hasPermission;
        }
        public static bool ValidateOpcion(int codPerfil, int codOpcion)
        {
            PerfilOpcion opcion = new PerfilOpcion();

            opcion = PerfilOpcionDB.GetItem(codPerfil, codOpcion);

            bool hasPermission = false;

            if (opcion != null)
            {
                hasPermission = true;
            }

            return hasPermission;
        }
    }
}
