import axios from 'axios';

//name of the axios instance is http here.
const http = axios.create({
  baseURL: "http://pokeapi.co/api/v2/pokemon"
});

export default {
    getPokemon(name) {
        return http.get('/' + name);
    }
}