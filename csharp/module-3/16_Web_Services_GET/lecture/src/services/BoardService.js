import axios from 'axios';

//name of the axios instance is http here.
const http = axios.create({
  baseURL: "http://localhost:3000"
});

export default {

  getBoards() {
    return http.get('/boards'); //get request to base URL/boards. 
    //passes the Promise back to the component
  },

  getCards(boardID) {
    return http.get(`/boards/${boardID}`)
  },

  getCard(boardID, cardID) {
    return http.get(`/boards/${boardID}`).then((response) => { //gets the board
      const cards = response.data.cards;  //gets the cards
      return cards.find(card => card.id == cardID); //gets the specific card.
    })
    //this all handles the initial Promise in the funciton and passes data back to the component.
  }

}
