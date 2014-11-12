﻿using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour {
		
		public float jumpSpeed = 5f;
		public bool standing;
		public GameObject groundCheck;
		
		// Update is called once per frame
		void Update () {
			var absVelY = Mathf.Abs(rigidbody2D.velocity.y);
			if(absVelY <= .05f){
				standing = true;
			}else{
				standing = false;
			}
			
			if( (Input.GetKeyDown("up") || Input.GetKeyDown("space")) && standing){
				rigidbody2D.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
			}
		}
	}