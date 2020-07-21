﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maze : MonoBehaviour
{
    static LinkedList <PathTile> path = new LinkedList <PathTile>();

    private static int playerPos = 0;
    private static int pathLength;
    [SerializeField] int pathTaken = -1;
    
    public void genPath()
    {
        System.Random rdm = new System.Random();
        pathLength = rdm.Next(5, 11);
        int[] dir = {};
        int next = 0;
        int prev = 2; //south exit

        int[] r0 = new int[3] { 0, 1, 3 };
        int[] r1 = new int[3] { 0, 1, 2 };
        int[] r2 = new int[3] { 1, 2, 3 };
        int[] r3 = new int[3] { 0, 2, 3 };

        for (int i = 1; i <= pathLength; i++)
        {
            int r = rdm.Next(0, 3);

            switch (prev)
            {
                case 0:
                    next = r0[r];
                    break;
                case 1:
                    next = r1[r];
                    break;
                case 2:
                    next = r2[r];
                    break;
                case 3:
                    next = r3[r];
                    break;
            }
            path.AddLast(new PathTile(prev, next));
            //Debug.Log(prev + " " + next);
            prev = next;

            
        }
        Debug.Log(pathLength);
        Debug.Log(path.ElementAt(0).next);
        Debug.Log(path.ElementAt(1).next);
        Debug.Log(path.ElementAt(2).next);
        Debug.Log(path.ElementAt(3).next);
        Debug.Log(path.ElementAt(4).next);
        Debug.Log(path.ElementAt(5).next);
        Debug.Log(path.ElementAt(6).next);
        Debug.Log(path.ElementAt(7).next);
        Debug.Log(path.ElementAt(8).next);
        Debug.Log(path.ElementAt(9).next);
    }
    public void OnTriggerEnter2D()
    {
        if (pathTaken == -1)
        {
            playerPos = 0;
            genPath();
        }

        if (pathTaken == path.ElementAt(playerPos).next)
        {
            playerPos++;
        }
        else
            playerPos = 0;

        if (playerPos == pathLength)
            Debug.Log("Finish");
    }
}



public class PathTile
{
    public int prev;
    public int next;
    
    public PathTile(int prev, int next)
    {
        this.prev = prev;
        this.next = next;
    }
}