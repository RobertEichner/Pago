using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialog : MonoBehaviour, IInteractable
{

    private GameObject textBox = null;
    [SerializeField] private float activeInThisRadius = 4f;
    private bool isOpen = false;
    private Transform targetPos = null;
    [SerializeField] private DialogSave startState = null;
    private Queue<State> currentStates = new Queue<State>();
    //private QuestManager qm;
    private Button SingleButtonText = null;
    private GridLayoutGroup cg = null;
    [SerializeField] private float cellSizeX = 1200;
    [SerializeField] private float cellSizeY = 200;

    private void Awake()
    {
        textBox = GameObject.FindWithTag("DialogBox");
        textBox.TryGetComponent(out cg);
        //GameObject.FindWithTag("Player").TryGetComponent(out qm);
        //qm = QuestManager.Instance;
        SingleButtonText = Resources.Load<Button>("Prefabs/ButtonSingle");
        currentStates.Enqueue(startState.StartState);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            if(Vector2.Distance(transform.position, targetPos.position) > activeInThisRadius)
                SwitchView();
        }
        
    }

    public void Interact(GameObject sender)
    {
        SwitchView();
        targetPos = sender.transform;
        StartStory();
    }

    private void SwitchView()
    {
        isOpen = !isOpen;
        textBox.SetActive(isOpen);
        ResetToStartState();
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
        float count = currentStates.Count;
        for (int i = 0; i < count; i++)
        {
            CreateTextBox(currentStates.Dequeue(), count);
        }
    }

    private void CreateTextBox(State stateForChoices, float stateCount)
    {
        cg.cellSize = new Vector2(cellSizeX, (cellSizeY/stateCount));
        Button button = Instantiate(SingleButtonText, textBox.transform);
        Text textComp = null;
        foreach (Transform child in button.transform) {
            child.TryGetComponent(out textComp);
            break;
        }

        textComp.text = stateForChoices.GetStateStory();
        button.onClick.AddListener(delegate
        {
            if (stateForChoices.IsAnchor)
                startState.StartState = stateForChoices;
            stateForChoices.StoryEvent();
            
            if (stateForChoices.GetNextStates().Length == 0)
            {
                SwitchView();
                return;
            }
            
            if (stateForChoices is DialogToFinish checkStat)
            {
                if (!checkStat.IsDone)
                {
                    SwitchView();
                    return;
                } 
            }

            foreach (var stat in stateForChoices.GetNextStates())
            {
                currentStates.Enqueue(stat);   
            }
            StartStory();
        });

    }

    private void ResetToStartState()
    {
        currentStates.Clear();
        currentStates.Enqueue(startState.StartState);
    }

}
