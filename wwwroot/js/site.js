// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function(){

        $('.flipCard').click(function(){
            if ($('.cardFront').is(":visible") == true) {
                $('.cardFront').hide();
                $('.cardBack').show();
                console.log("CLIKED!");
            } else {
                $('.cardFront').show();
                $('.cardBack').hide();
            }
        });
    });