public class Hobbits {
String name;

    public static void main(String[] args) {
        Hobbits [] h = new Hobbits[3];
        int z = 0;

       
        while (z < h.length){

            h[z]= new Hobbits();
            h[z].name = "bilbo ";
            
            if (z == 1) {
                h[z].name = "sam ";
            }
            
            System.out.println(h[z].name + "is a good hobbit name");
            z = z +1;
        }//end loop
     
    }//end main
    
}//end class