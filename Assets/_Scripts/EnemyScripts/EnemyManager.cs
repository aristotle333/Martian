using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public GameObject bear;
	public GameObject bunny;
	public GameObject Hellephant;
    public float spawnTime = 1f;
	public Transform Player_Position;
	public List<GameObject> Bunny_list;
	public List<GameObject> Bear_list;
	public List<GameObject> Hellephant_list;
	public int bear_number;
	public int bunny_number;
	public int Hellephant_number;

    void Start ()
    {
		Player_Position = Player.S.transform;
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

	void Update()
	{
		
	}

    void Spawn ()
    {
		if( Player.S.health <= 0f || Player.S.transform.position.y > 25 || Player.S.transform.position.y < 0)
        {
            return;
        }
		Bunny_list.RemoveAll(delegate (GameObject o) { return o == null; });
		Bear_list.RemoveAll(delegate (GameObject o) { return o == null; });
		Hellephant_list.RemoveAll(delegate (GameObject o) { return o == null; });
		if (Bunny_list.Count != bunny_number) 
		{
			Vector3 spawnPoint = new Vector3 (Random.Range (Player_Position.position.x - 100f, Player_Position.position.x + 100f), Player_Position.position.y, Random.Range (Player_Position.position.z - 100f, Player_Position.position.z + 100f));
			GameObject temp = MonoBehaviour.Instantiate (bunny, spawnPoint, Quaternion.identity) as GameObject;
			Bunny_list.Add (temp);
		}
		if (Bear_list.Count != bear_number) 
		{
			Vector3 spawnPoint = new Vector3 (Random.Range (Player_Position.position.x - 100f, Player_Position.position.x + 100f), Player_Position.position.y, Random.Range (Player_Position.position.z - 100f, Player_Position.position.z + 100f));
			GameObject temp = MonoBehaviour.Instantiate (bear, spawnPoint, Quaternion.identity) as GameObject;
			Bear_list.Add (temp);
		}
		if (Hellephant_list.Count != Hellephant_number) 
		{
			Vector3 spawnPoint = new Vector3 (Random.Range (Player_Position.position.x - 100f, Player_Position.position.x + 100f), Player_Position.position.y, Random.Range (Player_Position.position.z - 100f, Player_Position.position.z + 100f));
			GameObject temp = MonoBehaviour.Instantiate (Hellephant, spawnPoint, Quaternion.identity) as GameObject;
			Hellephant_list.Add (temp);
		}
    }
}
