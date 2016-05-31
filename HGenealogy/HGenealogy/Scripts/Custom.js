function showroute() {
    //L.marker([29.114, 107.358]).addTo(map)
    //	.bindPopup("<b>事件地點一</b>").openPopup();
    //L.polygon([
    //	[29.114, 107.358],
    //	[29.114, 107.328],
    //	[29.114, 107.318]
    //]).addTo(map).bindPopup("I am a polygon.");

    L.circle([29.114, 107.158], 50000, {
        color: 'red',
        fillColor: '#f03',
        fillOpacity: 0.5
    }).addTo(map).bindPopup("I am a circle.");

    pausecomp(2000)
    L.circle([28.014, 106.358], 50000, {
        color: 'blue',
        fillColor: '#f33',
        fillOpacity: 0.5
    }).addTo(map).bindPopup("I am a circle.");


    var popup = L.popup();
}


$("#showroute").click(showroute);