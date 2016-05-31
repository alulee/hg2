// get color depending on population density value
function getColor(d) {
    return d > 2000 ? '#800026' :
           d > 1950 ? '#BD0026' :
           d > 1900 ? '#E31A1C' :
           d > 1850 ? '#FC4E2A' :
           d > 1800 ? '#FD8D3C' :
           d > 1750 ? '#FEB24C' :
           d > 1700 ? '#FED976' :
                      '#FFEDA0';
}

function getColorByGeneration(d) {
    return d >= 16 ? '#2DB300' :
           d >= 15 ? '#8C0000' :
           d >= 14 ? '#4000FF' :
           d >= 13 ? '#FFFF26' :
           d >= 12 ? '#FFCC99' :
           d >= 11 ? '#FFB299' :
           d >= 10 ? '#FFDFBF' :
                    '#FFEDA0';
}

function style(feature) {
    return {
        weight: 2,
        opacity: 1,
        color: '#FF2626',
        dashArray: '3',
        fillOpacity: 0.7,
        fillColor: getColorByGeneration(feature.properties.generation)
    };
}

function highlightFeature(e) {
    var layer = e.target;

    layer.setStyle({
        weight: 3,
        color: '#00B300',
        dashArray: '1',
        fillOpacity: 0.7
    });

    if (!L.Browser.ie && !L.Browser.opera) {
        layer.bringToFront();
    }

    info.update(layer.feature.properties);
}
 
function zoomToFeature(e) {
    map.fitBounds(e.target.getBounds());
}

function onEachFeature(feature, layer) {
    layer.on({
        mouseover: highlightFeature,
        mouseout: resetHighlight,
        click: zoomToFeature
    });
}
var geojsonMarkerOptions = {
    radius: 6,
    fillColor: "#5CFF26",
    color: "#5CFF26",
    weight: 2,
    opacity: 1,
    fillOpacity: 0.6
};


function showRouteMap(points, map, displayRoute) {

    var currentPoint;
    var attr = {
        'stroke': '#B35900',
        'stroke-width': 3
    };

    if (points) {
        for (i = 0; i < points.length; i++) {
            currentPoint = points[i];
            if (i == 0) {
                resetMap(currentPoint, map);
            }
            showPoint(currentPoint, map);
            if (i >= 1 && displayRoute) {
                startPoint = points[i - 1];
                var b = new R.BezierAnim([startPoint, currentPoint], attr, showPoint);
                map.addLayer(b);
            }
        }
    }
}

function showPoint(currentPoint, map) {
    if (!currentPoint) {
        return;
    }

    var p = new R.Pulse(
            currentPoint,
            6,
            { 'stroke': '#FF2626', 'fill': '#FF2626' },
            { 'stroke': '#FF2626', 'stroke-width': 4 });

    map.addLayer(p);
    setTimeout(function () {
        //map.removeLayer(b).removeLayer(p);
    }, 3000);
}

function resetMap(initialPoint, map) {
   
    var tiles = new L.TileLayer('http://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '',
        maxZoom: 18
    });

 
    map.setView(initialPoint, 8).addLayer(tiles);
 
}