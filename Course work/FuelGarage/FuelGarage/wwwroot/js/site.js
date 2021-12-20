// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification

var btn = document.getElementById("theme-btn");
var link = document.getElementById("theme-link");
var lightTheme = "../css/light-theme.css";
var darkTheme = "../css/dark-theme.css";
var currTheme = link.getAttribute("href");
var links = document.getElementsByTagName("a");

btn.addEventListener("click", function () {
    ChangeTheme();
});

function ChangeTheme() {
    if (currTheme == lightTheme) {
        currTheme = darkTheme;
        theme = "dark";
        localStorage.setItem("theme", theme);
    } else {
        currTheme = lightTheme;
        theme = "light";
        localStorage.setItem("theme", theme);
    }

    link.setAttribute("href", currTheme);
}

function LoadTheme(theme) {
    if (theme == "dark") {
        currTheme = darkTheme;
    } else {
        currTheme = lightTheme;
    }

    link.setAttribute("href", currTheme);
}

document.addEventListener("DOMContentLoaded", () => {
    var savedTheme = localStorage.getItem("theme") || "light";
    LoadTheme(savedTheme);

    document.querySelector('.preloader').classList.add("preloader-remove");
});

links.addEventListener("click", function () {
    document.querySelector('.preloader').classList.replace("preloader-remove", "");
});