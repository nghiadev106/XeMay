var SiteController = function () {
    this.initialize = function () {
        regsiterEvents();
        loadData();
    }

    function loadData() {
        $.ajax({
            type: "GET",
            url: '/Cart/GetListItems',
            success: function (res) {
                $('.lbl_number_items_header').text(res.length);
                if (res.length === 0) {
                    $('#cart-wrapper').hide();
                    $('#emty-cart').show();
                } else {
                    $('#cart-wrapper').show();
                    $('#emty-cart').hide();
                }
                var html = '';
                var total = 0;

                $.each(res, function (i, item) {
                    var amount=0;
                    if (item.price > 0) {
                        amount = item.price * item.quantity;
                    } 
                    html += `
<li class="pr-cart-item">
                                            <div class="product-image">
                                                <figure><img src="` + item.logo + `" alt=""></figure>
                                            </div>
                                            <div class="product-name">
                                                <a class="link-to-product" href="/san-pham/`+ item.url + `/` + item.productId + `">` + item.name + `</a>
                                            </div>
                                            <div class="price-field produtc-price"><p class="price">` + numberWithCommas(item.price) + `&nbsp</p></div>
                                            <div class="quantity">
                                                <div class="quantity-input">
                                                    <input type="text" name="product-quatity"   id="quantity_` + item.productId + `"   value="`+ item.quantity + `" data-max="120" pattern="[0-9]*">
                                                    <a class="btn btn-increase qty-increase-cart" data-id="` + item.productId + `"></a>
                                                    <a class="btn btn-reduce qty-decrease-cart" data-id="` + item.productId + `"></a>
                                                </div>
                                            </div>
                                            <div class="price-field sub-total"><p class="price">` + numberWithCommas(amount) + `&nbsp;</p></div>
                                            <div class="delete">
                                                <a class="remove removeItem" data-id="` + item.productId + `" class="btn btn-delete" title="">
                                                    <i class="fa fa-times-circle" aria-hidden="true"></i>
                                                </a>
                                            </div>
                                        </li>

 
`;
                    total += amount;
                });
                $('.ListCart').html(html);
                $('.lbl_number_of_items').text(res.length);
                $('.lbl_total').text(numberWithCommas(total)+' đ');
                $('.lbl_number_items_header').text(res.length);
            }
        });
    }

    function updateCart(id, quantity) {
        $.ajax({
            type: "POST",
            url: '/Cart/UpdateCart',
            data: {
                id: id,
                quantity: quantity
            },
            success: function (res) {
                $('#lbl_number_items_header').text(res.length);
                loadData();
            },
            error: function (err) {
                toastr.error('Cập nhật giỏ hàng không thành công', 'Thất bại')
            }
        });
    }


    function regsiterEvents() {
        $('body').on('click', '.btn-add-cart', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            var quantity = 1;
            var qty_el = $("#input-quantity").val();
            var qty = parseInt(qty_el);
            if (!isNaN(qty) && qty >= 1) {
                quantity = qty;
            }
            $.ajax({
                type: "POST",
                url: '/Cart/AddToCart',
                data: {
                    id: id,
                    quantity: quantity
                },
                success: function () {
                    toastr.success('Thêm giỏ hàng thành công', 'Thành công')
                    loadData();
                },
                error: function () {
                    toastr.error('Thêm giỏ hàng không thành công', 'Thất bại')
                }
            });
        });

        $('body').on('click', '.btn-add-cart-2', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            var quantity = 1;
            $.ajax({
                type: "POST",
                url: '/Cart/AddToCart',
                data: {
                    id: id,
                    quantity: quantity
                },
                success: function () {
                    toastr.success('Thêm giỏ hàng thành công', 'Thành công')
                    loadData();
                },
                error: function () {
                    toastr.error('Thêm giỏ hàng không thành công', 'Thất bại')
                }
            });
        });


        $('body').on('click', '.order-now', function (e) {
            e.preventDefault();
            var model = {
                ProductId: $("#producId").val(),
                Quantity: parseInt($("#input-quantity2").val()),
                OrderName: $("#customer-name").val(),
                OrderAddress: $("#customer-address").val(),
                OrderEmail: $("#customer-email").val(),
                OrderPhone: $("#customer-phone").val(),
                OrderNote: $("#customer-note").val()
            }
            $.ajax({
                type: "POST",
                url: '/Cart/OrderNow',
                data: {
                    order:model
                },
                success: function () {
                    toastr.success('Đặt hàng thành công', 'Thành công')
                    loadData();
                },
                error: function () {
                    toastr.error('Đặt hàng không thành công', 'Thất bại')
                }
            });
        });

        $('body').on('click', '.qty-increase-product', function () {
            var qty_el = $("#input-quantity").val();
            var price = Number($("#price").val());
            var qty = parseInt(qty_el);
            if (!isNaN(qty) && !isNaN(price)) {
                qty++;
                var subTotal = price * qty;
                $(".sub-total").text(numberWithCommas(subTotal));  
                $("#input-quantity").val(qty);
            }
        });

        $('body').on('click', '.qty-decrease-product', function () {
            var qty_el = $("#input-quantity").val();
            var price = Number($("#price").val());
            var qty = parseInt(qty_el);
            if (!isNaN(qty) && !isNaN(price) && qty > 1) {
                qty--;
                var subTotal = price * qty;
                $(".sub-total").text(numberWithCommas(subTotal));
                $("#input-quantity").val(qty);
            }
        });
        // cart
        $('body').on('click', '.removeItem', function () {
            const id = $(this).data('id');
            updateCart(id, 0);
        });

        $('body').on('click', '.updateItem', function () {
            setTimeout(() => {
                const id = $(this).data('id');
                const quantity = parseInt($('#quantity_' + id).val());
                updateCart(id, quantity);
            }, 500);        
        });

        $('body').on('click', '.qty-increase-cart', function () {
            const id = $(this).data('id');
            var qty_el = $("#quantity_" + id).val();
            var qty = parseInt(qty_el);
            if (!isNaN(qty)) {
                qty++;
                updateCart(id, qty);
            }
            $("#quantity_" + id).val(qty);
        });

        $('body').on('click', '.qty-decrease-cart', function () {
            const id = $(this).data('id');
            var qty_el = $("#quantity_" + id).val();
            var qty = parseInt(qty_el);
            if (!isNaN(qty) && qty > 1) {
                qty--;
                updateCart(id, qty);
            }
            $("#quantity_" + id).val(qty);
        });
    }
}

function numberWithCommas(x) {
    if (x === null || x === 0) {
        return 'Liên hệ';
    }
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}