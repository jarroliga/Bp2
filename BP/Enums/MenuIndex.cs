using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snip.Enums
{
    public enum MenuIndex
    {
        Inicio = 0,
        Preinversion,
        Iniciativas,
        ProgramaPi,
        ComponentePi,
        ProyectoPi,
        BancoProyectos,
        Programa,
        Componente,
        Proyecto,
        Obra,
        Licitaciones,
        Licitacion,
        Contratos,
        Contrato,
        GestionMunicipal,
        Evaluacion,
        ConfiguracionBpm,
        Seguridad,
        Administracion,
        Reportes,
    }
    public enum MenuOptions
    {
        Aplicacion = 201,
        Opciones,
        Perfiles,
        Estados,
        Usuarios
    }
    public enum AppForms
    {
        OpcionList = 2101,
        OpcionNew,
        OpcionEdit,
        PerfilList = 2201,
        PerfilNew,
        PerfilEdit
    }
}