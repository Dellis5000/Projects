import java.awt.*;

public class CollisionDetection
{   
   //Constructor
   public CollisionDetection()
   {
            
   }
   //Method to detect collisions
   //Implementation was planned for implementation however ran out of time
   public void carTrackCollision(int x, int y)
   {
      Rectangle car = new Rectangle(x, y, 50,50);
      Rectangle innerTrack = new Rectangle(150, 200, 550, 300);
      
      if (car.intersects(innerTrack))
      {
         
      }
   
   }
   
}