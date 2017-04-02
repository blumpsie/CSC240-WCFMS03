﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC240_WCFMS03
{
    class ElementSet
    {
        // Data Fields
        private Element[] theList;
        private int currentIndex;
        private int currentSize;
        private const int MAXSETSIZE = 100;

        // Constructor
        public ElementSet()
        {
            theList = new Element[MAXSETSIZE];
            currentIndex = -1;
            currentSize = 0;
        }

        // Tests to see if passed Element is in the set
        public bool isMemberOf(Element anElement)
        {
            string paramClass = anElement.getClassName();
            string currClass;

            for (int i = 0; i < currentSize; i++)
            {
                currClass = theList[i].getClassName();

                if (currClass.Equals(paramClass))
                {
                    if (theList[i].equals(anElement))
                    {
                        return true;
                    }
                }
            }

            // not found
            return false;
        }

        // tests to see if theList is full
        public bool isFull()
        {
            return currentSize == MAXSETSIZE;
        }

        // Tests to see if theList is empty
        public bool isEmpty()
        {
            return currentSize == 0;
        }

        // Returns the current size of theList
        public int size()
        {
            return currentSize;
        }

        // Returns the current element
        public Element getCurrent()
        {
            int saveIndex = currentIndex;

            if (currentIndex == currentSize - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }

            return theList[saveIndex].clone();
        }

        // Adds an Element to theList
        public void add(Element anObject)
        {
            string classType = anObject.getClassName();

            if (currentSize == MAXSETSIZE)
            {
                throw new FullSetException(classType); // set is full
            }
            else if (this.isMemberOf(anObject))
            {
                throw new DuplicateObjectException(classType); // already in the set
            }

            // add to set
            theList[currentSize] = anObject.clone();

            // increment currentSize
            currentSize++;

            // set currentIndex to added Element if it is the first in the set
            if (currentSize == 1)
            {
                currentIndex = 0;
            }
        }

        // clears the entire set back to empty
        public void clear()
        {
            // clear up memory while in use
            for (int i = 0; i < currentSize; i++)
            {
                theList[i] = null;
            }

            // reset currentIndex and currentSize
            currentIndex = -1;
            currentSize = 0;
        }

        public void display()
        {
            if (currentSize == 0)
            {
                Console.WriteLine("There are no objects in the set.");
            }
            else
            {
                Console.WriteLine("Here are the Objects in the set: \n");
                for (int i = 0; i < currentSize; i++)
                {
                    theList[i].display();
                    Console.WriteLine("\n");
                }
            }
        }

        // Removes a specified object from theList
        public void removeAnObject(Element anObject)
        {
            string paramClass = anObject.getClassName();
            string currClass;
            Element lastItem;
            bool removed = false;

            for (int i = 0; i < currentSize; i++)
            {
                currClass = theList[i].getClassName();
                if (currClass.Equals(paramClass))
                {
                    if (theList[i].equals(anObject))
                    {
                        lastItem = theList[--currentSize]; // assigns the last item in the list to variable lastItem,
                                                           // using a prefix decrement of currentSize as the index.
                                                           // if currentSize is used an error would occur as currentSize 
                                                           // starts at 1 and the indexing starts at 0

                        theList[i] = lastItem;             // assigns the lastItem to the current index of theList, 
                                                           // writing over the object that was to be removed.
                                                           // in essence removing the object from the list. 
                        lastItem = null;                   // deletes the lastItem

                        if (currentIndex == currentSize - 1)
                        {
                            currentIndex = 0;
                        }

                        else if (isEmpty())
                        {
                            currentIndex = -1;
                        }

                        removed = true; // success
                    }
                }
            }

            if (!removed) // not found in set
            {
                throw new CannotRemoveException(paramClass);
            }
        }

        // replaces a specified object from theList with an user edited replacement
        public void editAnObject(Element editedObject)
        {
            string paramClass = editedObject.getClassName();
            string currClass;
            bool edited = false;

            for (int i = 0; i < currentSize; i++)
            {
                currClass = theList[i].getClassName();
                if (currClass.Equals(paramClass))
                {
                    if (theList[i].equals(editedObject))
                    {
                        theList[i] = editedObject.clone();
                        edited = true;
                    }
                }
            }

           if (!edited)
            {
                throw new CannotEditException(paramClass);
            }
        }
    }
}
