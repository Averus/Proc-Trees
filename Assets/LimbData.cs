using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LimbData  {

    public Color color = Color.black;

    public float maxLength = 100;
    public float maxWidth = 10;
    public float minWidth = 8;
    public float curveAggression = 0.3f;
    public int[] directions = new int[9];

    //public float childMaxLength = 0;
    //public float childMinWidth = 0;
    //public float childCurveAggression = 0;
    public int childGeneration = 0;
    public float minPercentageGrowthForChild = 0.5f;
    public float childProbability = 0.25f;
    public int maxChildren = 2;
    public int[] childSplitDirections = new int[9];

    //public float splitMaxLength = 0;
    //public float splitMinWidth = 0;
    //public float splitCurveAggression = 0;
    //There is no min percentage for splitting because that's the same as the max length, splitting occurs when growth has finished.
    public int splitGeneration = 0;
    public float splitProbability = 0.75f;
    public int maxSplits = 2;
    public int[] splitDirections = new int[9];






}
