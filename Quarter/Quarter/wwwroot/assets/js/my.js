$(document).ready(function () {
/*
    $(document).on("click", ".show-product-modal", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");

        fetch('https://localhost:44322/home/getbook/' + id)
            .then(response => response.text())
            .then(data => {


                $("#product-modal-detail").html(data)
            });
        // get data from controller

        //set data 

        $("#quickModal").modal("show")
    })*/

    $(document).on("click", ".add-wish-btn", function (e) {
        e.preventDefault();
        var id = $(this).attr("data-id");

        fetch('https://localhost:44369/shop/addwishlist/' + id)
            .then(response => response.text())

            .then(data => {

                $('.ltn__utilize-menu-inner').html(data);
            });
    });

    $(document).on("click", ".mini-cart-item-delete", function (e) {
        e.preventDefault()

        var id = $(this).attr("data-id");

        fetch('https://localhost:44369/shop/deletehouse/' + id)
            .then(response => response.text())
            .then(data => {
                $('.ltn__utilize-menu-inner').html(data);
            })
    });
   

    

})
