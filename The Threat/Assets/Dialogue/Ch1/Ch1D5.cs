using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Ch1D5 : MonoBehaviour
{
    public DialogManager DialogManager;


    void Start()
    {


        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Damn, poor bastards they're not so lucky as me. Once they were people. now they're just victims of failed 'Human Enhancement Technology' Experiment", "Zaki"));
        dialogTexts.Add(new DialogData("They became mindless, vicious Zombies.", "Zaki"));
        dialogTexts.Add(new DialogData("I swear i'll make Omega Corps pay for this", "Zaki"));


        DialogManager.Show(dialogTexts);


    }


}
