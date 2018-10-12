using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Branch 
{


    Texture2D texture;

    System.Random rng = new System.Random();

    public List<Vector2Int> branchCore = new List<Vector2Int>();

    public int currentX;
    public int currentY;
    //public int currentHeight = 1;

    public int startingThickness = 2;
    public int currentThickness = 2;
    public int TESTthickness = 0;

    public int[] directions = new int[9];
    public int total = 0;

    Color colour = Color.black;

    //test things

    int energy = 0;
    

    void Start()
    {
        Debug.Log("a branch is born");



    }




    public void Grow()
    {
        if (energy > 0)
        {
            int chosenDirection = rng.Next(total);



            int n = 0;

            for (int i = 0; i < directions.Length; i++)
            {
                n += directions[i];
                //Debug.Log("n is " + n + "chosen direction is " + chosenDirection);

                if (chosenDirection < n)
                {
                    switch (i)
                    {
                        case 0:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX -= 1;
                            currentY += 1;
                            GrowCore();
                            energy -= 1;
                            return;

                        case 1:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX -= 0;
                            currentY += 1;
                            GrowCore();
                           
                            energy -= 1;
                            return;

                        case 2:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX += 1;
                            currentY += 1;
                            GrowCore();
                            
                            energy -= 1;
                            return;

                        case 3:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX -= 1;
                            currentY += 0;
                            GrowCore();
                            texture.Apply();
                            energy -= 1;
                            return;

                        case 4:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX -= 0;
                            currentY += 0;
                            GrowCore();
                            texture.Apply();
                            energy -= 1;
                            return;

                        case 5:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX += 1;
                            currentY += 0;
                            GrowCore();
                           
                            energy -= 1;
                            return;

                        case 6:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX -= 1;
                            currentY -= 1;
                            GrowCore();
                          
                            energy -= 1;
                            return;

                        case 7:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX -= 0;
                            currentY -= 1;
                            GrowCore();
                            
                            energy -= 1;
                            return;

                        case 8:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX += 1;
                            currentY -= 1;
                            GrowCore();
                            
                            energy -= 1;
                            return;
                    }

       

                }

            }
        }


    }

    void GrowCore()
    {
        texture.SetPixel(currentX, currentY, colour);
        branchCore.Add(new Vector2Int(currentX, currentY));
        texture.Apply();
       
    }

    public void GrowOut()
    {
        

            for (int i = 0; i < branchCore.Count; i++)
            {
                if ((branchCore.Count / ((branchCore.Count / 100) * i + 1)) < currentThickness)
                {
                TESTthickness = (branchCore.Count / ((branchCore.Count / 100) * i + 1));
                    currentThickness--;
                }

                if (currentThickness > 1)
                {
                    FillOut(branchCore[i].x, branchCore[i].y, startingThickness - (branchCore.Count / (i+1)), colour);
                }
            
            }

        
    }

    void Wait()
    {
        for (int i = 0; i < 10000000; i++)
        {

        }
    }

    public void FillOut(int x, int y, int size, Color col)
    {
        if (size <= 1)
        {
            return;
        }
        if (size <= 2)
        {
            texture.SetPixel(x, y, colour);
            texture.SetPixel(x, y+1, colour);
            texture.SetPixel(x+1, y+1, colour);
            texture.SetPixel(x+1, y, colour);
            texture.Apply();
        }
        if (size <= 3)
        {
            texture.SetPixel(x, y, colour);
            texture.SetPixel(x, y + 1, colour);
            texture.SetPixel(x + 1, y + 1, colour);
            texture.SetPixel(x + 1, y, colour);
            texture.SetPixel(x + 1, y-1, colour);
            texture.SetPixel(x , y-1, colour);
            texture.SetPixel(x - 1, y-1, colour);
            texture.SetPixel(x - 1, y, colour);
            texture.SetPixel(x - 1, y+1, colour);
            texture.Apply();
        }
        if (size <= 4)
        {
            texture.SetPixel(x, y, colour);
            texture.SetPixel(x, y + 1, colour);
            texture.SetPixel(x + 1, y + 1, colour);
            texture.SetPixel(x + 1, y, colour);
         
            texture.SetPixel(x , y + 2, colour);
            texture.SetPixel(x + 1, y +2, colour);
            texture.SetPixel(x + 2, y + 1, colour);
            texture.SetPixel(x + 2, y, colour);
            texture.SetPixel(x + 1, y -1, colour);
            texture.SetPixel(x , y - 1, colour);
            texture.SetPixel(x-1, y, colour);
            texture.SetPixel(x -1, y + 1, colour);



            texture.Apply();
        }


    }

    int SumArray(int[] arr)
    {

        int total = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            total += arr[i];
        }

        return total;
    }



    public Branch(Texture2D drawSurface, Color c, int x, int y, int topLeft, int topMiddle, int topRight, int middleLeft, int middleMiddle, int middleRight, int bottomLeft, int bottomMiddle, int bottomRight, int initialenergy, int currentEnergy)
    {

        texture = drawSurface;
        this.colour = c;
        currentX = x;
        currentY = y;
        directions[0] = topLeft;
        directions[1] = topMiddle;
        directions[2] = topRight;
        directions[3] = middleLeft;
        directions[4] = middleMiddle;
        directions[5] = middleRight;
        directions[6] = bottomLeft;
        directions[7] = bottomMiddle;
        directions[8] = bottomRight;
        energy = initialenergy;


        total = SumArray(directions);

        Start();

    }

}
