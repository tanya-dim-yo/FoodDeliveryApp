document.getElementById('favoriteIcon').addEventListener('click', function (event) {
    toggleFavourite(event);
});

function toggleFavourite(event) {
    event.preventDefault();

    var productId = parseInt('@Model.Id');
    var isFavourite = '@Model.IsFavourite' === 'True'; // Parse string to boolean

    $.ajax({
        url: '/Product/Favourite',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ productId: productId, isFavourite: !isFavourite }), // Pass isFavourite as data
        success: function (response) {
            if (response.success) {
                var favoriteIcon = document.getElementById('favoriteIcon');
                if (response.isFavorite) {
                    favoriteIcon.querySelector('path').setAttribute('fill', '#f50505');
                } else {
                    favoriteIcon.querySelector('path').setAttribute('fill', '#000000');
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