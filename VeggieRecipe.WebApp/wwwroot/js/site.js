// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const { post } = require("jquery");

// Write your JavaScript code.
const main = document.querySelector('.main');
function tooglePassword() {
    var x = document.getElementById("passwordToggle");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
