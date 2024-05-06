$(document).ready(function () {
    var selectedSeats = [];
    // to calculate total price 
    var totalPrice = 0;

    var val = $('#reseatNo').val();
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


$(document).ready(function () {
    var seats = $('#fortheseats').val();    
    console.log(seats);
    var soldseats = seats.split(',').map(function (seat) {
        return seat.trim();
    });
    var totalrevenue = 0;
    if (seats.trim() !== '') {
        soldseats.forEach(function (seat) {
            var price = GetPrice(seat);
            totalrevenue += price;
        });
    }
    $('#noborderdisplay').val(seats.trim() === '' ? 0 : totalrevenue);
    console.log($('#noborderdisplay').val());
});

$(document).ready(function () {
    $('.chiild').each(function () {
        var parentBackgroundColor = $(this).parent('.parrent').css('background-color');
        $(this).css('background-color', parentBackgroundColor);
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