using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Ch1D6 : MonoBehaviour
{
    public DialogManager DialogManager;


    void Start()
    {
        

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/sound:Sniper-rifle-sound-effect/*BANG!! ", "System"));
        dialogTexts.Add(new DialogData("What was that, Sniper? ", "Zaki"));
        dialogTexts.Add(new DialogData("Judging from the distance and sound he must be at higher elevation, must be at the catwalk.", "Zaki"));
        dialogTexts.Add(new DialogData("And considering that he's a sniper he must be in cover. Gotta find him and 'force' him out of cover", "Zaki"));
        dialogTexts.Add(new DialogData("Once he's out of cover that where i can truly 'hurt' him", "Zaki"));



        DialogManager.Show(dialogTexts);


    }

}
