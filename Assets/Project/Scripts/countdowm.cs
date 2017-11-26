using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class countdowm : MonoBehaviour {

    public Text t;
    public float n;

	void Update () {

        n -= Time.deltaTime;
        // t.text = n.ToString();
         t.text = System.Math.Round(n, 2).ToString();
        //t.text = Mathf.Round(n).ToString();

        if(n<=0)
        {

            t.text = "TIME-UP";

        }
	
	}
}
