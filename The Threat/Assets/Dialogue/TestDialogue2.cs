using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
public class TestDialogue2 : MonoBehaviour
{
    



    // Start is called before the first frame update

    public DialogManager DialogManager;

    //public GameObject[] Example;


    void Start()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Oi Zaki, what the hell are you looking at?", "Reza"));
        dialogTexts.Add(new DialogData("Weird Art Don't you think?", "Zaki"));
        dialogTexts.Add(new DialogData("Maybe, what the hell happened to this world", "Reza"));
        dialogTexts.Add(new DialogData("Anyway focus on the job would you?!", "Reza"));
        dialogTexts.Add(new DialogData("hmm", "Zaki"));

        DialogManager.Show(dialogTexts);
    }

    // Update is called once per frame
    void Update()
    {
        //for picture
    }

}
