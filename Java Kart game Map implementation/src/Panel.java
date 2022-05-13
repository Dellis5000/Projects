import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.net.*;

public class Panel extends JPanel implements ActionListener, KeyListener
{    
   //Creation of track and karts  
   private Kart redKart = new Kart("Red", 0, 12, 425, 550);
   private Kart blueKart = new Kart("Blue",0, 12, 425, 500);      
   private Track track = new Track(); 
   private CollisionDetection coll = new CollisionDetection();
   
   public Panel()
   {     
      addKeyListener(this);
                                  
      Timer timer = new Timer(100, this); //Timer utilised to update display
      timer.start();     
      
   }
   public void addNotify()
   {
        super.addNotify();
        requestFocus();
   }
   //Paint method
   public void paintComponent(Graphics g)
   {
      super.paintComponent( g );
      //calls for painting of track and both karts at current locations
      track.paintTrack(g);                   
      redKart.paintKart(g);
      blueKart.paintKart(g);             
      
   }   
   //called on timer iteration   
   public void actionPerformed(ActionEvent e)
   {  
      redKart.determineMovement(); //Calls method in kart to determine new kart location
      blueKart.determineMovement();
      
      //Would of calculated kart collisons with track/karts however unimplemented
      coll.carTrackCollision(redKart.getLocationX(), redKart.getLocationY());
      
      repaint(); //repaint screen   
   }
   //Method for keypresses
   public void keyPressed(KeyEvent e)
   {
      int key = e.getKeyCode();
      
      //blue kart buttons Up down left and right keys
      if (key == KeyEvent.VK_LEFT){
         blueKart.setDirection(blueKart.getDirection() - 1); // sets a new direction through method in kart class
         if (blueKart.getDirection() < 0) //Checks we havent reached end of image array
         {
            blueKart.setDirection(15);
         }
      }      
      if (key == KeyEvent.VK_RIGHT){
          blueKart.setDirection(blueKart.getDirection() + 1);
          if (blueKart.getDirection() > 15)
          {
             blueKart.setDirection(0);
          }
      }      
      if (key == KeyEvent.VK_DOWN){
         if (blueKart.getSpeed() > 0 && blueKart.getSpeed() <= 100)
         {
            blueKart.setSpeed(blueKart.getSpeed() - 10);
         }
         else
         {}      
      }      
      if (key == KeyEvent.VK_UP){
         if (blueKart.getSpeed() >= 0 && blueKart.getSpeed() < 100)
         {
            blueKart.setSpeed(blueKart.getSpeed() + 10);
         }
         else
         {}

      } 
      //red kart buttons AWSD     
      if (key == KeyEvent.VK_A){
         redKart.setDirection(redKart.getDirection() - 1);
         if (redKart.getDirection() < 0)
         {
            redKart.setDirection(15);
         }

      }      
      if (key == KeyEvent.VK_D){
         redKart.setDirection(redKart.getDirection() + 1);
         if (redKart.getDirection() > 15)
         {
            redKart.setDirection(0);
         }

      }   
         
      if (key == KeyEvent.VK_S){
         if (redKart.getSpeed() > 0 && redKart.getSpeed() <= 100)
         {
            redKart.setSpeed(redKart.getSpeed() - 10);
         }
         else
         {}
      }      
      if (key == KeyEvent.VK_W){
         if (redKart.getSpeed() >= 0 && redKart.getSpeed() < 100)
         {
            redKart.setSpeed(redKart.getSpeed() + 10);
         }
         else
         {}      
      }         
   }  
   public void keyReleased(KeyEvent e)
   {
   }
   public void keyTyped(KeyEvent e) 
   {
   }   
  
}