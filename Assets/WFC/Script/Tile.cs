using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public GameObject tileObject;
    public bool isFill = false;
    public Module module;
    public Vector3 centerPostion;
    public Vector3 pivotPostion;
    public bool up = true;
    public bool down = true;
    public bool left = true;
    public bool right = true;
    public bool forward = true;
    public bool back = true;
    public List<Tile> neibors;
    public Tile(Vector3 _centerPos)
    {
        centerPostion = _centerPos;
        pivotPostion = _centerPos;
        pivotPostion = centerPostion + Vector3.one * 0.5f;
        neibors = new List<Tile>();
        //float tempX, tempY, tempZ;
        //tempX = PivotPostion.x >= 0 ? PivotPostion.x + 0.5f : PivotPostion.x + 0.5f;
        //tempY = PivotPostion.y >= 0 ? PivotPostion.y + 0.5f : PivotPostion.y + 0.5f;
        //tempZ = PivotPostion.z >= 0 ? PivotPostion.z + 0.5f : PivotPostion.z + 0.5f;
        //PivotPostion = new Vector3(tempX,tempY,tempZ);
    }
}

