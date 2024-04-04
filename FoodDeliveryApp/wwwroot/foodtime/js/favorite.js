// favorite.js
document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('favoriteToggle').addEventListener('click', function () {
        toggleFavourite();
    });
});

function toggleFavourite() {
    var productId = '@Model.Id';
    var isFavourite = '@Model.IsFavourite';

    $.ajax({
        url: '/Product/Favourite',
        type: 'POST',
        data: { productId: productId, isFavourite: !isFavourite },
        success: function (response) {
            if (response.success) {
                var favoriteIcon = document.getElementById('favoriteIcon');
                if (response.isFavorite) {
                    favoriteIcon.querySelector('path').setAttribute('fill', '#f50505'); // Set color to red
                } else {
                    favoriteIcon.querySelector('path').setAttribute('fill', '#000000'); // Set color to black
                }
            } else {
                console.error('Error toggling favorite status:', response.error);
            }
        },
        error: function (xhr, status, error) {
            console.error('AJAX error:', error);
        }
    });
}
