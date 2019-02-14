using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{

    DialogueParser parser;

    public string dialogue;
    public new string name;
    public Sprite pose;
    int lineNum;
    public int endLine;

    public GUIStyle customStyle, customStyleName;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = "";
        parser = GameObject.Find("DialogueParserObj").GetComponent<DialogueParser>();
        lineNum = 0;
        ResetImages();

        name = parser.GetName(lineNum);
        dialogue = parser.GetSpeech(lineNum);
        pose = parser.GetPose(lineNum);
        endLine = parser.finalLine();

        DisplayImages();

        lineNum++;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ResetImages();

            name = parser.GetName(lineNum);
            dialogue = parser.GetSpeech(lineNum);
            pose = parser.GetPose(lineNum);

            DisplayImages();

            lineNum++;
        }
    }

    void ResetImages()
    {
        if(name != "")
        {
            GameObject character = GameObject.Find(name);
            SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
            currSprite.sprite = null;
        }
    }

    void DisplayImages()
    {
        if(name != "")
        {
            GameObject character = GameObject.Find(name);
            SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
            currSprite.sprite = pose;
        }
    }

    void OnGUI()
    {
        dialogue = GUI.TextField(new Rect(0, 850, 1300, 150), dialogue, customStyle);
        name = GUI.TextField(new Rect(0, 800, 1300, 50), name, customStyleName);
    }
}
