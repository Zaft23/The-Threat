using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;


public class Ch1D7 : MonoBehaviour
{
    public DialogManager DialogManager;


    void Start()
    {


        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Here's the server. now to download the Intel", "Zaki"));
        dialogTexts.Add(new DialogData("/sound:Beep/Downloading Files..", "System"));
        dialogTexts.Add(new DialogData("Downloading Files..", "System"));
        dialogTexts.Add(new DialogData("Downloading Files..", "System"));
        dialogTexts.Add(new DialogData("/sound:Beep/Download Complete", "System"));
        dialogTexts.Add(new DialogData("Now to plant a Bomb that will level this building to the ground", "Zaki"));
        dialogTexts.Add(new DialogData("/sound:Beep/*beep", "System"));
        dialogTexts.Add(new DialogData("Time to go. Now where's the vent that the staff talked about", "Zaki"));


        DialogManager.Show(dialogTexts);


    }
}
