using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrammarGenerator : MonoBehaviour
{
    public int generatorSeed;

    private const int sentenceOrderPossibilities = 3;
    enum sentenceOrder {
        SVO,
        SOV,
        VSO
    }
    public int currentSentenceOrder;

    private const int nounPhraseOrderPossibilities = 2;
    enum nounPhraseOrder {
        HeadFinal,
        HeadFirst
    }
    public int currentNounPhraseOrder;

    private const int negationMethodPossibilities = 4;
    enum negationMethod {
        particleBeforeVerb,
        particleAfterVerb,
        particleAtSentenceStart,
        particleAtSentenceEnd
    }
    public int currentNegationMethod;


    // Start is called before the first frame update
    void Start()
    {
        if (generatorSeed != 0) {
            Random.InitState(generatorSeed);
        }

        currentSentenceOrder = (int)Mathf.Floor(Random.value * sentenceOrderPossibilities);
        // need to check this apparently because random.value has a 1 in ten million chance of generating a 1.0
        if (currentSentenceOrder == sentenceOrderPossibilities) {
            currentSentenceOrder--;
        }

        currentNounPhraseOrder = (int)Mathf.Floor(Random.value * nounPhraseOrderPossibilities);
        if (currentNounPhraseOrder == nounPhraseOrderPossibilities) {
            currentNounPhraseOrder--;
        }

        currentNegationMethod = (int)Mathf.Floor(Random.value * negationMethodPossibilities);
        if (currentNegationMethod == negationMethodPossibilities) {
            currentNegationMethod--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
