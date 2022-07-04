using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;



public class StartDialogue : MonoBehaviour
{
    public DialogManager DialogManager;


    void Start()
    {


        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/sound:Radio_Beep/*Reza To Zaki, are you there?*", "Reza"));
        dialogTexts.Add(new DialogData("I'm Here Reza, I landed on top of their facility. Thanks for flying me over.", "Zaki"));
        dialogTexts.Add(new DialogData("Hey Don't mention it, always happy to help and old friend.", "Reza"));
        dialogTexts.Add(new DialogData("Now, give those Omega Corps bastards some hell. Good hunting.", "Reza"));
        dialogTexts.Add(new DialogData("Will do.", "Zaki"));

        DialogManager.Show(dialogTexts);


    }
}
