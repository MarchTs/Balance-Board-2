using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class setGame : MonoBehaviour {

    public GameObject gg;
    public InputField InputName, InputAge, InputSex ;
    public writerfile1 writerFile;
    public BoxInsert BoxInsert1;
	public Text Total;
	public Dropdown dropdown1;
    public Toggle Choose1;
    public Toggle Choose2;
    public Toggle Choose3;
	public Toggle sex1;
	public Toggle sex2;
    public int Level = 0;
    public string Name, Sex = "";
	public int TotalBox, Age;

    public void startGame ()
    {
		if(TotalBox>=1)
		{
        	InputName = GameObject.Find("InputName").GetComponent<InputField>();

        	Name = InputName.text;

			if (sex1.isOn)
			{
				Sex = "Male";
			}
			else if (sex2.isOn)
			{
				Sex = "Female";
			}

	        if (Choose1.isOn)
    	    {
    	        Level = 1;
    	    }
        	else if (Choose2.isOn)
        	{
        	    Level = 2;
        	}
        	else if (Choose3.isOn)
        	{
        	    Level = 3;
        	}
		}
		writerDT ();
    }

	public void DropdownIndexChange(int index)
	{
		Age = (index+17);
	}

    public void InsertButton()
    {
        if ( TotalBox < 50 )
        {
            TotalBox = BoxInsert1.sendZone();
        }
        else
        {
            Debug.Log("  Total Box : Full !!!! ");
        }

		Total.text = ""+TotalBox.ToString()+"/50";
    }

    public void writerDT()
    {
		writerFile.dataWrite(Name, Sex, Age);
		BoxInsert1.ToaddData ();
		BoxInsert1.getToWrite ();

    }

	public void openFolderG()
	{
		System.Diagnostics.Process.Start("explorer.exe", @"C:\DataBLB\Game");
	}

}
