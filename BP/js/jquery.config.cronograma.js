Sys.Application.add_load(AppLoad);

function AppLoad(sender, args) {
    $(document).ready(function() {
        SetItems();
    });
}
function SetItems() {
    $('.colapsable').truncate({ max_length: 60, showLinks: false });

}