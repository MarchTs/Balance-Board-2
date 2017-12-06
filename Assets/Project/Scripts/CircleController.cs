using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Project.Entity;

public class CircleController : MonoBehaviour
{
    public string PatternName;
    private float maxinum = 10;
    private List<CirclePattern> listPattern;
    private Rigidbody mRigidbody;
    private int indexofPattern;
    private bool isPlay = false;

    // Use this for initialization
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
        indexofPattern = 0;
        listPattern = PatternManagement.GetPatterns();
        //Debug.Log(listPattern);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlay)
        Move(listPattern);
    }
    private void Move(List<CirclePattern> listPattern)
    {
        maxinum = listPattern[indexofPattern].level * 5;
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
    private void Move(CirclePattern pattern)
    {
        switch (pattern.direction)
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
    private string ReadPattern(List<CirclePattern> Pattern)
    {
        string debugLog = "";
        foreach (CirclePattern read in Pattern)
        {
            debugLog += read.direction + " " + read.level + " ";
        }
        return debugLog;
    }

    private void Move(float x, float y)
    {
        double difx = (x - getX()), dify = (y - getY());
        Move((float)difx, 0, (float)dify);
        Debug.Log("Pattern " + listPattern[indexofPattern]
            + " location : " + getX() + " " + getY()
            + " difx " + difx + " dify " + dify);
    }

    private void Move(float speedx, float speedy, float speedz)
    {
        mRigidbody.velocity = (new Vector3(speedx, speedy, speedz)).normalized;
    }
    private bool IsReach(CirclePattern pattern)
    {
        switch (pattern.direction)
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
