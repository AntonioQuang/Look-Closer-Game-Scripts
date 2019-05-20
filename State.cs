using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject  {
    //each individual state 
    [TextArea (10,14)][SerializeField]string storyText;//information inside the scriptable object
    [SerializeField] Sprite picture;
    [SerializeField] Sprite picture2;
    [SerializeField] Sprite picture3;
    [SerializeField] Sprite picture4;
    [SerializeField] Sprite picture5;
    [SerializeField]State[] nextStates;	//When its serialize, you can dynamically add assests to it in unity itself
    [SerializeField]string stateName;
    [SerializeField] Sprite textPicture;
    [SerializeField] AudioClip sound;
    [SerializeField] AudioClip sound2;
    [SerializeField] AudioClip sound3;
    [SerializeField] AudioClip music;
    [SerializeField] AudioClip voice;
    [SerializeField] AudioClip vNaniKore;
    [SerializeField] AudioClip vEh;
    [SerializeField] AudioClip vUnn;
    [SerializeField] AudioClip vMa;
    [SerializeField] AudioClip vChotto;
    [SerializeField] AudioClip vHehOnii;
    [SerializeField] AudioClip vOnegai;
    [SerializeField] AudioClip vArigatou;
    [SerializeField] AudioClip vNiku;
    [SerializeField] AudioClip vJyaNee;
    [TextArea(10, 14)] [SerializeField] string subtitles;

    public string GetStateStory()
    {
        return storyText;//returns the story of the string of the  state 
    }

    public string GetSubtitles()
    {
        return subtitles;
    }

    public string GetStateName()
    {
        return stateName;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public Sprite GetSprite()
    {
        return picture;
    }
    public Sprite GetSprite2()
    {
        return picture2;
    }

    public Sprite GetSprite3()
    {
        return picture3;
    }

    public Sprite GetSprite4()
    {
        return picture4;
    }

    public Sprite GetSprite5()
    {
        return picture5;
    }

    public Sprite GetTextSprite()
    {
        return textPicture;
    }

    public AudioClip GetSound()
    {
        return sound;
    }

    public AudioClip GetSound2()
    {
        return sound2;
    }

    public AudioClip GetSound3()
    {
        return sound3;
    }

    public AudioClip GetMusic()
    {
        return music;
    }

    public AudioClip GetVoice()
    {
        return voice;
    }

    public AudioClip GetvNaniKore()
    {
        return vNaniKore;
    }

    public AudioClip GetvEh()
    {
        return vEh;
    }

    public AudioClip GetvUnn()
    {
        return vUnn;
    }

    public AudioClip GetvMa()
    {
        return vMa;
    }

    public AudioClip GetvChotto()
    {
        return vChotto;
    }

    public AudioClip GetvHehOnii()
    {
        return vHehOnii;
    }

    public AudioClip GetvOnegai()
    {
        return vOnegai;
    }

    public AudioClip GetvArigatou()
    {
        return vArigatou;
    }

    public AudioClip GetvNiku()
    {
        return vNiku;
    }

    public AudioClip GetvJyaNee()
    {
        return vJyaNee;
    }



}
