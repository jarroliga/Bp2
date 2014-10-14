
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.Design;
using System.ComponentModel.Design;
using Snip.Web.UI.TextBox;

namespace Snip.Web.UI.TextBox.design
{
  public class snipTextBoxDesigner : ControlDesigner
  {
    private DesignerActionListCollection m_ActionLists = null;
    
   /// <summary>
   /// se sobreescribe esta propiedad para mostrar las etiquetas inteligentes.
   /// se debe derivar del controldesigner y luego se sobreescribe esa coleccion
   /// </summary>
    public override DesignerActionListCollection ActionLists
    {
      get
      {
        if (m_ActionLists == null)
        {
          m_ActionLists = base.ActionLists;
          m_ActionLists.Add(new snipTextBoxActionList((snipTextBox)Component));
        }
        return m_ActionLists;
      }
    }
  

  }
}
