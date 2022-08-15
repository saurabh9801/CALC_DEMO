function myFunction() {
    debugger;
    var result;
    var input = $('#fNum').val();

    var myArray = input.split(" ");

    var numFst = parseInt(myArray[0]);
    var operator = myArray[1];
    var numSnd = parseInt(myArray[2]);

    switch (operator) {
        case "+":
            result = numFst + numSnd;
            break;
        case "-":
            result = numFst - numSnd;
            break;
        case "X":
            result = numFst * numSnd;
            break;
        case "x":
            result = numFst * numSnd;
            break;
        case "/":
            result = numFst / numSnd;
            break;
    }

    $(document).ready(function () {
        $("#tResult").val(result);
    });
    //('#tResult').load(result);

    var today = new Date();
    var postData = { "Fst_Number": numFst, "Snd_Number": numSnd, "Operator": operator, "Result": result, "CreatedOn": today };

    $.ajax({
        url: 'http://localhost:62449/api/CalculatorCrud/PostCalcHistory',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(postData),
        //success: function () {
        //    alert('Success');
        //},
        //error: function () {
        //    alert('error');
        //}
    });
};