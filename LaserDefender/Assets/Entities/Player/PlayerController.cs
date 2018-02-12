using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 8f;
	public float padding = 1f;

	private float xmin,xmax;
	


	void Start () {
	
		// ViewportToWorldPoint devuelve puntos en el espacio en referencia a la camara
		// En este caso la camara Camera.main
	
		float distance = transform.position.z - Camera.main.transform.position.z;
	
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
		
	}
	
	
	void Update () {
	
		// Time.deltaTime es el tiempo entre frames. Haciendolo independiente del framerate.
	
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		
	}
}
