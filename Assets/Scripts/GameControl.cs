using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	public string nombreNivel;

	public void exit(){
				Application.Quit ();
		}

		public void play(){
			Application.LoadLevel (nombreNivel);

	
	}
}
