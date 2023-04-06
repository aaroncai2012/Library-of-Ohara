using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerator1 : MonoBehaviour
{
    public Canvas canvas;
    public Image charPrefab;

    public string word;
    public float offsetX;
    public float offsetY;

    [HideInInspector] public Sprite[] characters; // 0~9: 0~9; A~Z: 10~35 -> ASCII - 55

    void Start()
    {
        characters = Resources.LoadAll<Sprite>("Characters");
        word = word.ToUpper();
        switch (word.Length)
        {
            case 1:
                Character(word[0], Position.CENTER);
                break;
            case 2:
                Character(word[0], Position.LEFT);
                Character(word[1], Position.RIGHT);
                break;
            case 3:
                Character(word[0], Position.LEFT);
                Character(word[1], Position.TOPRIGHT);
                Character(word[2], Position.BASERIGHT);
                break;
            case 4:
                Character(word[0], Position.TOPLEFT);
                Character(word[1], Position.BASELEFT);
                Character(word[2], Position.TOPRIGHT);
                Character(word[3], Position.BASERIGHT);
                break;
            default:
                break;

        }
    }

    void Character(int i, Position position)
    {
        Image charImage = Instantiate(charPrefab, canvas.transform);
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
    }
}

enum Position
{
    CENTER,
    LEFT,
    RIGHT,
    TOPLEFT,
    TOPRIGHT,
    BASELEFT,
    BASERIGHT,
    BASELEFTLEFT,
    BASELEFTRIGHT,
    TOPRIGHTLEFT,
    TOPRIGHTRIGHT,
    BASERIGHTLEFT,
    BASERIGHTRIGHT
}
