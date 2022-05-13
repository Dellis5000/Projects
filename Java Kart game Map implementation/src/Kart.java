import java.awt.*;
import java.awt.event.*;
import java.io.Serializable;
import javax.swing.*;

class Kart implements Serializable  
{
   private String color; //Kart variable declaration
   private int speed, direction, locationX, locationY;
   protected ImageIcon kartImages[];
   
   //Kart constructor called on creation of new kart object
   public Kart(String colorInput, int startSpeed, int startDirection, int startLocationX, int startLocationY)
   {
      this.color = colorInput;
      this.speed = startSpeed;
      this.direction = startDirection;
      this.locationX = startLocationX;
      this.locationY = startLocationY; 
      this.kartImages = populateImages();  
   } 
   
   // Getters and setters for kart variables utilised 
   public int getSpeed()
   {
      return speed;
   }
   
   public void setSpeed(int newSpeed)
   {
      this.speed = newSpeed;
   }
   
   public int getDirection()
   {
      return direction;
   }
   
   public void setDirection(int newDirection)
   {
      this.direction = newDirection;
   }
   
   public int getLocationX()
   {
      return locationX;
   }
   
   public void setLocationX(int newLocationX)
   {
      this.locationX = newLocationX;
   }
   
   public int getLocationY()
   {
      return locationY;
   }
   
   public void setLocationY(int newLocationY)
   {
      this.locationY = newLocationY;
   }  
   //Method to draw kart at current location and direction
   public void paintKart(Graphics g) 
   {  
      kartImages[this.direction].paintIcon(null, g, this.locationX, this.locationY );     
   }

   
   //Method to poplate Image Array 
   public ImageIcon[] populateImages()
   {
      kartImages = new ImageIcon[16];   
      for (int i = 0; i < kartImages.length; i++)
      {  
         kartImages[i] = new ImageIcon(getClass().getResource( "kartimages\\" + this.color + "Kart" + (i) + ".png"));
      } 
      return kartImages;
   }
   
   //Method used to determine kart movement 
   //Calls a movement method based on kart direction
   public void determineMovement()
   {      
      if(this.getDirection() == 0)
      {
         movement0();
      }      
      if(this.getDirection() == 1)
      {
         movement1();
      }      
      if(this.getDirection() == 2)
      {         
         movement2();
      }
      
      if(this.getDirection() == 3)
      {
         movement3();
      }      
      if(this.getDirection() == 4)
      {         
         movement4();
      }
      if(this.getDirection() == 5)
      {
         movement5();
      }      
      if(this.getDirection() == 6)
      {
         movement6();
      }      
      if(this.getDirection() == 7)
      {         
         movement7();
      }      
      if(this.getDirection() == 8)
      {
         movement8();
      }
      if(this.getDirection() == 9)
      {
         movement9();
      }      
      if(this.getDirection() == 10)
      {
         movement10();
      }      
      if(this.getDirection() == 11)
      {         
         movement11();
      }      
      if(this.getDirection() == 12)
      {
         movement12();       
      }
      if(this.getDirection() == 13)
      {         
         movement13();
      }      
      if(this.getDirection() == 14)
      {         
         movement14();
      }     
      if(this.getDirection() == 15)
      {
         movement15();
      }      
   }
   
   //Methods to calculate movement of a kart based upon direction and speed
   public void movement0(){
      this.locationY = this.locationY - this.speed;
   }
   public void movement1(){
      this.locationY = this.locationY - ((this.speed / 10) * 8);
      this.locationX = this.locationX + ((this.speed / 10) * 2);
   }
   public void movement2(){
      this.locationY = this.locationY - (this.speed / 2);
      this.locationX = this.locationX + (this.speed / 2);
   }
   public void movement3(){
      this.locationY = this.locationY - ((this.speed / 10) * 2);
      this.locationX = this.locationX + ((this.speed / 10) * 8);
   }
   public void movement4(){
      this.locationX = this.locationX + this.speed;
   }
   public void movement5(){
      this.locationY = this.locationY + ((this.speed / 10) * 2);
      this.locationX = this.locationX + ((this.speed / 10) * 8);
   }
   public void movement6(){
      this.locationY = this.locationY + (this.speed / 2);
      this.locationX = this.locationX + (this.speed / 2);
   }
   public void movement7(){
      this.locationY = this.locationY + ((this.speed / 10) * 8);
      this.locationX = this.locationX + ((this.speed / 10) * 2);

   }
   public void movement8(){
      this.locationY = this.locationY + this.speed;
   }
   public void movement9(){
      this.locationY = this.locationY + ((this.speed / 10) * 8);
      this.locationX = this.locationX - ((this.speed / 10) * 2);
   }
   public void movement10(){
      this.locationY = this.locationY + (this.speed / 2);
      this.locationX = this.locationX - (this.speed / 2);
   }
   public void movement11(){
      this.locationY = this.locationY + ((this.speed / 10) * 2);
      this.locationX = this.locationX - ((this.speed / 10) * 8);
   }
   public void movement12(){
      this.locationX = this.locationX - this.speed;
   }
   public void movement13(){
      this.locationY = this.locationY - ((this.speed / 10) * 2);
      this.locationX = this.locationX - ((this.speed / 10) * 8);
   }
   public void movement14(){
      this.locationY = this.locationY - (this.speed / 2);
      this.locationX = this.locationX - (this.speed / 2);
   }
   public void movement15(){
      this.locationY = this.locationY - ((this.speed / 10) * 8);
      this.locationX = this.locationX - ((this.speed / 10) * 2);
   }
   //Movement methods for kart turning change direction of kart by 1 
   public void turnLeft()
   {
         this.direction = this.direction - 1;
         if (this.direction < 0)
         {
            this.direction = 15;
         }
   }
   public void turnRight()
   {
         this.direction = this.direction + 1;
         if (this.direction > 15)
         {
            this.direction = 0;
         }
   }
   //Methods to increase and decrease kart speed
   public void increaseSpeed()
   {
      if (this.speed > 0 && this.speed <= 100)
      {
         this.speed = this.speed - 10;
      }
      else
      {}      
   } 
   public void DecreaseSpeed()
   {
      if (this.speed > 0 && this.speed <= 100)
      {
         this.speed = this.speed + 10;
      }
      else
      {}      
   }  
 

}