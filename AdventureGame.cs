using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {

    [SerializeField] Text textComponent;//the actual UI text component in the game, where we will put the text. The serliazed field lets us select the UI text comput and initilize to textComp.
    [SerializeField] Text textComponent2;//subtitles
    [SerializeField] State startingState;//the first state of the story
    [SerializeField] Image imageComponent;
    [SerializeField] Image whatWouldYouDo;
    [SerializeField] AudioSource soundEffect;
    [SerializeField] AudioSource soundEffect2;
    [SerializeField] AudioSource musicEffect;
    [SerializeField] AudioSource voiceEffect;
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;

    State state;//allows us to access the state class, and this would be the current state of the story
    Boolean repeatMusic;
    Boolean repeatDoor;
    Boolean waitVoice = true;

	// Use this for initialization
	void Start () {
        button1.SetActive(false);
        button2.SetActive(false);
        state = startingState;//what state we are currently in
        textComponent.text = state.GetStateStory();//getting and setting the initial text into the game. Displaying the text in the game
        imageComponent.color = new Color(1, 1, 1, 1);
        imageComponent.sprite = state.GetSprite();
        soundEffect.clip = state.GetSound();
        musicEffect.clip = state.GetMusic();
        voiceEffect.clip = state.GetVoice();
        soundEffect.clip = state.GetSound2();
        repeatMusic = true;
        repeatDoor = true;


    }
	
	// Update is called once per frame
	void Update () {
        ManageState();
		
	}

    private IEnumerator Voice1()
    {
        waitVoice = false;
        yield return new WaitForSeconds(2.0f);///wait time
        textComponent2.text = state.GetSubtitles();
        voiceEffect.clip = state.GetVoice();
        soundEffect2.clip = state.GetSound2();
        voiceEffect.volume = 1f;
        voiceEffect.Play();
        yield return new WaitForSeconds(voiceEffect.clip.length);
        soundEffect2.Play();
        textComponent2.text = state.GetStateStory();
        imageComponent.sprite = state.GetSprite2();
        musicEffect.clip = state.GetMusic();
        musicEffect.volume = 0.05f;
        musicEffect.PlayDelayed(0.5f);
        button1.SetActive(true);
        button2.SetActive(true);
        //button1.GetComponentInChildren<Text>().text = " Hello";
        
    }

    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(voiceEffect.clip.length);
    }

    Boolean part1_1 = true;
    Boolean part1_2 = true;
    Boolean part1_3 = true;
    Boolean part1_4 = true;
    private IEnumerator Waiting1()
    {
        if (part1_1)
        {
        button1.SetActive(false);
        button2.SetActive(false);
        voiceEffect.clip = state.GetvNaniKore();
        imageComponent.sprite = state.GetSprite3();
        textComponent2.color = new Color(0, 0, 0);
        textComponent2.text = "What? Did you hit your head? This is our home.";
        voiceEffect.Play();
        yield return new WaitForSeconds(voiceEffect.clip.length);

        textComponent2.text = "";
        imageComponent.sprite = state.GetSprite2();
        button1.GetComponentInChildren<Text>().text = " I live here?";
        button2.GetComponentInChildren<Text>().text = " No way! Let me out!";
        button1.SetActive(true);
        button2.SetActive(true);
            part1_1 = false;
            part2_1 = false;
        } else if (part1_2)
        {
            button1.SetActive(false);
            button2.SetActive(false);
            voiceEffect.clip = state.GetvUnn();
            imageComponent.sprite = state.GetSprite3();
            textComponent2.color = new Color(0, 0, 0);
            textComponent2.text = "Yeah! With your sister!";
            voiceEffect.Play();
            yield return new WaitForSeconds(voiceEffect.clip.length);
            voiceEffect.clip = state.GetvMa();
            textComponent2.text = "Well then, Brother I have a request. Will you help me out?";
            voiceEffect.Play();
            yield return new WaitForSeconds(voiceEffect.clip.length);

            textComponent2.text = "";
            imageComponent.sprite = state.GetSprite2();
            button1.GetComponentInChildren<Text>().text = " YES";
            button2.GetComponentInChildren<Text>().text = " NO";
            button1.SetActive(true);
            button2.SetActive(true);
            part1_3 = false;
            part1_2 = false;
            part2_1 = false;
            part2_2 = false;
            part2_3 = false;
        }
        else if (part1_3)
        {
            button1.SetActive(false);
            button2.SetActive(false);
            voiceEffect.clip = state.GetvHehOnii();
            imageComponent.sprite = state.GetSprite3();
            textComponent2.color = new Color(0, 0, 0);
            textComponent2.text = "Heheh! You're my B-R-O-T-H-E-R";
            voiceEffect.Play();
            yield return new WaitForSeconds(voiceEffect.clip.length);
            yield return new WaitForSeconds(0.5f);
            voiceEffect.clip = state.GetvMa();
            textComponent2.text = "Well then, Brother I have a request. Will you help me out?";
            voiceEffect.Play();
            yield return new WaitForSeconds(voiceEffect.clip.length);

            textComponent2.text = "";
            imageComponent.sprite = state.GetSprite2();
            button1.GetComponentInChildren<Text>().text = " YES";
            button2.GetComponentInChildren<Text>().text = " NO";
            button1.SetActive(true);
            button2.SetActive(true);
            part1_3 = false;
            part1_2 = false;
            part2_1 = false;
            part2_2 = false;
            part2_3 = false;
        }else if (part1_4){
            button1.SetActive(false);
            button2.SetActive(false);
            voiceEffect.clip = state.GetvArigatou();
            imageComponent.sprite = state.GetSprite3();
            textComponent2.color = new Color(0, 0, 0);
            textComponent2.text = "Thank You Onii-chan. To tell you the truth.... I...I...I...want to..";
            voiceEffect.Play();
            yield return new WaitForSeconds(voiceEffect.clip.length);
            textComponent2.color = new Color(255, 0, 0);
            voiceEffect.clip = state.GetvNiku();
            soundEffect.clip = state.GetSound3();
            musicEffect.Stop();
            soundEffect.Play();
            voiceEffect.PlayDelayed(0.7f);
            imageComponent.sprite = state.GetSprite4();
            textComponent2.text = "EAT YOUR FLESH!!! JUST A SMALL BITE OKAY!?! OKAAAY!?!";
            yield return new WaitForSeconds(voiceEffect.clip.length+3);

            voiceEffect.clip = state.GetvJyaNee();
            imageComponent.sprite = state.GetSprite3();
            textComponent2.color = new Color(0, 0, 0);
            textComponent2.text = "Oh my! My monster came out! Hehe! Well then, See yaaa later!";
            voiceEffect.Play();
            yield return new WaitForSeconds(voiceEffect.clip.length);
        
            textComponent2.text = "";
            imageComponent.sprite = state.GetSprite2();
            yield return new WaitForSeconds(3);
            soundEffect2.Play();
            imageComponent.sprite = state.GetSprite();
            yield return new WaitForSeconds(2);
            soundEffect2.Play();
            imageComponent.sprite = state.GetSprite5();
        }


        
    }

    Boolean part2_1 = true;
    Boolean part2_2 = true;
    Boolean part2_3 = true;
    Boolean part2_4 = true;
    private IEnumerator Waiting2()
    {
        if (part2_1)
        {
        button1.SetActive(false);
        button2.SetActive(false);
        voiceEffect.clip = state.GetvEh();
        imageComponent.sprite = state.GetSprite3();
        textComponent2.color = new Color(0, 0, 0);
        textComponent2.text = "Ehhh are you okay Onii-Chan? I'm your little sister!";
        voiceEffect.Play();
        yield return new WaitForSeconds(voiceEffect.clip.length);

        textComponent2.text = "";
        imageComponent.sprite = state.GetSprite2();
        button1.GetComponentInChildren<Text>().text = " O-Onii- Chan?";
        button2.GetComponentInChildren<Text>().text = " Uh.. what?";
        button1.SetActive(true);
        button2.SetActive(true);
        part2_1 = false;
        part2_2 = false;
        part1_1 = false;
        part1_2 = false;

        }
        else if (part2_2)
        {
            button1.SetActive(false);
            button2.SetActive(false);
            voiceEffect.clip = state.GetvChotto();
            imageComponent.sprite = state.GetSprite3();
            textComponent2.color = new Color(0, 0, 0);
            textComponent2.text = "You're so weird Onii-chan~";
            voiceEffect.Play();
            yield return new WaitForSeconds(voiceEffect.clip.length);
            voiceEffect.clip = state.GetvMa();
            textComponent2.text = "Well then, Brother I have a request. Will you help me out?";
            voiceEffect.Play();
            yield return new WaitForSeconds(voiceEffect.clip.length);

            textComponent2.text = "";
            imageComponent.sprite = state.GetSprite2();
            button1.GetComponentInChildren<Text>().text = " YES";
            button2.GetComponentInChildren<Text>().text = " NO";
            button1.SetActive(true);
            button2.SetActive(true);
            part1_2 = false;
            part1_3 = false;
            part2_1 = false;
            part2_2 = false;
            part2_3 = false;
        }
        else if (part2_3)
        {
            //fix here
            button1.SetActive(false);
            button2.SetActive(false);
            voiceEffect.clip = state.GetvHehOnii();
            imageComponent.sprite = state.GetSprite3();
            textComponent2.color = new Color(0, 0, 0);
            textComponent2.text = "Heheh! You're my B-R-O-T-H-E-R";
            voiceEffect.Play();
            yield return new WaitForSeconds(voiceEffect.clip.length);
            yield return new WaitForSeconds(0.5f);
            voiceEffect.clip = state.GetvMa();
            textComponent2.text = "Well then, Brother I have a request. Will you help me out?";
            voiceEffect.Play();
            yield return new WaitForSeconds(voiceEffect.clip.length);

            textComponent2.text = "";
            imageComponent.sprite = state.GetSprite2();
            button1.GetComponentInChildren<Text>().text = " YES";
            button2.GetComponentInChildren<Text>().text = " NO";
            button1.SetActive(true);
            button2.SetActive(true);
            part1_2 = false;
            part1_3 = false;
            part2_1 = false;
            part2_2 = false;
            part2_3 = false;
        }else if (part2_4)
        {
            button1.SetActive(false);
            button2.SetActive(false);
            voiceEffect.clip = state.GetvOnegai();
            imageComponent.sprite = state.GetSprite3();
            textComponent2.color = new Color(0, 0, 0);
            textComponent2.text = "Pleeease, Onii-chan!!";
            voiceEffect.Play();
            yield return new WaitForSeconds(voiceEffect.clip.length);

            textComponent2.text = "";
            imageComponent.sprite = state.GetSprite2();
            button1.GetComponentInChildren<Text>().text = "YES";
            button2.GetComponentInChildren<Text>().text = " YES";
            button1.SetActive(true);
            button2.SetActive(true);
            part1_2 = false;
            part1_3 = false;
            part2_1 = false;
            part2_2 = false;
            part2_3 = false;
            part2_4 = false;
        }
        else
        {
            button1.SetActive(false);
            button2.SetActive(false);
            voiceEffect.clip = state.GetvArigatou();
            imageComponent.sprite = state.GetSprite3();
            textComponent2.color = new Color(0, 0, 0);
            textComponent2.text = "Thank You Onii-chan. To tell you the truth.... I...I...I...want to..";
            voiceEffect.Play();
            yield return new WaitForSeconds(voiceEffect.clip.length);
            textComponent2.color = new Color(255, 0, 0);
            voiceEffect.clip = state.GetvNiku();
            soundEffect.clip = state.GetSound3();
            musicEffect.Stop();
            soundEffect.Play();
            voiceEffect.PlayDelayed(0.7f);
            imageComponent.sprite = state.GetSprite4();
            textComponent2.text = "EAT YOUR FLESH!!! JUST A SMALL BITE OKAY!?! OKAAAY!?!";
            yield return new WaitForSeconds(voiceEffect.clip.length + 3);

            voiceEffect.clip = state.GetvJyaNee();
            imageComponent.sprite = state.GetSprite3();
            textComponent2.color = new Color(0, 0, 0);
            textComponent2.text = "Oh my! My monster came out! Hehe! Well then, See yaaa later!";
            voiceEffect.Play();
            yield return new WaitForSeconds(voiceEffect.clip.length);

            textComponent2.text = "";
            imageComponent.sprite = state.GetSprite2();
            yield return new WaitForSeconds(3);
            soundEffect2.Play();
            imageComponent.sprite = state.GetSprite();
            yield return new WaitForSeconds(2);
            soundEffect2.Play();
            imageComponent.sprite = state.GetSprite5();
        }


    }


    public void Button1Call()
    {
        StartCoroutine(Waiting1());
        }



    public void Button2Call()
    { 
        StartCoroutine(Waiting2());

    }




    private void ManageState()
    {
        var nextStates = state.GetNextStates();//var is a shortcut, since you know its returning whatever
        String name = state.GetStateName();
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(nextStates.Length >= 1)
            {
            state = nextStates[0];
            if (name != "Afteropen" && name != "After open 2")
            {
                soundEffect.clip = state.GetSound();
                soundEffect.Play();
            }
            else if (repeatDoor)
            {
                soundEffect.clip = state.GetSound();
                soundEffect.Play();
                repeatDoor = false;
            }
            }




        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(nextStates.Length >= 2)
            {
            state = nextStates[1];
            soundEffect.clip = state.GetSound();
            soundEffect.Play();
            }



        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if(nextStates.Length == 3)
            {
            state = nextStates[2];
            soundEffect.clip = state.GetSound();
            soundEffect.Play();
            }



        }

        

        if (repeatMusic && name == "Afteropen")
        {
            musicEffect.clip = state.GetMusic();
            musicEffect.PlayDelayed(2);
            repeatMusic = false;
        }


        if (name == "Closer final")
        {
      
            musicEffect.Stop();


            imageComponent.rectTransform.sizeDelta = new Vector2(1920, 1080);//change the width and height of the image
            imageComponent.rectTransform.localPosition = new Vector3(0, 0, 0);//change the position of the image
            whatWouldYouDo.sprite = state.GetTextSprite();//changes to WHAT WOULD YOU DO image
        }

        if (name == "one")
        {
            whatWouldYouDo.sprite = state.GetTextSprite();
            if (waitVoice)
            {
                StartCoroutine(Voice1());
            }
        }



        if(!(name == "one"))
        {
        imageComponent.color = new Color(1, 1, 1, 1);//changing image and story text
        imageComponent.sprite = state.GetSprite();
        textComponent.text = state.GetStateStory();
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
