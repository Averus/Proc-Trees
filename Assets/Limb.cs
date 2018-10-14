﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Limb {

    public Tree parentTree;
    public Texture2D texture; //the texture to be drawn on
    public List<Vector3> points = new List<Vector3>(); //x and y for coordinates, Z for size

    System.Random rng = new System.Random();
    Color colour = Color.black;

    public int generation = 0; // roughly 0 = trunk, 1= bough, 2= big branch, 3= small branch

    public LimbData limbData = new LimbData();

    public int currentX; //furthest point in growth
    public int currentY;
    public int growingOutPoint = 0;
    int sumDirections = 0;





    public void Grow()
    {
        GrowInDirection(ChooseDirection(limbData.growthDirections));
    }

    public void GrowInDirection(int direction)
    {
        if (points.Count <= limbData.maxLength)
        {
            switch (direction)
            {
                case 0:
                    //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                    currentX -= 1;
                    currentY += 1;
                    AddPoint();
                    //energy -= 1;
                    return;

                case 1:
                    //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                    currentX -= 0;
                    currentY += 1;
                    AddPoint();

                    //energy -= 1;
                    return;

                case 2:
                    //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                    currentX += 1;
                    currentY += 1;
                    AddPoint();

                    // energy -= 1;
                    return;

                case 3:
                    //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);


                    currentX += 1;
                    currentY += 0;
                    AddPoint();


                    //energy -= 1;
                    return;

                case 4:
                    //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);


                    currentX += 1;
                    currentY -= 1;
                    AddPoint();


                    return;

                case 5:
                    //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);


                    currentX -= 0;
                    currentY -= 1;
                    AddPoint();


                    return;

                case 6:
                    //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                    currentX -= 1;
                    currentY -= 1;
                    AddPoint();


                    return;

                case 7:
                    //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                    currentX -= 1;
                    currentY += 0;
                    AddPoint();

                    return;

                case 8:
                    //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                    currentX -= 0;
                    currentY += 0;
                    AddPoint();
                    return;
            }

        }

        
    }

    public int ChooseDirection(Directions dir)
    {
        int chosenDirection = rng.Next(sumDirections);

        int n = 0;

        for (int i = 0; i < dir.directions.Length; i++)
        {
            n += dir.directions[i];

            if (chosenDirection < n)
            {
                switch (i)
                {
                    case 0: return i;
                    case 1: return i;
                    case 2: return i;
                    case 3: return i;
                    case 4: return i;
                    case 5: return i;
                    case 6: return i;
                    case 7: return i;
                    case 8: return i;


                }
               
            }

        }
        return 0;
    }

    public void ChooseDirection()
    {
        if (points.Count <= limbData.maxLength) //if growth has not yet finished
        {
            int chosenDirection = rng.Next(sumDirections);

            int n = 0;

            for (int i = 0; i < limbData.growthDirections.directions.Length; i++)
            {
                n += limbData.growthDirections.directions[i];


                if (chosenDirection < n)
                {
                    switch (i)
                    {
                        case 0:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX -= 1;
                            currentY += 1;
                            AddPoint();
                            //energy -= 1;
                            return;

                        case 1:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX -= 0;
                            currentY += 1;
                            AddPoint();

                            //energy -= 1;
                            return;

                        case 2:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX += 1;
                            currentY += 1;
                            AddPoint();

                            // energy -= 1;
                            return;

                        case 3:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                           

                            currentX += 1;
                            currentY += 0;
                            AddPoint();


                            //energy -= 1;
                            return;

                        case 4:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            

                            currentX += 1;
                            currentY -= 1;
                            AddPoint();


                            return;

                        case 5:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            

                            currentX -= 0;
                            currentY -= 1;
                            AddPoint();


                            return;

                        case 6:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX -= 1;
                            currentY -= 1;
                            AddPoint();


                            return;

                        case 7:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX -= 1;
                            currentY += 0;
                            AddPoint();

                            return;

                        case 8:
                            //Debug.Log(chosenDirection + " case " + i + ": " + currentX + " " + currentY);
                            currentX -= 0;
                            currentY += 0;
                            AddPoint();
                            return;
                    }



                }

            }

        }


            
        } //outdated

    public int[] shiftDirectionsLeft(int[] arr)
    {
        int[] copy = new int[arr.Length];

        System.Array.Copy(arr, 1, copy, 0, arr.Length - 2);
        copy[arr.Length - 2] = arr[0];

        copy[8] = arr[8];//the final element that contains the 'no direction' direction stays at the end.

        return copy;
    }

    public int[] shiftDirectionsRight(int[] arr)
    {
        int[] copy = new int[arr.Length];

        System.Array.Copy(arr, 0, copy, 1, arr.Length - 2);
        copy[0] = arr[arr.Length-2];

        copy[8] = arr[8];//the final element that contains the 'no direction' direction stays at the end.

        return copy;
    }

    public void Split()
    {
        Debug.Log("splitting " + limbData.splitDirections.Count);

        for (int i = 0; i < limbData.splitDirections.Count; i++)
        {
            Debug.Log("splitting2");
            for (int ii = 0; ii < limbData.splitDirections[i].directions.Length; ii++)
            {
                Debug.Log("splitting3");
                if (limbData.splitDirections[i].directions[ii] > 0)
                {
                    Debug.Log("splitting4");

                    int []rotatedDirections = limbData.growthDirections.directions; //the childs default direction is the same as the parent

                    int dir = ii;

                    switch (ii)
                    {
                        case 0:
                            //top left from parent direction...
                            rotatedDirections = shiftDirectionsLeft(rotatedDirections);
                            break;

                        case 1://up from parent direction (so continuing in parent direction - no change)...
                            break;

                        case 2://top right from parent direction...
                            rotatedDirections = shiftDirectionsRight(rotatedDirections);
                            break;

                        case 3:
                            rotatedDirections = shiftDirectionsRight(rotatedDirections);
                            rotatedDirections = shiftDirectionsRight(rotatedDirections);
                            break;

                        case 4:
                            rotatedDirections = shiftDirectionsRight(rotatedDirections);
                            rotatedDirections = shiftDirectionsRight(rotatedDirections);
                            rotatedDirections = shiftDirectionsRight(rotatedDirections);
                            break;

                        case 5:
                            rotatedDirections = shiftDirectionsRight(rotatedDirections);
                            rotatedDirections = shiftDirectionsRight(rotatedDirections);
                            rotatedDirections = shiftDirectionsRight(rotatedDirections);
                            rotatedDirections = shiftDirectionsRight(rotatedDirections);
                            break;

                        case 6:
                            rotatedDirections = shiftDirectionsLeft(rotatedDirections);
                            rotatedDirections = shiftDirectionsLeft(rotatedDirections);
                            rotatedDirections = shiftDirectionsLeft(rotatedDirections);
                            break;

                        case 7:
                            rotatedDirections = shiftDirectionsLeft(rotatedDirections);
                            rotatedDirections = shiftDirectionsLeft(rotatedDirections);
                            break;

                        case 8:
                            break;
                    }

                    //tell the Tree to grow the a limb of the child generation with the rotatedDirections
                    Directions newDirections = new Directions();
                    newDirections.directions = rotatedDirections;

                    parentTree.CreateLimb(currentX, currentY, limbData.splitGeneration, newDirections);
                }
            }
        }

        
    }

    public void SproutChild()
    {

        int[] rotatedDirections = limbData.growthDirections.directions; //the childs default direction is the same as the parent

        int direction = ChooseDirection(limbData.childSplitDirections); //the directions will get shifted locally, imagining that direcion 1 (up) is the current direction

        switch (direction)
        {
            case 0:
                //top left from parent direction...
                rotatedDirections = shiftDirectionsLeft(rotatedDirections);
                break;

            case 1://up from parent direction (so continuing in parent direction - no change)...
                break;

            case 2://top right from parent direction...
                rotatedDirections = shiftDirectionsRight(rotatedDirections);
                break;

            case 3:
                rotatedDirections = shiftDirectionsRight(rotatedDirections);
                rotatedDirections = shiftDirectionsRight(rotatedDirections);
                break;

            case 4:
                rotatedDirections = shiftDirectionsRight(rotatedDirections);
                rotatedDirections = shiftDirectionsRight(rotatedDirections);
                rotatedDirections = shiftDirectionsRight(rotatedDirections);
                break;

            case 5:
                rotatedDirections = shiftDirectionsRight(rotatedDirections);
                rotatedDirections = shiftDirectionsRight(rotatedDirections);
                rotatedDirections = shiftDirectionsRight(rotatedDirections);
                rotatedDirections = shiftDirectionsRight(rotatedDirections);
                break;

            case 6:
                rotatedDirections = shiftDirectionsLeft(rotatedDirections);
                rotatedDirections = shiftDirectionsLeft(rotatedDirections);
                rotatedDirections = shiftDirectionsLeft(rotatedDirections);
                break;

            case 7:
                rotatedDirections = shiftDirectionsLeft(rotatedDirections);
                rotatedDirections = shiftDirectionsLeft(rotatedDirections);
                break;

            case 8:
                break;
        }

        //tell the Tree to grow the a limb of the child generation with the rotatedDirections
        Directions newDirections = new Directions();
        newDirections.directions = rotatedDirections;

        parentTree.CreateLimb(currentX, currentY, limbData.childGeneration, newDirections);

        
    }

    /*
    public void Sprout(string direction)
    {
        if (limbData.minWidth > 1)
        {
            if (direction == "left")
            {


                int[] newDirections = limbData.directions;

                newDirections = shiftDirectionsLeft(newDirections);

                int newMinWidth = 1;

                if (limbData.minWidth >= 3)
                {
                    newMinWidth = (int)limbData.minWidth - 2;
                }

                parentTree.limbs.Add(new Limb(this.parentTree, ((int)(maxLength  /2)), (int)GetMaxWidth(), newMinWidth, 0.3f, newDirections, currentX, currentY, Color.black, texture));
                return;


            }

            if (direction == "right")
            {
                int[] newDirections = directions;

                newDirections = shiftDirectionsRight(newDirections);

                int newMinWidth = 1;

                if (minWidth >= 3)
                {
                    newMinWidth = (int)minWidth - 2;
                }

                parentTree.limbs.Add(new Limb(this.parentTree, ((int)(maxLength /2)), (int)GetMaxWidth(), newMinWidth, 0.3f, newDirections, currentX, currentY, Color.black, texture));
                return;
            }



        }
        }
        */

    void AddPoint()
    {
        int x = Mathf.RoundToInt(currentX);
        int y = Mathf.RoundToInt(currentY);

        texture.SetPixel(x,y, colour);
        points.Add(new Vector3(x,y,GetMaxWidth()));
        texture.Apply();

        //test stuff below
        
        if (points.Count == limbData.maxLength) //I redid this somewhere, sometimes the percentage calculation is not right (ending on 99.2 for example)...or does this fix that?
        {
            Split();
        }

        
        ChooseToSproutChild();
       

        //end test stuff

    }

    public void ChooseToSproutChild()
    {
        float percentage = ((points.Count / limbData.maxLength));

        if (percentage > limbData.minPercentageGrowthForChild && limbData.maxChildren > 0)
        {
            if (rng.Next(100) < (limbData.childProbability * 100))
            {
                SproutChild();
                limbData.maxChildren--;
            }
        }
    }


    /*
    public void ChooseToSplit()
    {
        

        for (int i = 0; i < limbData.maxSplits; i++)
        {
            int rand = rng.Next(100);
            Debug.Log(rand);

            if ( rand < (limbData.splitProbability * 100))
            {
             
                Split();
                
            }
        }
           
        
    }

    */

    float GetMaxWidth()
    {
        float result = 0;
        float percentage = 0;

        percentage = ((points.Count/ limbData.maxLength ) * 100);

        result = limbData.maxWidth * Mathf.Pow(percentage, 0- limbData.curveAggression);

        //flo = (int)(maxWidth * Mathf.Pow(((maxLength / 100) * points.Count),-curveAggresion));

        //Debug.Log(points.Count + " " + percentage + "%" + " " + result);

        if (result > limbData.maxWidth)
        {
            return limbData.maxWidth;
        }

        if (result < limbData.minWidth)
        {
            return limbData.minWidth;
        }

        return result;
        

        /*

        if (points.Count > ((maxLength/10) * 9))
        {
            return 1;
        }

        if (points.Count > ((maxLength / 10) * 7))
        {
            return 2;
        }

        if (points.Count > ((maxLength / 10) * 5))
        {
            return 3;
        }

        if (points.Count > (maxLength / 10) * 4 )
        {
            return 4;
        }

        if (points.Count > (maxLength / 10) * 3)
        {
            return 5;
        }

        if (points.Count > (maxLength / 10) * 2)
        {
            return 6;
        }

        if (points.Count <= (maxLength / 10) * 1)
        {
            return 7;
        }

        return 1;
        */
    }

    public void FillOut()
    { 

        if (growingOutPoint < points.Count)
        {

            int x = (int)points[growingOutPoint].x;
            int y = (int)points[growingOutPoint].y;
            float size = points[growingOutPoint].z;
       

            if (size <= 1)
            {
                growingOutPoint++;
                return;
            }

            if (size <= 2)
            {
                texture.SetPixel(x, y, colour);
                texture.SetPixel(x, y + 1, colour);
                texture.SetPixel(x + 1, y + 1, colour);
                texture.SetPixel(x + 1, y, colour);
                texture.Apply();
                growingOutPoint++;
                return;
            }
            if (size <= 3)
            {
                texture.SetPixel(x, y, colour);
                texture.SetPixel(x, y + 1, colour);
                texture.SetPixel(x + 1, y + 1, colour);
                texture.SetPixel(x + 1, y, colour);
                texture.SetPixel(x + 1, y - 1, colour);
                texture.SetPixel(x, y - 1, colour);
                texture.SetPixel(x - 1, y - 1, colour);
                texture.SetPixel(x - 1, y, colour);
                texture.SetPixel(x - 1, y + 1, colour);
                texture.Apply();
                growingOutPoint++;
                return;
            }
            if (size <= 4)
            {
                texture.SetPixel(x, y, colour);
                texture.SetPixel(x, y + 1, colour);
                texture.SetPixel(x + 1, y + 1, colour);
                texture.SetPixel(x + 1, y, colour);

                texture.SetPixel(x, y + 2, colour);
                texture.SetPixel(x + 1, y + 2, colour);
                texture.SetPixel(x + 2, y + 1, colour);
                texture.SetPixel(x + 2, y, colour);
                texture.SetPixel(x + 1, y - 1, colour);
                texture.SetPixel(x, y - 1, colour);
                texture.SetPixel(x - 1, y, colour);
                texture.SetPixel(x - 1, y + 1, colour);



                texture.Apply();
                growingOutPoint++;
                return;
            }
            if (size <= 5)
            {
                texture.SetPixel(x, y, colour);
                texture.SetPixel(x, y + 1, colour);
                texture.SetPixel(x + 1, y + 1, colour);
                texture.SetPixel(x + 1, y, colour);

                texture.SetPixel(x, y + 2, colour);
                texture.SetPixel(x + 1, y + 2, colour);
                texture.SetPixel(x + 2, y + 1, colour);
                texture.SetPixel(x + 2, y, colour);
                texture.SetPixel(x + 1, y - 1, colour);
                texture.SetPixel(x, y - 1, colour);
                texture.SetPixel(x - 1, y, colour);
                texture.SetPixel(x - 1, y + 1, colour);

                texture.SetPixel(x+2, y-1, colour);
                texture.SetPixel(x+1, y-2, colour);
                texture.SetPixel(x, y-2, colour);
                texture.SetPixel(x-1, y-2, colour);
                texture.SetPixel(x-1, y-1, colour);
                texture.SetPixel(x-2, y-1, colour);
                texture.SetPixel(x-2, y, colour);
                texture.SetPixel(x-2, y+1, colour);
                texture.SetPixel(x-1, y+2, colour);





                texture.Apply();
                growingOutPoint++;
                return;
            }
            if (size <= 6)
            {
                texture.SetPixel(x, y, colour);
                texture.SetPixel(x, y + 1, colour);
                texture.SetPixel(x + 1, y + 1, colour);
                texture.SetPixel(x + 1, y, colour);

                texture.SetPixel(x, y + 2, colour);
                texture.SetPixel(x + 1, y + 2, colour);
                texture.SetPixel(x + 2, y + 1, colour);
                texture.SetPixel(x + 2, y, colour);
                texture.SetPixel(x + 1, y - 1, colour);
                texture.SetPixel(x, y - 1, colour);
                texture.SetPixel(x - 1, y, colour);
                texture.SetPixel(x - 1, y + 1, colour);

                texture.SetPixel(x + 2, y - 1, colour);
                texture.SetPixel(x + 1, y - 2, colour);
                texture.SetPixel(x, y - 2, colour);
                texture.SetPixel(x - 1, y - 2, colour);
                texture.SetPixel(x - 1, y - 1, colour);
                texture.SetPixel(x - 2, y - 1, colour);
                texture.SetPixel(x - 2, y, colour);
                texture.SetPixel(x - 2, y + 1, colour);
                texture.SetPixel(x - 1, y + 2, colour);

                texture.SetPixel(x+2, y+2, colour);
                texture.SetPixel(x-2, y+2, colour);
                texture.SetPixel(x+2, y-2, colour);
                texture.SetPixel(x-2, y-2, colour);

                texture.SetPixel(x-1, y+3, colour);
                texture.SetPixel(x, y+3, colour);
                texture.SetPixel(x+1, y+3, colour);
                texture.SetPixel(x+3, y+1, colour);
                texture.SetPixel(x+3, y, colour);
                texture.SetPixel(x+3, y-1, colour);
                texture.SetPixel(x-1, y-3, colour);
                texture.SetPixel(x, y-3, colour);
                texture.SetPixel(x+1, y-3, colour);
                texture.SetPixel(x-3, y+1, colour);
                texture.SetPixel(x-3, y, colour);
                texture.SetPixel(x-3, y-1, colour);






                texture.Apply();
                growingOutPoint++;
                return;
            }
            if (size <= 7)
            {
                texture.SetPixel(x, y, colour);
                texture.SetPixel(x, y + 1, colour);
                texture.SetPixel(x + 1, y + 1, colour);
                texture.SetPixel(x + 1, y, colour);

                texture.SetPixel(x, y + 2, colour);
                texture.SetPixel(x + 1, y + 2, colour);
                texture.SetPixel(x + 2, y + 1, colour);
                texture.SetPixel(x + 2, y, colour);
                texture.SetPixel(x + 1, y - 1, colour);
                texture.SetPixel(x, y - 1, colour);
                texture.SetPixel(x - 1, y, colour);
                texture.SetPixel(x - 1, y + 1, colour);

                texture.SetPixel(x + 2, y - 1, colour);
                texture.SetPixel(x + 1, y - 2, colour);
                texture.SetPixel(x, y - 2, colour);
                texture.SetPixel(x - 1, y - 2, colour);
                texture.SetPixel(x - 1, y - 1, colour);
                texture.SetPixel(x - 2, y - 1, colour);
                texture.SetPixel(x - 2, y, colour);
                texture.SetPixel(x - 2, y + 1, colour);
                texture.SetPixel(x - 1, y + 2, colour);

                texture.SetPixel(x + 2, y + 2, colour);
                texture.SetPixel(x - 2, y + 2, colour);
                texture.SetPixel(x + 2, y - 2, colour);
                texture.SetPixel(x - 2, y - 2, colour);

                texture.SetPixel(x - 1, y + 3, colour);
                texture.SetPixel(x, y + 3, colour);
                texture.SetPixel(x + 1, y + 3, colour);
                texture.SetPixel(x + 3, y + 1, colour);
                texture.SetPixel(x + 3, y, colour);
                texture.SetPixel(x + 3, y - 1, colour);
                texture.SetPixel(x - 1, y - 3, colour);
                texture.SetPixel(x, y - 3, colour);
                texture.SetPixel(x + 1, y - 3, colour);
                texture.SetPixel(x - 3, y + 1, colour);
                texture.SetPixel(x - 3, y, colour);
                texture.SetPixel(x - 3, y - 1, colour);

                texture.SetPixel(x - 1, y + 4, colour);
                texture.SetPixel(x, y + 4, colour);
                texture.SetPixel(x + 1, y + 4, colour);
                texture.SetPixel(x + 2, y + 3, colour);
                texture.SetPixel(x + 3, y + 2, colour);
                texture.SetPixel(x + 4, y + 1, colour);
                texture.SetPixel(x + 4, y, colour);
                texture.SetPixel(x + 4, y - 1, colour);
                texture.SetPixel(x + 3, y - 2, colour);
                texture.SetPixel(x + 2, y - 3, colour);
                texture.SetPixel(x + 1, y - 4, colour);
                texture.SetPixel(x, y - 4, colour);
                texture.SetPixel(x - 1, y - 4, colour);
                texture.SetPixel(x - 2, y - 3, colour);
                texture.SetPixel(x - 3, y - 2, colour);
                texture.SetPixel(x - 4, y - 1, colour);
                texture.SetPixel(x - 4, y, colour);
                texture.SetPixel(x - 4, y + 1, colour);
                texture.SetPixel(x - 3, y + 2, colour);
                texture.SetPixel(x - 2, y + 3, colour);





                texture.Apply();
                growingOutPoint++;
                return;
            }

                if (size <= 8)
                {
                    texture.SetPixel(x, y, colour);
                    texture.SetPixel(x, y + 1, colour);
                    texture.SetPixel(x + 1, y + 1, colour);
                    texture.SetPixel(x + 1, y, colour);

                    texture.SetPixel(x, y + 2, colour);
                    texture.SetPixel(x + 1, y + 2, colour);
                    texture.SetPixel(x + 2, y + 1, colour);
                    texture.SetPixel(x + 2, y, colour);
                    texture.SetPixel(x + 1, y - 1, colour);
                    texture.SetPixel(x, y - 1, colour);
                    texture.SetPixel(x - 1, y, colour);
                    texture.SetPixel(x - 1, y + 1, colour);

                    texture.SetPixel(x + 2, y - 1, colour);
                    texture.SetPixel(x + 1, y - 2, colour);
                    texture.SetPixel(x, y - 2, colour);
                    texture.SetPixel(x - 1, y - 2, colour);
                    texture.SetPixel(x - 1, y - 1, colour);
                    texture.SetPixel(x - 2, y - 1, colour);
                    texture.SetPixel(x - 2, y, colour);
                    texture.SetPixel(x - 2, y + 1, colour);
                    texture.SetPixel(x - 1, y + 2, colour);

                    texture.SetPixel(x + 2, y + 2, colour);
                    texture.SetPixel(x - 2, y + 2, colour);
                    texture.SetPixel(x + 2, y - 2, colour);
                    texture.SetPixel(x - 2, y - 2, colour);

                    texture.SetPixel(x - 1, y + 3, colour);
                    texture.SetPixel(x, y + 3, colour);
                    texture.SetPixel(x + 1, y + 3, colour);
                    texture.SetPixel(x + 3, y + 1, colour);
                    texture.SetPixel(x + 3, y, colour);
                    texture.SetPixel(x + 3, y - 1, colour);
                    texture.SetPixel(x - 1, y - 3, colour);
                    texture.SetPixel(x, y - 3, colour);
                    texture.SetPixel(x + 1, y - 3, colour);
                    texture.SetPixel(x - 3, y + 1, colour);
                    texture.SetPixel(x - 3, y, colour);
                    texture.SetPixel(x - 3, y - 1, colour);

                    texture.SetPixel(x - 1, y + 4, colour);
                    texture.SetPixel(x, y + 4, colour);
                    texture.SetPixel(x + 1, y + 4, colour);
                    texture.SetPixel(x + 2, y + 3, colour);
                    texture.SetPixel(x + 3, y + 2, colour);
                    texture.SetPixel(x + 4, y + 1, colour);
                    texture.SetPixel(x + 4, y, colour);
                    texture.SetPixel(x + 4, y - 1, colour);
                    texture.SetPixel(x + 3, y - 2, colour);
                    texture.SetPixel(x + 2, y - 3, colour);
                    texture.SetPixel(x + 1, y - 4, colour);
                    texture.SetPixel(x, y - 4, colour);
                    texture.SetPixel(x - 1, y - 4, colour);
                    texture.SetPixel(x - 2, y - 3, colour);
                    texture.SetPixel(x - 3, y - 2, colour);
                    texture.SetPixel(x - 4, y - 1, colour);
                    texture.SetPixel(x - 4, y, colour);
                    texture.SetPixel(x - 4, y + 1, colour);
                    texture.SetPixel(x - 3, y + 2, colour);
                    texture.SetPixel(x - 2, y + 3, colour);

                    texture.SetPixel(x+2, y+4, colour);
                    texture.SetPixel(x +3, y + 3, colour);
                    texture.SetPixel(x +4 , y + 2, colour);

                    texture.SetPixel(x + 2, y - 4, colour);
                    texture.SetPixel(x + 3, y - 3, colour);
                    texture.SetPixel(x + 4, y - 2, colour);

                    texture.SetPixel(x - 2, y + 4, colour);
                    texture.SetPixel(x - 3, y + 3, colour);
                    texture.SetPixel(x - 4, y + 2, colour);

                    texture.SetPixel(x - 2, y - 4, colour);
                    texture.SetPixel(x - 3, y - 3, colour);
                    texture.SetPixel(x - 4, y - 2, colour);

                    texture.Apply();
                    growingOutPoint++;
                    return;
                }

                if (size <= 9)
                {
                    texture.SetPixel(x, y, colour);
                    texture.SetPixel(x, y + 1, colour);
                    texture.SetPixel(x + 1, y + 1, colour);
                    texture.SetPixel(x + 1, y, colour);

                    texture.SetPixel(x, y + 2, colour);
                    texture.SetPixel(x + 1, y + 2, colour);
                    texture.SetPixel(x + 2, y + 1, colour);
                    texture.SetPixel(x + 2, y, colour);
                    texture.SetPixel(x + 1, y - 1, colour);
                    texture.SetPixel(x, y - 1, colour);
                    texture.SetPixel(x - 1, y, colour);
                    texture.SetPixel(x - 1, y + 1, colour);

                    texture.SetPixel(x + 2, y - 1, colour);
                    texture.SetPixel(x + 1, y - 2, colour);
                    texture.SetPixel(x, y - 2, colour);
                    texture.SetPixel(x - 1, y - 2, colour);
                    texture.SetPixel(x - 1, y - 1, colour);
                    texture.SetPixel(x - 2, y - 1, colour);
                    texture.SetPixel(x - 2, y, colour);
                    texture.SetPixel(x - 2, y + 1, colour);
                    texture.SetPixel(x - 1, y + 2, colour);

                    texture.SetPixel(x + 2, y + 2, colour);
                    texture.SetPixel(x - 2, y + 2, colour);
                    texture.SetPixel(x + 2, y - 2, colour);
                    texture.SetPixel(x - 2, y - 2, colour);

                    texture.SetPixel(x - 1, y + 3, colour);
                    texture.SetPixel(x, y + 3, colour);
                    texture.SetPixel(x + 1, y + 3, colour);
                    texture.SetPixel(x + 3, y + 1, colour);
                    texture.SetPixel(x + 3, y, colour);
                    texture.SetPixel(x + 3, y - 1, colour);
                    texture.SetPixel(x - 1, y - 3, colour);
                    texture.SetPixel(x, y - 3, colour);
                    texture.SetPixel(x + 1, y - 3, colour);
                    texture.SetPixel(x - 3, y + 1, colour);
                    texture.SetPixel(x - 3, y, colour);
                    texture.SetPixel(x - 3, y - 1, colour);

                    texture.SetPixel(x - 1, y + 4, colour);
                    texture.SetPixel(x, y + 4, colour);
                    texture.SetPixel(x + 1, y + 4, colour);
                    texture.SetPixel(x + 2, y + 3, colour);
                    texture.SetPixel(x + 3, y + 2, colour);
                    texture.SetPixel(x + 4, y + 1, colour);
                    texture.SetPixel(x + 4, y, colour);
                    texture.SetPixel(x + 4, y - 1, colour);
                    texture.SetPixel(x + 3, y - 2, colour);
                    texture.SetPixel(x + 2, y - 3, colour);
                    texture.SetPixel(x + 1, y - 4, colour);
                    texture.SetPixel(x, y - 4, colour);
                    texture.SetPixel(x - 1, y - 4, colour);
                    texture.SetPixel(x - 2, y - 3, colour);
                    texture.SetPixel(x - 3, y - 2, colour);
                    texture.SetPixel(x - 4, y - 1, colour);
                    texture.SetPixel(x - 4, y, colour);
                    texture.SetPixel(x - 4, y + 1, colour);
                    texture.SetPixel(x - 3, y + 2, colour);
                    texture.SetPixel(x - 2, y + 3, colour);

                    texture.SetPixel(x + 2, y + 4, colour);
                    texture.SetPixel(x + 3, y + 3, colour);
                    texture.SetPixel(x + 4, y + 2, colour);

                    texture.SetPixel(x + 2, y - 4, colour);
                    texture.SetPixel(x + 3, y - 3, colour);
                    texture.SetPixel(x + 4, y - 2, colour);

                    texture.SetPixel(x - 2, y + 4, colour);
                    texture.SetPixel(x - 3, y + 3, colour);
                    texture.SetPixel(x - 4, y + 2, colour);

                    texture.SetPixel(x - 2, y - 4, colour);
                    texture.SetPixel(x - 3, y - 3, colour);
                    texture.SetPixel(x - 4, y - 2, colour);


                    texture.SetPixel(x-1, y+5, colour);
                    texture.SetPixel(x -1, y +5, colour);
                    texture.SetPixel(x  , y+5, colour);
                    texture.SetPixel(x + 1, y +5, colour);
                    texture.SetPixel(x + 2, y + 5, colour);

                    texture.SetPixel(x - 1, y - 5, colour);
                    texture.SetPixel(x - 1, y - 5, colour);
                    texture.SetPixel(x, y - 5, colour);
                    texture.SetPixel(x + 1, y - 5, colour);
                    texture.SetPixel(x + 2, y - 5, colour);

                    texture.SetPixel(x +5, y + 2, colour);
                    texture.SetPixel(x +5, y + 1, colour);
                    texture.SetPixel(x+5, y, colour);
                    texture.SetPixel(x + 5, y + 1, colour);
                    texture.SetPixel(x + 5, y + 2, colour);

                    texture.SetPixel(x - 5, y + 2, colour);
                    texture.SetPixel(x - 5, y + 1, colour);
                    texture.SetPixel(x - 5, y, colour);
                    texture.SetPixel(x - 5, y + 1, colour);
                    texture.SetPixel(x - 5, y + 2, colour);

                    texture.SetPixel(x + 3, y + 4, colour);
                    texture.SetPixel(x + 4 , y + 3, colour);

                    texture.SetPixel(x +3, y -4, colour);
                    texture.SetPixel(x +4, y -3, colour);

                    texture.SetPixel(x -3, y - 4, colour);
                    texture.SetPixel(x - 4, y -3, colour);

                    texture.SetPixel(x -3, y + 4, colour);
                    texture.SetPixel(x -4, y + 3, colour);


                    texture.Apply();
                    growingOutPoint++;

                    return;
                   
                }

                if (size <= 10)
                {
                    Debug.Log("at 10");
                    texture.SetPixel(x, y, colour);
                    texture.SetPixel(x, y + 1, colour);
                    texture.SetPixel(x + 1, y + 1, colour);
                    texture.SetPixel(x + 1, y, colour);

                    texture.SetPixel(x, y + 2, colour);
                    texture.SetPixel(x + 1, y + 2, colour);
                    texture.SetPixel(x + 2, y + 1, colour);
                    texture.SetPixel(x + 2, y, colour);
                    texture.SetPixel(x + 1, y - 1, colour);
                    texture.SetPixel(x, y - 1, colour);
                    texture.SetPixel(x - 1, y, colour);
                    texture.SetPixel(x - 1, y + 1, colour);

                    texture.SetPixel(x + 2, y - 1, colour);
                    texture.SetPixel(x + 1, y - 2, colour);
                    texture.SetPixel(x, y - 2, colour);
                    texture.SetPixel(x - 1, y - 2, colour);
                    texture.SetPixel(x - 1, y - 1, colour);
                    texture.SetPixel(x - 2, y - 1, colour);
                    texture.SetPixel(x - 2, y, colour);
                    texture.SetPixel(x - 2, y + 1, colour);
                    texture.SetPixel(x - 1, y + 2, colour);

                    texture.SetPixel(x + 2, y + 2, colour);
                    texture.SetPixel(x - 2, y + 2, colour);
                    texture.SetPixel(x + 2, y - 2, colour);
                    texture.SetPixel(x - 2, y - 2, colour);

                    texture.SetPixel(x - 1, y + 3, colour);
                    texture.SetPixel(x, y + 3, colour);
                    texture.SetPixel(x + 1, y + 3, colour);
                    texture.SetPixel(x + 3, y + 1, colour);
                    texture.SetPixel(x + 3, y, colour);
                    texture.SetPixel(x + 3, y - 1, colour);
                    texture.SetPixel(x - 1, y - 3, colour);
                    texture.SetPixel(x, y - 3, colour);
                    texture.SetPixel(x + 1, y - 3, colour);
                    texture.SetPixel(x - 3, y + 1, colour);
                    texture.SetPixel(x - 3, y, colour);
                    texture.SetPixel(x - 3, y - 1, colour);

                    texture.SetPixel(x - 1, y + 4, colour);
                    texture.SetPixel(x, y + 4, colour);
                    texture.SetPixel(x + 1, y + 4, colour);
                    texture.SetPixel(x + 2, y + 3, colour);
                    texture.SetPixel(x + 3, y + 2, colour);
                    texture.SetPixel(x + 4, y + 1, colour);
                    texture.SetPixel(x + 4, y, colour);
                    texture.SetPixel(x + 4, y - 1, colour);
                    texture.SetPixel(x + 3, y - 2, colour);
                    texture.SetPixel(x + 2, y - 3, colour);
                    texture.SetPixel(x + 1, y - 4, colour);
                    texture.SetPixel(x, y - 4, colour);
                    texture.SetPixel(x - 1, y - 4, colour);
                    texture.SetPixel(x - 2, y - 3, colour);
                    texture.SetPixel(x - 3, y - 2, colour);
                    texture.SetPixel(x - 4, y - 1, colour);
                    texture.SetPixel(x - 4, y, colour);
                    texture.SetPixel(x - 4, y + 1, colour);
                    texture.SetPixel(x - 3, y + 2, colour);
                    texture.SetPixel(x - 2, y + 3, colour);

                    texture.SetPixel(x + 2, y + 4, colour);
                    texture.SetPixel(x + 3, y + 3, colour);
                    texture.SetPixel(x + 4, y + 2, colour);

                    texture.SetPixel(x + 2, y - 4, colour);
                    texture.SetPixel(x + 3, y - 3, colour);
                    texture.SetPixel(x + 4, y - 2, colour);

                    texture.SetPixel(x - 2, y + 4, colour);
                    texture.SetPixel(x - 3, y + 3, colour);
                    texture.SetPixel(x - 4, y + 2, colour);

                    texture.SetPixel(x - 2, y - 4, colour);
                    texture.SetPixel(x - 3, y - 3, colour);
                    texture.SetPixel(x - 4, y - 2, colour);


                    texture.SetPixel(x - 1, y + 5, colour);
                    texture.SetPixel(x - 1, y + 5, colour);
                    texture.SetPixel(x, y + 5, colour);
                    texture.SetPixel(x + 1, y + 5, colour);
                    texture.SetPixel(x + 2, y + 5, colour);

                    texture.SetPixel(x - 1, y - 5, colour);
                    texture.SetPixel(x - 1, y - 5, colour);
                    texture.SetPixel(x, y - 5, colour);
                    texture.SetPixel(x + 1, y - 5, colour);
                    texture.SetPixel(x + 2, y - 5, colour);

                    texture.SetPixel(x + 5, y + 2, colour);
                    texture.SetPixel(x + 5, y + 1, colour);
                    texture.SetPixel(x + 5, y, colour);
                    texture.SetPixel(x + 5, y + 1, colour);
                    texture.SetPixel(x + 5, y + 2, colour);

                    texture.SetPixel(x - 5, y + 2, colour);
                    texture.SetPixel(x - 5, y + 1, colour);
                    texture.SetPixel(x - 5, y, colour);
                    texture.SetPixel(x - 5, y + 1, colour);
                    texture.SetPixel(x - 5, y + 2, colour);

                    texture.SetPixel(x + 3, y + 4, colour);
                    texture.SetPixel(x + 4, y + 3, colour);

                    texture.SetPixel(x + 3, y - 4, colour);
                    texture.SetPixel(x + 4, y - 3, colour);

                    texture.SetPixel(x - 3, y - 4, colour);
                    texture.SetPixel(x - 4, y - 3, colour);

                    texture.SetPixel(x - 3, y + 4, colour);
                    texture.SetPixel(x - 4, y + 3, colour);



                    texture.SetPixel(x -2, y -6, colour);
                    texture.SetPixel(x - 1, y - 6, colour);
                    texture.SetPixel(x - 0, y - 6, colour);
                    texture.SetPixel(x + 1, y - 6, colour);
                    texture.SetPixel(x + 2, y - 6, colour);

                    texture.SetPixel(x - 2, y + 6, colour);
                    texture.SetPixel(x - 1, y + 6, colour);
                    texture.SetPixel(x - 0, y + 6, colour);
                    texture.SetPixel(x + 1, y + 6, colour);
                    texture.SetPixel(x + 2, y + 6, colour);

                    texture.SetPixel(x - 6, y - 2, colour);
                    texture.SetPixel(x - 6, y - 1, colour);
                    texture.SetPixel(x - 6, y - 0, colour);
                    texture.SetPixel(x - 6, y + 1, colour);
                    texture.SetPixel(x - 6, y + 2, colour);

                    texture.SetPixel(x + 6, y - 2, colour);
                    texture.SetPixel(x + 6, y - 1, colour);
                    texture.SetPixel(x + 6, y - 0, colour);
                    texture.SetPixel(x + 6, y + 1, colour);
                    texture.SetPixel(x + 6, y + 2, colour);


                    texture.SetPixel(x + 3, y + 5, colour);
                    texture.SetPixel(x + 4, y + 4, colour);
                    texture.SetPixel(x + 5, y + 3, colour);

                    texture.SetPixel(x + 3, y - 5, colour);
                    texture.SetPixel(x + 4, y - 4, colour);
                    texture.SetPixel(x + 5, y - 3, colour);

                    texture.SetPixel(x - 3, y + 5, colour);
                    texture.SetPixel(x - 4, y + 4, colour);
                    texture.SetPixel(x - 5, y + 3, colour);

                    texture.SetPixel(x - 3, y - 5, colour);
                    texture.SetPixel(x - 4, y - 4, colour);
                    texture.SetPixel(x - 5, y - 3, colour);

                    texture.Apply();
                    growingOutPoint++;
                    return;
                }
            }
        }



    public void SumDirections()
    {

        int total = 0;

        for (int i = 0; i < limbData.growthDirections.directions.Length; i++)
        {
            total += limbData.growthDirections.directions[i];
        }

        sumDirections = total;
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







}
