var changedValues = new Array();
function OnValueChanged(s, fieldName, keyValue) {
	var itemIsFound = false;
	for (var i = 0; i < changedValues.length; ++i) {
		if ((changedValues[i].key == keyValue)
			&& (changedValues[i].field == fieldName)) {
			changedValues[i].value = s.GetValue();
			itemIsFound = true;
			break;
		}
	}
	if (!itemIsFound)
		changedValues.push({ key: keyValue, field: fieldName, value: s.GetValue() });
}

function OnClick(url) {
	$.ajax({
		type: "POST",
		url: url,
		data: $.postify(changedValues),
		beforeSend: function () {
			$(".status").text("Request has been sent");
		},
		success: function (msg) {
			$(".status").html(msg);
		}
	});
}

$.postify = function (value) {
	var result = {};
	var buildResult = function (object, prefix) {
		for (var key in object) {

			var postKey = isFinite(key)
	                ? (prefix != "" ? prefix : "") + "[" + key + "]"
	                : (prefix != "" ? prefix + "." : "") + key;

			switch (typeof (object[key])) {
				case "number": case "string": case "boolean":
					result[postKey] = object[key];
					break;

				case "object":
					if (object[key].toUTCString)
						result[postKey] = object[key].toUTCString().replace("UTC", "GMT");
					else {
						buildResult(object[key], postKey != "" ? postKey : key);
					}
			}
		}
	};

	buildResult(value, "changedValues");

	return result;
};