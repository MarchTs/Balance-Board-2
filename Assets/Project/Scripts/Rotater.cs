using UnityEngine;
using System.Collections;

public class Rotater : MonoBehaviour {

    private float n=3;
    private bool size=false;
    // Update is called once per frame

    public void fab()
    {
        size = true;
    }
    
	void Update () {
        //สั่งให้หมุนแกนแต่ละแกนต่อวิ 
        transform.Rotate(new Vector3(15, 30, 45)*Time.deltaTime);

        if (size)
        {
            n -= Time.deltaTime;
            transform.localScale += new Vector3(1.0F, 1.0f, 1.0f);
            if (n==0)
            {
                size = false;
            }
        }

    }
}
