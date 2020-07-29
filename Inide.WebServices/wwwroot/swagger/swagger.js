
(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            let logo = document.getElementsByClassName("link");
            logo[0].href = "https://www.inide.gob.ni/";
            logo[0].target = "_blank";

            logo[0].children[0].alt = "Implementando Swagger";
            logo[0].children[0].src = "logo.png";
        });
    });
})();