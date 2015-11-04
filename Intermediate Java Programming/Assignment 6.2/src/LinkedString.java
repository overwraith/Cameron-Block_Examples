/* Author: Cameron Block
 * File: LinkedString.java
 * Purpose: to create a mutable String based on the linked list data type. 
 * */
import java.io.Serializable;
import java.util.LinkedList;

public class LinkedString implements CharSequence, Serializable{
	
	private LinkedList<Character> str;//Basically is the string. 
	
	public static void main(String[] args) {
		
		LinkedString str = new LinkedString();
		str.append("Hello World");
		str.insert(" World ", 5);
		str.append(new Character[]{'A', 'B', 'C'});
		str.append("Hello World");
		str.insert('X', 5);
		str.insert(12.34F, 12);
		str.insert("World", 0);
		System.out.println(str.toString());
		
		System.out.println("Finding the String\"Hello\": " 
				+ str.indexOf("Hello"));
		System.out.println("Finding the String\"World\": " 
					+ str.indexOf("World"));
		System.out.println("Finding the String\"X\": " + str.indexOf("X"));
		System.out.println("Finding the String\"_\": " + str.indexOf("_"));
		
		System.out.println("Finding the String\"Hello\" from Index 10: " 
				+ str.indexOf("Hello", 10));
		System.out.println("Finding the String\"Hello\" from Index 10: " 
		+ "WorldHelloX World12.34  WorldABCHello World".indexOf("Hello", 10));
		
		//Time 1
		long startTime1, startTime2, endTime1, endTime2; 
		
		startTime1 = System.currentTimeMillis();
		
		StringBuilder string1 = new StringBuilder("");
		for(int x = 0 ; x < 1000000 ; x++)
			string1.append("Java");
		
		endTime1 = System.currentTimeMillis();
		
		System.out.println("Time for empty StringBuilder: " + (endTime1 - startTime1) + " milliseconds. ");
		
		//Time 2
		startTime2 = System.currentTimeMillis();
		
		LinkedString string2 = new LinkedString();
		for(int x = 0 ; x < 1000000 ; x++)
			string2.append("Java");
		
		endTime2 = System.currentTimeMillis();
		
		System.out.println("Time for empty LinkedString: " + (endTime2 - startTime2) + " milliseconds. ");
		
		
		
	}
	
	//INDEX OF METHOD
	public int indexOf(String findstr){//Verified
		//find a string in the object
		
		for(int i = 0 ; i < this.length() ; i++){
			//Iterate through LinkedString object
			for(int j = 0 ; j < findstr.length() ; j++, i++){
				//Iterate through the string we are finding
				if(this.charAt(i) == findstr.charAt(j)){
					//If the characters match, keep going
					if(j == findstr.length() - 1){
						//If we reach the end of the string minus the null 
						//character return the value
						return i - findstr.length() + 1;
						//+1 to get rid of null character
					}
				}
				else//not a match, start over
					break;
			}//end loop
		}//end loop
		
		return -1;//failure to find anything
	}
	
	//INDEX OF METHOD
	public int indexOf(String findstr, int index){//Verified
		//find a string in the object
		
		for(int i = index ; i < this.length() ; i++){
			//Iterate through LinkedString object
			for(int j = 0 ; j < findstr.length() ; j++, i++){
				//Iterate through the string we are finding
				if(this.charAt(i) == findstr.charAt(j)){
					//If the characters match, keep going
					if(j == findstr.length() - 1){
						//If we reach the end of the string minus the null 
						//character return the value
						return i - findstr.length() + 1;
						//+1 to get rid of null character
					}
				}
				else//not a match, start over
					break;
			}//end loop
		}//end loop
		
		return -1;//failure to find anything
	}
	
	//SUBSTRING METHOD
	public String substring(int start, int end){//Verified
		char ch[] = new char[end-start];
		
		if(end > start)
			for(int i = start ; i < end ; i++ )
				ch[i] = ((Character)this.charAt(i)).charValue();
		else
			return null;
		
		return new String(ch);
	}
	
	//CONSTRUCTORS
	public LinkedString(){//Verified
		str = new LinkedList<Character>();
	}
	
	public LinkedString(String str){//Verified
		this.str = new LinkedList<Character>();
		this.append(str);
	}
	
	//APPEND METHOD
	public void append(char ch[]){//Verified
		for(int i = 0 ; i < ch.length ; i++)
			this.str.add((Character)ch[i]);
	}
	
	public void append(Character ch[]){//Verified
		for(int i = 0 ; i < ch.length ; i++)
			this.str.add(ch[i]);
	}
	
	public void append(Object obj){//Verified
		String str = obj.toString();
		for(int i = 0 ; i < str.length() ; i++)
			this.str.add((Character)str.charAt(i));
	}
	
	//CHAR AT METHOD
	public char charAt(int i){//Verified
		return Character.valueOf(this.str.get(i));
	}
	
	//INSERT METHOD
	public void insert(Object obj, int index){//Verified
		//covers floats, doubles, longs, etc
		String str = obj.toString();
		for(int i = index, j = 0; j < str.length() ; i++, j++)
			this.str.add(i, (Character)str.charAt(j));
	}
	
	public void insert(char ch[], int index){//Verified
		for(int i = index, j = 0; j < ch.length ; i++, j++)
			this.str.add(i, (Character)ch[j]);
	}
	
	public void insert(Character ch[], int index){//Verified
		for(int i = index, j = 0; j < ch.length ; i++, j++)
			this.str.add(i, ch[j]);
	}
	
	//DELETE METHOD
	public void delete(int start, int end){//Verified
		for(int i = start ; i < end ; i++)
			this.str.remove(i);
	}
	
	public void delete(int index){
		this.str.remove(index);
	}
	
	//LENGTH METHOD
	public int length(){//Verified
		return this.str.size();
	}
	
	//TO ARRAY METHOD
	public Object[] toArray(){
		return str.toArray();
	}
	
	//TO CHARACTER ARRAY
	public Character[] toCharacterArray(){//Verified
		Object theContents[] = str.toArray();
		Character ch[] = new Character[theContents.length];
		
		for(int i = 0 ; i < ch.length ; i++)
			ch[i] = (Character)theContents[i];
		
		return ch;
	}
	
	//TO CHAR ARRAY
	public char[] toCharArray(){//Verified
		Object theContents[] = str.toArray();
		char ch[] = new char[theContents.length];
		
		for(int i = 0 ; i < ch.length ; i++)
			ch[i] = ((Character)theContents[i]).charValue();
		
		return ch;
	}
	
	//TO STRING
	public String toString(){//Verified
		Object[] ch = str.toArray();
		char retCh[] = new char[ch.length];//return character array retCh
		
		for(int i = 0 ; i < ch.length ; i++)
			retCh[i] = Character.valueOf((Character)ch[i]);
			 
		return new String(retCh);
	}
	
	//SUB SEQUENCE METHOD
	public CharSequence subSequence(int start, int end) {
		char ch[] = new char[end-start];
		
		if(end > start)
			for(int i = start ; i < end ; i++ )
				ch[i] = ((Character)this.charAt(i)).charValue();
		else
			return null;
		
		return new String(ch);
	}
}//end class
