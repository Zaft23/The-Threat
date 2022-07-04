using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;


public class Ch2D1 : MonoBehaviour
{
    public DialogManager DialogManager;


    void Start()
    {


        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/sound:Radio_Beep/*Threat where are you? You got seperated from us ", "Afia"));
        dialogTexts.Add(new DialogData("Doesn’t matter do whatever you need to link up with me I need to find the Weapon", "Zaki"));
        dialogTexts.Add(new DialogData("Understood, you be careful out there", "Hardi"));
      


        DialogManager.Show(dialogTexts);


    }


}