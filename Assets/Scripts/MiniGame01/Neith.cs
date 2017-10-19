using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (Animator))]
public class Neith : MonoBehaviour {

	private Animator Anim;
	float _time = 0f;
	public Arrow arrow;
	Arrow inst;
	public float timeBetweenShoots = 0.1f;
	bool recharging = false;
	public float ultraShotHoldTime = 1f;
	public float arrowDamage = 10f;
	public float maxLife = 100f;
	float hp;

	void Start(){
		Anim = GetComponent<Animator> ();
		hp = maxLife;
	}

	void Update(){
		Shoot ();
		if (inst && recharging) {
			inst.transform.SetPositionAndRotation (transform.position, transform.rotation);
			//print (inst.name);
			if (_time >= ultraShotHoldTime) {
				Anim.SetTrigger ("UltraAim");
			}
		}
	}

	void Shoot(){
		if (!recharging && Input.GetMouseButtonDown(0) && _time > timeBetweenShoots) {
			inst = Instantiate (arrow.gameObject, transform.position, transform.rotation).GetComponent<Arrow> ();
			inst.SetSpeed (0f);
			recharging = true;
			_time = 0f;
			Anim.SetTrigger ("Aim");
		}
		if (recharging && Input.GetMouseButtonUp (0)) {
			if (_time >= ultraShotHoldTime) {
				inst.gameObject.tag = "UltraArrow";
				inst.SetSpeed (30f);
				inst.SetDamage (2 * arrowDamage);
			} else {
				inst.SetSpeed (20f);
				inst.SetDamage (arrowDamage);
			}
			recharging = false;
			_time = 0f;
			Anim.SetTrigger ("Release");
		}

		_time += Time.deltaTime;
	}

	public void Hurt(float damage){
		hp -= damage;
		if (hp <= 0f) {
			Die ();
		}
	}

	public float currentHealth(){
		return hp;
	}

	void Die(){
		print ("Faliceu");
		SceneManager.LoadScene ("MiniGame01");
	}

}
