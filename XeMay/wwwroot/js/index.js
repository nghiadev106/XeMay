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

<tr>
                                    <td class="cart-pic first-row"><img src="` + item.logo + `" alt=""></td>
                                    <td class="cart-title first-row">
                                        <h5>` + item.name + `</h5>
                                    </td>
                                    <td class="p-price first-row">` + numberWithCommas(item.price) + `&nbsp</td>
                                    <td class="qua-col first-row">
                                        <div class="quantity">
                                            <div class="">
                                                <input style="width:50px;text-align:center;" type="text" id="quantity_` + item.productId + `"   value="` + item.quantity + `"/>
                                                    <a class="btn btn-reduce qty-decrease-cart" data-id="` + item.productId + `">-</a>
                                                    <a class="btn btn-increase qty-increase-cart" data-id="` + item.productId + `">+</a>
                                            </div>
                                        </div>
                                    </td>
                                    <td class="total-price first-row">` + numberWithCommas(amount) + `&nbsp;</td>
                                    <td class="close-td first-row"><i class="ti-close removeItem"  data-id="` + item.productId + `"></i></td>
                                </tr>

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

        $('body').on('click', '.qty-increase-product', function () {
            var qty_el = $("#input-quantity").val();
            var qty = parseInt(qty_el);
            if (!isNaN(qty)) {
                qty++;
                $("#input-quantity").val(qty);
            }
        });

        $('body').on('click', '.qty-decrease-product', function () {
            var qty_el = $("#input-quantity").val();
            var qty = parseInt(qty_el);
            if (!isNaN(qty) && qty > 1) {
                qty--;
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