using UnityEngine;
using System.Collections.Generic;

//Class script to control grids - grids hold slot objects
//Includes all helper functions
//All functions regarding grids and controlling grids should be handled by this class
[System.Serializable]
public class Grid
{
    public int width {get;}
    public int height {get;}

    //The scale of individual slots in the grid
    public Vector2 scale {get;}
    
    List<SlotObject> slots;
    
    //World Space position of the grid
    Vector2 position;

    public Vector2 GetPosition()
    {
        return position;
    }

    public void SetPosition(Vector2 newPosition)
    {
        position = newPosition;
    }

    public Grid(int width, int height, Vector2 scale, Vector2 position)
    {
        this.height = height;
        this.width = width;
        this.position = position;
        //Create list of empty slot objects
        //List is used here instead of Array because of added functionality
        slots = new List<SlotObject>();
        for(int i = 0; i < width*height; i++)
        {
            slots.Add(null);
        }

        this.scale = scale;
    }

    //Helper functions to move between differnt space
    
    //Fucntion to go fomr 2D to 1D array
    public int XYtoN(int x, int y)
    {
        return x + y * width;
    }

    //Function to go from 1D to 2D array
    public Vector2Int NtoXY(int n)
    {
        return new Vector2Int(n%width, n/width);
    }

    public Vector2 SlotToWorld(int n)
    {
        Vector2Int p = NtoXY(n);
        Vector2 pos = new Vector2(p.x*scale.x,p.y*scale.y) + position;
        return pos;
    }

    public List<SlotObject> GetSlots()
    {
        return slots;
    }
    
    public int WorldToSlot(Vector2 wordPos)
    {
        //Get world position and transform to grid position
        // floor functions quantize world positon
        int x = Mathf.FloorToInt((wordPos.x+(scale.x/2) - position.x)/scale.x);
        int y = Mathf.FloorToInt((wordPos.y+(scale.y/2) - position.y)/scale.y);
        int n = -1;

        if(x >= 0 && y >= 0 && x < width && y < height)
        {
            n = XYtoN(x,y);
            
        }

        return n;
    }

    public int WorldToSlot(Vector2 wordPos, out SlotObject slotObject)
    {
        int x = Mathf.FloorToInt((wordPos.x+(scale.x/2) - position.x)/scale.x);
        int y = Mathf.FloorToInt((wordPos.y+(scale.y/2) - position.y)/scale.y);
        slotObject = null;
        int n = -1;

        if(x >= 0 && y >= 0 && x < width && y < height)
        {
            n = XYtoN(x,y);
            slotObject = slots[n];
        }

        return n;
    }
    public void SetSlot(SlotObject slotObject, int x, int y)
    {
        int p = XYtoN(x,y);
        slots[p] = slotObject;
    }
    public void SetSlot(SlotObject slotObject, int n)
    {
        slots[n] = slotObject;
    }
    public SlotObject GetSlot(int x, int y)
    {
        int p = XYtoN(x,y);
        return slots[p];
    }
    public SlotObject GetSlot(int n)
    {
        return slots[n];
    }
    public void SetSize(int width, int height)
    {
        
    }

    //Delegate fucntion to enable anonymous functions to be run on all slot objects present in grid
    //To be used to run funciton/checks on all slot objects
    public delegate void UpdateFunction(SlotObject slotObject, int n);
    public void UpdateBoard(UpdateFunction function)
    {
        for(int i = 0; i < slots.Count; i++)
        {
            if(slots[i] != null)
            {
                function(slots[i], i);
            }
        }
    }

}
