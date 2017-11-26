using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternManagement : MonoBehaviour {

    public Text TextOutput;
    private static string textPattern;
	public void OnClick(string direction)
    {
        TextOutput.text += direction+ " ";
        textPattern = TextOutput.text;
    }
    public static string getPattern()
    {
        return textPattern;
    }
}
