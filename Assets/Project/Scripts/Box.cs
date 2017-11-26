using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class Box : MonoBehaviour {

	public writerfile1 writerfile;
	public play toPlay;
	public GameObject[] box = new GameObject[38]; 
	private List<string> Zone = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" };
	private List<string> data = new List<string> ();
	private List<string> rowData = new List<string> ();
	private List<int> roundL = new List<int> ();
	private string Name, Sex, Age, Level;
	private int round;
	private bool T = true, F = false;


	public int receiveBox()
	{
		
		string[] read = System.IO.File.ReadAllLines (@"C:\\DataBLB\\system\\Box.txt");
		foreach (string line in read) 
		{
			data.Add (line);
		}

		int l;
		int x;
		for (int j = 0; j < (data.Count-1); j++) 
		{

			if (data [j].Length == 5)
				l = 1;
			else
				l = 2;

			x = Int32.Parse (data [j].Substring (4,l));

			roundL.Add (x);
		}

		x = 0;
		for(int d=0;d<(data.Count-1);d++)
		{
			for(int t=1;t<=roundL[d];t++)
			{
				rowData.Add( data[d]);
				Debug.Log (x+" : "+rowData[x]);
				x++;
			}
		}


		if (read [read.Length-1] == "random") 
		{
			int leg = rowData.Count-1;
			int gen;
			string dep;
			for (int p = 0; p <= leg; p++) 
			{
				gen = UnityEngine.Random.Range (0,leg);
				dep = rowData [p];
				rowData[p] = rowData[gen];
				rowData [gen] = dep;
			}
			for (int h = 0; h <= leg; h++) 
			{
				Debug.Log (" r"+h+": "+rowData[h]);
			}

		}

		for (int i=0; i <= 36; i++) {
			box [i].SetActive (F);
		}

		for (int c = 0; c < (data.Count - 2); c++) 
		{
			
		}

		return rowData.Count;
		//Debug.Log (data[count].Substring(2,1));
	}


	public void setBox (int count,int cp) 
	{
		//Debug.Log (" set : "+count);

		if(cp==0)
		{
			int poss = 0;
			for (int pos=0; pos < 12; pos++) 
			{
				if (Zone [pos] == rowData [count].Substring (0, 1)) //check zone in Box
				{
					for (int i = 1; i <= 3; i++) 
					{
						if (i + "" == rowData [count].Substring (2, 1))
							box [poss+i].SetActive (T);
					}
				} 
				else 
				{
					poss= poss+3;
				}
			}
		}

		if (cp == 1) 
		{
			box [0].SetActive (T);
		}

	}

	public void finish(int count, float receT)
	{
		rowData [count-1] = rowData [count-1] + "," + System.Math.Round(receT, 2).ToString();
		Debug.Log (rowData[count-1]);
	}

	public void  writeDataGame()
	{
		string[] read = System.IO.File.ReadAllLines (@"C:\\DataBLB\\system\\dataGame.txt");
		Name = read [0];
		Sex = read [1];
		Age = read [2];

		writerfile.getWriteDTgame (Name,Sex,Age,rowData);

	}
		

}
