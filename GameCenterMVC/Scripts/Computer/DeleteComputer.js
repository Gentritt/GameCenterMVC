$(function () {
	var SuccessMessage = 'Success'
	if (SuccessMessage != '')
		alertify.success(SuccessMessage);

});

function Delete(id) {
	alertify.confirm('customer Management System', 'Are You Sure To Delete This Record ?', function () {
		window.location.href = '@Url.Action("Remove","Computer")/' + id;
	}, null);
}
