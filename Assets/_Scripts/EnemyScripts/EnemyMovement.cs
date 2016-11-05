using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	Player player;
	EnemyHealth enemyHealth;
	NavMeshAgent nav;
	public Vector3 origin;
	public int counter;
	public Vector3 move;
	public float Radius = 20f;
	public float original_Speed;
	public bool PlayerinRange = false;
	void Awake ()
	{
		player = Player.S;
		enemyHealth = GetComponent <EnemyHealth> ();
		nav = GetComponent <NavMeshAgent> ();
	}

	void Start()
	{
		origin = this.transform.position;
		original_Speed = this.gameObject.GetComponent<NavMeshAgent> ().speed;
		//print (origin.position);
	}

	void Update ()
	{ 
			if (GameManager.S.isNight ()) {
				this.gameObject.GetComponent<NavMeshAgent> ().speed = original_Speed + 1f;
			} else
				this.gameObject.GetComponent<NavMeshAgent> ().speed = original_Speed;
			
			if (PlayerinRange == false)
				counter++;
        if (enemyHealth.currentHealth > 0 && player.health > 0)
        {
            float Distance = Vector3.Distance(origin, player.transform.position);
           // if (Distance > 100)
           // {
            //    Destroy(this.gameObject);
           // }
            if (Distance <= Radius)
            {
                nav.SetDestination(player.transform.position);
                PlayerinRange = true;
            }
            else {
                nav.SetDestination(origin);
                float Distance_Origin = Vector3.Distance(origin, this.transform.position);
                //print (Distance_Origin);
                if (Distance_Origin < 2f)
                    PlayerinRange = false;
            }


            if (PlayerinRange == false)
            {
                if (counter == 100)
                    move = new Vector3(Random.Range(origin.x - Radius, origin.x + Radius), origin.y, Random.Range(origin.z - Radius, origin.z + Radius));
                else if (counter > 100 && counter <= 400)
                    nav.SetDestination(move);
                else if (counter > 400)
                    counter = 0;
            }
        }
        else {
            nav.enabled = false;
        }
	}


}
