using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 

public class PopUpGui : MonoBehaviour {
    public Canvas nameCanvas;
    public bool tampil = false;

	// Use this for initialization
	public void TampilPopUp ()
    {

        if(tampil == false)
        {
            tampil = true;
            nameCanvas.enabled = true;

        }
        else if (tampil == true)

        {
            tampil = false;
            nameCanvas.enabled = false;

        }
	
	}
	
	
}
