using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestSetPixel : MonoBehaviour
{

    Texture2D texture;
    public int length = 50;
    public float angle = 90;
    int centerX =50;
    int centerY=200;

    public Branch b;
    public List<Branch> branches = new List<Branch>();
    public int numberOfSubBranches = 5;

    System.Random rng = new System.Random();


    //Test stuff below

    public int TESTthickness;


    void Start()
    {

        texture = new Texture2D(128, 128);
        texture.filterMode = FilterMode.Point;
        GetComponent<Renderer>().material.mainTexture = texture;



        branches.Add(new Branch(texture, Color.black, 200, 10, 33, 33, 33, 0, 0, 0, 0, 0, 0, 100, 0));

        InvokeRepeating("GrowBranches", 2.0f, 0.5f);
        
       // InvokeRepeating("FillOutBranches", 5f, 0.5f);




    }

    void GrowBranches()
    {

        for (int i = 0; i < branches.Count; i++)
        {
            branches[i].Grow();
        }

        for (int i = 0; i < branches[0].branchCore.Count; i++)
        {
           // TESTthickness = (branches[0].branchCore.Count / ((branches[0].branchCore.Count / 100) * i + 1));

            branches[0].FillOut(branches[0].branchCore[i].x, branches[0].branchCore[i].y, 2, Color.red);
        }

        /*
        int randomSpawn = rng.Next(20);
        Debug.Log(randomSpawn);

        if (randomSpawn == 1 && numberOfSubBranches > 0)
        {
            Debug.Log("Spawn left");
            branches.Add(new Branch(texture, Color.black, branches[0].currentX, branches[0].currentY, 50, 0, 0, 25, 0, 0, 25, 0, 0, 25, 0));
            numberOfSubBranches -= 1;
        }
        if (randomSpawn == 2 && numberOfSubBranches > 0)
        {
            Debug.Log("Spawn right");
            branches.Add(new Branch(texture, Color.black, branches[0].currentX, branches[0].currentY, 0, 0, 50, 0, 0, 25, 0, 0, 25, 25, 0));
            numberOfSubBranches -= 1;
        }
        */

    }

    void FillOutBranches()
    {
        for (int i = 0; i < 4; i++)
        {
           
                branches[0].startingThickness = i;
                branches[0].GrowOut();
            
        }
    }

    void TestDraw()
    {

        texture.SetPixel(centerX, centerY, Color.red);


        int x2 = Mathf.RoundToInt(centerX + length * Mathf.Cos(Mathf.Deg2Rad * angle));
        int y2 = Mathf.RoundToInt(centerY - length * Mathf.Sin(Mathf.Deg2Rad * angle));

        texture.SetPixel(x2, y2, Color.blue);

        DrawLine(texture, centerX, centerY, x2, y2, Color.yellow);

        texture.Apply();

        
    }

    void DrawLine(Texture2D tex, int x0, int y0, int x1, int y1, Color col)
    {
        int dy = (int)(y1 - y0);
        int dx = (int)(x1 - x0);
        int stepx, stepy;

        if (dy < 0) { dy = -dy; stepy = -1; }
        else { stepy = 1; }
        if (dx < 0) { dx = -dx; stepx = -1; }
        else { stepx = 1; }
        dy <<= 1;
        dx <<= 1;

        float fraction = 0;

        tex.SetPixel(x0, y0, col);
        if (dx > dy)
        {
            fraction = dy - (dx >> 1);
            while (Mathf.Abs(x0 - x1) > 1)
            {
                if (fraction >= 0)
                {
                    y0 += stepy;
                    fraction -= dx;
                }
                x0 += stepx;
                fraction += dy;
                tex.SetPixel(x0, y0, col);
            }
        }
        else
        {
            fraction = dx - (dy >> 1);
            while (Mathf.Abs(y0 - y1) > 1)
            {
                if (fraction >= 0)
                {
                    x0 += stepx;
                    fraction -= dy;
                }
                y0 += stepy;
                fraction += dx;
                tex.SetPixel(x0, y0, col);
            }
        }
    }




 

    void DrawLine2(int x1,int y1,int x2,int y2,Color c)
    {

        int drawX = x1;
        int drawY = y1;

        int stepX = 1;
        int stepY = 1;

        if (x1 > x2)
        {
            stepX = -1;
        }


        if (y1 > y2)
        {
            stepY = -1;
        }

        while (drawX != x2 || drawY != y2)
        {
            if (drawX != x2)
            {
                drawX += stepX;
            }
            if (drawY != y2)
            {
                drawY += stepY;
            }

            texture.SetPixel(drawX, drawY, c);
        }

        

    }



}