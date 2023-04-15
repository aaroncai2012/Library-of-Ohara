using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextToSpeech : MonoBehaviour
{
    public AudioClip[] audioClips;
    public float waitTime;
    public List<AudioClip> playList = new List<AudioClip>();
    private void Start()
    {
        
    }

    private void Update()
    {
        string InputText = this.GetComponent<CharacterGenerator1>().input;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayAudioForText(InputText);
            StartCoroutine(PlayAudio());
        }
        
    }
    IEnumerator PlayAudio()
    {
        for(int i = 0; i < playList.Count; i++)
        {
            
            this.GetComponent<AudioSource>().clip = playList[i];
            this.GetComponent<AudioSource>().Play();
            if(playList[i]!=null)
                yield return new WaitForSeconds(playList[i].length);
            else
                yield return new WaitForSeconds(waitTime);
        }
        this.GetComponent<AudioSource>().clip = null;

    }


    private void PlayAudioForText(string text)
    {
        string[] words = text.Split(' ');  
        foreach (string word in words)
        {
            if (string.IsNullOrEmpty(word))
                continue;

            char firstLetter = word[0];
            AudioClip clip = null;
            if (firstLetter.Equals(","))
            {
                clip = null;
            }
            else
            {
                clip = GetAudioClipForLetter(firstLetter);
            }
            
            if (clip != null)
            {
                playList.Add(clip);
                playList.Add(null);
            }
                
        }
    }

    private AudioClip GetAudioClipForLetter(char letter)
    {
        foreach (AudioClip clip in audioClips)
        {
            if (clip.name.StartsWith(letter.ToString(), System.StringComparison.OrdinalIgnoreCase))
                return clip;
        }
        return null;
    }
}