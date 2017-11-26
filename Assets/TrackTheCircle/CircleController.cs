using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CircleController : MonoBehaviour
{
    public string PatternName;
    private float maxinum = 10;
    private List<string> listPattern;
    private Rigidbody mRigidbody;
    private int indexofPattern;
    private bool isPlay = false;

    // Use this for initialization
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
        indexofPattern = 0;
        Debug.Log(ReadPattern(getPattern()));
    }

    // Update is called once per frame
    void Update()
    {
        listPattern = getPattern();
        if(isPlay)
        Move(listPattern);
    }
    private void Move(List<string> listPattern)
    {
        if (!(indexofPattern <= listPattern.Count))
        {
            Move(0, 0, 0);
            //Debug.Log("pattern " + listPattern[indexofPattern]+ " isReach " + IsReach(listPattern[indexofPattern])+" is at "+indexofPattern+" velocity "+mRigidbody.velocity);
        }
        else if (!IsReach(listPattern[indexofPattern]))
            Move(listPattern[indexofPattern]);
        else
            Move(0, 0, 0);
    }
    private void Move(string pattern)
    {
        switch (pattern)
        {
            case "n":
                Move(0, maxinum);
                break;
            case "s":
                Move(0, -maxinum);
                break;
            case "w":
                Move(-maxinum, 0);
                break;
            case "e":
                Move(maxinum, 0);
                break;
            case "ne":
                Move(maxinum, maxinum);
                break;
            case "se":
                Move(maxinum, -maxinum);
                break;
            case "nw":
                Move(-maxinum, maxinum);
                break;
            case "sw":
                Move(-maxinum, -maxinum);
                break;
            default:
                throw new InvalidOperationException();
        }
        //Debug.Log("Pattern " + pattern + " location : " + (getX()) + " " + getY() + " " + mRigidbody.position.z);

    }



    private List<string> getPattern()
    {
        //List<string> mypattern = new List<string>();
        //mypattern.Add("w");
        //mypattern.Add("s");
        //mypattern.Add("n");
        //mypattern.Add("sw");
        //mypattern.Add("s");
        //mypattern.Add("e");
        //return mypattern;
        return new List<string>(PatternManagement.getPattern().Split(' '));
    }
    private string ReadPattern(List<string> Pattern)
    {
        string debugLog = "";
        foreach (string read in Pattern)
        {
            debugLog += read + " ";
        }
        return debugLog;
    }

    private void Move(float x, float y)
    {
        double difx = (x - getX()), dify = (y - getY());
        Move((float)difx, 0, (float)dify);
        //Debug.Log("Pattern " + listPattern[indexofPattern]
        //    + " location : " + getX() + " " + getY()
        //    + " difx " + difx + " dify " + dify);
    }

    private void Move(float speedx, float speedy, float speedz)
    {
        mRigidbody.velocity = (new Vector3(speedx, speedy, speedz)).normalized;
    }
    private bool IsReach(string pattern)
    {
        switch (pattern)
        {
            case "n":
                if ((isBetween(getX(), 0.1)) && (getY() > maxinum * 0.9 && getY() < maxinum * 1.1))
                {
                    indexofPattern++;
                    return true;
                }
                break;
            case "s":
                if (isBetween(getX(), 0.1) && getY() < -maxinum * 0.9)
                {
                    indexofPattern++;
                    return true;
                }
                break;
            case "w":
                if (isBetween(getY(), 0.1) && getX() < -maxinum * 0.9)
                {
                    indexofPattern++;
                    return true;
                }
                break;
            case "e":
                if (isBetween(getY(), 0.1) && getX() > -maxinum * 0.9)
                {
                    indexofPattern++;
                    return true;
                }
                break;
            case "ne":
                if (getX() > maxinum * 0.9 || getY() > maxinum * 0.9)
                {
                    indexofPattern++;
                    return true;
                }
                break;
            case "se":
                if (getX() > maxinum * 0.9 || getY() < -maxinum * 0.9)
                {
                    indexofPattern++;
                    return true;
                }
                break;
            case "nw":
                if (getX() < -maxinum * 0.9 || getY() > maxinum * 0.9)
                {
                    indexofPattern++;
                    return true;
                }
                break;
            case "sw":
                if (getX() < -maxinum * 0.9 || getY() < -maxinum * 0.9)
                {
                    indexofPattern++;
                    return true;
                }
                break;
            default:
                throw new InvalidOperationException();
        }
        return false;
    }

    private bool isBetween(double position, double weight)
    {
        return position > -maxinum * weight && position < maxinum * weight;
    }

    private double getX()
    {
        return mRigidbody.position.x;
    }
    private double getY()
    {
        return mRigidbody.position.z;
    }
    public void ChangePlay()
    {
        isPlay = !isPlay;
    }
}
