using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FireLeft,FireRight;
    private Quaternion startRotation;
    void Start()
    {
        startRotation = transform.rotation;
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
            { FireRight.SetActive(true); }
            else
            {
                StartCoroutine(Swing());
                Invoke("StopSwing", 2f);
            }
        }
        else
        {
            if (this.GetComponent<CharacterGeneratorSingle>().input == RandomQuestion.Instance.Question.ToUpper())
            {
                FireLeft.SetActive(true);
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
                StartCoroutine(Swing());
                Invoke("StopSwing", 2f);
            }
        }

    }

    IEnumerator Swing()
    {
        float t = 0f;
        while (t < 2f)
        {
            float t1 = Mathf.PingPong(t, 2f) / 2f;
            float angle = Mathf.Lerp(-20f, 20f, t1);

            GameObject.Find("SkullImg").transform.rotation = Quaternion.Euler(0f, 0f, angle);
            t += Time.deltaTime;
            yield return null;
        }
        GameObject.Find("SkullImg").transform.rotation = startRotation;

    }

    void StopSwing()
    {
        StopCoroutine(Swing());
    }

}
