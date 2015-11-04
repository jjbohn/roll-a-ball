﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	
	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		SetCountText (0);
		winText.text = "";
	} 
	
	// 
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("pickup")) {
			other.gameObject.SetActive(false);
			SetCountText(++count);
		}
	}

	void SetCountText(int count) {
		countText.text = "Count: " + count.ToString();
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}
}
