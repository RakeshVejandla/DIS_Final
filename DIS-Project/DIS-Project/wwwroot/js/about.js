
function ImageClick(){
    const data = document.getElementById("all_profiles_one");
    if(data.style.display == "none"){
        data.style.display == "block";
    }
    else{
        data.style.display = "none";
    }
}

window.onload = function () {
    document.getElementById("all_profiles_one").style.display = "none";
    document.getElementById("all_profiles_two").style.display = "none";
    document.getElementById("all_profiles_three").style.display = "none";
    document.getElementById("all_profiles_four").style.display = "none";
    document.getElementById("toggle-all").style.display = "none";
}

function toggleAll() {
    document.getElementById("all_profiles_one").style.display = "none";
    document.getElementById("all_profiles_two").style.display = "none";
    document.getElementById("all_profiles_three").style.display = "none";
    document.getElementById("all_profiles_four").style.display = "none";
    document.getElementById("toggle-all").style.display = "none";
}

function toggleContentOne() {
    const contentToToggle = document.getElementById("all_profiles_one");
    const removeAll = document.getElementById("toggle-all")

    // Toggle the display of the content
    if (contentToToggle.style.display === "none") {
        contentToToggle.style.display = "flex";
        removeAll.style.display = "block";
    } else {
        contentToToggle.style.display = "none";
    }
}

function toggleContentTwo() {
    const contentToToggle = document.getElementById("all_profiles_two");
    const removeAll = document.getElementById("toggle-all")

    // Toggle the display of the content
    if (contentToToggle.style.display === "none") {
        contentToToggle.style.display = "flex";
        removeAll.style.display = "block";
    } else {
        contentToToggle.style.display = "none";
    }
}

function toggleContentThree() {
    const contentToToggle = document.getElementById("all_profiles_three");
    const removeAll = document.getElementById("toggle-all")

    // Toggle the display of the content
    if (contentToToggle.style.display === "none") {
        contentToToggle.style.display = "flex";
        removeAll.style.display = "block";
    } else {
        contentToToggle.style.display = "none";
    }
}

function toggleContentFour() {
    const contentToToggle = document.getElementById("all_profiles_four");
    const removeAll = document.getElementById("toggle-all")

    // Toggle the display of the content
    if (contentToToggle.style.display === "none") {
        contentToToggle.style.display = "flex";
        removeAll.style.display = "block";
    } else {
        contentToToggle.style.display = "none";
    }
}