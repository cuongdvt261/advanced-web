$(document).ready(function () {
    (function ProductCount() {
        $.ajax({
            type: "POST",
            url: "/Admin/Statistics/GetProductCount",
            success: function (data) {
                $("#product-count").text(data);
                setTimeout(ProductCount, 5000);
            }
        });
    })();

    (function OrderCount() {
        $.ajax({
            type: "POST",
            url: "/Admin/Statistics/GetOrderCount",
            success: function (data) {
                $("#order-count").text(data);
                setTimeout(OrderCount, 5000);
            }
        });
    })();

    (function UserCount() {
        $.ajax({
            type: "POST",
            url: "/Admin/Statistics/GetCountUser",
            success: function (data) {
                $("#user-count").text(data);
                setTimeout(UserCount, 5000);
            }
        });
    })();
});