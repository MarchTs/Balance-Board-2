using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class BoxInsert : MonoBehaviour {

	public writerfile1 wt;
    public setGame setGame;
    public Dropdown dropdown1;
    public Dropdown dropdown2;
    public Dropdown dropdown3;
	public Dropdown dropdown4;
	public Dropdown dropdown5;
	public Dropdown dropdown6;
    public Toggle[] Choose = new Toggle[27]; 
	public Toggle Sort, Randomm;
    public InputField InputField;
    public string show;
	private List<string[]> rowData = new List<string[]>();
    private List<string> Zone = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" };
    public string SelectZone1,SelectZone2,SelectZone3;
	public Text[] showPosCount = new Text[37];
    public int TotalBox;
    public int[,] data = new int[13,3];
    public int[] dex1 = new int[3];
	public int[] dex2 = new int[3];


    void Start ()
    {
        PopulateList();
       
	}
	public void showCount()
	{
		int counut = 0;
		for (int i = 0; i <= 12; i++)
		{
			for (int j = 0; j <= 2; j++)
			{
				if (data [i, j] > 0) {
					showPosCount [counut].text = data [i, j].ToString ();
				} 

				counut++;
			}
		}
	}
    void PopulateList()
    {
        dropdown1.AddOptions(Zone);
        dropdown2.AddOptions(Zone);
        dropdown3.AddOptions(Zone);
		dropdown4.AddOptions(Zone);
		dropdown5.AddOptions(Zone);
		dropdown6.AddOptions(Zone);
    }
    public void DropdownIndexChangel(int index)
    {
        dex1[0] = index;
    }
    public void DropdownIndexChangell(int index)
    {
        dex1[1] = index;
    }
    public void DropdownIndexChangelll(int index)
    {
        dex1[2] = index;
    }
	public void DropdownIndexChangej(int index)
	{
		dex2[0] = index;
	}
	public void DropdownIndexChangejj(int index)
	{
		dex2[1] = index;
	}
	public void DropdownIndexChangejjj(int index)
	{
		dex2[2] = index;
	}

    public int sendZone()
    {
		sendZone1 ();
		if (TotalBox < 50) {
			int nine = 0;
			for (int i = 1; i <= 3; i++) {
				for (int j = 1; j <= 3; j++) {
					if (Choose [nine].isOn) {
						InputField = GameObject.Find ("InputField" + (i) + (j)).GetComponent<InputField> ();
						show = InputField.text;
						TotalBox = TotalBox + int.Parse (show);
						if (TotalBox < 50) {
							data [dex1 [i - 1], j - 1] = data [dex1 [i - 1], j - 1] + int.Parse (show);
						}
					}
					nine++;
				}
			}
		}

        if (TotalBox > 50)
        {
            return 321;
        }
		if(TotalBox<=50)
		{
			
			showCount ();
		}
        
        
        return TotalBox;
    }

	public void sendZone1()
	{

		int nine = 9;
		for (int i = 1; i <=3 ; i++)
		{
			for (int j = 1; j <= 3; j++)
			{
				if (Choose[nine].isOn)
				{
					InputField = GameObject.Find("InputFieldT"+(i) + (j)).GetComponent<InputField>();
					show = InputField.text;
					TotalBox = TotalBox + int.Parse(show);
					if(TotalBox<50)
					{
						data[dex2[i-1], j-1] = data[dex2[i - 1], j - 1]+int.Parse(show);
					}
				}
				nine++;
			}
		}
		if(TotalBox<=50)
		{
			showCount ();
		}
	}

	public void ToaddData()
	{
		for (int i = 0; i <= 12; i++)
		{
			for (int j = 0; j <= 2; j++)
			{
				if (data[i,j]>0)
				{
					addData (Zone[i],""+(j+1),""+data[i, j]);
					Debug.Log("" + Zone[i] + "- "+(j+1)+":" + data[i, j]);

				}

			}
		}
	}

	public void addData(string Zone1,string pos,string count)
	{
		string[] dataWrite = new string[3];
		dataWrite [0] = Zone1;
		dataWrite [1] = pos;
		dataWrite [2] = count;
		rowData.Add (dataWrite);
	}

	public void getToWrite()
	{
		
		if (Sort.isOn)
			wt.boxWrite (rowData, "sort");
		
		if (Randomm.isOn)
			wt.boxWrite (rowData, "random");
	}

}
