using System;

namespace VariableNaming
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            1. 4 birds are sitting on a branch. 1 flies away. How many birds are left on
            the branch?
            */

            // ### EXAMPLE:
            int initialNumberOfBirds = 4;
            int birdsThatFlewAway = 1;
            int remainingNumberOfBirds = initialNumberOfBirds - birdsThatFlewAway;
            
            /*
            2. There are 6 birds and 3 nests. How many more birds are there than
            nests?
            */

            // ### EXAMPLE:
            int numberOfBirds = 6;
            int numberOfNests = 3;
            int numberOfExtraBirds = numberOfBirds - numberOfNests;



            /*
            3. 3 raccoons are playing in the woods. 2 go home to eat dinner. How
            many raccoons are left in the woods?
            */
            int initialNumberOfRaccoons = 3;
            int raccoonsWhoLeft = 2;
            int raccoonsRemaining = initialNumberOfRaccoons - raccoonsWhoLeft;
        
            /*
            4. There are 5 flowers and 3 bees. How many less bees than flowers?
            */
            int numberOfFlowers = 5;
            int numberOfBees = 3;
            int lessBeesThanFlowers = numberOfFlowers - numberOfBees;
   

            /*
            5. 1 lonely pigeon was eating breadcrumbs. Another pigeon came to eat
            breadcrumbs, too. How many pigeons are eating breadcrumbs now?
            */

            int initialNumberOfPigeons = 1;
            int additionalPigeons = 1;
            int newNumberOfPigeons = initialNumberOfPigeons + additionalPigeons;
         

            /*
            6. 3 owls were sitting on the fence. 2 more owls joined them. How many
            owls are on the fence now?
            */

            int initialNumberOFOwls = 3;
            int owlsWhoJoined = 2;
            int totalNumberOfOwls = initialNumberOFOwls + owlsWhoJoined;


            /*
            7. 2 beavers were working on their home. 1 went for a swim. How many
            beavers are still working on their home?
            */
            int beaversWorkingOnHome = 2;
            int beaversWhoSwam = 1;
            int remainingBeavers = beaversWorkingOnHome - beaversWhoSwam;


            /*
            8. 2 toucans are sitting on a tree limb. 1 more toucan joins them. How
            many toucans in all?
            */

            int toucansOnLimb = 2;
            int toucansWhoJoined = 1;
            int totalToucans = toucansOnLimb + toucansWhoJoined;

            /*
            9. There are 4 squirrels in a tree with 2 nuts. How many more squirrels
            are there than nuts?
            */

            int numberOfSquirrels = 4;
            int numberOfNuts = 2;
            int differenceBetweenSquirrelsAndNuts = numberOfSquirrels - numberOfNuts;

            /*
            10. Mrs. Hilt found a quarter, 1 dime, and 2 nickels. How much money did
            she find?
            */
            decimal quarter = .25M;
            decimal dime = .10M;
            decimal nickel = .05M;
            decimal moneyFound = quarter + dime + (nickel * 2);


            /*
            11. Mrs. Hilt's favorite first grade classes are baking muffins. Mrs. Brier's
            class bakes 18 muffins, Mrs. MacAdams's class bakes 20 muffins, and
            Mrs. Flannery's class bakes 17 muffins. How many muffins does first
            grade bake in all?
            */

            int mrsBriersMuffins = 18;
            int mrsMacadamsMuffins = 20;
            int mrsFlannerysMuffins = 17;
            int totalMuffins = mrsBriersMuffins + mrsMacadamsMuffins + mrsFlannerysMuffins;

            /*
            12. Mrs. Hilt bought a yoyo for 24 cents and a whistle for 14 cents. How
            much did she spend in all for the two toys?
            */

            decimal yoyoPrice = .24M;
            decimal whistlePrice = .14M;
            decimal totalCost = yoyoPrice + whistlePrice;

            /*
            13. Mrs. Hilt made 5 Rice Krispies Treats. She used 8 large marshmallows
            and 10 mini marshmallows. How many marshmallows did she use
            altogether?
            */

            int largeMarshmallows = 8;
            int miniMarshmallows = 10;
            int totalMarshmallows = largeMarshmallows + miniMarshmallows;

            /*
            14. At Mrs. Hilt's house, there was 29 inches of snow, and Brecknock
            Elementary School received 17 inches of snow. How much more snow
            did Mrs. Hilt's house have?
            */

            int hiltHouseSnow = 29;
            int brecknockSchoolSnow = 17;
            int differenceInSnow = hiltHouseSnow - brecknockSchoolSnow;

            /*
            15. Mrs. Hilt has $10. She spends $3 on a toy truck and $2 on a pencil
            case. How much money does she have left?
            */

            int startingMoney = 10;
            int toyTruckCost = 3;
            int pencilCaseCost = 2;
            decimal moneyLeftover = startingMoney - toyTruckCost - pencilCaseCost;


            /*
            16. Josh had 16 marbles in his collection. He lost 7 marbles. How many
            marbles does he have now?
            */

            int startingMarbles = 16;
            int marblesLost = 7;
            int marblesRemaining = startingMarbles - marblesLost;

            /*
            17. Megan has 19 seashells. How many more seashells does she need to
            find to have 25 seashells in her collection?
            */

            int currentSeashells = 19;
            int targetSeashells = 25;
            int seashellsNeeded = targetSeashells - currentSeashells;

            /*
            18. Brad has 17 balloons. 8 balloons are red and the rest are green. How
            many green balloons does Brad have?
            */

            int totalBalloons = 17;
            int redBalloons = 8;
            int greenBalloons = totalBalloons - redBalloons;

            /*
            19. There are 38 books on the shelf. Marta put 10 more books on the shelf.
            How many books are on the shelf now?
            */

            int booksOnShelf = 38;
            int booksAdded = 10;
            int totalBooksOnShelf = booksOnShelf + booksAdded;

            /*
            20. A bee has 6 legs. How many legs do 8 bees have?
            */

            int beeLegs = 6;
            int numberOfBeesWithLegs = 8;
            int totalBeeLegs = beeLegs * numberOfBeesWithLegs;

            /*
            21. Mrs. Hilt bought an ice cream cone for 99 cents. How much would 2 ice
            cream cones cost?
            */

            decimal coneCost = .99M;
            int numberOfCones = 2;
            decimal totalCostOfCones = coneCost * numberOfCones;

            /*
            22. Mrs. Hilt wants to make a border around her garden. She needs 125
            rocks to complete the border. She has 64 rocks. How many more rocks
            does she need to complete the border?
            */

            int startingRocks = 64;
            int totalRocksNeeded = 125;
            int rocksToCompleteBorder = totalRocksNeeded - startingRocks;

            /*
            23. Mrs. Hilt had 38 marbles. She lost 15 of them. How many marbles does
            she have left?
            */

            int beginningNumberOfMarbles = 38;
            int marblesSheLost = 15;
            int marblesAfterLosingFifteen = beginningNumberOfMarbles - marblesSheLost;

            /*
            24. Mrs. Hilt and her sister drove to a concert 78 miles away. They drove 32
            miles and then stopped for gas. How many miles did they have left to drive?
            */

            int milesToConcert = 78;
            int milesDriven = 32;
            int milesRemaining = milesToConcert - milesDriven;

            /*
            25. Mrs. Hilt spent 1 hour and 30 minutes shoveling snow on Saturday
            morning and 45 minutes shoveling snow on Saturday afternoon. How
            much total time (in minutes) did she spend shoveling snow?
            */

            int morningSnowShovelTime = 90;
            int afternoonSnowShovelTime = 45;
            int totalSnowShovelTime = morningSnowShovelTime + afternoonSnowShovelTime;

            /*
            26. Mrs. Hilt bought 6 hot dogs. Each hot dog cost 50 cents. How much
            money did she pay for all of the hot dogs?
            */

            decimal hotDogCost = .50M;
            int numberOfHotDogs = 6;
            decimal totalHotDogCost = hotDogCost * numberOfHotDogs;

            /*
            27. Mrs. Hilt has 50 cents. A pencil costs 7 cents. How many pencils can
            she buy with the money she has?
            */

            decimal moneyInHand = .50M;
            decimal pencilCost = .07M;
            int pencilsMrsHiltCanBuy = (int) (moneyInHand / pencilCost);

            /*
            28. Mrs. Hilt saw 33 butterflies. Some of the butterflies were red and others
            were orange. If 20 of the butterflies were orange, how many of them
            were red?
            */

            int totalButterflies = 33;
            int orangeButterflies = 20;
            int redButterflies = totalButterflies - orangeButterflies;

            /*
            29. Kate gave the clerk $1.00. Her candy cost 54 cents. How much change
            should Kate get back?
            */

            decimal moneyToClerk = 1M;
            decimal costOfCandy = .54M;
            decimal changeReceived = moneyToClerk - costOfCandy;

            /*
            30. Mark has 13 trees in his backyard. If he plants 12 more, how many trees
            will he have?
            */

            int preexistingTrees = 13;
            int addedTrees = 12;
            int totalNumberOfTrees = preexistingTrees + addedTrees;

            /*
            31. Joy will see her grandma in two days. How many hours until she sees
            her?
            */

            int hoursInADay = 24;
            int numberOfDaysTilSeeingGrandma = 2;
            int hoursTilGrandmaVisit = hoursInADay * numberOfDaysTilSeeingGrandma;

            /*
            32. Kim has 4 cousins. She wants to give each one 5 pieces of gum. How
            much gum will she need?
            */

            int numberOfCousins = 4;
            int piecesOfGumPerPerson = 5;
            int piecesOfGumNeeded = numberOfCousins * piecesOfGumPerPerson;

            /*
            33. Dan has $3.00. He bought a candy bar for $1.00. How much money is
            left?
            */

            decimal moneyDanHas = 3.00M;
            decimal costOfCandyBar = 1.00M;
            decimal moneyAfterCandyPurchase = moneyDanHas - costOfCandyBar;

            /*
            34. 5 boats are in the lake. Each boat has 3 people. How many people are
            on boats in the lake?
            */

            int boatsOnLake = 5;
            int peoplePerBoat = 3;
            int peopleOnLake = boatsOnLake * peoplePerBoat;

            /*
            35. Ellen had 380 legos, but she lost 57 of them. How many legos does she
            have now?
            */

            int startingNumberOfLegos = 380;
            int lostLegos = 57;
            int legosLeftover = startingNumberOfLegos - lostLegos;

            /*
            36. Arthur baked 35 muffins. How many more muffins does Arthur have to
            bake to have 83 muffins?
            */

            int numberOfMuffinsBaked = 35;
            int muffinsToBeBaked = 83;
            int muffinsInDifference = muffinsToBeBaked - numberOfMuffinsBaked;

            /*
            37. Willy has 1400 crayons. Lucy has 290 crayons. How many more
            crayons does Willy have then Lucy?
            */

            int willysCrayons = 1400;
            int lucysCrayons = 290;
            int moreCrayonsForWillyThanLucy = willysCrayons - lucysCrayons;

            /*
            38. There are 10 stickers on a page. If you have 22 pages of stickers, how
            many stickers do you have?
            */

            int stickersPerPage = 10;
            int pagesOfStickers = 22;
            int totalNumberOfStickers = stickersPerPage * pagesOfStickers;

            /*
            39. There are 100 cupcakes for 8 children to share. How much will each
            person get if they share the cupcakes equally?
            */

            decimal numberOfCupcakes = 100M;
            decimal numberOfChildren = 8M;
            decimal cupcakesPerChild = numberOfCupcakes / numberOfChildren;

            /*
            40. She made 47 gingerbread cookies which she will distribute equally in
            tiny glass jars. If each jar is to contain six cookies, how many
            cookies will not be placed in a jar?
            */

            int totalNumberOfCookies = 47;
            int cookiesPerJar = 6;
            int cookiesNotInJars = totalNumberOfCookies % cookiesPerJar;

            /*
            41. She also prepared 59 croissants which she plans to give to her 8
            neighbors. If each neighbor received an equal number of croissants,
            how many will be left with Marian?
            */

            int preparedCroissants = 59;
            int neighborsToGetCroissants = 8;
            int croissantsLeftover = preparedCroissants % neighborsToGetCroissants;

            /*
            42. Marian also baked oatmeal cookies for her classmates. If she can
            place 12 cookies on a tray at a time, how many trays will she need to
            prepare 276 oatmeal cookies at a time?
            */

            int oatmealCookiesPerTray = 12;
            int totalOatmealCookies = 276;
            int traysNeeded = totalOatmealCookies / oatmealCookiesPerTray;

            /*
            43. Marian’s friends were coming over that afternoon so she made 480
            bite-sized pretzels. If one serving is equal to 12 pretzels, how many
            servings of bite-sized pretzels was Marian able to prepare?
            */

            int biteSizedPretzels = 480;
            int servingSize = 12;
            int numberOfServings = biteSizedPretzels / servingSize;

            /*
            44. Lastly, she baked 53 lemon cupcakes for the children living in the city
            orphanage. If two lemon cupcakes were left at home, how many
            boxes with 3 lemon cupcakes each were given away?
            */

            int totalLemonCupcakes = 53;
            int cupcakesPerBox = 3;
            int numberOfCupcakeBoxes = (totalLemonCupcakes - 2) / cupcakesPerBox;

            /*
            45. Susie's mom prepared 74 carrot sticks for breakfast. If the carrots
            were served equally to 12 people, how many carrot sticks were left
            uneaten?
            */

            int totalCarrotSticks = 74;
            int carrottEaters = 12;
            int uneatenCarrots = totalCarrotSticks % carrottEaters;

            /*
            46. Susie and her sister gathered all 98 of their teddy bears and placed
            them on the shelves in their bedroom. If every shelf can carry a
            maximum of 7 teddy bears, how many shelves will be filled?
            */

            int allTheTeddyBears = 98;
            int teddyBearsPerShelf = 7;
            int shelvesFullOfBears = allTheTeddyBears / teddyBearsPerShelf;

            /*
            47. Susie’s mother collected all family pictures and wanted to place all of
            them in an album. If an album can contain 20 pictures, how many
            albums will she need if there are 480 pictures?
            */

            int picturesPerAlbum = 20;
            int totalNumberOfPictures = 480;
            int albumsNeeded = totalNumberOfPictures / picturesPerAlbum;

            /*
            48. Joe, Susie’s brother, collected all 94 trading cards scattered in his
            room and placed them in boxes. If a full box can hold a maximum of 8
            cards, how many boxes were filled and how many cards are there in
            the unfilled box?
            */

            int allTradingCards = 94;
            int cardsPerBox = 8;
            int fullBoxesOfCards = allTradingCards / cardsPerBox;
            int cardsInUnfilledBox = allTradingCards % cardsPerBox;

            /*
            49. Susie’s father repaired the bookshelves in the reading room. If he has
            210 books to be distributed equally on the 10 shelves he repaired,
            how many books will each shelf contain?
            */

            int booksToBeDistributed = 210;
            int shelvesRepaired = 10;
            int booksPerRepairedShelf = booksToBeDistributed / shelvesRepaired;

            /*
            50. Cristina baked 17 croissants. If she planned to serve this equally to
            her seven guests, how many will each have?
            */

            double croissantsBaked = 17;
            double guestsToEatCroissants = 7;
            double croissantsPerGuest = croissantsBaked / guestsToEatCroissants;
            //Console.WriteLine(croissantsPerGuest);

            /*
            51. Bill and Jill are house painters. Bill can paint a standard room in 2.15 hours, while Jill averages
            1.90 hours. How long will it take the two painters working together to paint 5 standard rooms?
            Hint: Calculate the rate at which each painter can complete a room (rooms / hour), combine those rates,
            and then divide the total number of rooms to be painted by the combined rate.
            */

            double billHoursPerRoom = 2.15;
            double jillHoursPerRoom = 1.90;
            double billRoomsPerHour = 1 / billHoursPerRoom;
            double jillRoomsPerHour = 1 / jillHoursPerRoom;
            int roomsToBePainted = 5;
            double combinedRateOfPainting = billRoomsPerHour + jillRoomsPerHour;
            // Console.WriteLine(combinedRateOfPainting);
            double timeToPaintFiveRooms = roomsToBePainted / combinedRateOfPainting;
            // Console.WriteLine(timeToPaintFiveRooms);

            /*
            52. Create and assign variables to hold a first name, last name, and middle initial. Using concatenation,
            build an additional variable to hold the full name in the order of last name, first name, middle initial. The
            last and first names should be separated by a comma followed by a space, and the middle initial must end
            with a period. Use "Grace", "Hopper, and "B" for the first name, last name, and middle initial.
            Example: "John", "Smith, "D" —> "Smith, John D."
            */

            string firstName = "Grace";
            string lastName = "Hopper";
            char middleInitial = 'B';
            string fullNamePlusInitial = lastName + ", " + firstName + ' ' + middleInitial + '.';
            //Console.WriteLine(fullNamePlusInitial);

            /*
            53. The distance between New York and Chicago is 800 miles, and the train has already travelled 537 miles.
            What percentage of the trip as a whole number (integer) has been completed?
            */

            decimal distanceChicagoToNewYork = 800M;
            decimal distanceAlreadyTraveled = 537M;
            decimal percentTripCompleted = (distanceAlreadyTraveled / distanceChicagoToNewYork) * 100 ;
            int integerPercentTripCompleted = (int) percentTripCompleted;
        }
    }
}
