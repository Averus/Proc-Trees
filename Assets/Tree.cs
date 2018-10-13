using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {


    Texture2D texture; //the texture to be drawn on
    int[,] map = new int[128, 128]; //a representation of the texture

    public int maxLimbGeneration = 4;
    public List<LimbData> limbData = new List<LimbData>();

    
    //public List<List<Limb>> limbs = new List<List<Limb>>();

    public List<Limb> limbs = new List<Limb>();

    public int originX = 0;
    public int originY = 0;

    public int[] initialDirections = new int[9];




    //test stuff below






    // Use this for initialization
    void Start () {

        texture = new Texture2D(300, 300);
        texture.filterMode = FilterMode.Point;
        GetComponent<Renderer>().material.mainTexture = texture;
        originX = texture.width / 2;
        originY = 63;



        CreateLimbData();




        //test stuff below

        //int[] directions = new int[] { 10,30, 10, 0, 0, 0, 0, 0, 0 };


       
        //limbs.Add(new Limb(this, 100, 10, 7, 0.3f, directions, texture.width/2, 5, Color.black, texture));


        //copy = limbs[0].shiftDirectionsRight(arr);

        

        //InvokeRepeating("GrowTrunk", 1.0f, 0.05f);
        //InvokeRepeating("FillOut", 10.0f, 0.05f);

        //Invoke("GenerateBough", 5.0f);

        //InvokeRepeating("GrowBough", 7.0f, 0.01f);

        //Invoke("GenerateBranch", 9.0f);

        //InvokeRepeating("GrowBranch", 11.0f, 0.01f);

    }

    //creates empty limb Data objects for each planned generation of limbs
    public void CreateLimbData()
    {
        for (int i = 0; i < maxLimbGeneration; i++)
        {
            limbData.Add(new LimbData());
        }
    }


    public void CreateLimb( int x, int y, int generation, int[] directions)
    {
       
        Limb limb = new Limb();
        limb.parentTree = this;
        limb.texture = texture;
        limb.currentX = x;
        limb.currentY = y;
        limb.generation = generation;

        LimbData l = new LimbData();
        l.maxLength = limbData[generation].maxLength;
        l.maxWidth = limbData[generation].maxWidth;
        l.minWidth = limbData[generation].minWidth;
        l.curveAggression = limbData[generation].curveAggression;
        l.directions = directions; //directions are given as an argument because they are local, individual to each limb

        l.childGeneration = limbData[generation].childGeneration;
        l.minPercentageGrowthForChild = limbData[generation].minPercentageGrowthForChild;
        l.childProbability = limbData[generation].childProbability;
        l.maxChildren = limbData[generation].maxChildren;
        l.childSplitDirections = limbData[generation].childSplitDirections; //these directions on the other hand are more like instructions for rotating the local direction, so they are inherited.

        l.splitGeneration = limbData[generation].splitGeneration;
        l.splitProbability = limbData[generation].splitProbability;
        l.maxSplits = limbData[generation].maxSplits;
        l.splitDirections = limbData[generation].directions;


        limb.limbData = l;

        limbs.Add(limb);


    }




    void Grow()
    {
        for (int i = 0; i < limbs.Count; i++)
        {
            limbs[i].Grow();
        }
        
        
        
    }

    void FillOut()
    {
        for (int i = 0; i < limbs.Count; i++)
        {
            limbs[i].FillOut();
        }
            
    }

    /*
    void GenerateBough()
    {
        int[] directions = new int[] { 0, 33, 33, 33, 0, 0, 0, 0, 0 };
        limbs.Add(new Limb(this, 40, 6, 3, 0.3f, directions, limbs[0].currentX, limbs[0].currentY, Color.black, texture));

        int[] directions2 = new int[] { 33, 33, 0, 0, 0, 0, 0, 33, 0 };
        limbs.Add(new Limb(this, 40, 6, 3, 0.3f, directions2, limbs[0].currentX, limbs[0].currentY, Color.black, texture));
    }

    void GrowBough()
    {

        limbs[1].ChooseDirection();
        limbs[2].ChooseDirection();


    }

    void GenerateBranch()
    {
        int[] directions = new int[] { 33, 33, 33, 0, 0, 0, 0, 0, 0 };
        limbs.Add(new Limb(this, 20, 3, 1, 0.3f, directions, limbs[1].currentX, limbs[1].currentY, Color.black, texture));

        int[] directions2 = new int[] { 0, 0, 0, 0, 0, 33, 33, 33, 0 };
        limbs.Add(new Limb(this, 20, 3, 1, 0.3f, directions2, limbs[1].currentX, limbs[1].currentY, Color.black, texture));

        int[] directions3 = new int[] { 0, 0, 0, 0, 0, 33, 33, 33, 0 };
        limbs.Add(new Limb(this, 20, 3, 1, 0.3f, directions3, limbs[2].currentX, limbs[2].currentY, Color.black, texture));

        int[] directions4 = new int[] { 0, 33, 33, 33, 0, 0, 0, 0, 0 };
        limbs.Add(new Limb(this, 20, 3, 1, 0.3f, directions4, limbs[2].currentX, limbs[2].currentY, Color.black, texture));
    }

    void GrowBranch()
    {

        limbs[3].ChooseDirection();
        limbs[4].ChooseDirection();
        limbs[5].ChooseDirection();
        limbs[6].ChooseDirection();


    }

    void BeginGrowth()
    {

    }

    */

    // Update is called once per frame
    void Update () {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateLimb(originX, originY, 0, initialDirections);
            InvokeRepeating("Grow", 1.0f, 0.05f);
            //InvokeRepeating("FillOut", 10.0f, 0.05f);
        }

    }
}
