using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckAnswerOnClick()
    {
        if(RandomQuestion.Instance.GameEnd == 1)
        {
            if (this.GetComponent<CharacterGeneratorSingle>().input == RandomQuestion.Instance.Question.ToUpper())
            { GameObject.Find("RespoundText").GetComponent<Text>().text = "You Did!"; }
            else
            {
                GameObject.Find("RespoundText").GetComponent<Text>().text = "Guess Again";
            }
        }
        else
        {
            if (this.GetComponent<CharacterGeneratorSingle>().input == RandomQuestion.Instance.Question.ToUpper())
            {
                    GameObject.Find("RespoundText").GetComponent<Text>().text = "Next One";
                if (this.GetComponent<CharacterGeneratorSingle>().input == "FIRE")
                {
                    RandomQuestion.Instance.GameEnd = 1;
                    TextReStructure.Instance.AddFire();
                    RandomQuestion.Instance.Question = "LORD";
                }
                else if (this.GetComponent<CharacterGeneratorSingle>().input == "FISH")
                {
                    RandomQuestion.Instance.GameEnd = 1;
                    TextReStructure.Instance.AddFish();
                    RandomQuestion.Instance.Question = "RIVER";
                    
                }
                else if (this.GetComponent<CharacterGeneratorSingle>().input == "RIVER")
                {
                    RandomQuestion.Instance.GameEnd = 1;
                    TextReStructure.Instance.AddRiver();
                    RandomQuestion.Instance.Question = "FISH";
                }
            }
            else
            {
                GameObject.Find("RespoundText").GetComponent<Text>().text = "Guess Again";
            }
        }

    }
}
