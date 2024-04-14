document.querySelectorAll('.add-to-cart').forEach(button => {
    button.addEventListener('click', async (event) => {
        const productId = event.target.dataset.productId;
        const quantityInput = document.getElementById(`Quantity-${productId}`);
        const quantity = quantityInput.value;

        const response = await fetch(`/Cart/AddToCart`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ productId, quantity })
        });

        if (response.ok) {
            const cart = await response.json();
            if (cart.updated) {
                alert('Carrello aggiornato');
            } else {
                alert('Prodotto aggiunto al carrello');
            }
        } else {
            alert('Non è stato possibile aggiornare il carrello');
        }
    });
});


document.addEventListener("DOMContentLoaded", () => {
    const removeButtons = document.querySelectorAll(".remove-from-cart");
    removeButtons.forEach((button) => {
        button.addEventListener("click", async (event) => {
            event.preventDefault();
            const productId = event.target.closest("tr").dataset.productId;
            const response = await fetch(`/cart/remove?productId=${productId}`, {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ productId })
            });
            if (response.ok) {
                // Refresh the page or update the DOM dynamically
                location.reload();
            } else {
                alert("Non è stato possibile rimuovere il prodotto dal carrello.");
            }
        });
    });
});


document.addEventListener("DOMContentLoaded", () => {
    const userInfoButton = document.querySelectorAll(".user-info").forEach(button => {
        button.addEventListener("click", async (event) => {
            event.preventDefault();
            
            const FirstName = document.getElementsByClassName("user1")[0].value;
            const LastName = document.getElementsByClassName("user2")[0].value;
            const Email = document.getElementsByClassName("user3")[0].value;
            const Nation = document.getElementsByClassName("user-nation")[0].value;
            const Newsletter = document.getElementsByClassName("user4")[0].checked;
            const Bill = document.getElementsByClassName("user5")[0].checked;
            const P_IVA = document.getElementsByClassName("user6")[0].value;
            const C_Fiscale = document.getElementsByClassName("user7")[0].value;
            const Privacy = document.getElementsByClassName("user8")[0].checked;
            
            
            const response = await fetch(`/Cart/AddBillingInfo`, {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ FirstName, LastName, Email, Nation, Newsletter, Bill, P_IVA, C_Fiscale, Privacy })
            });
            if (response.ok) {
                $('#checkout-button').trigger('click');
            } else {
                alert("Non è stato possibile inserire i dati utente. Ricontrolla i campi.");
            }
        });
    });
})


document.addEventListener("DOMContentLoaded", () => {
    const coupon_button = document.querySelectorAll("#coupon-button").forEach(button => {
        button.addEventListener("click", async (event) => {
            event.preventDefault();
            const code = document.getElementById("coupon").value;

            const response = await fetch(`/Cart/IsCouponValid?code=${code}`, {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ code })
            });
            if (response.ok) {
                alert("Sconto applicato");
            } else {
                alert("Sconto non applicato");
            }
        })
    })

})