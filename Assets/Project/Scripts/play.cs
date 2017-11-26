using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using System.Threading;
using System;
using System.IO;

public class play : MonoBehaviour
{
    //ส่วนของการดึงค่า
    public Sensor SS;
    public Rotater RTT;
    public Text y, p, r;
    public GameObject Hi;
    public float ze = 0, cd = 5;

    public Box box;
    public timeGame TG;
    public Sound Sou;
    private Rigidbody rb; //ใช้ในการเคลื่อนที่
    public float speed; // ความเร็วผู้เล่น
    public Text countText, cd1;
    public Text winText;
    private bool adCheck = false;

    private int count, scroc;//นับคะแนน
    private int Total;
    private int setStart = 1, u = 0;
    private float sendT;
    private bool statusStart = false, butSt = false, GG = true;


    //ฟังก์ชันทำงานครั้งเดียว
    // Use this for initialization
    void Start()
    {
        transform.GetComponent<Renderer>().material.color = Color.green;
        SS.ConnectBT();
        rb = GetComponent<Rigidbody>();
        count = 1;
        Total = box.receiveBox();
        box.setBox(0, 0);
        countText.text = "0/" + Total;
        //audio.PlayoneShot(cc);

        //SetCountText();

        //winText.text = "";

    }

    // ทำงานวนลูป
    // Update is called once per frame
    //void Update () {

    /*void FixedUpdate() {

        //ลองเรียกค่าวิธีใหม่
        


        //float moveHorizontal = Input.acceleration.test;

        //float moveVertical = Input.acceleration.;

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //rb.AddForce(movement * speed);

    }*/

    //--------------------------

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Box"))
        {
            SetCountText();
            //RTT.fab();
            //int gg = Movesize();
            other.gameObject.SetActive(false);


            if (count < Total && setStart == 0)
            {
                Sou.soundBase();
                //transform.GetComponent<Renderer>().material.color = Color.green;
                box.setBox(count, 0);
                setStart = 1;
                count++;
            }
            else if (count != Total && setStart == 1)
            {
                Sou.soundBox();
                //transform.GetComponent<Renderer>().material.color = Color.red;
                sendT = TG.setT();
                box.finish(count, sendT);
                box.setBox(count, 1);
                setStart = 0;
            }
            else if (count == Total)
            {
                TG.setTO();
                winn();
            }
        }
    }

    public void winn()
    {

        SS.DisConnectBT();
        sendT = TG.setT();
        box.finish(count, sendT);
        if (count == Total)
        {
            Sou.soundWinwin();
            winText.text = "Finish";
            box.writeDataGame();
        }
        else
        {
            box.writeDataGame();
            winText.text = "Time Up";
        }
    }


    void SetCountText()

    {
        countText.text = "" + count + "/" + Total;

    }
    private float n = 3;

    public int nn = 0;
    void Update()
    {
        float[] refer = SS.getDegree();

        if (statusStart)
        {
            Hi.transform.position = new Vector3(refer[2] * (-1), 0.76f, refer[0]);
        }
        if (GG)
        {
            nn = TG.checkNN();
            if (nn == 2)
            {
                GG = false;
                winn();
            }
        }


    }

    public void setStaS()
    {
        statusStart = true;
    }
}



