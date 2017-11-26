using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timeGame : MonoBehaviour {

	public Sound Sou;
	public Text t,cd1;
	private float n=999,ns;
	public bool tu=false,chw = true,chb = true;
	private int K = 1;
	private int nn=1;

	void Start ()
	{	/*
		string[] read = System.IO.File.ReadAllLines (@"C:\\DataBLB\\system\\dataGame.txt");
		if (read [3] == "1") 
		{
			ns = 20f;
		} 
		else if (read [3] == "2") 
		{
			ns = 15f;
		} 
		else 
		{
			ns = 10f;
		}
			
		Debug.Log (" + +"+ns);*/
	}

	public void setTime()
	{
		Sou.soundGo ();
		n = 123.3f;
        tu = true;

	}

    public void setTO()
    {
        tu = false;
    }

    public float setT()
	{
			return n;
	}

	public int checkNN()
	{
		return nn;
	}

	void Update () {
		
		if (tu&n!=-200) {
			n -= Time.deltaTime;
		}
		if(tu&n<=120)
		{
			
			//t.text = n.ToString();
			t.text = System.Math.Round(n, 2).ToString();
        	//t.text = Mathf.Round(n).ToString();
			if (chb) {
				Sou.backG (1);
				chb = false;
			}
		}
        if (n==999)
        {
            t.text = "";
        }
		if (chw&&n <= 12.7f) {
			chw = false;
			Sou.soundTen ();
		}
		if(n<0)
		{
			t.text = "TIME-UP";
			nn = 2;
		}

	}
}
