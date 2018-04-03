using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Vector3 aim;

	void Start() {
		//print(name + Mathf.Cos(transform.rotation.eulerAngles.z) + "  " + Mathf.Sin(transform.rotation.eulerAngles.z));
		float tempAngle = (((180-transform.rotation.eulerAngles.z+360)%360)*Mathf.PI)/180;
		aim = new Vector3(Mathf.Sin(tempAngle), Mathf.Cos(tempAngle),0);
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position, 0.3f);
		Gizmos.color = Color.red;
		Vector3 direction = transform.TransformDirection(Vector3.down) * 0.5f;
		Gizmos.DrawRay(transform.position, direction);
	}
}
