@section scripts{
	<script>
		$(function () {
			var SuccessMessage = '["Success"]'
			if (SuccessMessage != '')
				alertify.success(SuccessMessage);

		});

		function Delete(id) {
			alertify.confirm('Warning !!', 'Are You Sure To Delete This Record ?', function () {
				window.location.href = '@Url.Action("Remove","Product")/' + id;
			}, null);
		}
		</script>

}