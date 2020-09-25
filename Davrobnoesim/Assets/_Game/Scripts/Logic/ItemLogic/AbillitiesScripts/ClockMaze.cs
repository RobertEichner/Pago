using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ItemAbilities/ClockMaze")]
public class ClockMaze : ItemAbility
{
     private GameObject textBox = null;
     private bool isOpen = false;
     private Transform targetPos = null;
     private Button SingleButtonText = null;
     private GridLayoutGroup cg = null;
    [SerializeField] private float cellSizeX = 1200;
    [SerializeField] private float cellSizeY = 200;
    
    public override void UseItem(GameObject target)
    {
        GameObject playerUI = GameObject.Find("PlayerUI");
        cg = playerUI.GetComponentInChildren<GridLayoutGroup>(true);
        textBox = cg.gameObject;
        SingleButtonText = Resources.Load<Button>("Prefabs/ButtonSingle");
        SwitchView();
        targetPos = target.transform;
        StartStory();
    }
    
    private void SwitchView()
    {
        isOpen = !isOpen;
        textBox.SetActive(isOpen);
    }

    private void StartStory()
    {
        RemoveChildren();
        DisplayText();
    }

    private void RemoveChildren()
    {
        foreach (Transform child in textBox.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void DisplayText()
    {
        cg.cellSize = new Vector2(cellSizeX, (cellSizeY));
        Button button = Instantiate(SingleButtonText, textBox.transform);
        Text textComp = null;
        foreach (Transform child in button.transform) {
            child.TryGetComponent(out textComp);
            break;
        }

        string defaultText = "The clock seems to be broken";

        LinkedList<PathTile> maze = Maze.Path;
        int playerPos = Maze.PlayerPos;


        if (maze.Count > 0)
        {
            int nextPos = maze.ElementAt(playerPos).next;

            switch (nextPos)
            {
                case 0:
                    defaultText = "The clock shows 12 o'clock";
                    break;
                case 1:
                    defaultText = "The clock shows 3 o'clock";
                    break;
                case 2:
                    defaultText = "The clock shows 6 o'clock";
                    break;
                case 3:
                    defaultText = "The clock shows 9 o'clock";
                    break;
                default:
                    defaultText = "The clock seems to be spinning";
                    break;
            }
        }
             
        textComp.text = defaultText;
        button.onClick.AddListener(SwitchView);
    }

}
