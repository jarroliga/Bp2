using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using Snip.BP.BO.App;
using Snip.BP.Bll.App;
using Snip.Enums;

namespace BP
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.HideMenuAll();
            Master.SetMenuVisible(MenuIndex.Inicio, true);

            if (Request.QueryString.Get("do") != null)
            {
                if (String.Compare(Request.QueryString["do"].ToString(), "logout") == 0)
                {
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                    Response.Redirect("LoginPage.aspx");
                }
            }
        }
        /// <summary>
        /// Manejador de evento para el evento de validación de credenciales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LogBpsAuthenticate(object sender, AuthenticateEventArgs e)
        {
            string loginUsuario = this.logBP.UserName;
            string password = this.logBP.Password;

            //int codAplicacion = Convert.ToInt32(Application["CodAplicacion"]);
            int codAplicacion = 1;

            Usuario usuario = new Usuario();

            usuario = UsuarioManager.Validate(loginUsuario, password);

            if (usuario != null)
            {
                UsuarioPerfil perfilUsuario = new UsuarioPerfil();

                perfilUsuario = UsuarioManager.GetPerfilUsuarioByAplicacion(usuario.Codigo, codAplicacion);

                if (perfilUsuario != null)
                {
                    e.Authenticated = true;
                    SessionManager.RegisterSession(Session.SessionID, usuario.Codigo, codAplicacion, Session.Timeout);

                    //BOFiltros.ClearSessionFiltro(Session.SessionID);
                    //this.Session.Add("LoginUsuario", loginUsuario);
                    this.Session.Add("CodUsuario", usuario.Codigo);
                    this.Session.Add("CodPerfil", perfilUsuario.Perfil.Codigo);
                    this.Session.Add("IdPerfil", perfilUsuario.Perfil.IdPerfil);

                    string anioEjer = AplicacionManager.ParametroGetValueById("ANIO_EJER");

                    if (anioEjer != null)
                    {
                        this.Session.Add("AnioPIP", anioEjer);
                    }

                    FormsAuthentication.RedirectFromLoginPage(loginUsuario, true);
                }
            }
            else
            {
                e.Authenticated = false;
            }

        }
    }
}