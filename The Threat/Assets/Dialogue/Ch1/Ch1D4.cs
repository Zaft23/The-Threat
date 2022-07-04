using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Ch1D4 : MonoBehaviour
{
    public DialogManager DialogManager;


    void Start()
    {


        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Aaaaahhhhh! Please Don't kill me! I I.. I'm just a staff here.. I.. I have a wife and kids please i beg you!", "Scientist"));
        dialogTexts.Add(new DialogData("Shut up! you gotta know something, you work for Omega Corps. the source of all the shits and problem in the world", "Zaki"));
        dialogTexts.Add(new DialogData("I know I'm sorry, I also hate working here. *stuttering* I.. I'll tell you anything please!.", "Scientist"));
        dialogTexts.Add(new DialogData("Give me the information i need, and don't try to lie because i can tell if you do.", "Zaki"));
        dialogTexts.Add(new DialogData("Now, where's the server room, and a way out of this facility without going through the front or the back door?!", "Zaki"));
        dialogTexts.Add(new DialogData("The server room is at ground floor, pass the Storage room.", "Scientist"));
        dialogTexts.Add(new DialogData("the wayout is  also in there. there's a vent that leads to the city's waterway. please i swear that's all i know", "Scientist"));
        dialogTexts.Add(new DialogData("When this is over, and if find out you're still working here. You're history. Understand?", "Zaki"));
        dialogTexts.Add(new DialogData("y.. Yes. I swear i'll run far away", "Scientist"));

        DialogManager.Show(dialogTexts);


    }
}
