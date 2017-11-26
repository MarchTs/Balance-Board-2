using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System;

public class main : MonoBehaviour {
    public Sensor SS;
    public Text y, p, r;
    public writerfile1 writerfile;
    public GameObject bord, bord1;
    public float  ze = 0;
    public Text showZone, degree, timeSS, statusS;
    public string zone = "";
    private static System.Timers.Timer aTimer;
	public InputField inputTimeSave, inputPort;
    public int timeSave, tim, degreeC, round = 0;
    public int count;
    public float result = 0; 
    public Boolean runStat1,runStat,run = false;


    // Use this for initialization
    void Start ()
    {
        count = 1;
    }
	
	// Update is called once per frame
	void Update ()
    { 
        var test = SS.getDegree();
        y.text = "" + test[0]; //หมุนรอบแกน x
        p.text = "" + test[1]; //หมุนรอบแกน z
        r.text = "" + test[2]; //หมุนรอบแกน y

		bord.transform.localEulerAngles = new Vector3(test[0], test[2], ze);
        bord1.transform.localEulerAngles = new Vector3(test[0], ze, test[2]);
        
        if (test[0] == 0.0 && test[2] == 0.0)
        {
            zone = "CT";
            showZone.text = "CT";
        }
        else if (test[2] > 0 && test[0] > 0)
        {
            zone = "AM";
            showZone.text = "AM";
        }
        else if (test[2] > 0 && test[0] == 0)
        {
            zone = "AM.PM";
            showZone.text = "AM.PM";
        }
        else if (test[2] > 0 && test[0] < 0)
        {
            zone = "PM";
            showZone.text = "PM";
        }
        else if (test[2] == 0 && test[0] > 0)
        {
            zone = "AL.AM";
            showZone.text = "AL.AM";
        }
        else if (test[2] < 0 && test[0] < 0)
        {
            zone = "PL";
            showZone.text = "PL";
        }
        else if (test[2] == 0 && test[0] < 0)
        {
            zone = "PM.PL";
            showZone.text = "PM.PL";
        }
        else if (test[2] < 0 && test[0] > 0)
        {
            zone = "AL";
            showZone.text = "AL";
        }
        else
        {
            zone = "PL.AL";
            showZone.text = "PL.AL";
        }

        if (SS.check)
        {
             degreeC = (int)Math.Sqrt(Math.Pow(test[2], 2)+Math.Pow(test[0], 2));
             degree.text = degreeC.ToString();
         }

        if (run)
        {
            writerfile.getDTtest(count.ToString(), test[0].ToString(), test[2].ToString(), zone, degreeC.ToString());
            run = false;
        }

        if (runStat1 && count < timeSave)
        {
            timeSS.text = count.ToString();
        }
        if (runStat)
        {
            if (round > 0)
            {
                statusS.text = "Save [" + round.ToString()+ "] : OK";
            }
        }

    }


    public void openFolder()
    {
        System.Diagnostics.Process.Start("explorer.exe", @"C:\DataBLB\Test");
    }

    public void saveDT()
    {
        inputTimeSave = GameObject.Find("input_time").GetComponent<InputField>();
        timeSave = int.Parse(inputTimeSave.text);
        if (timeSave > 0)
        {
            print(" time set : " + timeSave);
            timeSave++;
            writerfile.setDTtest();
            SetTimer();
        }
    }
    

    private void SetTimer()
    {
        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(200);
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }

    public void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        //aTimer.Stop();
        if (count == timeSave)
        {
            round++;
            writerfile.getWriteDTtest();
            print(" Save[" + round + "] : OK ");
            timeSave = 0;
            count = 1;
            runStat = true;
            runStat1 = false;
            aTimer.Stop();
        }
        else
        {
            if (count != timeSave)
            {
                runStat1 = true;
                if (tim == 5)
                {
                    tim = 0;
                    if (count != timeSave)
                    {
                        count++;
                    }
                }

                if (count != timeSave)
                {
                    print(" run Time " + count);
                    run = true;
                    tim++;
                }
            }
        }   
    }

}