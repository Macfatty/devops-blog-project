// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
console.log("✅ site.js is loaded!"); // Debugging: Check if site.js is running

document.addEventListener("DOMContentLoaded", function () {
    const toggleButton = document.getElementById("darkModeToggle");
    const body = document.body;

    // ✅ Check if dark mode is already enabled in localStorage
    if (localStorage.getItem("dark-mode") === "enabled") {
        body.classList.add("dark-mode");
        toggleButton.innerText = "☀ Light Mode";
    }

    // ✅ Toggle dark mode when button is clicked
    toggleButton.addEventListener("click", function () {
        if (body.classList.contains("dark-mode")) {
            body.classList.remove("dark-mode");
            localStorage.setItem("dark-mode", "disabled");
            toggleButton.innerText = "🌙 Dark Mode";
        } else {
            body.classList.add("dark-mode");
            localStorage.setItem("dark-mode", "enabled");
            toggleButton.innerText = "☀ Light Mode";
        }
    });
});
