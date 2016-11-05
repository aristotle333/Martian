using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;


	Animator anim;
	Player player;
	EnemyHealth enemyHealth;
	public bool playerInRange;
	public float timer;


	void Awake ()
	{
		player = Player.S;
		enemyHealth = GetComponent<EnemyHealth>();
		anim = GetComponent <Animator> ();
	}


	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			playerInRange = true;
		}
	}


	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			playerInRange = false;
		}
	}


	void Update ()
	{
		timer += Time.deltaTime;
		if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
		{
			Attack ();
		}
	}


	void Attack ()
	{
		timer = 0f;

		if(player.health> 0)
		{
			player.health -= attackDamage;
		}
	}
}
