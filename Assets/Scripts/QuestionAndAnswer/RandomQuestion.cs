using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomQuestion : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] QuestionList;
    public string Question;

    public static RandomQuestion Instance;
    private void Awake()
    {
        if (!Instance) Instance = this;
        Question = QuestionList[Random.Range(0, 3)];
    }
    void Start()
    {

        

       
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = Question;
    }
}
