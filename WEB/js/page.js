$(document).ready(function(){
   $('[data-toggle="offcanvas"]').click(function(){
       $("#navigation").toggleClass("hidden-xs");
   });
    $('.side-nav .collapse').on("show.bs.collapse", function() {                        
        $(this).prev().find(".fa").eq(1).removeClass("fa-angle-down").addClass("fa-angle-right");        
    });
});

$(document).ready(function(){
google.charts.load('current', {'packages':['corechart']});
  google.charts.setOnLoadCallback(drawChart);

  function drawChart() {

    var data = google.visualization.arrayToDataTable([
      ['Task', 'Hours per Day'],
      ['New Enquiry',     11],
      ['Complaint Enquiry',      2],
      ['Closed Enquiry',  2],
      ['in Process', 2]
    ]);

    var options = {
      title: '',
	  is3D: true,
        pieStartAngle: 0,
    };

    var chart = new google.visualization.PieChart(document.getElementById('piechart'));

    chart.draw(data, options);
  }
  
  });
  
  
  
  
  
  
//var modal = document.getElementById('myModal');
//var btn = document.getElementById("myBtn");
//var span = document.getElementsByClassName("close")[0];
//btn.onclick = function () {
//    modal.style.display = "block";
//    modal.style.display = "block";
//}
//span.onclick = function () {
//    modal.style.display = "none";
//}
//window.onclick = function (event) {
//    if (event.target == modal) {
//        modal.style.display = "none";
//    }
//}
      
	  
	  
	  
	
	

