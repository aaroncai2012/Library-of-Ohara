using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class CharacterGeneratorSingle : MonoBehaviour
{
    public Image charPrefab;

    [TextAreaAttribute] public string input;
    public float offsetX;
    public float offsetY;
    public float wordSpacing;
    public float lineSpacing;

    public int wordNumPerLine;
    [HideInInspector] public Sprite[] characters; // 0~9: 0~9; A~Z: 10~35 -> ASCII - 55

    public void Start()
    {
        if (transform.childCount != 0)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        characters = Resources.LoadAll<Sprite>("Characters");
        input = new string(input.Where(c => !char.IsPunctuation(c)).ToArray());
        input = input.ToUpper();
        string[] words = input.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            Vector2 center = Vector2.zero;
            switch (words[i].Length)
            {
                case 1:
                    Character(words[i][0], Position.CENTER, center);
                    break;
                case 2:
                    Character(words[i][0], Position.LEFT, center);
                    Character(words[i][1], Position.RIGHT, center);
                    break;
                case 3:
                    Character(words[i][0], Position.LEFT, center);
                    Character(words[i][1], Position.TOPRIGHT, center);
                    Character(words[i][2], Position.BASERIGHT, center);
                    break;
                case 4:
                    Character(words[i][0], Position.TOPLEFT, center);
                    Character(words[i][1], Position.BASELEFT, center);
                    Character(words[i][2], Position.TOPRIGHT, center);
                    Character(words[i][3], Position.BASERIGHT, center);
                    break;
                default:
                    Character(words[i][0], Position.TOPLEFT, center);
                    Character(words[i].Length % 10, Position.BASELEFT, center);
                    int factor = GetFactor(words[i].Length);
                    Character(words[i][factor], Position.TOPRIGHT, center);
                    Character(words[i][factor * 2], Position.BASERIGHT, center);
                    break;
            }
        }
    }

    void Character(int i, Position position, Vector2 center)
    {
        Image charImage = Instantiate(charPrefab, transform);
        i = i > 9 ? i - 55 : i;
        charImage.sprite = characters[i];
        switch (position)
        {
            case Position.CENTER:
                break;
            case Position.LEFT:
                charImage.rectTransform.sizeDelta = new Vector2(72, 93);
                charImage.rectTransform.anchoredPosition = new Vector2(-offsetX, 0);
                break;
            case Position.RIGHT:
                charImage.rectTransform.sizeDelta = new Vector2(72, 93);
                charImage.rectTransform.anchoredPosition = new Vector2(offsetX, 0);
                break;
            case Position.TOPLEFT:
                charImage.rectTransform.sizeDelta = new Vector2(50, 50);
                charImage.rectTransform.anchoredPosition = new Vector2(-offsetX, offsetY);
                break;
            case Position.TOPRIGHT:
                charImage.rectTransform.sizeDelta = new Vector2(50, 50);
                charImage.rectTransform.anchoredPosition = new Vector2(offsetX, offsetY);
                break;
            case Position.BASELEFT:
                charImage.rectTransform.sizeDelta = new Vector2(50, 50);
                charImage.rectTransform.anchoredPosition = new Vector2(-offsetX, -offsetY);
                break;
            case Position.BASERIGHT:
                charImage.rectTransform.sizeDelta = new Vector2(50, 50);
                charImage.rectTransform.anchoredPosition = new Vector2(offsetX, -offsetY);
                break;
        }
        charImage.rectTransform.anchoredPosition += center;
    }

    int GetFactor(int num)
    {
        num = (int)Mathf.Ceil((float)num / 2);
        int res = 2;
        for (int i = 2; i < num; i++)
        {
            bool isPrimeNum = true;
            for (int j = 2; j < i - 1; j++)
            {
                if (i % j == 0)
                {
                    isPrimeNum = false;
                    break;
                }
            }
            if (isPrimeNum)
            {
                res = Mathf.Max(res, i);
            }
        }
        return res;
    }

    public void MakeWordsOnClick()
    {
        Start();
    }
}


