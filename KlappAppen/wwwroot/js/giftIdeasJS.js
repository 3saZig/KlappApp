


var slider = document.getElementById("myRange");
var output = document.getElementById("demo");
output.innerHTML = slider.value; // Display the default slider value


let nollTillFem = ["Bok", "Skallra", "Något", "Annat"];
let nfl = nollTillFem.length;
let text = "<ul>";





// Update the current slider value (each time you drag the slider handle)
slider.oninput = function () {

	output.innerHTML = this.value;
	var x = document.getElementById("myRange").value;

	if (x >= 0 && x < 5) {
		document.getElementById("giftDisplay").innerHTML = "Sångbok med ljudspelare" + "<br/>" + "En katt" + "<br/>" + "Playmobil" + "<br/>" + "Småbilar" + "<br/>" + "Badkarsleksaker";
	}
	else if (x >= 5 && x < 10) {
		document.getElementById("giftDisplay").innerHTML = "Pyssel" + "<br/>" + "Dagbok" + "<br/>" + "Målarfärger" + "<br/>" + "Lego" + "<br/>" + "En katt";
	}
	else if (x >= 10 && x < 15) {
		document.getElementById("giftDisplay").innerHTML = "Hörlurar" + "<br/>" + "Lego" + "<br/>" + "Brädspel" + "<br/>" + "En katt" + "<br/>" + "Kläder";
	}
	else if (x >= 15 && x < 20) {
		document.getElementById("giftDisplay").innerHTML = "Bluetooth-högtalare" + "<br/>" + "En katt" + "<br/>" + "Konsertbiljett" + "<br/>" + "Presentkort" + "<br/>" + "Parfym";
	}
	else if (x >= 20 && x < 30) {
		document.getElementById("giftDisplay").innerHTML = "Resa" + "<br/>" + "En katt" + "<br/>" + "Ljudsystem" + "<br/>" + "Husgeråd" + "<br/>" + "Zorbing";
	}
	else if (x >= 30 && x < 40) {
		document.getElementById("giftDisplay").innerHTML = "Träningskläder" + "<br/>" + "Klocka" + "<br/>" + "En katt" + "<br/>" + "Elcykel" + "<br/>" + "Fallskärmshopp";
	}
	else if (x >= 40 && x < 50) {
		document.getElementById("giftDisplay").innerHTML = "Tekopp" + "<br/>" + "Restaurangbesök" + "<br/>" + "Ölprovning" + "<br/>" + "En katt" + "<br/>" + "Fotoalbum";
	}
	else if (x >= 50 && x < 60) {
		document.getElementById("giftDisplay").innerHTML = "Klocka" + "<br/>" + "Golfklubba" + "<br/>" + "Digital fotoram" + "<br/>" + "Kaffemaskin" + "<br/>" + "En katt";
	}
	else if (x >= 60 && x < 70) {
		document.getElementById("giftDisplay").innerHTML = "Riktigt bra choklad" + "<br/>" + "Kakform" + "<br/>" + "En katt" + "<br/>" + "Bok" + "<br/>" + "Löparskor";
	}
	else if (x >= 70 && x < 80) {
		document.getElementById("giftDisplay").innerHTML = "Marmeladkulor" + "<br/>" + "Tekopp" + "<br/>" + "Garnnystan" + "<br/>" + "En katt" + "<br/>" + "Tofflor";
	}
	else if (x >= 80 && x < 100) {
		document.getElementById("giftDisplay").innerHTML = "Spotify-abonnemang" + "<br/>" + "En katt" + "<br/>" + "Champagne" + "<br/>" + "Teaterbesök" + "<br/>" + "Chokladfontän";
	}
	else if (x >= 100 && x <= 120) {
		document.getElementById("giftDisplay").innerHTML = "Fotoalbum" + "<br/>" + "Tekanna" + "<br/>" + "Zombie escape" + "<br/>" + "En katt" + "<br/>" + "Fallskärmshopp";
	}
	else if (x >= 120 && x <= 130) {
		document.getElementById("giftDisplay").innerHTML = "Globalkniv" + "<br/>" + "Riktigt gott kaffe" + "<br/>" + "Ullunderställ" + "<br/>" + "Ut och äta med barnbarnsbarnen" + "<br/>" + "En katt";
	}
};





//var x = document.getElementById("myRange").value;

