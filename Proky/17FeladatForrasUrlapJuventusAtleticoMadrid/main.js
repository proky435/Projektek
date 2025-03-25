function betolt() {
	document.getElementById('eredmeny').style.display = 'none';
}

function torol() {
	location.reload();
}

function szamol() {

	document.getElementById('eredmeny').style.display = '';

	const USD = 281.5;
	const EUR = 317.2;

	let jegyTipusAr = document.getElementById('jegyTipus').value;
	let jegyDb = document.getElementById('jegyDb').value;

	jegyTipusAr = parseInt(jegyTipusAr);
	jegyDb = parseInt(jegyDb);

	document.getElementById('jegy1Db').innerHTML = jegyTipusAr + ' HUF';
}
