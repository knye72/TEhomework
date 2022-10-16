-- 21. For every person in the person table with the first name of "George", list the number of movies they've been in. Name the count column 'num_of_movies'.
-- Include all Georges, even those that have not appeared in any movies. Display the names in alphabetical order. 
-- (59 rows)

SELECT DISTINCT(person_name), COUNT(title) AS num_of_movies FROM person
left JOIN movie_actor ON movie_actor.actor_id = person.person_id
left JOIN movie ON movie.movie_id = movie_actor.movie_id
WHERE person_name LIKE 'George%'
GROUP BY person_name, person_id


/*SELECT person_name, COUNT(title) AS num_of_movies FROM movie
right JOIN movie_actor ON movie_actor.movie_id = movie.movie_id
right JOIN person ON person.person_id = movie_actor.actor_id
WHERE person_name LIKE 'George%'
GROUP BY person_name, person_id */