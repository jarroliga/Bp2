Sys.Application.add_load(AppLoad);

function AppLoad(sender, args) {
    $(document).ready(function() {
        SetItems();
    });
}
function SetItems() {
    $('.colapsable').truncate({ max_length: 75, showLinks: false });

}