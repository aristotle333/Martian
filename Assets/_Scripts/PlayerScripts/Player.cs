using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public static        Player S;
    public float         x_f, y_f, z_f;
    public bool          hasJetPack = true;
    public bool          isInBlueRoom;
    public bool          isInAPuzzleRoom;
    public bool          isChangingRoom = false;
    public bool          playerCollidedWithQuestDoor;               // Used to avoid multiple collisions

    public bool          carriesSignalTowerPart = false;
	public Vector3 startingPosition;
	public GameObject light_source;
	public bool light_on;
	public const int	 MAXHEALTH = 100;
	[SerializeField]
	private int 		 _health = MAXHEALTH;
    private GameObject   camera;
    public Vector3       playerDirection;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip m_Dead;
	[SerializeField] private AudioClip m_hurted;
	[SerializeField] private AudioClip breathing;
    [SerializeField] private AudioClip changeMirrorRoom;
	[SerializeField] private AudioClip questPickupSound;

    public int health {
		get {
			return _health;
		}
		set {
			if (value > MAXHEALTH)
				_health = MAXHEALTH;
			else 
				_health = value;

			audioSource.clip = m_hurted;
			GameManager.S.playerHealthValue = _health;
			if (_health <= 0) {
				transform.position = startingPosition;

				audioSource.clip = m_Dead;
				audioSource.Play ();
				health = 80;
				GameManager.S.setPromptText (Strings.DEADTEXT);
			} else {
				audioSource.Play ();
			}
		}
	}

	void Awake() {
		S = this;
//		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = breathing;
		audioSource.Play();
        isInAPuzzleRoom = false;
        playerCollidedWithQuestDoor = false;
		startingPosition = transform.position;
    }

	// Use this for initialization
	void Start () {
        x_f = this.transform.position.x;
        y_f = this.transform.position.y;
        z_f = this.transform.position.z;
		light_on = false;
        camera = GameObject.Find("FirstPersonCharacter");
	}
	
	// Update is called once per frame
	void Update () {
        x_f = this.transform.position.x;
        y_f = this.transform.position.y;
        z_f = this.transform.position.z;
        playerDirection = findPlayerDirection();
		if (Input.GetKeyDown(KeyCode.F) && light_on == false) 
		{
			light_source.gameObject.SetActive (true);
			light_on = true;
			print (light_on);
		}
		else if (Input.GetKeyDown(KeyCode.F) && light_on == true) 
		{
			light_source.gameObject.SetActive (false);
			light_on = false;
			print (light_on);
		}
        if (Input.GetKey(KeyCode.Space) && hasJetPack) {
            CharacterController controller = GetComponent<CharacterController>();
            print(this.GetComponent<CharacterController>().velocity);
            if (GetComponent<CharacterController>().velocity.y <= Utils.jetPackMaxSpeed) {
                Vector3 currPos = this.transform.position;
                currPos.y += 1f;
                //Vector3 moveDirection = controller.velocity;
                //moveDirection = transform.TransformDirection(moveDirection);
                //moveDirection.y += Utils.jetPackAcceleration;
                this.transform.position = currPos;

                print("I am moving up");
                //controller.Move(moveDirection);
            }
            else {
                print("velocity too high");
            }
        }

        // Check the room number as long as player is in a Puzzle room
        if (isInAPuzzleRoom) {
            if (this.transform.position.x > GameManager.S.Rooms[GameManager.S.activeRoomNumber].gameObject.transform.position.x) {
                if (isInBlueRoom && !isChangingRoom) {
                    audioSource.PlayOneShot(changeMirrorRoom);
                }
                isInBlueRoom = false;
            }
            else {
                if (!isInBlueRoom && !isChangingRoom) {
                    audioSource.PlayOneShot(changeMirrorRoom);
                }
                isInBlueRoom = true;
            }
        }
    }

    Vector3 findPlayerDirection() {
        Vector3 vec;
        vec = camera.transform.forward;
        return vec;
    }

	void OnCollisionEnter(Collision coll){

		int value;
        switch (coll.gameObject.tag) {

		case "OxygenCollectible":
			value = coll.gameObject.GetComponent<OxygenCollectible> ().quantity;
			print (value);
            GameManager.S.oxygenValue += value;
            break;
//	    case "IronCollectible":
//			value = coll.gameObject.GetComponent<IronCollectible> ().quantity;
//            GameManager.S.ironValue += value;
//            break;
		case "HealthCollectible":
			value = coll.gameObject.GetComponent<HealthCollectible> ().quantity;
			health += value;
			break;
        }
		print (coll.gameObject.tag);
    }

    void OnTriggerEnter(Collider coll) {
        switch(coll.gameObject.name) {
		case "SignalTowerPart1":
			audioSource.clip = questPickupSound;
			audioSource.Play ();
            Destroy(coll.gameObject);
            carriesSignalTowerPart = true;
            break;
        case "SignalTowerPart2":
			audioSource.clip = questPickupSound;
			audioSource.Play ();
            Destroy(coll.gameObject);
            carriesSignalTowerPart = true;
            break;
        case "SignalTowerPart3":
			audioSource.clip = questPickupSound;
			audioSource.Play ();
            carriesSignalTowerPart = true;
            Destroy(coll.gameObject);
            break;
        }
    }
}
