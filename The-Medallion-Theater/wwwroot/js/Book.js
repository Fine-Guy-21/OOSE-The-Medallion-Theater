$(document).ready(function () {
    var selectedSeats = [];
    // to calculate total price 
    var totalPrice = 0;

/*    var val = "A6, G4, H12, H13, D25, D26, D27, C27, C26, C25, B25, B26, B27, A27, X11, X13, X5";*/
    var val = $('#reseatNo').val();
    console.log(val);
    var notAvailableSeats = val.split(',').map(function (seat) {
        return seat.trim();
    });

    $('.s').each(function () {
        var seat = $(this).text().trim();
        if (notAvailableSeats.includes(seat)) {
            $(this).css("background-color", "red");
        }
    });

    $('.seat').on('click', '.s', function () {
        var seattxt = $(this).text();
        var seat = $(this);



        if (notAvailableSeats.includes(seattxt)) {
            console.log("Not available")
        }
        else {
            var index = selectedSeats.indexOf(seattxt);
            if (index === -1) {
                // Adding the seat to the selected seats array
                selectedSeats.push(seattxt);
                var price = GetPrice(seattxt);
                totalPrice = totalPrice + price
                $(".price").val(totalPrice)
            } else {
                // Removing the seat from the selected seats array
                selectedSeats.splice(index, 1);
                var price = GetPrice(seattxt);
                totalPrice = totalPrice - price
                $(".price").val(totalPrice)
            }
        }
        // Updating the "Seats" input value with the selected seats
        $('#seatNo').val(selectedSeats.join(', '));
    });
});

// to show a seat is available or not 
$(document).ready(function () {

    var val = $('#reseatNo').val();
    
    var notAvailableSeats = val.split(',').map(function (seat) {
        return seat.trim();
    });

    $(".s").click(function () {
        var seattxt = $(this).text();
        var seat = $(this);
        var firstLetter = seattxt.charAt(0)
        if (notAvailableSeats.includes(seattxt)) {
            console.log("No color change")
        }
        else {
            if (seat.css("background-color") == "rgb(255, 0, 0)" && seat) {
                if (firstLetter >= 'A' && firstLetter <= 'F') {
                    if (seattxt.charAt(1) >= 'A' && seattxt.charAt(1) <= 'F') {

                        seat.css("background-color", "rgb(204, 255, 204)");
                    }

                    else {
                        seat.css("background-color", "rgb(222, 235, 247)");
                    }
                }
                else if (firstLetter >= 'G' && firstLetter <= 'N') {
                    seat.css("background-color", "rgb(251, 229, 214)");
                }
                else {
                    seat.css("background-color", "rgb(255, 230, 153)");
                }
            }
            else {
                seat.css("background-color", "red");
            }
        }

    });

});


function GetPrice(seat_text) {
    var firstLetter = seat_text.charAt(0);

    if (firstLetter >= 'A' && firstLetter <= 'F') {
        if (seat_text.charAt(1) >= 'A' && seat_text.charAt(1) <= 'F') {

            return 40;
        }

        else {

            return 65;
        }
    }
    else if (firstLetter >= 'G' && firstLetter <= 'N') {

        return 55;
    }
    return 80;
} 