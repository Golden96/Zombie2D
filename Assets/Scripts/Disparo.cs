using UnityEngine;
using System.Collections;

public class Disparo : MonoBehaviour {


	public GameObject bala;
	public Transform PuntoDisparo;


	public void Fire(){
		if (bala != null) {
			var clone = Instantiate(bala, PuntoDisparo.position,
			                        Quaternion.identity) as GameObject;
			clone.transform.localScale = transform.localScale;

		}
	
	}
}
