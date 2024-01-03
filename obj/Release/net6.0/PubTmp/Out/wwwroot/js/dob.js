function disableDates(minDate, maxDate) {
    $(document).ready(function () {
        $("#dob").datepicker({
            minDate: minDate,
            maxDate: maxDate
        });
    });
}
