using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    // ฟังก์ชันทำงานครั้งเดียว
	// Use this for initialization
	void Start () {

        offset = transform.position - player.transform.position;
	
	}
	// ฟังก์ชันทำงานวนลูป
	// Update is called once per frame
	void LateUpdate () {

        transform.position = player.transform.position + offset;
	
	}
}
