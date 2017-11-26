using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class CB : MonoBehaviour {

	GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube );
	public string pos = "A";
	//private List<float> point1 = new List<float>() { 16.9f,67.5f };
	//public List<float> point2 = new List<float>(2);
	//public List<float> point3 = new List<float>(2);
	public float[] point1 = new float[2]{16.9F,67.5F};
	public float[] point2 = new float[2]{33.6F,133F};
	public float[] point3 = new float[2]{47.3F,190.2F};
	public float pointCenter = 25.14F;

	void Start() {
		// add a new Cube object
		//cube.transform.position=new Vector3 (16.9F,25.14F,67.5F);
		//cube.transform.Rotate(1,2,3);
		cube.transform.localScale=new Vector3 (20.1f,20.2f,20.3f);

		//cube.transform.position=new Vector3 (point1[0],pointCenter,point1[1]);
		//setBox (1);
	}

	public void setBox(int num)
	{
		if(pos== "A")
		{
			if(num==1)
			{
				cube.transform.position=new Vector3 (point1[0],pointCenter,point1[1]);
			}
			if(num==2)
			{
				cube.transform.position=new Vector3 (point2[0],pointCenter,point2[1]);
			}
			if(num==3)
			{
				cube.transform.position=new Vector3 (point3[0],pointCenter,point3[1]);
			}
		}
	}

	//(1848.224F, 478.8F, -1149.5F)
	void Update () {
		//สั่งให้หมุนแกนแต่ละแกนต่อวิ 

		cube.transform.Rotate(new Vector3(15, 30, 45)*Time.deltaTime);
	}
}