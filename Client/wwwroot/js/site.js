Pusher.logToConsole = true;

var pusher = new Pusher('APP_KEY', {
    cluster: 'APP_CLUSTER'
});

var channel = pusher.subscribe('my-channel');
channel.bind('my-event', function(data) {

    var content = "<div class='alert alert-success alert-dismissible fade show' role='alert'>" 
    content += "<span>" + data.message + "</span>"
    content += "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>"
    content += "<span aria-hidden='true'>&times;</span>"
    content += "</button></div>"

    $("#message-panel").append(content)
});