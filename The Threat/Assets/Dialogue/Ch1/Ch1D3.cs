using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;



public class Ch1D3 : MonoBehaviour
{
    public DialogManager DialogManager;


    void Start()
    {


        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Looks like they're trying to quickly empty the building after that little skirmish.", "Zaki"));
        dialogTexts.Add(new DialogData("I guess i gotta check the Staff Room, maybe someone who know where the server room is still there.", "Zaki"));
        dialogTexts.Add(new DialogData("Need to go up another level.", "Zaki"));
       


        DialogManager.Show(dialogTexts);


    }
}
