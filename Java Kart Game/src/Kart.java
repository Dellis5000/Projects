import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class Kart    
{
   private String color; //variables declared for each kart object
   private int direction, locationX, locationY;
   protected ImageIcon kartImages[]; //Imageicons used to store images of karts
   
   //Kart constructor declares variables input on creation
   public Kart(String colorInput, int directionInput,int startLocationX, int startLocationY)
   {
      this.color = colorInput;
      this.direction = directionInput;
      this.locationX = startLocationX;
      this.locationY = startLocationY;
      this.kartImages = populateImages();
   }
   //Method to paint kart
   public void paintKart(Graphics g) 
   {  
      if(direction >= 15)
      {
         this.direction = 0; //sets direction back to first image if end of array hit
      }
      else
      {      
         this.direction = this.direction + 1; //ensures we use full array of images
      }      
      //paint icon at karts current ditection

      kartImages[this.direction].paintIcon(null, g, this.locationX, this.locationY ); //paint icon at karts current ditection
            
   }
   //method called from constructor populates the array of kart images
   public ImageIcon[] populateImages()
   {
      kartImages = new ImageIcon[16]; // array size declaration   
      for (int i = 0; i < kartImages.length; i++) //Loop through entire array
      {  
         //Through the use of loop changes which image is added to the array each iteration
         kartImages[i] = new ImageIcon(getClass().getResource( "kartimages\\" + this.color + "Kart" + (i) + ".png"));
      } 
      return kartImages; //return the array
   }
   
}