using Assets.Project.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternManagement : MonoBehaviour {

    public Text TextOutput;
    private static string textPattern;
	public void OnClick(string direction)
    {
        TextOutput.text += direction+ ",";
        textPattern = TextOutput.text;
    }

    public static List<CirclePattern> GetPatterns()
    {
        List<CirclePattern> patterns = new List<CirclePattern>();
        List<string> tempListPattern = new List<string>(textPattern.Split(',','-'));
        for (int i = 0; i < tempListPattern.Count-1; i += 2)
        {
            patterns.Add(new CirclePattern(tempListPattern[i], tempListPattern[i + 1]));
        }
        return patterns;
    }
}
