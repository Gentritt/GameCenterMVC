@section Scripts{


    <script>
        $(function () {
        var SuccessMessage = '@TempData["SuccessMessage"]'
        if (SuccessMessage != '')
            alertify.success(SuccessMessage);

    });

    function Delete(id) {
            alertify.confirm('customer Management System', 'Are You Sure To Delete This Record ?', function () {
                window.location.href = '@Url.Action("Delete","Employee")/' + id;
            }, null);
    }
	</script>

} 