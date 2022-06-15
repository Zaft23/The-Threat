using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class TestDialogueTimed : MonoBehaviour
{
    // Start is called before the first frame update

    public DialogManager DialogManager;

    //public GameObject[] Example;


    void Start()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Hurry up on the killings", "Reza"));
        dialogTexts.Add(new DialogData("Hmmm, you starting to irritate me", "Zaki"));
        dialogTexts.Add(new DialogData("HAHAHHAHAH", "Reza"));


        DialogManager.Show(dialogTexts);
    }

    // Update is called once per frame
    void Update()
    {
        //for picture
    }
}
