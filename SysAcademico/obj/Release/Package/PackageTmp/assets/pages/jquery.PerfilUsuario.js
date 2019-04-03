
function CargarImagen(imagen) {
	$("#avatar-2").fileinput({
		overwriteInitial: true,
		maxFileSize: 1500,
		showClose: false,
		showCaption: false,
		showBrowse: false,
		browseOnZoneClick: true,
		removeLabel: '',
		removeIcon: '<i class="glyphicon glyphicon-remove"></i>',
		removeTitle: 'Cancel or reset changes',
		elErrorContainer: '#kv-avatar-errors-2',
		msgErrorClass: 'alert alert-block alert-danger',
		defaultPreviewContent: '<img src="'+imagen+'" alt="Your Avatar" style="max-width: 100%;"><h6 class="text-muted">Cambiar de imagen</h6>',
		//layoutTemplates: { main2: '{preview} ' + btnCust + ' {remove} {browse}' },
		allowedFileExtensions: ["jpg", "png", "gif"]
	});
}