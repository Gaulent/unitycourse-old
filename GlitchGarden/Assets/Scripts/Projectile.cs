using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed = 1f;
	public float damage = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
}
