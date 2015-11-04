/* Author: Cameron Block
 * File: SchoolTextBook.java
 * Intermediate Java I
 * Purpose: to create a class that sorts an array of SchoolTextBook objects. 
 * */
import java.io.IOException;
import java.util.Arrays;
import java.util.Scanner;

public class SchoolTextBook implements Comparable{
	private String author, title, isbn;
	private int pages;
	private double price;
	
	private static boolean sortByAuthor = false, sortByTitle = false, 
			sortByISBN = false, sortByPages = false, sortByPrice = false;
	
	private static final int ARRAY_LENGTH = 5; 
	
	public static void main(String[] args) {
		
		SchoolTextBook books[] = new SchoolTextBook[ARRAY_LENGTH];
		Scanner sc = new Scanner(System.in);
		String options[] = new String[]{"Author", "Title", "ISBN", "Pages", 
				"Price"};
		
		//initialize values of the array. 
		books[0] = new SchoolTextBook("Joyce Farrell", 
				"Java Programming 6th ed", "1-11-52944-2", 952, 82.95);
		books[1] = new SchoolTextBook("Nell Dale", 
				"Programming and problem solving with Java", "0-7637-0490-3", 
				789, 86.83);
		books[2] = new SchoolTextBook("Maria Litvin", "Java Methods A&AB", 
				"0-9727055-7-0", 666, 40.00);
		books[3] = new SchoolTextBook("Joel Murach", "Murach's Java SE 6", 
				"1-890774-42-1", 810, 52.50);
		books[4] = new SchoolTextBook("Paul Deitel", "C how to program 6th ed", 
				"978-81-203-4006-0", 966, 65.82);
		
		System.out.format("%s\t%13s\t%44s\t%23s\t%7s\n", "Author", "Title", 
				"ISBN", "Pages", "Price");
		
		//display the sorted array. 
		for(SchoolTextBook book : books)
			System.out.println(book.toString());
		
		System.out.println();
		
		String sortBy = getString(sc, "Please Enter the field you wish sorted \n" 
		+ "(Options: Author, Title, ISBN, Pages, Price, Title, ): ", options);
		
		if(sortBy.equalsIgnoreCase(options[0]))
			SchoolTextBook.sortByAuthor(books);
		else if(sortBy.equalsIgnoreCase(options[1]))
			SchoolTextBook.sortByTitle(books);
		else if(sortBy.equalsIgnoreCase(options[2]))
			SchoolTextBook.sortByISBN(books);
		else if(sortBy.equalsIgnoreCase(options[3]))
			SchoolTextBook.sortByPages(books);
		else if(sortBy.equalsIgnoreCase(options[4]))
			SchoolTextBook.sortByPrice(books);
		
		System.out.println();
		
		System.out.format("%s\t%13s\t%44s\t%23s\t%7s\n", "Author", "Title", 
				"ISBN", "Pages", "Price");
		
		//display the sorted array. 
		for(SchoolTextBook book : books)
			System.out.println(book.toString());
	}//end main
	
	//CONSTRUCTOR
	public SchoolTextBook(String author, String title, String isbn, int pages, 
			double price){
		this.setAuthor(author);
		this.setTitle(title);
		this.setISBN(isbn);
		this.setPages(pages);
		this.setPrice(price);
	}
	
	//GET METHODS
	public String getAuthor(){ return author; }
	
	public String getTitle(){ return title; }
	
	public String getISBN(){ return isbn; }
	
	public int getPages(){ return pages; }
	
	public double getPrice(){ return price; }
	
	//SET METHODS
	public void setAuthor(String author){ this.author = author; }
	
	public void setTitle(String title){ this.title = title; }
	
	public void setISBN(String isbn){ this.isbn = isbn; }
	
	public void setPages(int pages){ this.pages = pages; }
	
	public void setPrice(double price){ this.price = price; }
	
	//SORT METHODS
	public static void sortByAuthor(SchoolTextBook books[]){ 
		sortByAuthor = true;
		sortByTitle = false; 
		sortByISBN = false;
		sortByPages = false;
		sortByPrice = false;
		Arrays.sort(books);
	}
	
	public static void sortByTitle(SchoolTextBook books[]){
		sortByAuthor = false;
		sortByTitle = true; 
		sortByISBN = false;
		sortByPages = false;
		sortByPrice = false;
		Arrays.sort(books);
	}
	
	public static void sortByISBN(SchoolTextBook books[]){
		sortByAuthor = false;
		sortByTitle = false; 
		sortByISBN = true;
		sortByPages = false;
		sortByPrice = false;
		Arrays.sort(books);
	}
	
	public static void sortByPages(SchoolTextBook books[]){
		sortByAuthor = false;
		sortByTitle = false; 
		sortByISBN = false;
		sortByPages = true;
		sortByPrice = false;
		Arrays.sort(books);
	}
	
	public static void sortByPrice(SchoolTextBook books[]){
		sortByAuthor = false;
		sortByTitle = false; 
		sortByISBN = false;
		sortByPages = false;
		sortByPrice = true;
		Arrays.sort(books);
	}
	
	//TO STRING
	public String toString(){
		//Unfortunately something like 115 characters of console width is 
		//required to adequately display this. Can change character width
		//in command line settings, or just compile using eclipse or another
		//compiler. 
		return String.format("%s\t%-45s\t%-20s\t%5d\t$%6.2f", this.author, 
				this.title, this.isbn, this.pages, this.price);
	}
	
	public static String getString(Scanner sc, String prompt, String[] options){
		//The following loop and try/catch prompts user to enter correct 
		//data infinitely until the user follows the prompts instructions. 
		while(true){
			try{
				System.out.print(prompt);
				String input = sc.nextLine();
				for(int i = 0 ; i < options.length ; i++){
					if(options[i].equalsIgnoreCase(input))
						return input;
					else if(i == options.length - 1)
						throw new IOException("Doesnt match");
				}
			}catch(Exception ex){
				System.out.println("\nInput error, please try again. ");
				sc.nextLine();
			}
		}//end loop
	}//end method

	public int compareTo(Object other) {
		if(sortByAuthor)
			return this.author.compareTo(((SchoolTextBook)other).getAuthor());
		else if(sortByTitle)
			return this.title.compareTo(((SchoolTextBook)other).getTitle());
		else if(sortByISBN)
			return this.isbn.compareTo(((SchoolTextBook)other).getISBN());
		else if(sortByPages){
			if(this.pages > ((SchoolTextBook)other).getPages())
				return 1;
			else if(this.pages < ((SchoolTextBook)other).getPages())
				return -1;
			else
				return 0;
		}
		else{//sortByPrice
			if(this.price > ((SchoolTextBook)other).getPrice())
				return 1;
			else if(this.price < ((SchoolTextBook)other).getPrice())
				return -1;
			else
				return 0;
		}
	}
	
}//end class
