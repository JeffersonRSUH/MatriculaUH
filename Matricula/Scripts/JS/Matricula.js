function matricular() {
    var idEstudiante = $('#txtEstudianteId').val();
    var idGrupo = $('#txtGrupoId').val();

    $.ajax({
        type: "POST",
        url: "ManejoMatricula.aspx/Matricular",
        data: JSON.stringify({ idEstudiante: idEstudiante, idGrupo: idGrupo }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.d);
            // Refresh matriculas list
            refreshMatriculas();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function desmatricular() {
    var idMatricula = $('#txtMatriculaId').val();

    $.ajax({
        type: "POST",
        url: "ManejoMatricula.aspx/Desmatricular",
        data: JSON.stringify({ idMatricula: idMatricula }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.d);
            // Refresh matriculas list
            refreshMatriculas();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function refreshMatriculas() {
    $.ajax({
        type: "POST",
        url: "ManejoMatricula.aspx/ListarMatriculas",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $('#ltMatriculas').html(response.d);
        }
    });
}