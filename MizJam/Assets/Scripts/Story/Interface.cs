﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public TextMeshPro speakerComponent;
    public TextMeshPro textComponent;

    public GameObject[] icons;
    public GameObject arrow;

    public DialogueData[] story;
    int currentDialogue;

    // Start is called before the first frame update
    void Start()
    {
        currentDialogue = 0;

        for (int i = 0; i < 4; i++) icons[i].SetActive(false);
        arrow.SetActive(false);

        updateDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked");
            updateDialogue();
        }
    }

    void nextDialogue()
    {
        currentDialogue++;
        updateDialogue();
    }

    void setIcon(int index)
    {
        for(int i = 0; i < 4; i++)
        {
            if (i == index) icons[i].SetActive(true);
            else            icons[i].SetActive(false);
        }
    }

    void updateDialogue()
    {
        updateSpeaker(story[currentDialogue].speaker);
        string nextBlock = story[currentDialogue].getNextBlock();
        if (nextBlock == "") nextDialogue();
        else updateText(nextBlock);
    }

    void updateSpeaker(string name)
    {
        switch (name)
        {
            case "":
                arrow.SetActive(false);
                break;

            case "Anger":
            case "anger":
            case "ang":
                speakerComponent.color = new Color(255 / 255.0F, 88 / 255.0F, 88 / 255.0F);
                speakerComponent.text = "Anger Core";
                setIcon(0);
                arrow.SetActive(true);
                break;

            case "Curiosity":
            case "curiosity":
            case "cur":
                speakerComponent.color = new Color(250 / 255.0F, 227 / 255.0F, 81 / 255.0F);
                speakerComponent.text = "Curiosity Core";
                setIcon(1);
                arrow.SetActive(true);
                break;

            case "Intelligence":
            case "intelligence":
            case "int":
                speakerComponent.color = new Color(47 / 255.0F, 99 / 255.0F, 255 / 255.0F);
                speakerComponent.text = "Intelligence Core";
                setIcon(2);
                arrow.SetActive(true);
                break;

            case "Morality":
            case "morality":
            case "mor":
                speakerComponent.color = new Color(194 / 255.0F, 30 / 255.0F, 255 / 255.0F);
                speakerComponent.text = "Morality Core";
                setIcon(3);
                arrow.SetActive(true);
                break;
        }
    }

    void updateText(string text)
    {
        textComponent.text = text;
    }
}