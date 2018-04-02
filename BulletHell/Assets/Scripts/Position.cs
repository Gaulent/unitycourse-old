using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	// Añadir un gizmo a un gameobject para poder trabajar con el en diseño. 

	void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}
}
