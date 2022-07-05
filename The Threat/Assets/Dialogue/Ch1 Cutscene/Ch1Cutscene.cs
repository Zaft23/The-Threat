using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;


public class Ch1Cutscene : MonoBehaviour
{
    public DialogManager DialogManager;


    void Start()
    {


        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("A threat, or a spirit that demand vengeance for the people who’ve created chaos. Those what people call me, sentences that describe who I am.", "ZakiNoAvatar"));
        dialogTexts.Add(new DialogData("People whose being hunted by me also call me by those names.", "ZakiNoAvatar"));
        dialogTexts.Add(new DialogData("I’m a terror for those who ruined my live and everything that they did to me and this City. I’d do everything and anything to have the judged by own hand and ways. ", "ZakiNoAvatar"));
        dialogTexts.Add(new DialogData("My name is Zaki, but from many names people gave me. They know me more by the name ‘The Threat’", "ZakiNoAvatar"));
        //dialogTexts.Add(new DialogData("", "ZakiNoAvatar"));
        //dialogTexts.Add(new DialogData("", "ZakiNoAvatar"));
        //dialogTexts.Add(new DialogData("", "ZakiNoAvatar"));



        DialogManager.Show(dialogTexts);


    }

}
