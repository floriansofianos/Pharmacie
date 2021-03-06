$(document).ready(function(){
  $('.bxslider').bxSlider({
  mode: 'fade',
	  pager: false
	});
	if($('#map-container')){
		initialize();
		var marker = new google.maps.Marker({
    		position : latLng,
    		map      : map,
    		title    : "Pharmacie Sofianos"
		});
		var contentMarker = '<div><h1>Pharmacie Sofianos</h1></div><div>135 Rue de Conflans</div>'
		var infoWindow = new google.maps.InfoWindow({
    						content  : contentMarker,
    						position : latLng
		});
		infoWindow.open(map,marker);
		google.maps.event.addListener(marker, 'click', function() {
    		infoWindow.open(map,marker);
		});
	}
	

	
});

var map;
var initialize;
var latLng = new google.maps.LatLng(48.998319,2.152193);
 
initialize = function(){
  var myOptions = {
    zoom      : 16,
    center    : latLng,
    mapTypeId : google.maps.MapTypeId.ROADMAP,
    maxZoom   : 20
  };
 
  map      = new google.maps.Map(document.getElementById('map_container'), myOptions);
};

deleteOrdonnance = function(id){
	$.get( "/Handlers/OrdonnanceHandler.ashx", { cas: "deleteOrdonnance", id: id } )
		.done(function( data ) {
			alert( "Data deleted " + data );
		});
	};
 
approveOrdonnance = function(id){
	$.get( "/Handlers/OrdonnanceHandler.ashx", { cas: "approveOrdonnance", id: id } )
		.done(function( data ) {
			alert( "Data approved " + data );
		});
	};