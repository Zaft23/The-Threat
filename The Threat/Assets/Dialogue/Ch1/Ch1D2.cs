using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;


public class Ch1D2 : MonoBehaviour
{
    public DialogManager DialogManager;


void Start()
{


    var dialogTexts = new List<DialogData>();

    dialogTexts.Add(new DialogData("My main objective here is to download Important Intelligence File that can help me bring down Omega Corporation", "Zaki"));
    dialogTexts.Add(new DialogData("But to do that I need to find their server room.", "Zaki"));
    dialogTexts.Add(new DialogData("Hmmm, Gotta find someone who knows where it is, Maybe one of their Scientist or staff will know.", "Zaki"));
    dialogTexts.Add(new DialogData("Gotta Keep Looking.", "Zaki"));


    DialogManager.Show(dialogTexts);


}
}
