using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = ""; //String read form user.
            int N;  //integer.
            bool sucess = false;    //Flag set to false.
            bool ALLOK = true;
            bool DOO = false;
            int Option;
            int S; // # of solution 
            S = 0;
            do
            {
                // This tells you to enter a number it anilizes what you typed in to see if there is a solution. 
                // If no solution it tells you so.
                Console.Write("Enter number between 1 and 14: ");
                x = Console.ReadLine(); // Read info...
                sucess = int.TryParse(x, out N); // Parse the input into the integer a
                if (sucess)
                {
                    if (N <= 0 || N > 14)
                    {
                        sucess = false;
                    }
                }
                if (!sucess)
                {
                      Console.Write(" Enter a number between 1 and 14!:  ");
                }
            } while (!sucess || N < 1 || N > 14);

            if (N == 2 || N == 3)
            {
                Console.WriteLine("There are no Solutions!");
            }
                // Coming up with the sloutions.
            else
            {
                int[] QueenInColl = new int[N];

                for (int i = 0; i < N; i++)
                {
                    QueenInColl[i] = -1;
                }
                // Asking what info you want. 
                do
                {
                    Console.WriteLine("Option 1 = # of Sol only");
                    Console.WriteLine("Option 2 = # of Sol and 1st Sol");
                    if (N <= 8)
                    {
                        Console.WriteLine("Option 3 = # of Sol and all Sol");
                    }
                    x = Console.ReadLine(); // Read information 
                    sucess = int.TryParse(x, out Option);
                    if (sucess)
                    {
                        if (Option < 1 || Option > 3 || (Option == 3 && N > 8))
                        {
                            sucess = false;
                        }
                        // Saying answer not valid.
                    }
                    if (sucess == false)
                    {
                        Console.WriteLine("Enter a valid Option");
                    }
                } while (sucess == false);

                for (int r = 0; r <= N - 1; r++) // loop a  // 
                {
                    do
                    {
                        for (int c = QueenInColl[r] + 1; c <= N - 1; c++) // loop b
                        {
                            ALLOK = true;

                            for (int p = r - 1; p >= 0; p--) // loop c
                            {
                                int t = c - (r - p);   // northwest // checking to see if there are any soloutions in that area.
                                if (t >= 0)
                                {
                                    if (t == QueenInColl[p])    // If nothing there check another area.
                                    {                           
                                        ALLOK = false;
                                    }

                                }
                                t = c;   // north           //Checking that area for solutions.
                                if (t == QueenInColl[p])
                                {
                                    ALLOK = false;      //Nothing? Cheack somewhere else. 
                                }
                                t = c + (r - p);   //northeast    //Check in this area. 
                                if (t <= N - 1)
                                {
                                    if (t == QueenInColl[p])
                                    {
                                        ALLOK = false;  //Check for solution.
                                    }
                                }

                                if (ALLOK == false)
                                {
                                    break;  //If all good the exit 
                                }
                            } // End of loop C

                            if (ALLOK == true)
                            {
                                QueenInColl[r] = c;  //Increasing number of solutions that were found.

                                if (r == N - 1)
                                {
                                    S = S + 1;    //Increment number of solutions found
                                    if (Option == 3 || (Option == 2 && DOO == false))
                                    {

                                        Console.WriteLine(" S {0}", S);   //If there are solutions say them. 
                                        for (int i = 0; i < N; i++)
                                        {
                                            Console.WriteLine("{0} ", QueenInColl[i]);
                                        }
                                        //out put this solution!!
                                        DOO = true;
                                    }
                                    ALLOK = false;
                                }

                                else  //Break out if solutions found and outputted. 
                                {
                                    break;
                                }
                            }

                        } //end of loop B

                        if (ALLOK == false)
                        {
                            QueenInColl[r] = -1;
                            r = r - 1;
                            while (r >= 0 && QueenInColl[r] == N - 1)
                            {
                                QueenInColl[r] = -1;
                                r = r - 1;              //Take step back. 
                            }
                        }
                        // backup one or more rows

                    } while (ALLOK == false && r >= 0);

                    if (r < 0)
                    {
                        break;
                    }
                    // if row < 0 then break out of loop A because there are no more solutions.

                }//end of loop A

                Console.WriteLine("Total # of Sol : S {0}", S);
            }
            Console.WriteLine(" Press any Key to End.");
            Console.ReadKey();
                            
            // Output total number of solutions
            // Telling to end program by pressing any key.
        }
    }
}
