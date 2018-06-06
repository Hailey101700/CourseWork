package Numerical;

import java.util.Scanner;

import com.sun.org.apache.xpath.internal.operations.Number;

public class FindPrime {

	public static void main(String[] args) {
		
		Scanner sc = new Scanner(System.in);
		 
	    System.out.print("Enter a number: ");
	 
	    int n = sc.nextInt();
	 
	    int N, c, i;
	    N=1;
	    c=0;
	 
	    while (c < n){
	      N = N+1;
	      for (i = 2; i <= N; i++){
	        if (N % i == 0) {
	          break;
	        }
	      }
	      if ( i == N){
	        c = c+1;
	      }
	    }
	    System.out.println("Here you go: " + N);
	  }
	}

// Had to use help on some parts.
	

  
	

			
		
								
			
			
	
		
	
	