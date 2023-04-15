using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossibleAnswerList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<string> FireAnswerList = new List<string>();
        List<string> FishAnswerList = new List<string>();
        List<string> RiverAnswerList = new List<string>();


        if (RandomQuestion.Instance.Question == "Fish")
        {
            Debug.Log("1");
        }
        else if (RandomQuestion.Instance.Question == "Fire")
        {
            Debug.Log("2");
        }
        else if (RandomQuestion.Instance.Question == "River")
        {
            Debug.Log("3");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
