using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;


public class TestDialogue1 : MonoBehaviour
{
    // Start is called before the first frame update

    public DialogManager DialogManager;

    //public GameObject[] Example;


    void Start()
    {
        

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Hey, Soldier Welcome to the Prototype", "Reza"));
        dialogTexts.Add(new DialogData("Sup Reza", "Zaki"));
        dialogTexts.Add(new DialogData("Later on we'll talk about the dialogue when you finished interacting with something", "Reza"));
        dialogTexts.Add(new DialogData("Then Dailogue to start talking after killing a boss", "Reza"));
        dialogTexts.Add(new DialogData("Okay my friend", "Zaki"));

        DialogManager.Show(dialogTexts);

        
    }

    // Update is called once per frame
    void Update()
    {
        //for picture
    }
}
