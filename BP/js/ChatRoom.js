/// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />
//Ing.Fco javier areas rios

     
        function SetScrollPosition()
        {
            //var div = document.getElementById('divMessages');
            //div.scrollTop = 100000000000;
            var objDiv = document.getElementById("divMessages");
            objDiv.scrollTop = objDiv.scrollHeight;

        }
        
        
        function SetToEnd(txtMessage)
        {                    
            if (txtMessage.createTextRange)
            {
                var fieldRange = txtMessage.createTextRange();
                fieldRange.moveStart('character', txtMessage.value.length);
                fieldRange.collapse();
                fieldRange.select();
            }
        }
               
        function ReplaceChars() 
        {
            var txt = document.getElementById('txtMessage').value;
            var out = "<"; 
            var add = "";
            var temp = "" + txt; 

            while (temp.indexOf(out)>-1) 
            {
                pos= temp.indexOf(out);
                temp = "" + (temp.substring(0, pos) + add + 
                temp.substring((pos + out.length), temp.length));
            }
            
            document.getElementById('txtMessage').value = temp;
        }
        
        function LogOutUser(result, context) {
        }
        
        //Invocamos una funcion en el servidor Icallbackeventhandler
        function LogMeOut() {
            LogOutUserCallBack();   
        }
  