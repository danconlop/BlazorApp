function DotNetStaticMethodTest() {
    DotNet.invokeMethodAsync("BlazorApp.Client", "GetCurrentCount")
        .then(result => {
            console.log("Current count from Javascript is " + result);
        });
}

function DotNetInstanceMethodTest(dotNetHelper) {
    dotNetHelper.invokeMethodAsync("IncrementCount");
}

window.getSelectedValues = function (sel) {
	var results = [];
	var i;
	for (i = 0; i < sel.options.length; i++) {
		if (sel.options[i].selected) {
			results[results.length] = sel.options[i].value;
		}
	}
	return results;
};
