using Grafpack;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;


namespace GrafPack
{
    public partial class GrafPack : Form
    {
        private List<Shape> listOfShapes = new List<Shape>(); //Definition of List used to store all shapes

        //Definition of various bools to define which action is being performed
        private bool selectCircleStatus = false;
        private bool selectSquareStatus = false;
        private bool selectTriangleStatus = false;
        private bool selectRectStatus = false;
        private bool selectShapeStatus = false;
        private bool selectShapeUsingMouse = false;
        private bool moveUsingMouseID = false;
        private bool isShapeSelected = false;
        
        //Definition of variables used for storage in various methods
        private int clicknumber = 0;
        private int selectedShape = 0;
        private Point one, two, three, clickedPoint;
        private int lowestDistance;
        


        public GrafPack()
        {            
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
            this.KeyPreview = true;

            // The following approach uses menu items coupled with mouse clicks
            //All menu items added for various functions implemented
            MainMenu mainMenu = new MainMenu();
            MenuItem createShape = new MenuItem();
            MenuItem selectShape = new MenuItem();
            MenuItem usingKeyboard = new MenuItem();
            MenuItem usingMouse = new MenuItem();
            MenuItem moveShape = new MenuItem();
            MenuItem moveUsingKey = new MenuItem();
            MenuItem moveUsingMouse = new MenuItem();
            MenuItem transformShape = new MenuItem();
            MenuItem deleteShape = new MenuItem();
            MenuItem exit = new MenuItem();
            MenuItem squareShape = new MenuItem();
            MenuItem triangleShape = new MenuItem();
            MenuItem circleShape = new MenuItem();
            MenuItem rectShape = new MenuItem();
            MenuItem scale = new MenuItem();
            MenuItem rotate = new MenuItem();

            //Definition of text displayed to user for all menu options
            createShape.Text = "&Create";
            squareShape.Text = "&Square";
            triangleShape.Text = "&Triangle";
            circleShape.Text = "&Circle";
            rectShape.Text = "&Rectangle";
            selectShape.Text = "&Select";
            moveShape.Text = "&Move Shape";
            moveUsingKey.Text = "&Move using keyboard input";
            moveUsingMouse.Text = "&Move using Mouse input";
            usingKeyboard.Text = "&Select using Keyboard";
            usingMouse.Text = "&Select using Mouse";
            transformShape.Text = "&Transform";
            scale.Text = "&Scale";
            rotate.Text = "&Rotate";
            deleteShape.Text = "&Delete";
            exit.Text = "&exit";

            //Addition of various menu items to form
            mainMenu.MenuItems.Add(createShape);
            createShape.MenuItems.Add(squareShape);
            createShape.MenuItems.Add(triangleShape);
            createShape.MenuItems.Add(circleShape);
            createShape.MenuItems.Add(rectShape);
            mainMenu.MenuItems.Add(selectShape);
            selectShape.MenuItems.Add(usingKeyboard);
            selectShape.MenuItems.Add(usingMouse);
            mainMenu.MenuItems.Add(moveShape);
            moveShape.MenuItems.Add(moveUsingKey);
            moveShape.MenuItems.Add(moveUsingMouse);
            mainMenu.MenuItems.Add(transformShape);
            transformShape.MenuItems.Add(scale);
            transformShape.MenuItems.Add(rotate);
            mainMenu.MenuItems.Add(deleteShape);
            mainMenu.MenuItems.Add(exit);
            
            //Click events added to active methods upon menu items being clicked
            exit.Click += new System.EventHandler(this.SelectExit);
            deleteShape.Click += new System.EventHandler(this.DeleteShape);
            squareShape.Click += new System.EventHandler(this.SelectSquare);
            triangleShape.Click += new System.EventHandler(this.SelectTriangle);
            rectShape.Click += new System.EventHandler(this.SelectRect);
            circleShape.Click += new System.EventHandler(this.SelectCircle);
            moveUsingKey.Click += new System.EventHandler(this.MoveUsingKeyboard);
            moveUsingMouse.Click += new System.EventHandler(this.MoveUsingMouse);
            scale.Click += new System.EventHandler(this.ScaleShapes);
            rotate.Click += new System.EventHandler(this.RotateShape);
            usingKeyboard.Click += new System.EventHandler(this.SelectShapeKey);
            usingMouse.Click += new System.EventHandler(this.SelectShapeMouse);


            this.Menu = mainMenu;
            this.MouseClick += MousePointClick; //Mouse click events stored
            this.KeyDown += KeyboardPressed; // Key events stored

        }

        //Method for exitig the program
        private void SelectExit(object sender, EventArgs e)
        {
            MessageBox.Show("Closing Application now"); // Displays to user
            Application.Exit();// Terminates the program

        }
        // Generally, all methods of the form are usually private
        private void SelectSquare(object sender, EventArgs e)
        {
            selectSquareStatus = true; //Bool set to true for activation of another method
            MessageBox.Show("Click OK and then click once each at two locations to create a square");
        }

        //Method for triangle selected in menu
        private void SelectTriangle(object sender, EventArgs e)
        {
            selectTriangleStatus = true; //Bool set to true for activation of another method
            MessageBox.Show("Click OK and then click once each at three locations to draw a triangle");
        }

        //Method for Circle selected in menu
        private void SelectCircle(object sender, EventArgs e)
        {
            selectCircleStatus = true; //Bool set to true for activation of another method
            MessageBox.Show("Click OK and then click two locations to set the diameter of the circle");
        }
        private void SelectRect(object sender, EventArgs e)
        {
            selectRectStatus = true;
            MessageBox.Show("Click OK and then click two locations to set the 2 corners of the rectangle");
        }

        //Method for select shape using keyboard being clicked
        private void SelectShapeKey(object sender, EventArgs e)
        {
            selectShapeStatus = true;
            if (listOfShapes.Count == 0) // Checks if any shapes are currently stored in the List
            {
                MessageBox.Show("No shapes currently stored.");
            }
            else
            {
                MessageBox.Show("You selected the Select option selected shapes will be highlighted with a red outline"); //Displays to user
                MessageBox.Show("Use the arrow keys to navigate shapes and enter when desired shape is selected");
            }
        }

        //Method for selecting a shape using mouse
        private void SelectShapeMouse(object sender, EventArgs e)
        {
            selectShapeStatus = true;
            if (listOfShapes.Count == 0) // Check if the list currently contains any shapes
            {
                MessageBox.Show("No shapes currently stored.");
            }
            else
            {
                MessageBox.Show("Please click on the middle of the shape you wish to select.");
                selectShapeUsingMouse = true; //Bool set to true for activtion of other code
            }
        }

        // This method is quite important and detects all mouse clicks - other methods may need
        // to be implemented to detect other kinds of event handling eg keyboard presses.
        private void MousePointClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int xDistance;
                int yDistance;
                // 'if' statements can distinguish different selected menu operations to implement.
                // There may be other (better, more efficient) approaches to event handling,
                // but this approach works.
                if (selectShapeUsingMouse == true)
                {
                    lowestDistance = 9999999; //set to a high value so we can obtain the closest object             
                    clickedPoint = new Point(e.X, e.Y); //Obtain the point clicked by user

                    for (int i = 0; i < listOfShapes.Count; i++) //Loop through all stored shapes
                    {
                        
                        Point currentShapeMid = listOfShapes[i].GetMid(); //Returns midpoint of current shape being examined
                        xDistance = Math.Abs(clickedPoint.X - currentShapeMid.X); // calculation of difference in X distance
                        yDistance = Math.Abs(clickedPoint.Y - currentShapeMid.Y);//Calculation of difference in Y distance
                        
                        if (xDistance < lowestDistance || yDistance < lowestDistance) // Check if either distance is lower than currently stored lowest
                        {
                            lowestDistance = xDistance;
                            if(yDistance < xDistance)
                            {
                                lowestDistance = yDistance;
                            }
                            selectedShape = i; // If distance is lowest we know this was the shape the user wanted to select
                        }                   

                    }
                    selectShapeUsingMouse = false; //Reset bool to false so as to not retrigger the method
                    isShapeSelected = true; // set to true to show that the user has selected a shape
                    RedrawShapes(); // Redraw shapes will show selected in red outline
                }
                else if (moveUsingMouseID == true)
                {
                    clickedPoint = new Point(e.X, e.Y); //Stores the point the user clicked
                    Point currentShapeMid = listOfShapes[selectedShape].GetMid();//Returns mid point of currently selected shape
                    xDistance = clickedPoint.X - currentShapeMid.X;
                    yDistance = clickedPoint.Y - currentShapeMid.Y;
                    listOfShapes[selectedShape].Move(xDistance, yDistance); //Activates the method stored to move a shape by the distance from current mid point to the clicked point
                    this.Refresh();//Refreshes the form
                    RedrawShapes();//Redraws all shapes so the selected shape is moved to its new position
                    moveUsingMouseID = false; //Set to false so code does not reactivate
                }
                else if (selectSquareStatus == true) // Activates if user is drawing a new square
                {
                    if (clicknumber == 0) //click number used for storing points of square
                    {
                        one = new Point(e.X, e.Y); 
                        clicknumber = 1; //Increase click to activate else statement
                    }
                    else
                    {
                        two = new Point(e.X, e.Y);
                        NewSquare(one, two); // Creation of new square with user input points
                    }
                }

                else if (selectTriangleStatus == true) // creation of new triangle
                {
                    if (clicknumber == 0)
                    {
                        one = new Point(e.X, e.Y);
                        clicknumber++;
                    }
                    else if (clicknumber == 1)
                    {
                        two = new Point(e.X, e.Y);
                        clicknumber++;
                    }
                    else
                    {
                        three = new Point(e.X, e.Y);
                        NewTriangle(one, two, three); //Creates new triangle with 3 user defined points
                    }
                }
                else if (selectCircleStatus == true)//Creation of new circle
                {
                    if (clicknumber == 0)
                    {
                        one = new Point(e.X, e.Y);
                        clicknumber = 1;
                    }
                    else
                    {
                        two = new Point(e.X, e.Y);
                        NewCircle(one, two); //Create the new circle with user defined points
                    }
                }
                else if (selectRectStatus == true)//Creation of new Rectangle
                {
                    if (clicknumber == 0)
                    {
                        one = new Point(e.X, e.Y);
                        clicknumber = 1;
                    }
                    else
                    {
                        two = new Point(e.X, e.Y);
                        NewRectangle(one, two); //Create the new Rectangle with user defined points
                    }
                }
            }
        }

        //Method for new square
        private void NewSquare(Point pt1, Point pt2)
        {
            clicknumber = 0; //Reset click numbers for later use
            selectSquareStatus = false; // reset the bool

            Graphics g = this.CreateGraphics(); //creation of graphics object
            Pen blackpen = new Pen(Color.Black); // Creation of pen for drawing

            Square aShape = new Square(pt1, pt2); //Creation of square object
            aShape.Draw(g, blackpen);//Draw the shape using draw method in the shapes class
            listOfShapes.Add(aShape);//Addition of Square to the shapes list
        }

        //Method for new triangle utilises similar code to square
        private void NewTriangle(Point pt1, Point pt2, Point pt3)
        {
            clicknumber = 0;
            selectTriangleStatus = false;

            Graphics g = this.CreateGraphics();
            Pen blackpen = new Pen(Color.Black);

            Triangle aShape = new Triangle(pt1, pt2, pt3);
            aShape.Draw(g, blackpen);
            listOfShapes.Add(aShape);
        }

        //Method for new circle Utilises similar code to circle
        private void NewCircle(Point pt1, Point pt2)
        {
            clicknumber = 0;
            selectCircleStatus = false;

            Graphics g = this.CreateGraphics();
            Pen blackPen = new Pen(Color.Black);

            Circle aShape = new Circle(pt1, pt2);
            aShape.Draw(g, blackPen);
            listOfShapes.Add(aShape);
        }

        //Method for a new rectangle
        private void NewRectangle(Point pt1, Point pt2)
        {
            clicknumber = 0;
            selectRectStatus = false;

            Graphics g = this.CreateGraphics();
            Pen blackPen = new Pen(Color.Black);

            Grafpack.Rectangle aShape = new Grafpack.Rectangle(pt1, pt2);
            aShape.Draw(g, blackPen);
            listOfShapes.Add(aShape);
        }

        //Method for shape movement using keyboard
        private void MoveUsingKeyboard(object sender, EventArgs e)
        {
            float check = 999999999;
            if (isShapeSelected == false) //Check a shape has been selected
            {
                MessageBox.Show("No shape currently selected");
            }
            else if (listOfShapes.Count == 0) //CHeck if list of shapes is empty
            {
                MessageBox.Show("No shapes currently stored.");
            }
            else
            {
                MessageBox.Show("You are now going to move the currently selected shape using keyboard input movement values.");
                float movementx = GetUserInput("movement value for X between ", -500, 500);//Takes a user input for X movement
                float movementy = GetUserInput("movement value for Y between ", -500, 500);//Takes a user input for Y movement
                if (movementx == check || movementy == check)
                {
                }
                else
                {
                    listOfShapes[selectedShape].Move(movementx, movementy); // Activates move method uniquely in each shapes class
                    this.Refresh();
                    RedrawShapes();
                }
            }
        }
        
        //Method for movement using mouse
        private void MoveUsingMouse(object sender, EventArgs e)
        {
            if (isShapeSelected == false) //Check a shape has been selected
            {
                MessageBox.Show("No shape currently selected");
            }
            else if (listOfShapes.Count == 0) //CHeck if list of shapes is empty
            {
                MessageBox.Show("No shapes currently stored.");
            }
            else
            {
                MessageBox.Show("You are now going to move the currently selected shape using Mouse input.");
                MessageBox.Show("Please click where you would like to move the currently selected shape to");
                moveUsingMouseID = true;
            }
        }

        //Method to detect keypresses
        private void KeyboardPressed(object sender, KeyEventArgs e)
        {   
            
            if (selectShapeStatus == true)
            {
                
                if (e.KeyCode == Keys.Left)//Activates if key pressed is left
                {                    
                    selectedShape -= 1; //Moves through the list of shapes selectedShape ultimately stores a selected shapes location in the list
                    
                    if (selectedShape <= -1) //Checks if we reached the start of the list
                    {
                        selectedShape = listOfShapes.Count - 1;
                    }
                }
                else if (e.KeyCode == Keys.Right)
                {
                    selectedShape += 1;
                    
                    if (selectedShape == listOfShapes.Count)//Check if we reached end of list
                    {
                        selectedShape = 0;
                    }
                }
                else if (e.KeyCode == Keys.Enter) //Finishes the method when user hits enter key
                {
                    selectShapeStatus = false; //reset bool
                    isShapeSelected = true;//Set the bool to identify if a shape has been selected
                }
            }
            RedrawShapes(); //Redraw so currently selected shape is shown to user in red
        }

        //Method to redraw all currently stored shapes
        public void RedrawShapes()
        {
            Graphics g = this.CreateGraphics(); 
            Pen blackPen = new Pen(Color.Black);
            Pen redPen = new Pen(Color.Red); //Red pen used to identify selected shape

            for (int i = 0; i < listOfShapes.Count; i ++) // Loop through all shapes
            {
                if(i == selectedShape) //Check if the current shape is the selected shape
                {
                    listOfShapes[i].Draw(g, redPen); //Activate draw method with red pen to highlight selected shape
                }
                else
                {
                    listOfShapes[i].Draw(g, blackPen); //Activate draw method
                }
            }
        }

        //Method for scaling of shapes
        private void ScaleShapes(object sender, EventArgs e)
        {
            if(isShapeSelected == false) //Check a shape has been selected
            {
                MessageBox.Show("No shape currently selected");
            }            
            else
            {
                float scalerInput = GetUserInput("Scaler value between ", 0, 10); //Takes user input using user input form with defined variables on creation 
                
                if (scalerInput == 999999999) // used when a user cancels a scaling
                {
                    return;
                }
                else
                {
                    listOfShapes[selectedShape].Scale(scalerInput);
                   
                    this.Refresh();
                    RedrawShapes();
                }
            }
        }

        private void DeleteShape(object sender, EventArgs e)
        {
            if (isShapeSelected == false) //Check a shape has been selected
            {
                MessageBox.Show("No shape currently selected");
            }
            
            //Displays a message to user to confirm shape deletion
            else if (MessageBox.Show("You are about to delete the currently selected shape", "Please Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listOfShapes.Remove(listOfShapes[selectedShape]); //Deletion of the currently selected shape
                
                this.Refresh();//Refresh the screen to remove deleted shape
            }
            else
            {
                return;
            }
            RedrawShapes(); //Redraw shape method called
        }

        //Method for getting user input takes input for form definitions
        public float GetUserInput(string inputType, int lower, int upper)
        {
            float input;          
              
            
             UserInput userInput = new UserInput(inputType, lower, upper); //Creation of a user input form

             userInput.ShowDialog(); //Brings user input form to the front and stops actions on main form
             input = userInput.GetInput(); // Take the users input from user input form 
             userInput.Close(); // Close deletes the form and removes all resources used by it
             return input;  //Returns the users input from the form
            

        }

        //Method for the rotation of a shape
        private void RotateShape(object sender, EventArgs e)
        {
            if (isShapeSelected == false) //Check a shape has been selected
            {
                MessageBox.Show("No shape currently selected");
            }

            else if (listOfShapes[selectedShape].GetType() == "Circle") //check if shape is a circle as no point rotating a circle
            {
                MessageBox.Show("Cannot rotate a circle");
            }

            else
            {
                float rotateInput = GetUserInput("Rotation angle between ", 0, 360); //Definitions for user input form for rotation

               
                if (rotateInput == 999999999) // Used in the event of cancel clicked on form
                {
                    return;
                }
                else
                {
                    listOfShapes[selectedShape].Rotate(rotateInput); //Calls the rotation method on the selected shape

                    this.Refresh(); //Refresh screen and redraw all shapes to display the rotation
                    RedrawShapes();
                }
            }
        }



        public static void Main()
        {
            Application.Run(new GrafPack()); //Runs the application
        }
    }

}


