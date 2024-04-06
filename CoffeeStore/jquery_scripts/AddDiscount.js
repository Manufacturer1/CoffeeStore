


export const UpdateDiscount = (discount) => {
    
  $('#discount').text(discount.toLocaleString('en-US', { style: 'currency', currency: 'USD' }));
 
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