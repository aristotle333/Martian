using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

	public CollectiblesType type;
	public int quantity;
	public float timeToLive;

	public Collectible(CollectiblesType _type, int _quantity, float _timeToLive) {
		this.type = _type;
		this.quantity = _quantity;
		this.timeToLive = _timeToLive;
	}

    void OnCollisionEnter(Collision coll) {
        switch (coll.gameObject.tag) {
            case "Player":
                // Play sound for getting object
                // Perhaps a different one for each kind of object
				print("Collected by Player" + this.gameObject.tag);
                Destroy(this.gameObject);
                break;

            case "Ground":
                // Hit the ground do nothing
                break;
            default:
                //Debug.Assert(false);
                break;
        }
    }
}
