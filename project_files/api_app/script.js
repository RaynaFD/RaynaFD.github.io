$('#datepicker').datepicker({
    endDate: new Date(),
    autoclose: true,
    format: 'yyyy-mm-dd'
  });
  
const $submit = document.getElementById('submit');
const $output = document.getElementById('output');
const $saved = document.getElementById('saved');
const $date = document.getElementById('datepicker');
const $clear = document.getElementById('clear');
const $favButton = document.getElementById("favButton");
let contentType, mediaUrl, $submission, data; 

document.addEventListener("DOMContentLoaded", function() {
    Object.entries(localStorage).forEach(([key, value]) => {
        const [mediaUrl, contentType] = value.split(", ");
        showSavedSearches(key, mediaUrl, contentType);
        // $main.appendChild($savedContainer);
    });
});
//received data from api:
//-date -explanation -hdurl -media_type 
//-service_version -title -url <span class="bi-heart"></span>
//ONLY FAVOURITES NEED TO GO INTO LOCAL STORAGE, CREATE EVENT THAT ADDS TO LOCAL STORAGE GET RID OF OTHER LOCAL STORAGE LINES



$submit.addEventListener('click', (event) => {
    event.preventDefault();
    fetch(`https://api.nasa.gov/planetary/apod?api_key=gPgbbxChJ2NuRKBDn5qhH0Tc9fFNSGDEAWKNCTmF&date=${$date.value}`)
        .then(response => response.json())
        .then(result => {
            data=result;
            console.log(data);
             contentType = data.media_type;
             mediaUrl = data.url;
            
            if (contentType === "video") {
                $output.classList.add("py-2", "text-center", "my-2", "h-100", "output");
                $output.innerHTML = `<div id= "submission"><h3>${data.title}</h3></br><a href="${data.hdurl}" target="_blank"><iframe width="720" height="515" src="${data.url}"></iframe></a></br><p class="fw-bold my-3">${data.explanation}</p></div>`;
                // if ($output.classList.contains("fav")) {
                //     localStorage.setItem(data.date, `${mediaUrl}, ${contentType}, ${fav}`);
                // } else {
               //localStorage.setItem(data.date, `${mediaUrl}, ${contentType}`);
                // }
            } else if (contentType === "image") {
                $output.classList.add("py-2", "text-center", "my-2", "h-100", "output");
                $output.innerHTML = `<div id= "submission"><h3>${data.title}</h3></br><a href="${data.hdurl}" target="_blank"><img src="${data.url}"></a></br><p class="fw-bold my-3">${data.explanation}</p></div>`;
                //localStorage.setItem(data.date, `${mediaUrl}, ${contentType}`);
            }
    
           
           return data, $output, mediaUrl, contentType; 

        });
    
        
    });




 $favButton.addEventListener("click", (event) => {
    event.preventDefault();
    console.log("clicked");
    $submission = document.getElementById("submission");
    console.log("div found")
    $submission.classList.toggle("fav"); // Use toggle to add/remove class
    console.log("fav toggled");

    if ($submission.classList.contains("fav")) {
        localStorage.setItem( data.date, `${mediaUrl}, ${contentType}`);
        console.log("fav saved");
    } else {
        localStorage.removeItem(data.date);
        console.log("fav removed");
    }
});

//Using local storage, incorporate a feature that allows the user to save Pictures as favourites.
// Favourited images should be displayed on page load. The user should be able to remove images as a favourite,
// which should remove them from the page and local storage.
function showSavedSearches(date, mediaUrl, contentType) {
    const $savedContainer = document.getElementById("saved");  
    const $saved = document.createElement("div");
    //if item is favourite, add to saved container
    if (contentType ==="image"){
        $saved.classList.add("py-2", "my-2", "h-25", "saved");
        $saved.innerHTML=`<a href= "${mediaUrl}"><img src="${mediaUrl}"</a><h4>${date}</h4>`}
    else if (contentType ==="video"){
        $saved.classList.add("py-2", "my-2", "h-25", "saved");
        $saved.innerHTML=`<h4>${date}</h4><a href= "${mediaUrl}"><iframe width="420" height="315" src="${mediaUrl}"></iframe></a>`
    }
    $savedContainer.appendChild($saved);
    
    };

$clear.addEventListener("click", (event) => {
        event.preventDefault()
        localStorage.clear();
        $savedContainer.innerHTML="";});