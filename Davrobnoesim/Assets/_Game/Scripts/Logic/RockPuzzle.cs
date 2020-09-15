using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class RockPuzzle : MonoBehaviour
{
    private static int order = 0;
    private static bool solved = false;
    private bool rock1, rock2, rock3, rock4;

    private void Awake()
    {
        if (solved == true) {
            GameObject chest = GameObject.Find("BanditChest");
            chest.transform.position = new Vector2(-10.5f, 5f);
        }
    }

    private void Update()
    {
        if (solved == true)
            return;

        GameObject chest = GameObject.Find("BanditChest");

        rock1 = (GameObject.Find("Rock_1") != null);
        rock2 = (GameObject.Find("Rock_2") != null);
        rock3 = (GameObject.Find("Rock_3") != null);
        rock4 = (GameObject.Find("Rock_4") != null);

        if (order == 0)
        {
            if ((rock1 == false) && (rock2 == true) && (rock3 == true) && (rock4 == true)) //first state
                order = 1;
        }

        if (order == 1)
        {
            if ((rock2 == false) && (rock3 == true) && (rock4 == true)) //second state
                order = 2;
            else if (!(rock2 == true) && (rock3 == true) && (rock4 == true))
                order = 0;
        }

        if (order == 2)
        {
            if ((rock3 == false) && (rock4 == true)) //third state
                order = 3;
            else if (!(rock3 == true) && (rock4 == true))
                order = 0;
        }

        if (order == 3)
        {
            if (rock4 == false)
            {//final state
                chest.transform.position = new Vector2(-10.5f, 5f);
                solved = true;
            }
        }
    }
    

    


}
