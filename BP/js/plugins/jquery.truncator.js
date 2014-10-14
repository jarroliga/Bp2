/// <reference name="MicrosoftAjax.js"/>
/// <reference path="jquery-vsdoc.js" />

// HTML Truncator for jQuery
// by Henrik Nyh <http://henrik.nyh.se> 
// Free to modify and redistribute with credit.

//Se realizaron modificaciones por Ing. Francisco Javier Areas Rios

(function($) {

  var trailing_whitespace = true;

  $.fn.truncate = function(options) {

    var opts = $.extend({}, $.fn.truncate.defaults, options);
    
    $(this).each(function() {

      var content_length = $.trim(squeeze($(this).text())).length;
      if (content_length <= opts.max_length)
        return;  

      var actual_max_length = opts.max_length - opts.more.length - 3;  // 3 for " ()"    
      var truncated_node = recursivelyTruncate(this, actual_max_length);
      var full_node = $(this);

      truncated_node.insertAfter(full_node);
      truncated_node.find('p:last').add(truncated_node).eq(0).
        append(' (<a href="#show more content" title="Click aca para mostrar todo el contenido">' + opts.more + '</a>)');

      full_node.hide();
      full_node.find('p:last').add(full_node).eq(0).
        append(' (<a href="#show less content" title="Click aca para ocultar el contenido">' + opts.less + '</a>)');

      truncated_node.find('a:last').click(function() {
        truncated_node.hide(); full_node.show(); return false;
    });
      
      full_node.find('a:last').click(function() {
      truncated_node.show(); full_node.hide();  return false;
      });

    });
  }

 
  $.fn.truncate.defaults = {
    max_length: 50,
    more: 'M&aacute;s',
    less: 'Menos'
  };

  function recursivelyTruncate(node, max_length) {
    return (node.nodeType == 3) ? truncateText(node, max_length) : truncateNode(node, max_length);
  }

  function truncateNode(node, max_length) {
    var node = $(node);
    var new_node = node.clone().html("");
    node.contents().each(function() {
      var remaining_length = max_length - new_node.text().length;
      if (remaining_length == 0) return;
      new_node.append(recursivelyTruncate(this, remaining_length));
    });
    return new_node;
  }

  function truncateText(node, max_length) {
    var text = squeeze(node.data);
    if (trailing_whitespace)  
      text = text.replace(/^ /, '');  
    trailing_whitespace = !!text.match(/ $/);
    var text = text.slice(0, max_length);
    text = $('<div/>').text(text).html();
    return text;
  }

  // colapsar
  function squeeze(string) {
    return string.replace(/\s+/g, ' ');
  }

})(jQuery);