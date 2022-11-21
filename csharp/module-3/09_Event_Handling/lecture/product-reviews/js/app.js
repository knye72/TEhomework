const book_name = 'Cigar Parties for Dummies';
let description = 'Host and plan the perfect cigar party for all of your squirrelly friends.';
let reviews = [
  {
    reviewer: 'Malcolm Madwell',
    title: 'What a book!',
    review:
    "It certainly is a book. I mean, I can see that. Pages kept together with glue and there's writing on it, in some language. Yes indeed, it is a book!",
    rating: 3
  }
];

/**
 * Add product name to the page title.
 */
function setPageTitle() {
  const pageTitle = document.getElementById('page-title');
  pageTitle.querySelector('.name').innerText = book_name;
}

/**
 * Add product description to the page.
 */
function setPageDescription() {
  document.querySelector('.description').innerText = description;
}

/**
 * Display all of the reviews in the reviews array.
 */
function displayReviews() {
  if ('content' in document.createElement('template')) {
    reviews.forEach((review) => {
      displayReview(review);
    });
  } else {
    console.error('Your browser does not support templates');
  }
}

/**
 * Add single review to the page.
 *
 * @param {Object} review The review to display
 */
function displayReview(review) {
  const main = document.getElementById('main');
  const tmpl = document.getElementById('review-template').content.cloneNode(true);
  tmpl.querySelector('h4').innerText = review.reviewer;
  tmpl.querySelector('h3').innerText = review.title;
  tmpl.querySelector('p').innerText = review.review;
  // there will always be 1 star because it is a part of the template
  for (let i = 1; i < review.rating; ++i) {
    const img = tmpl.querySelector('img').cloneNode();
    tmpl.querySelector('.rating').appendChild(img);
  }
  main.appendChild(tmpl);
}

// LECTURE STARTS HERE ---------------------------------------------------------------

// Set the product reviews page title.
setPageTitle();
// Set the product reviews page description.
setPageDescription();
// Display all of the product reviews on our page.
displayReviews();

//STEP ONE: find the target of my event (i want to click on the description)
const descriptionParagraph = document.querySelector('.description');
//STEP TWO: register an event listener. 
descriptionParagraph.addEventListener('click', toggleDescriptionEdit); //no extra () because we're referencing the function, not actually calling it.
const inputDescription = document.getElementById('inputDesc');
inputDescription.addEventListener('keyup', (event) => {
  if(event.key === 'Enter'){ //everything after 'keyup' is the event handler now.
  exitDescriptionEdit(event.target, true); //the event target is the thing you're interacting with.
}
  if(event.key === 'Escape') {
    exitDescriptionEdit(event.target, false);
  }

});


/**
 * Hide the description and show the text box.
 *
 * @param {Element} desc the element containing the description
 */
function toggleDescriptionEdit() {
  const desc = document.querySelector('.description');
  const textBox = desc.nextElementSibling;
  textBox.value = desc.innerText;
  textBox.classList.remove('d-none');
  desc.classList.add('d-none');
  textBox.focus();
}

/**
 * Hide the text box and show the description.
 * If save is true, also set the description to the contents of the text box.
 *
 * @param {Element} textBox the input element containing the edited description
 * @param {Boolean} save should we save the description text
 */
function exitDescriptionEdit(textBox, save) {
  let desc = textBox.previousElementSibling;
  if (save) {
    desc.innerText = textBox.value;
  }
  textBox.classList.add('d-none');
  desc.classList.remove('d-none');
}

//i want to show the hidden form when i click the 'add review' button
const addReviewBtn = document.getElementById('btnToggleForm');
// addReviewBtn.addEventListener('click', (event) => {
//   showHideForm()
// });
//could also do it like this:
addReviewBtn.addEventListener('click', showHideForm);  //this works because showHideForm doesn't have params.


//make the 'save review' button work.
const saveReviewButton = document.getElementById('btnSaveReview');
saveReviewButton.addEventListener('click', 
(event) => {
  event.preventDefault(); //stop the default form submission behavior
  saveReview()
});


/**
 * Toggle visibility of the add review form.
 */
function showHideForm() {
  const form = document.querySelector('form');
  const btn = document.getElementById('btnToggleForm');

  if (form.classList.contains('d-none')) {
    form.classList.remove('d-none');
    btn.innerText = 'Hide Form';
    document.getElementById('name').focus();
  } else {
    resetFormValues();
    form.classList.add('d-none');
    btn.innerText = 'Add Review';
  }
}

/**
 * Reset all of the values in the form.
 */
function resetFormValues() {
  const form = document.querySelector('form');
  const inputs = form.querySelectorAll('input');
  inputs.forEach((input) => {
    input.value = '';
  });
  document.getElementById('rating').value = 1;
  document.getElementById('review').value = '';
}

/**
 * Save the review that was added using the add review form.
 */
function saveReview() {
  let name = document.getElementById('name');
  let title = document.getElementById('title');
  let rating = document.getElementById('rating');
  let review = document.getElementById('review');

const newReview = {
  reviewer: name.value,
  title: title.value,
  review: review.value,
  rating: rating.value
}

displayReview(newReview);


}
