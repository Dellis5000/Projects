import javax.swing.*;
import java.awt.*;

public class Display extends JFrame
{
   private Panel p;
   
   public Display()
   {
      setTitle("Racing Track"); //Title of frame
      setBounds(100,100,1000,900); //set bounds of the Jframe
      setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
      
      Container cp = getContentPane();          
	   cp.setLayout(null);
      
      p = new Panel();              
	   p.setBounds(90, 90, 850, 650);
      
      cp.add(p);
   }
   
   public static void main(String[] args) // main method
   {
	Display run = new Display();  
	run.setVisible(true);          // Make JFrame visible
   }

   
}
