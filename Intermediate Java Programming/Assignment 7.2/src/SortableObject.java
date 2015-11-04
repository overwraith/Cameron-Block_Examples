import java.util.Arrays;

public class SortableObject implements Comparable{
	
	public int number;
	
	//The following is sorting backwards, and has some errors. 
	public static void main(String[] args) {
		SortableObject stuff[] = new SortableObject[100];
		
		//Initialize to avoid null pointer exceptions. 
		for(int i = 0 ; i < stuff.length ; i++)
			stuff[i] = new SortableObject();
		
		//Make some random values. 
		for(int i = 0 ; i < stuff.length ; i++)
			stuff[i].number = (int)(Math.random() * 1000);
		
		//Sort. 
		Arrays.sort(stuff);
		
		//Display Output. 
		for(int i = 1 ; i < stuff.length ; i++)
			System.out.print(stuff[i].number 
					+ ((i == stuff.length - 1) ? "" : ", "));
		
	}
	
	public SortableObject(){
		number = 0;
	}

	public int compareTo(Object other) {
		if(this.number > (other).number)
			return -1;
		if(this.number < ((SortableObject)other).number)
			return 1;
		else
			return 0;
	}

}//end class
