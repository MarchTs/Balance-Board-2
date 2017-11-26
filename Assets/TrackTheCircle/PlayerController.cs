using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    //public Text CountText;
    //public Text WinText;

    private int count;
    private Rigidbody rb;

    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        UpdateCountedMesage();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(horizontal * speed, 0.0f, vertical * speed));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            count++;
            other.gameObject.SetActive(false);
            UpdateCountedMesage();
        }
    }

    void UpdateCountedMesage()
    {
        //CountText.text = "Count : " + count.ToString();
        //if (count == 8) WinText.text = "You Win!";
        //else WinText.text = "";
    }
}
