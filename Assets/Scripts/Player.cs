using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(2,3);
	private Animator animator;

	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animator> ();


	}
	
	// Update is called once per frame
	void Update () {
	
		var absVelX = Mathf.Abs (rigidbody2D.velocity.x);
		var forceX = 0f;
		var forceY = 0f;
    

		//Las lineas de codigo que van a hacer que el personaje pueda ir a la derecha.
		if (Input.GetKey ("right")) 
		{

			if(rigidbody2D.velocity.x < 0){
				rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);
			}

						if (absVelX < maxVelocity.x)
								forceX = speed;

			//Esto pone el personaje mirando a la derecha.
						this.transform.localScale = new Vector3 (1, 1, 1);

				} 
		//Las lineas de codigo que van a hacer que el personaje pueda ir a la derecha.
		else if (Input.GetKey ("left")) 
		
		{
			//Frena al personaje cuando va a la derecha y pulso izquierda.
			if(rigidbody2D.velocity.x > 0)
		   rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);

						if (absVelX < maxVelocity.x)
								forceX = -speed;
			//Esto pone el sprite mirando a la izquierda.
			this.transform.localScale = new Vector3 (-1, 1, 1);


				}
		if(absVelX > 0)
			animator.SetFloat("velocity",absVelX);

		rigidbody2D.AddForce(new Vector2(forceX, forceY));

		if (Input.GetKey("f")) {
			animator.SetBool ("Fire",true);

		}else{
			animator.SetBool ("Fire",false);

	   }
	}
}