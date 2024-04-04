


export const SetDiscount = (totalPrice, expiration, discount_Value,FinalTotal,deliveryPrice) => {
    let discountApplied = localStorage.getItem('discountApplied') === 'true';
    if (discountApplied) {
        return totalPrice;
    }
    const discountExpirationTime = expiration * 1000;

    const discountedPrice = totalPrice - (totalPrice * discount_Value);

    setTimeout(function () {
        localStorage.setItem('discountApplied', 'true');
        onDiscountExpired(totalPrice, 0);
        FinalTotal = totalPrice;
        FinalTotal = SetDelivery(FinalTotal, deliveryPrice);
        UpdateFinalTotal(FinalTotal);
        $('#alertContainer').fadeIn();
    }, discountExpirationTime);
    return discountedPrice;
}
export const UpdateDiscount = (subtotal, discount_Value) => {
    let discount_in_dollars = 0;
    let discountApplied = localStorage.getItem('discountApplied') === 'true';
    if (subtotal && !discountApplied) {
        const discountAmount = subtotal * discount_Value;
        const discountedSubtotal = subtotal - discountAmount;
        discount_in_dollars = subtotal - discountedSubtotal;
    }
    $('#discount').text(discount_in_dollars.toLocaleString('en-US', { style: 'currency', currency: 'USD' }));
}
export const onDiscountExpired = (subtotal, discount_Value) => {
    console.log("Discount expired!");
    UpdateDiscount(subtotal, discount_Value);
}
export const UpdateFinalTotal = (FinalTotal) => {
    $('#finalTotal').text(FinalTotal.toLocaleString('en-US', { style: 'currency', currency: 'USD' }));
}
export const SetDelivery = (subtotal, deliveryPrice) => {
    var totalPrice = subtotal + deliveryPrice;
    return totalPrice;
}
export const UpdateDelivery = (priceDelivery) => {
    $('#delivery').text(priceDelivery.toLocaleString('en-US', { style: 'currency', currency: 'USD' }));
}