using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile,projectileParent;

	private void FireGun() {
		GameObject newProjectile = Instantiate (projectile, transform.FindChild("Gun").position, Quaternion.identity) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
	}
}
