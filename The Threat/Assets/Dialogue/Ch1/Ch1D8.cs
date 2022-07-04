using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Ch1D8 : MonoBehaviour
{
    public DialogManager DialogManager;


    void Start()
    {


        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/sound:Explosion/*Boom!! ", "System"));
        dialogTexts.Add(new DialogData("/sound:Radio_Beep/The Threat do you copy?, Threat?, Dad? Are you okay?*", "Hardi"));
        dialogTexts.Add(new DialogData("*Sigh Never been better, i'm on my way home now Kid", "Zaki"));
        dialogTexts.Add(new DialogData("Thank god, I was monitoring the facility from here and I saw the facility got blown up real bad I thought something happened to you.", "Hardi"));
        dialogTexts.Add(new DialogData("It's all part of the plan, gotta make a little fireworks for them, you know sometimes we gotta improvise... now stay safe until i get back.", "Zaki"));
 

        DialogManager.Show(dialogTexts);


    }
}
