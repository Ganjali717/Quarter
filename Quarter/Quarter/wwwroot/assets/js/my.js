$(document).ready(function () {

    $(document).on("click", ".show-modal-house", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");

        fetch('https://localhost:44369/shop/gethouse/' + id)
            .then(response => response.text())
            .then(data => {


                $(".modal-content").html(data)
            });
        // get data from controller

        //set data 

        $("#quickModal").modal("show")
    })

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

    $(".house-search").keyup(function (e) {
        e.preventDefault()

        var search = $(this).val();

        fetch('https://localhost:44369/shop/SearchFilter?search=' + search)
            .then(response => response.text())
            .then(data => {
                $('#search-list-box').html(data);
                console.log(data)
               
            })
    });
    

})
