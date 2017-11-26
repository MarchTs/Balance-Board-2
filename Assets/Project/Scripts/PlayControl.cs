using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayControl : MonoBehaviour{

    private Rigidbody rb; //ใช้ในการเคลื่อนที่

    public float speed; // ความเร็วผู้เล่น

    public Text countText;

    public Text winText;

    private int count;//นับคะแนน

    

    //ฟังก์ชันทำงานครั้งเดียว
    // Use this for initialization
    void Start() {


        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        winText.text = "";
   
    }

    // ทำงานวนลูป
    // Update is called once per frame
    //void Update () {

    void FixedUpdate() {

        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

    }

    //--------------------------

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Box")) ;

        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();


            if (count >= 8)
            {
                winText.text = "ยินดีด้วยคุณผ่านด่านนี้แล้ว!!!!";

            }



        }

    }  

        void SetCountText()

    {

        countText.text = " Score :" + count.ToString();


    }

            
        

 }

   

