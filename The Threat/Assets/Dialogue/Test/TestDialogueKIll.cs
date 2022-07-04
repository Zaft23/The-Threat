using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class TestDialogueKIll : MonoBehaviour
{
    // Start is called before the first frame update

    public DialogManager DialogManager;

    //public GameObject[] Example;


    void Start()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Hey!! you kill your first Zombie", "Reza"));
        dialogTexts.Add(new DialogData("Hmmm", "Zaki"));
        dialogTexts.Add(new DialogData("C'mon have more fun would you?", "Reza"));


        DialogManager.Show(dialogTexts);
    }

    // Update is called once per frame
    void Update()
    {
        //for picture
    }
}
