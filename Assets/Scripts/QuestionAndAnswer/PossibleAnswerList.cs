using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PossibleAnswerList : MonoBehaviour
{
    List<string> FireAnswerList = new List<string>();
    List<string> FishAnswerList = new List<string>();
    List<string> RiverAnswerList = new List<string>();
    List<string> LordAnswerList = new List<string>();

    public static PossibleAnswerList Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!Instance) Instance = this;
    }
    void Start()
    {

        FireAnswerList.Add("Fish");
        FireAnswerList.Add("River");
        FireAnswerList.Add("Fire");

        FishAnswerList.Add("Fish");
        FishAnswerList.Add("Fire");
        FishAnswerList.Add("Lord");

        RiverAnswerList.Add("Lord");
        RiverAnswerList.Add("River");
        RiverAnswerList.Add("Fire");

        LordAnswerList.Add("Fish");
        LordAnswerList.Add("Cook");
        LordAnswerList.Add("Lord");

        if (RandomQuestion.Instance.Question == "Fish")
            ChangeToFishAnswerList();
        else if (RandomQuestion.Instance.Question == "Fire")
            ChangeToFireAnswerList();
        else if (RandomQuestion.Instance.Question == "River")
            ChangeToRiverAnswerList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeToLordAnswerList()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform child = this.transform.GetChild(i);
            child.GetComponent<CharacterGeneratorSingle>().input = LordAnswerList[i];
            child.GetComponent<CharacterGeneratorSingle>().Start();
        }
    }

    public void ChangeToFishAnswerList()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform child = this.transform.GetChild(i);
            child.GetComponent<CharacterGeneratorSingle>().input = FishAnswerList[i];
            child.GetComponent<CharacterGeneratorSingle>().Start();
        }
    }

    public void ChangeToFireAnswerList()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform child = this.transform.GetChild(i);
            child.GetComponent<CharacterGeneratorSingle>().input = FireAnswerList[i];
            child.GetComponent<CharacterGeneratorSingle>().Start();
        }
    }

    public void ChangeToRiverAnswerList()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform child = this.transform.GetChild(i);
            child.GetComponent<CharacterGeneratorSingle>().input = RiverAnswerList[i];
            child.GetComponent<CharacterGeneratorSingle>().Start();
        }
    }
}
