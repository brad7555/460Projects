$('#request').click(function () {
    var ath = $('#athchoice').val();
    var ev = $('#evchoice').val();
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: "/Graph/GraphMath",
        data: { 'event': ev, 'athlete': ath },
        success: plotGraph,
        error: errorOnAjax
    });
});

function errorOnAjax() {
    console.log('Error on AJAX return');
}

function plotGraph(data) {
    
    var dateArray = [];
    for (var i = 0; i < data.length; ++i) {
        dateArray[i] = data[i].eventDate;
    }
    
    var timeArray = [];
    for (var i = 0; i < data.length; ++i) {
        timeArray[i] = data[i].Result1;
    }
    var trace = {
        x: dateArray,
        y: timeArray,
        mode: 'lines',
        type: 'scatter',
    };
    var plotData = [trace];
    var layout = {};
    Plotly.newPlot('theplot', plotData, layout);
} 