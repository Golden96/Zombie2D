using UnityEngine;
﻿using UnityEngine;
using System.Collections;

public class nextLevel : MonoBehaviour {
	
	public string nombreNivel = "Escena2";
	public float tiempoEspera = 2f; 
	
	bool cargando = false; 
	void OnTriggerStay2D(Collider2D target){
		
		if (target.transform.tag == "Player") {
			//Application.LoadLevel(nombreNivel);
			if(!cargando) 
				StartCoroutine(cargaNivel());
			
		}
	}
	

	void OnTriggerExit2D(Collider2D target){
		cargando = false;
	}

	void OnTriggerEnter2D (Collider2D target) {
				cargando = true;


		}
	

	IEnumerator cargaNivel() {
		cargando = true;
		yield return new WaitForSeconds(tiempoEspera); 
		if(cargando) 
			Application.LoadLevel(nombreNivel);
	}
}