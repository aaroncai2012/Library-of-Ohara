using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(this.GetComponent<CharacterGeneratorSingle>().input == RandomQuestion.Instance.Question.ToUpper())
        {
            Debug.Log("True");
            if (this.GetComponent<CharacterGeneratorSingle>().input == "FIRE")
            {
                TextReStructure.Instance.AddFire();
            }
            else if (this.GetComponent<CharacterGeneratorSingle>().input == "FISH")
            {
                TextReStructure.Instance.AddFish();
            }
        }
        else
        {
            Debug.Log("False");
        }
    }
}
