using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using System.Threading;
using System;
using System.IO;


public class Sensor : MonoBehaviour
{
    bool run = false;
    public bool check = false;
    private Thread thread;
    SerialPort sp;
    public Text ShowPort;
    public string portName;
    public string noSensor;
    string[] dataIn;
    private bool showPopUp = false;
    public Text ShowX;

    char[] cut = { ',', '=' };
    public GameObject tConnect, fConnect;
    float x = 0, y = 0, z = 0;
    float sX = 0, sY = 0, sZ = 0;
    float rX = 0, rY = 0, rZ = 0;

    private Rect windowRect = new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 200, 300);

    public float[] getDegree()
    {
        return new float[] { rX, rY, rZ };
    }
    void OpenSerialPort()
    {
        run = false;
        sp.Open();
        if (sp.IsOpen)
        {
            do
            {
                dataIn = sp.ReadLine().ToString().Trim().Split(cut);
            } while (!CheckDataIn(dataIn));
            x = float.Parse(dataIn[7]);
            y = float.Parse(dataIn[6]);
            z = float.Parse(dataIn[8]);
            run = true;
            while (run)
            {
                dataIn = sp.ReadLine().ToString().Trim().Split(cut);
                if (CheckDataIn(dataIn))
                {
                    x = float.Parse(dataIn[7]);
                    y = float.Parse(dataIn[6]);
                    z = float.Parse(dataIn[8]);
                }
            }
            sp.Close();
        }
    }

    void Start()
    {

    }

    public void getPort()
    {
        using (TextReader reader = File.OpenText(@"C:\\DataBLB\\system\\PortSensor.txt"))
        {
            portName = reader.ReadLine();
        }
        print(portName);
        sp = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
        //ShowPort.text = inputPort;
    }

    void Update()
    {
        if (run)
        {
            rX = (int)(x - sX);
            rY = (int)(y - sY);
            rZ = (int)(z - sZ);
        }
    }

    bool IsNum(string t)
    {
        float c;
        return float.TryParse(t, out c);
    }
    bool CheckDataIn(string[] arr)
    {
        return arr.Length == 12 && arr[0] == "Yaw" && arr[1] == "Pitch" && arr[2] == "Roll" && arr[3] == "Ax" && arr[4] == "Ay" && arr[5] == "Az" && IsNum(arr[6]) && IsNum(arr[7]) && IsNum(arr[8]) && IsNum(arr[9]) && IsNum(arr[10]) && IsNum(arr[11]);
    }

    public void SetNew()
    {
        sX = x; sY = y; sZ = z;
    }

    public void SwitchConnectBT()
    {
        if (!run)
        {
            ConnectBT();
        }
        else
        {
            DisConnectBT();
        }
    }

    public void ConnectBT()
    {
        getPort();
        if (!run)
        {
            Debug.Log("ConnectBT");
            thread = new Thread(OpenSerialPort);
            thread.Start();
            var result = Retry.For<bool>(() =>
            {
                return run;
            }, TimeSpan.FromSeconds(10));
            if (result)
            {
                SetNew();
                //alertBox.AlertOk("Connect Bluetooth", "เชื่อมต่อ " + noSensor + " เรียบร้อย");
                check = true;
                tConnect.SetActive(true);
                fConnect.SetActive(false);
            }
            else
            {
                thread = null;
                showPopUp = true;
                OnGUI();
            }
        }
        SetNew();
    }


    public void DisConnectBT()
    {
        showPopUp = false;
        if (run)
        {
            Debug.Log("DisConnectBT");
            check = false;
            run = false;
            thread = null;
            //alertBox.AlertOk("Connect Bluetooth", "ตัดการเชื่อมต่อ " + noSensor + " เรียบร้อย");
            tConnect.SetActive(false);
            fConnect.SetActive(true);
            rX = rY = rZ = 0;
        }
    }

    void OnGUI()
    {
        if (showPopUp)
        {
            GUI.Window(1, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 65
                   , 250, 120), ShowGUI, "Warning");

        }
    }

    void ShowGUI(int windowID)
    {
        // You may put a label to show a message to the player

        GUI.Label(new Rect(50, 40, 200, 30), "การเชื่อมต่อ sensor 'ล้มเหลว'!");

        // You may put a button to close the pop up too

        if (GUI.Button(new Rect(130, 80, 75, 30), "OK"))
        {
            showPopUp = false;
            // you may put other code to run according to your game too
        }
        if (GUI.Button(new Rect(45, 80, 75, 30), "Try again"))
        {
            ConnectBT();

            // you may put other code to run according to your game too
        }

    }
}
