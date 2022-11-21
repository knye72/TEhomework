//grab the blue button. 
const blueBtn = document.getElementById('blueBtn');

//we want to clear the text area when we click the blue button. 
blueBtn.addEventListener('click', function() {
    const txtArea = document.getElementById('txtArea');
    txtArea.value = "";
});

//red button
const redBtn = document.getElementById('redBtn');

redBtn.addEventListener('click', function(event) {
                    const txtArea = document.getElementById('txtArea');
                    txtArea.value = `The red button's event type was: ${event.type}
                    and it happened at: ${event.timeStamp}`;

});

//green button -> turn the text box green. thanks joe.
//make a CSS class to do a green background.
const greenBtn = document.getElementById('greenBtn');
greenBtn.addEventListener('click', () => {
    const txtArea = document.getElementById('txtArea');
    txtArea.classList.toggle('greenBackground');
    txtArea.value = "The green button was clicked. Thank you for the attention.";
    const title = document.querySelector('h1');
    title.innerText = "Clicking the green button changes the title of the site!";
});

//get the text input
const txtInput = document.getElementById('txtInput');
txtInput.addEventListener('keyup', (event) => {
    const para = document.getElementById('borderedPara');

    //i want to know if they pressed Enter
    if(event.key === 'Enter') {
        //put the value of the text input in the paragraph tag
        para.innerText = txtInput.value;
    }
    if(event.key ==='`') {
        displaySecretMessage(para);
    }
});

//Separate function that we will call from an event handler. 
function displaySecretMessage(element) {
    element.innerText = "Squirrel cigar party. The oak tree in my backyard. 9:00 p.m."
}