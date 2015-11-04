
public class RaceHorseAppII {

	public static void main(String[] args) {
		/*new RaceHorse("Stan").start();
		new RaceHorse("Tom").start();
		new RaceHorse("Harry").start();
		new RaceHorse("Finn").start();
		new RaceHorse("Sawyer").start();*/
		
		Thread t = new Thread(new RaceHorseII("Sawyer"));
		Thread t2 = new Thread(new RaceHorseII("Tom"));
		
        t.start();
        t2.start();
		
		//new RaceHorseII("Sawyer");
		//new RaceHorseII("Sawyer");
		
	}
	
	public static class RaceHorse extends Thread{
		
		private String name = "";
		
		public RaceHorse(String name){
			this.name = name; 
		}
		
		public void run() {
			for(int i = 0 ; i < 50 ; i++){
				System.out.println(name);
			}
		}
		
	}//end inner class
	
	public static class RaceHorseII implements Runnable{
		
		private String name = "";
		
		public RaceHorseII(String name){
			this.name = name; 
		}
		
		public void run() {
			for(int i = 0 ; i < 50 ; i++){
				System.out.println(name);
				
			}
		}
		
	}//end inner class

}//end class
