

function myFunction(user, repo) {
    

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Home/commits?user=" + user + "&repo=" + repo,
        data: { 'userName': user, 'repoName': repo },
        success: displayCommits,
        error: errorOnAjax
    });
};

function displayCommits(data) {

    console.log(data); 
};
function errorOnAjax() {
    console.log('Error on AJAX return');
};
function displayCommits(data) {
    document.getElementById("commits1").remove();
    $('#commitsTable').append($('<table id="commits1">'));
    $('#commits1').append($('<tr id="tableTr">'));
    $('#tableTr').append($('<td id="tdSha"> <b>  SHA </td>'));
    $('#tableTr').append($('<td id="tdCommitter"> <b> Committer </td>'));
    $('#tableTr').append($('<td id="tdWhen"> <b>  Time </td>'));
    $('#tableTr').append($('<td id="tdMessage"> <b> Message </td>'));
    $('#commits1').append($('</tr>'));
    $('#commitsTable').append($('</table>'));

    for (var i = data.length - 1; i >= 0; --i) {
        var count = 1;
        var table = document.getElementById("commits1");
        var row = table.insertRow(count);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        var cell3 = row.insertCell(2);
        var cell4 = row.insertCell(3);
        cell1.innerHTML = '<a href="' + data[i].CommitUrl + '">' + data[i].Sha + '</a>';
        cell2.innerHTML = data[i].Committer;
        cell3.innerHTML = data[i].Date;
        cell4.innerHTML = data[i].Message;
        count++;
    }
}