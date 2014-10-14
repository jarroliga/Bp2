Sys.Application.add_load(AppLoad);

function AppLoad(sender, args) {
    $(document).ready(function() {
        SetItems();
    });
}
function SetItems() {
    $('.colapsable').truncate({ max_length: 35, showLinks: false });

}