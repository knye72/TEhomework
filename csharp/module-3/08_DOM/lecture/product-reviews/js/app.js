const book_name = 'Cigar Parties for Dummies';
const description = 'Host and plan the perfect cigar party for all of your squirrelly friends.';
const reviews = [
  {
    reviewer: 'Malcolm Madwell',
    title: 'What a book!',
    review:
    "It certainly is a book. I mean, I can see that. Pages kept together with glue and there's writing on it, in some language. Yes indeed, it is a book!",
    rating: 3
  },
  {
    reviewer: 'Tim Ferriss',
    title: 'Had a cigar party started in less than 4 hours.',
    review:
      "It should have been called the four hour cigar party. That's amazing. I have a new idea for muse because of this.",
    rating: 4
  },
  {
    reviewer: 'Ramit Sethi',
    title: 'What every new entrepreneurs needs. A door stop.',
    review:
      "When I sell my courses, I'm always telling people that if a book costs less than $20, they should just buy it. If they only learn one thing from it, it was worth it. Wish I learned something from this book.",
    rating: 1
  },
  {
    reviewer: 'Gary Vaynerchuk',
    title: 'And I thought I could write',
    review:
      "There are a lot of good, solid tips in this book. I don't want to ruin it, but prelighting all the cigars is worth the price of admission alone.",
    rating: 3
  }
];

/**
 * Add the product name to the page title
 * Get the page title by the id and the query the .name selector
 * once you have the element you can add the product name to the span.
 */
function setPageTitle() {
  //get the page title h1
  const pageTitle = document.getElementById('page-title');
  //look inside the h1 to find the span with class "name"
  const pageTitleSpan = pageTitle.querySelector('.name');
  //put the book title inside the span
  pageTitleSpan.innerText = book_name;
}

/**
 * Add the product description to the page.
 */
function setPageDescription() {
  const pageDescription = document.querySelector('.description');
  pageDescription.innerText = description;
}

/**
 * Display all of the reviews on the page.
 * Loop over the array of reviews and use some helper functions
 * to create the elements needed for the markup and add them to the DOM.
 */
function displayReviews() {
  const main = document.getElementById('main');

  // need four boxes, so let's do a forEach loop.
    reviews.forEach((review) => {

       //use document.createElement to make a new div.
  const container = document.createElement('div');
  //set some CSS classes on the container so we can see it better.
  container.classList.add('review');

  //call addReviewer to get the reviewer's name in the div
  addReviewer(container, review.reviewer);

  //call addRating to get this into the div
  addRating(container, review.rating);

  addTitle(container, review.title);

  addReview(container, review.review);

  //time to insert our new div into the DOM
  main.insertAdjacentElement('beforeend', container);  //"end" in 'beforeEnd' is the closing tag of the element.

    })

}

/**
 * Create a new h2 element with the name of the reviewer and append it to
 * the parent element that is passed to me.
 *
 * @param {HTMLElement} parent: The element to append the reviewer to
 * @param {string} name The name of the reviewer
 */
function addReviewer(parent, name) {
  //create the h2
  const reviewer = document.createElement('h2');
  //set the inner text to the reviewer's name
  reviewer.innerText = name;
  //append the h2 onto the parent element (the parent element here is the div, so this gets added as the last child of main)
  parent.appendChild(reviewer);


}

/**
 * Add the rating div along with a star image for the number of ratings 1-5
 * @param {HTMLElement} parent
 * @param {Number} numberOfStars
 */
function addRating(parent, numberOfStars) {
//create anohter div to hold the star rating.
  const ratingDiv = document.createElement('div');
  ratingDiv.classList.add('rating');

//put the right numbre of star images in, corresponding with rating.
//use a for loop to count up to the number of stars
  for(let i = 0; i < numberOfStars; i++) {

    //add a star in the ratingDiv
    const star = document.createElement('img');

    star.src = 'img/star.png'; // we can do this. or we can do ...
    //setAttribute takes 2 params: attribute and value
    //star.setAttribute('src', 'img/star.png');  set attribute can be used for any attribute, not just an image.

    //now we need to append it to the ratingDiv
    ratingDiv.appendChild(star);
  }

//append the rating div to the container div
  parent.appendChild(ratingDiv);

}

/**
 * Add an h3 element along with the review title
 * @param {HTMLElement} parent
 * @param {string} title
 */
function addTitle(parent, title) {
  const reviewTitle = document.createElement('h3');
  reviewTitle.innerText = title;
  parent.appendChild(reviewTitle);

}

/**
 * Add the product review
 * @param {HTMLElement} parent
 * @param {string} review
 */
function addReview(parent, review) {
  const reviewParagraph = document.createElement('p');
  reviewParagraph.innerText = review;

  //reviewParagraph.innerHTML = 'this is review text <strong>in bold</strong>. <div> This is another div! </div> <h4> and an h4</h4>';
//if you try the above with the .innerText function, it'll put in the literal text, without the HTML. 


  parent.appendChild(reviewParagraph);

}

// set the product reviews page title
setPageTitle();
// set the product reviews page description
setPageDescription();
// display all of the product reviews on the page
displayReviews();
