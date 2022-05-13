import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.net.*;

public class Panel extends JPanel implements ActionListener
{   
   private Kart redKart = new Kart("Red", 0, 50, 50); //Creation of red kart object
   private Kart blueKart = new Kart("Blue", 0, 50, 100);//Creation of blue kart object

   public Panel()
   {           
      Timer timer = new Timer(100, this); //Timer called to prompt the repaint
      timer.start(); //Start timer      
         
   }
   
   public void actionPerformed(ActionEvent e) {
   
      repaint(); //Repaint panel with updated images
   
   }
   
   public void paintComponent(Graphics g)
   {
     super.paintComponent( g );
           
     redKart.paintKart(g); //Call paint kart method from kart class
     blueKart.paintKart(g); 
   }
   
}
