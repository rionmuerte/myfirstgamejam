using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class DialogueParser : MonoBehaviour
{

    List<DialogueLine> lines;
    List<Sprite> images;

    struct DialogueLine
    {
        public string name;
        public string speech;
        public string poseColin;
        public string poseAnais;
        public string poseJon;

        public DialogueLine(string n, string s, string pC, string pA, string pJ)
        {
            name = n;
            speech = s;
            poseColin = pC;
            poseAnais = pA;
            poseJon = pJ;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        string file = "Dialogue.txt";
        lines = new List<DialogueLine>();
        LoadDialogue(file);
        images = new List<Sprite>();
        LoadImages();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int finalLine()
    {
        return lines.Count;
    }

    void LoadImages()
    {
        for(int i = 0; i < lines.Count; i++)
        {
            string pose = "";
            if (lines[i].name == "Colin")
            {
                pose = lines[i].poseColin;
            }
            else if (lines[i].name == "Anais")
            {
                pose = lines[i].poseAnais;
            }
            else if (lines[i].name == "Jon")
            {
                pose = lines[i].poseJon;
            }
            string imageName = lines[i].name + pose;
            Sprite image = (Sprite) Resources.Load("PNG/" + lines[i].name + "/" + imageName, typeof(Sprite));
            //if(!images.Contains (image))
            //{
            //    images.Add(image);
            //}
            images.Add(image);
        }
    }

    public string GetName(int lineNumber)
    {
        if(lineNumber < lines.Count)
            return lines[lineNumber].name;
            
        return "";
    }

    public string GetSpeech(int lineNumber)
    {
        if(lineNumber < lines.Count)
            return lines[lineNumber].speech;
            
        return "";
    }

    public Sprite GetPose(int lineNumber)
    {
        if(lineNumber < lines.Count)
            return images[lineNumber];
            
        return null;
    }

    // Function to Load the Dialogues
    void LoadDialogue(string filename)
    {
        string file = "Assets/Resources/" + filename;
        string line;
        StreamReader r = new StreamReader(file);

        using(r)
        {
            do
            {
                line = r.ReadLine();
                if(line != null)
                {
                    string[] line_values = SplitCsvLine(line); // Splits a CSV row
                    DialogueLine line_entry = new DialogueLine(line_values[0], line_values[1], line_values[2], line_values[3], line_values[4]);
                    lines.Add(line_entry);
                }
            } while (line != null);
            r.Close();
        }
    }

    // Link to the solution for a CSV ReGex
    // https://answers.unity.com/questions/144200/are-there-any-csv-reader-for-unity3d-without-needi.html?sort=oldest
    private string[] SplitCsvLine(string line)
    {
        string pattern = @"
        # Match one value in valid CSV string.
        (?!\s*$)                                      # Don't match empty last value.
        \s*                                           # Strip whitespace before value.
        (?:                                           # Group for value alternatives.
            '(?<val>[^'\\]*(?:\\[\S\s][^'\\]*)*)'       # Either $1: Single quoted string,
        | ""(?<val>[^""\\]*(?:\\[\S\s][^""\\]*)*)""   # or $2: Double quoted string,
        | (?<val>[^,'""\s\\]*(?:\s+[^,'""\s\\]+)*)    # or $3: Non-comma, non-quote stuff.
        )                                             # End group of value alternatives.
        \s*                                           # Strip whitespace after value.
        (?:,|$)                                       # Field ends on comma or EOS.
        ";
        string[] values = (from Match m in Regex.Matches(line, pattern, 
            RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline)
            select m.Groups[1].Value).ToArray();
        return values;        
    }

}
