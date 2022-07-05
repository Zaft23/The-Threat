using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Ch2Cutscene : MonoBehaviour
{
    public DialogManager DialogManager;


    void Start()
    {


        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("From the Intel I’ve stolen from the last Facility Hardi, and I decided that for this mission I need to go to Syria..to investigate and destroy a weapon that Omega Corporation developing right now.", "ZakiNoAvatar"));
        dialogTexts.Add(new DialogData("From the looks of it it’ll be more powerful and dangerous than the experiment they did to me.", "ZakiNoAvatar"));
        dialogTexts.Add(new DialogData("So better to do this mission while Hardi try to gather more information about Omega Corp’s Owner and next potential mission.", "ZakiNoAvatar"));
        dialogTexts.Add(new DialogData("Once I arrived at Syria, I need to find a contact name Afia, that would help me find the Weapon.", "ZakiNoAvatar"));
        //dialogTexts.Add(new DialogData("", "ZakiNoAvatar"));
        //dialogTexts.Add(new DialogData("", "ZakiNoAvatar"));
        //dialogTexts.Add(new DialogData("", "ZakiNoAvatar"));



        DialogManager.Show(dialogTexts);


    }

}
