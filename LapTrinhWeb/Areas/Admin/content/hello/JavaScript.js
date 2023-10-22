let navbar = document.querySelector('.navbar');
document.querySelector('#menu-btn').onclick = () => {

    navbar.classList.toggle('active');
    searchFrom.classList.remove('active');
    cartItem.classList.remove('active');
}

let searchFrom = document.querySelector('.search-form');
document.querySelector('#search-btn').onclick = () => {
    searchFrom.classList.toggle('active');
    navbar.classList.remove('active');
    cartItem.classList.remove('active');
}



let cartItem = document.querySelector('.cart-items-container');
document.querySelector('#cart-btn').onclick = () => {
    cartItem.classList.toggle('active');
    navbar.classList.remove('active');
    searchFrom.classList.remove('active');
}


window.onscroll = () => {
    navbar.classList.remove('active');
    searchFrom.classList.remove('active');
    cartItem.classList.remove('active');
}


let list = document.querySelector('.slider .list');
let items = document.querySelectorAll('.slider .list .item');
let dots = document.querySelectorAll('.slider .dots li');
let prev = document.getElementById('prev');
let next = document.getElementById('next');

let active = 0;
let lengthItems = items.length - 1;

next.onclick = function () {
    if (active + 1 > lengthItems) {
        active = 0;
    } else {
        active = active + 1;
    }
    reloadSlider();
}

prev.onclick = function () {
    if (active - 1 < 0) {
        active = lengthItems;
    } else {
        active = active - 1;
    }
    reloadSlider();
}

let refreshSlider = setInterval(() => { next.click() }, 4000)

function reloadSlider() {
    let checkLeft = items[active].offsetLeft;
    list.style.left = -checkLeft + "px";

    let moveActive = document.querySelector('.slider .dots li.active');
    moveActive.classList.remove('active');
    dots[active].classList.add('active');
    clearInterval(refreshSlider);
    refreshSlider = setInterval(() => { next.click() }, 4000);


}
dots.forEach((li, key) => {
    li.addEventListener('click', function () {
        active = key;
        reloadSlider();
    })
})