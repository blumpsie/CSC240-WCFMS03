using System;

namespace CSC240_WCFMS03
{
    class Program
    {
        static void Main(string[] args)
        {
            ElementSet theList = new ElementSet();
            /*
            Movie movie = new Movie();
            Console.WriteLine(movie.ToString());
            */
            // present the menu for user to choose from
            // and process their choice
            bool terminate = false;
            do
            {
                bool validChoice = false;
                string userChoice;
                do
                {
                    Console.Write("\nWEST CHESTER FABULOUS MOVIE SOCIETY DATA MENU\n"
                                 + "1 - Add a Movie or an Opera\n"
                                 + "2 - Display the titles for all of the Movies\n"
                                 + "3 - Display the titles for all of the Operas\n"
                                 + "4 - Display the data for a particular Movie\n"
                                 + "5 - Display the data for a particular Opera\n"
                                 + "6 - Edit the data for a particular Movie or Opera\n"
                                 + "7 - Remove a particular Movie or Opera\n"
                                 + "8 - Quit the program\n");
                    userChoice = Console.ReadLine();

                    if (userChoice[0] != '1' ||
                        userChoice[0] != '2' ||
                        userChoice[0] != '3' ||
                        userChoice[0] != '4' ||
                        userChoice[0] != '5' ||
                        userChoice[0] != '6' ||
                        userChoice[0] != '7' ||
                        userChoice[0] != '8')
                    {
                        validChoice = true;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid choice. Please try again.");
                    }

                } while (!validChoice);

                
                switch (userChoice[0])
                {
                    case '1':
                        Console.WriteLine("\nWhich would you like to add (Movie/Opera)?");
                        string choice = Console.ReadLine().ToUpper();

                        if (choice[0] == 'M')
                        {
                            addMovie(theList);
                        }
                        else if (choice[0] == 'O')
                        {
                            addOpera(theList);
                        }
                        else
                        {
                            Console.WriteLine("\nNot a valid choice.");
                        }
                        break;
                    case '2':
                        displayMovieTitles(theList);
                        break;
                    case '3':
                        displayOperaTitles(theList);
                        break;
                    case '4':
                        Console.WriteLine("\nWhat Movie would you like to see information for?");
                        string title = Console.ReadLine().ToUpper();
                        displayMovie(theList, title);
                        break;
                    case '5':
                        Console.WriteLine("\nWhat Opera would you like to see information for?");
                        title = Console.ReadLine().ToUpper();
                        displayOpera(theList, title);
                        break;
                    case '6':
                        Console.WriteLine("\nWhich would you like to edit (Movie/Opera)?");
                        choice = Console.ReadLine().ToUpper();

                        if (choice[0] == 'M')
                        {
                            Element movie = new Movie(); // create new Movie object
                            movie.readIn();              // get the new information
                            bool edited;

                            try
                            {
                                theList.editAnObject(movie);
                                edited = true;
                            }
                            catch (CannotEditException ex)
                            {
                                Console.WriteLine(ex.Message);
                                edited = false;
                            }
                            
                            if (edited)
                            {
                                Console.WriteLine("\nSuccessful edit.");
                            }
                        }
                        else if (choice[0] == 'O')
                        {
                            Element opera = new Opera(); // create new Opera object
                            opera.readIn();              // get the new information
                            bool edited; // the object and place store the result

                            try
                            {
                                theList.editAnObject(opera);
                                edited = true;
                            }
                            catch (CannotEditException ex)
                            {
                                Console.WriteLine(ex.Message);
                                edited = false;
                            }

                            if (edited)
                            {
                                Console.WriteLine("\nSuccessful edit.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNot a valid option.");
                        }
                        break;
                    case '7':
                        Console.WriteLine("\nWhich would you like to remove (Movie/Opera)?");
                        choice = Console.ReadLine().ToUpper();

                        if (choice[0] == 'M')
                        {
                            Movie movie = new Movie();                        // create new Movie object
                            Console.WriteLine("\nWhat is the title of the Movie that you would like to remove?");
                            movie.Title = Console.ReadLine().ToUpper();               // get the new information
                            bool removed;    // the object and place store the result

                            try
                            {
                                theList.removeAnObject(movie);
                                removed = true;
                            }
                            catch (CannotRemoveException ex)
                            {
                                removed = false;
                                Console.WriteLine(ex.Message);
                            }

                            if (removed)
                            {
                                Console.WriteLine("\nSuccessful remove.");
                            }
                        }
                        else if (choice[0] == 'O')
                        {
                            Opera opera = new Opera(); // create new Opera object
                            Console.WriteLine("\nWhat is the title of the Opera that you would like to remove?");
                            opera.Title = Console.ReadLine().ToUpper();               // get the new information
                            bool removed; // the object and place store the result

                            try
                            {
                                theList.removeAnObject(opera);
                                removed = true;
                            }
                            catch (CannotRemoveException ex)
                            {
                                removed = false;
                                Console.WriteLine(ex.Message);
                            }

                            if (removed)
                            {
                                Console.WriteLine("\nSuccessful remove.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNot a valid option.");
                        }
                        break;
                    case '8':
                        Console.WriteLine("\nAre you sure (Y/N)?");
                        string exitChoice = Console.ReadLine().ToUpper();
                        if (exitChoice[0] == 'Y')
                        {
                            terminate = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nNot a valid choice. Please choose again.");
                        break;
                }
            } while (!terminate);
        }
        
        // Display's the title of all the movies
        public static void displayMovieTitles(ElementSet anElementSet)
        {
            Element currObject;
            Movie movie;

            Console.WriteLine("\n");
            for (int i = 0; i < anElementSet.size(); i++)
            {
                currObject = anElementSet.getCurrent();
                
                if (currObject.getClassName().Equals("Movie"))
                {
                    movie = (Movie)currObject; // casts the currentObject as Movie Object
                                               // so that the title can be accessed
                    Console.WriteLine(movie.Title);
                }
            }
        }

        // Display's the title of all the operas
        public static void displayOperaTitles(ElementSet anElementSet)
        {
            Element currObject;
            Opera opera;

            Console.WriteLine("\n");
            for (int i = 0; i < anElementSet.size(); i++)
            {
                currObject = anElementSet.getCurrent();
                if (currObject.getClassName().Equals("Opera"))
                {
                    opera = (Opera)currObject; // casts the currentObject as Movie Object
                                               // so that the title can be accessed
                    Console.WriteLine(opera.Title);
                }
            }
        }

        // Display's the information for a specified movie
        public static void displayMovie(ElementSet anElementSet, string title)
        {
            bool found = false;

            Element currObject;
            Movie movie;

            Console.WriteLine("\n");
            for (int i = 0; i < anElementSet.size(); i++)
            {
                currObject = anElementSet.getCurrent();
                if (currObject.getClassName().Equals("Movie"))
                {
                    movie = (Movie)currObject;
                    if (movie.Title.Equals(title))
                    {
                        movie.display();
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("There is no Movie with that title.");
            }
        }

        // Display's the information for a specified opera
        public static void displayOpera(ElementSet anElementSet, string title)
        {
            bool found = false;

            Element currObject;
            Opera opera;

            Console.WriteLine("\n");
            for (int i = 0; i < anElementSet.size(); i++)
            {
                currObject = anElementSet.getCurrent();
                if (currObject.getClassName().Equals("Opera"))
                {
                    opera = (Opera)currObject;
                    if (opera.Title.Equals(title))
                    {
                        opera.display();
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("There is no Movie with that title.");
            }
        }

        // adds a Movie to the set
        public static void addMovie(ElementSet anElementSet)
        {
            Element movie = new Movie();
            movie.readIn();
            bool added;

            // feedback on the result of the add
            try
            {
                anElementSet.add(movie);
                added = true;
            }
            catch (FullSetException ex)
            {
                added = false;
                Console.WriteLine(ex.Message);
            }
            catch (DuplicateObjectException ex)
            {
                added = false;
                Console.WriteLine(ex.Message);
            }


            if (added)
            {
                Console.WriteLine("\nSuccessful add.");
            }
        }

        // adds an Opera to the set
        public static void addOpera(ElementSet anElementSet)
        {
            Element opera = new Opera();
            opera.readIn();
            bool added;

            // feedback on the result of the add
            try
            {
                anElementSet.add(opera);
                added = true;
            }
            catch (FullSetException ex)
            {
                added = false;
                Console.WriteLine(ex.Message);
            }
            catch (DuplicateObjectException ex)
            {
                added = false;
                Console.WriteLine(ex.Message);
            }

            if (added)
            {
                Console.WriteLine("\nSuccessful add.");
            }
        }
    }
}
