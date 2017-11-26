using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using UnityEngine.UI;

public class SetPort : MonoBehaviour {

    public InputField InputPort;

	public void setPort()
	{
		string port = "";
		string path = @"C:\DataBLB\system";
		InputPort = GameObject.Find("InputPort").GetComponent<InputField>();
		port = InputPort.text;
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		File.WriteAllText("C:\\DataBLB\\system\\PortSensor.txt",""+port);
	}
}