using UnityEngine;
using System.Collections;

public class HurtSystem : MonoBehaviour {
	public string tagDamage = "Default";
	public int damage = 5;
	public float force = 0;
	public bool destroyOnCollision = false;
	public bool destroyOnTrigger = false;

	private DamageSystem ds;

	void OnCollisionStay2D(Collision2D target) { herir (target.transform);}

	
	void OnTriggerStay2D(Collider2D target) { herir (target.transform);} 

		
		void herir (Transform target) {
			if (target.tag == tagDamage) {
			ds = target.transform.GetComponent<DamageSystem>();
			if(ds){
				ds.hurt(damage);
				if(force > 0){
					var direction = target.position - transform.position  ;
					ds.rigidbody2D.AddForce(direction.normalized * force/10,ForceMode2D.Impulse);
				}
			}


			if (destroyOnTrigger) {
				Destroy(gameObject);
		}

		}
		
		if (destroyOnCollision) {
			Destroy(gameObject);
		}
	}
}