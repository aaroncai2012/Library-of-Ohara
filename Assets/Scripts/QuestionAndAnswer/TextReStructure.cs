using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine.UI;

public class TextReStructure : MonoBehaviour
{
    // Start is called before the first frame update
    public int Sentence = 1;

    public int sentenceOrder;
    public int nounPhraseOrder;
    public int negationOrder;
    public static TextReStructure Instance;
    void Awake()
    {
        if (!Instance) Instance = this;

        sentenceOrder = this.GetComponent<GrammarGenerator>().currentSentenceOrder;
        nounPhraseOrder = this.GetComponent<GrammarGenerator>().currentNounPhraseOrder;
        negationOrder = this.GetComponent<GrammarGenerator>().currentNegationMethod;

        var subject = "lord";
        var verb = "gave";
        string Objects = "";
        string subclauseSubject = "", subclauseVerb = "", subclauseObject = "";
        string sentence = "";

        this.GetComponent<CharacterGenerator1>().input = "";

        for (int i = 1; i <= 3; i++)
        {
            switch (i)
            {
                case 1:
                    subclauseSubject = "many things";
                    subclauseVerb = "";
                    subclauseObject = "";
                    break;

                case 2:
                    subclauseSubject = "Rivers";
                    subclauseVerb = "Catch";
                    subclauseObject = "Fish";
                    break;

                case 3:
                    subclauseSubject = "Fire";
                    subclauseVerb = "Cook";
                    subclauseObject = "Fish";
                    break;
            }

            if (nounPhraseOrder == 0)
            {
                Objects = subclauseObject + " " + subclauseVerb + " " + subclauseSubject;
                if (i == 1)
                    Objects = subclauseSubject;
            }
            else
            {
                Objects = subclauseSubject + " " + subclauseVerb + " " + subclauseObject;
                if (i == 1)
                    Objects = subclauseSubject;
            }

            if (sentenceOrder == 1)
            {
                sentence = subject + " " + verb + " " + Objects;
            }
            else if (sentenceOrder == 2)
            {
                sentence = subject + " "  + Objects + " " + verb ;
            }
            else
            {
                sentence = verb + " " + subject + " " + Objects ;
            }

            if (i != 3)
                this.GetComponent<CharacterGenerator1>().input += sentence + " " + "N" + " ";
            else
                this.GetComponent<CharacterGenerator1>().input += sentence + " " + "N";
        }

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddFire()
    {
        var subject = "followers";
        var verb = "throw";
        string Objects = "";
        string subclauseSubject = "Offerings", subclauseVerb = "lord", subclauseObject = "fire";
        string sentence = "";

        if (nounPhraseOrder == 0)
        {
            Objects = subclauseObject + " " + subclauseVerb + " " + subclauseSubject;
        }
        else
        {
            Objects = subclauseSubject + " " + subclauseVerb + " " + subclauseObject;
        }

        if (sentenceOrder == 1)
        {
            sentence = subject + " " + verb + " " + Objects;
        }
        else if (sentenceOrder == 2)
        {
            sentence = subject + " " + Objects + " " + verb;
        }
        else
        {
            sentence = verb + " " + subject + " " + Objects;
        }

        this.GetComponent<CharacterGenerator1>().input += " " + sentence + " " + "N";

        GameObject.Find("EnglishText").GetComponent<Text>().text += "Followers throw offerings to the lord into fire.";
        this.GetComponent<CharacterGenerator1>().Start();
        PossibleAnswerList.Instance.ChangeToLordAnswerList();
    }
    public void AddFish()
    {
        var subject = "";
        var subjectNoun = "river";
        var subjectAdjective = "near the mountain";
        var verb = "has";
        string Objects = "";
        string subclauseNoun = "fish", subclauseAdjective = "many";
        string sentence = "";

        if (negationOrder == 0)
        {
            subject = subjectAdjective + " " + subjectNoun;
            Objects = subclauseAdjective + " " + subclauseNoun;
            sentence = subject + " " + verb + " " + Objects;

        }
        else if (negationOrder == 1)
        {
            subject = subjectAdjective + " " + subjectNoun;
            Objects = subclauseAdjective + " " + subclauseNoun;
            sentence = Objects + " " + verb + " " + subject;
        }
        else if (negationOrder == 2)
        {
            subject = subjectNoun + " " + subjectAdjective;
            Objects = subclauseNoun + " " + subclauseAdjective;
            sentence = subject + " " + verb + " " + Objects;
        }
        else
        {
            subject = subjectNoun + " " + subjectAdjective;
            Objects = subclauseNoun + " " + subclauseAdjective;
            sentence = Objects + " " + verb + " " + subject;
        }
            this.GetComponent<CharacterGenerator1>().input += " " + sentence + " " + "N";

        GameObject.Find("EnglishText").GetComponent<Text>().text += "The river near the mountain has many fish.";
        this.GetComponent<CharacterGenerator1>().Start();
        PossibleAnswerList.Instance.ChangeToRiverAnswerList();
    }

    public void AddRiver()
    {
        var subject = "";
        var subjectNoun = "river";
        var subjectAdjective = "near the mountain";
        var verb = "has";
        string Objects = "";
        string subclauseNoun = "fish", subclauseAdjective = "many";
        string sentence = "";

        if (negationOrder == 0)
        {
            subject = subjectAdjective + " " + subjectNoun;
            Objects = subclauseAdjective + " " + subclauseNoun;
            sentence = subject + " " + verb + " " + Objects;

        }
        else if (negationOrder == 1)
        {
            subject = subjectAdjective + " " + subjectNoun;
            Objects = subclauseAdjective + " " + subclauseNoun;
            sentence = Objects + " " + verb + " " + subject;
        }
        else if (negationOrder == 2)
        {
            subject = subjectNoun + " " + subjectAdjective;
            Objects = subclauseNoun + " " + subclauseAdjective;
            sentence = subject + " " + verb + " " + Objects;
        }
        else
        {
            subject = subjectNoun + " " + subjectAdjective;
            Objects = subclauseNoun + " " + subclauseAdjective;
            sentence = Objects + " " + verb + " " + subject;
        }
        this.GetComponent<CharacterGenerator1>().input += " " + sentence + " " + "N";

        GameObject.Find("EnglishText").GetComponent<Text>().text += "The river near the mountain has many fish.";
        this.GetComponent<CharacterGenerator1>().Start();
        PossibleAnswerList.Instance.ChangeToFishAnswerList();
    }
}
