/// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />

/*Extension de Jquery para simular mensajes tipo chat de gmail*/
/*Basado en el libro de animaciones y ajax de jquery 1.3 */
/* y API de Gmail, se adapto a jquery*/

(function($) {
$.widget("ui.notificationmsg", {
    
    init: function() {
        $.ui.notificationmsg._bottompost=this.element.css("bottom");
        $.ui.notificationmsg._height=this.element.css("height");  
    },
    
    show: function(){
        var o = this.options;
        if(this.element.is(":hidden")){
            this.element.queue(function(){$.ui.notificationmsg.animations[o.animation](this, o);}).dequeue();
        }            
    },
    
    hide: function(){
        this.element.stop(true);
        var o = this.options;
        if(this.element.is(":visible")){
            this.element.queue(function(){$.ui.notificationmsg.animations[o.animation](this, o);}).dequeue();
        }
    }
});    

$.ui.notificationmsg._bottompost = "0px";
$.ui.notificationmsg._css;
$.extend($.ui.notificationmsg, {
    defaults: {
        // velocidad de la animacion
        speed: 1000,
        //Periodo
        period: 8000, 
        // animacion por defecto
        animation:'slide'
    },
    animations: {
        slide: function(e, options) {
            if($(e).is(":hidden")){
                
                //  animar
                $anim = $(e).animate({height: "show"}, options.speed)
                
                if(options.period && options.period > 0){
                    $anim.animate({opacity: 1.0}, options.period)
                        .animate({height: "hide"}, options.speed);
                }
            }
            else{
                $(e).animate({height: "hide"}, options.speed)
            }
            
            $(e).css("height",$.ui.notificationmsg._height);
        },
        fade: function(e, options) {
            if($(e).is(":hidden")){
                //  animar
                $anim = $(e).animate({opacity: "show"}, options.speed);
                
                if(options.period && options.period > 0){
                    $anim.animate({opacity: 1.0}, options.period)
                        .animate({opacity: "hide"}, options.speed);
                }
            }
            else{
                $(e).animate({opacity: "hide"}, options.speed);
            }
            
            $(e).css("opacity",1.0);
        },
        slidethru: function(e, options) {
            //  establecer las posicion
            var b = $.ui.notificationmsg._bottompost;
            var h = $.ui.notificationmsg._height;
            if($(e).is(":hidden")){
                //  animar
                $anim = $(e).animate({height: "show"}, options.speed);
                
                if(options.period && options.period > 0){                       
                    $anim.animate({opacity: 1.0}, options.period)
                        .animate({height: "hide", bottom: h}, options.speed)
                        .animate({bottom: b}, 1);
                }
            }
            else{
                $(e).css({height:h,bottom:b});
                $(e).animate({height: "hide", bottom: h}, options.speed)
                    .animate({bottom: b}, 1);
            }
            $(e).css({height:h,bottom:b});
                           
        }
    }
});
})(jQuery);