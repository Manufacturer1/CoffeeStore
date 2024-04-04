export function calculateSubtotal(cartItems) {
    return cartItems.reduce(function (total, currentItem) {
        return total + (currentItem.Product.Price * currentItem.Quantity);
    }, 0);
}

// Function to update the subtotal displayed on the webpage
export function updateSubtotal(subtotal) {
    $('#subtotal').text(subtotal.toLocaleString('en-US', { style: 'currency', currency: 'USD' }));
}
