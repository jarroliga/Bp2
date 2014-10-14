using System;
using System.Collections.Generic;
using System.ComponentModel;

using Snip.BP.BO.App;
using Snip.BP.Dal.App;
using Snip.BP.Validation;

namespace Snip.BP.Bll.App
{
    public static class SessionManager
    {
        public static Session GetItem(string sessionId)
        {
            return SessionDB.GetItem(sessionId);
        }
        public static Session GetItem(string sessionId, bool getFiltros)
        {
            Session session = new Session();

            session = SessionDB.GetItem(sessionId);

            if (session != null && getFiltros)
            {
                session.Filtros = FiltroDB.GetList(session.Codigo);
            }

            return session;
        }

        public static void RegisterSession(string sessionId, int codUsuario, int codAplicacion, int timeout)
        {
            Session session = new Session();

            session.SessionId = sessionId;
            session.Aplicacion.Codigo = codAplicacion;
            session.Usuario.Codigo = codUsuario;
            session.FechaEmision = DateTime.Now;
            session.Validez = timeout;

            SessionDB.Save(session);
        }
    }
}
