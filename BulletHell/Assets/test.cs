using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	private SpriteRenderer spriteR;
	public Sprite fireSprite;
	public Sprite iceSprite;
		
		
		void Start () {

			spriteR = GetComponent<SpriteRenderer>();
		ChangeToFire();
		}
	
		void ChangeToFire() {
			print("Called");
			spriteR.sprite = fireSprite;
		}
	}