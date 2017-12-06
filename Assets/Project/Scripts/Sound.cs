using UnityEngine;
using System.Collections;
using System;

public class Sound : MonoBehaviour {

	public AudioClip Go;
	public AudioClip Box;
	public AudioClip Base;
	public AudioClip Win;
	public AudioClip Winwin;
	public AudioClip Back;
	public AudioClip Ten;
    new AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}

	public void soundBox()
	{
		audio.PlayOneShot(Box);
	}

	public void soundBase()
	{
		audio.PlayOneShot(Base);
	}

	public void soundWin()
	{
		audio.PlayOneShot(Win);
	}

	public void soundWinwin()
	{
		audio.PlayOneShot(Winwin);
	}

	public void soundGo()
	{
		audio.PlayOneShot(Go);
	}

	public void backG(int i)
	{
		if (i == 1) {
			audio.loop = true;
			audio.clip = Back;
			audio.Play ();
		} else {
			audio.Stop ();
		}
	}

	public void soundTen()
	{
		backG (0);
		audio.PlayOneShot(Ten);
	}
}