using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maze : MonoBehaviour
{
    static LinkedList<PathTile> path = new LinkedList<PathTile>();

    private static int playerPos = 0;
    private static int pathLength;
    [SerializeField] int pathTaken = -1;

    System.Random rdm = new System.Random(System.DateTime.Now.Millisecond);

    public static LinkedList<PathTile> Path => path;

    public static int PlayerPos => playerPos;

    public void genPath()
    {
        path.Clear();
        pathLength = 5;
        int[] dir = { };
        int next = 0;
        int prev = 0; //south exit

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
        Debug.Log(path.ElementAt(0).next);
        Debug.Log(path.ElementAt(1).next);
        Debug.Log(path.ElementAt(2).next);
        Debug.Log(path.ElementAt(3).next);
        Debug.Log(path.ElementAt(4).next);
    }
    public void OnTriggerEnter2D()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (pathTaken == -1)
        {
            playerPos = 0;
            genPath();
        }

        if (pathTaken == path.ElementAt(playerPos).next)
        {
            playerPos++;
        }
        else if (pathTaken != -1)
            SceneManager.activeSceneChanged += SceneChanged; //exit

        if (playerPos == pathLength) {
            SceneManager.activeSceneChanged += SceneChanged; //teleport
        }

    } 

    private void SceneChanged(Scene current, Scene next)
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (playerPos == pathLength)
            player.transform.position = new Vector2(0, 13.5f);
        else
        {
            SceneManager.LoadScene(0);
            player.transform.position = new Vector2(1, 30);
        }


        SceneManager.activeSceneChanged -= SceneChanged;
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
