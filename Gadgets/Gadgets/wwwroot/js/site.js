// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function() {
    // Initialize Bootstrap tooltips and popovers if you're using them
    $('[data-toggle="tooltip"]').tooltip();
    $('[data-toggle="popover"]').popover();

    // Handle review form submission
    $('.review-form').on('submit', function(e) {
        e.preventDefault();
        var form = $(this);
        var productId = form.find('input[name="ProductId"]').val();
        var modal = $(`#reviewModal-${productId}`);

        $.post('/Review/Create', form.serialize())
            .done(function(response) {
                if (response.success) {
                    toastr.success(response.message);
                    
                    // Update only the specific product's review container
                    var reviewContainer = $(`[data-review-container="${productId}"]`);
                    var stars = '';
                    for (var i = 1; i <= 5; i++) {
                        stars += `<i class="fas fa-star ${i <= response.review.rating ? 'text-warning' : ''}"></i>`;
                    }
                    reviewContainer.html(`
                        <div class="text-warning">
                            ${stars}
                        </div>
                        <small class="text-muted">You reviewed this product</small>
                    `);

                    // Properly hide the modal and remove the backdrop
                    modal.modal('hide');
                    $('.modal-backdrop').remove();
                    $('body').removeClass('modal-open');
                } else {
                    toastr.error(response.message);
                }
            })
            .fail(function() {
                toastr.error('Failed to submit review');
            });
    });

    // Star rating hover effect
    $('.rating input').on('change', function() {
        var ratingContainer = $(this).closest('.rating');
        ratingContainer.find('label')
            .removeClass('text-warning');
        ratingContainer.find('label')
            .slice(0, $(this).val())
            .addClass('text-warning');
    });

    // Add client-side validation for numeric input
    $("#CardNumber, #CVV").on("input", function() {
        this.value = this.value.replace(/[^0-9]/g, '');
    });
});
