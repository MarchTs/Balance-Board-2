using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class writerfile1 : MonoBehaviour
{

    private List<string[]> rowData = new List<string[]>();
    public int[] countDegree = { 0,0,0,0,0};

    public void setDTtest()
    {
        string[] rowDataTemp = new string[5];
        rowDataTemp[0] = "Time";
        rowDataTemp[1] = "Yaw(X)";
        rowDataTemp[2] = "Roll(Y)";
        rowDataTemp[3] = "Zone";
        rowDataTemp[4] = "Degree";
        rowData.Add(rowDataTemp);

        countDegree[0] = 0;
        countDegree[1] = 0;
        countDegree[2] = 0;
        countDegree[3] = 0;
        countDegree[4] = 0;

    }

    public void getDTtest(string tim,string x, string y, string zone, string degree)
    {

        int num;
        string[] rowDataTemp = new string[5];
        rowDataTemp[0] = tim;
        rowDataTemp[1] = x;
        rowDataTemp[2] = y;
        rowDataTemp[3] = zone;
        rowDataTemp[4] = degree;
        rowData.Add(rowDataTemp);

        for (int i = 1; i <= 5; i++)
        {
            num = Int32.Parse(degree);
            if (num <= (i * 5))
            {
                countDegree[i - 1]++;
                break;
            }
        }
    }

	public void getWriteDTtest()
    {
        string[] count = new string[5];
        count[0] = "0-5: " + countDegree[0];
        count[1] = "6-10: " + countDegree[1];
        count[2] = "11-15: " + countDegree[2];
        count[3] = "16-20: " + countDegree[3];
        count[4] = "21-25: " + countDegree[4];
        rowData.Add(count);


        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));

        string dateTime = DateTime.Now.ToString("dd-MM-yyyy"); 
        dateTime = dateTime + " ," + DateTime.Now.ToString("HH.mm.ss tt");
        string filePath = @"C:\DataBLB\Test\"+dateTime+" .csv";
        string path = @"C:\DataBLB\Test";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();

        rowData.Clear();
    }

	public void boxWrite(List<string[]> rowData1,string fun)
	{
		string[][] output = new string[rowData1.Count][];
		string path = @"C:\DataBLB\system";

		for (int i = 0; i < output.Length; i++)
		{
			output[i] = rowData1[i];
		}

		int length = output.GetLength(0);
		string delimiter = ",";

		StringBuilder sb = new StringBuilder();

		for (int index = 0; index < length; index++)
			sb.AppendLine(string.Join(delimiter, output[index]));
		sb.AppendLine (fun);
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		File.WriteAllText("C:\\DataBLB\\system\\Box.txt",sb+"");

		Debug.Log ("Box OK.");
	}

	public void dataWrite(string Name,string Sex, int Age)
	{
		if (Name != "") {
			string path = @"C:\DataBLB\system";


			StringBuilder sb = new StringBuilder ();

			sb.AppendLine (Name);
			sb.AppendLine (Sex);
			sb.AppendLine (Age + "");

			if (!Directory.Exists (path)) {
				Directory.CreateDirectory (path);
			}
			File.WriteAllText ("C:\\DataBLB\\system\\dataGame.txt", sb + "");
		}
	}

	public void setData()
	{
		string[] dataGame = new string[4];
		dataGame [0] = "Name";
		dataGame [1] = "Sex";
		dataGame [2] = "Age";
		rowData.Add (dataGame);
	}

	public void setData1()
	{
		string[] dataGame = new string[4];
		dataGame[0] = "Zone";
		dataGame[1] = "Pos";
		dataGame[2] = "Num";
		dataGame[3] = "Sec";
		rowData.Add (dataGame);
	}

	public void getWriteDTgame (string Name,string Sex, string Age,List<string> rowDataGame)
    {
		setData ();
		string[] dataGame = new string[3];
        Debug.Log("  Name :" + Name + " Age :" + Age + "  Sex :" + Sex );
		string path = @"C:\DataBLB\Game";

		dataGame [0] = Name;
		dataGame [1] = Sex;
		dataGame [2] = Age + "";
		rowData.Add (dataGame);

		setData1 ();

		string[][] output = new string[rowData.Count][];

		for (int i = 0; i < output.Length; i++)
		{
			output[i] = rowData[i];
		}

		int length = output.GetLength(0);
		string delimiter = ",";

		StringBuilder sb = new StringBuilder();

		for (int index = 0; index < length; index++)
			sb.AppendLine(string.Join(delimiter, output[index]));
		
		foreach (string mess in rowDataGame) {
			sb.AppendLine (mess);
		}

		string filePath = @"C:\DataBLB\Game\"+Name+".csv";

		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		StreamWriter outStream = System.IO.File.CreateText(filePath);
		outStream.WriteLine(sb);
		outStream.Close();

		rowData.Clear();
    }

}