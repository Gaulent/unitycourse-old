using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 1f;

	private float xmin,xmax;
	private bool movingRight = true;
		
	// Use this for initialization
	void Start () {
		// La salida de Instantiate develve un Object, lo parseamos a GameObject
		
		foreach(Transform child in transform) {
			GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity) as GameObject;

			// Pone el objeto creado bajo este en la jerarquia
			enemy.transform.parent = child;
		}
		
		float distance = transform.position.z - Camera.main.transform.position.z;
		
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		
		xmin = leftmost.x;
		xmax = rightmost.x;
	}
	
	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {

		if(movingRight)
			transform.position += Vector3.right * speed * Time.deltaTime;
		else
			transform.position += Vector3.left * speed * Time.deltaTime;

		float rightEdgeOfFormation = transform.position.x + width/2;
		float leftEdgeOfFormation = transform.position.x - width/2;

		if (leftEdgeOfFormation <= xmin)
			movingRight=true;
		if (rightEdgeOfFormation >= xmax)
			movingRight=false;
		
	}
}
