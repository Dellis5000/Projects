import javax.swing.*;
import java.awt.*;

public class Display extends JFrame
{
   private Panel p; //variable declaration for panel
   
   public Display()
   {
      setTitle("Spinning Kart"); //Title of frame
      setBounds(100,100,500,500); //set bounds of the Jframe
      setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); 
      
      Container cp = getContentPane();          
	   cp.setLayout(null);
      
      p = new Panel();              
	   p.setBounds(90, 90, 400, 400); // set bounds of panel
      
      cp.add(p);
      
   }
   
   public static void main(String[] args) // main method
   {
	Display run = new Display();  
	run.setVisible(true);          // Make JFrame visible
   }

}