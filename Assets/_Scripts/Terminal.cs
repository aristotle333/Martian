using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Terminal : MonoBehaviour {

	public static Terminal S;
    public GameObject SignalTowerReference;

	public const int FIRSTQUESTTRIGGER = 2;
	public const int SECONDQUESTTRIGGER = 5;
	public const int THIRDQUESTTRIGGER = 9;
	const string INCOMPLETEQUESTERRORMESSAGE = "COMPLETE QUEST BEFORE CONTINUING TO BUILD";

	const int SMGCOST = 100;
	const int RIFLECOST = 300;
	const int GRAVITYGUNCOST = 200;

	bool triggerExited;

	public bool questActive = false;
	[SerializeField]
	bool questPromptShown = false;

	bool playerInRange;

	[SerializeField]
	Canvas terminalCanvas;	
//	[SerializeField]
//	Text insufficientIronMessage;
	[SerializeField]
	Text questProgressText;
	[SerializeField]
	Slider questSlider;
	[SerializeField]
	Text hintMsg;
	[SerializeField]
	Text questButtonText;

	public GameObject firstQuest;
	public GameObject secondQuest;
	public GameObject thirdQuest;

	int _numSteelBeamsMade;

	public int numSteelBeamsMade {
		get {
			return _numSteelBeamsMade;
		}
		set { 
			_numSteelBeamsMade = value;
			int percent = _numSteelBeamsMade * 10;
			questProgressText.text = percent + "% complete" ;
			questSlider.value = percent;
			    
			// At percent 30, 60, 90, show quest or something
			if (_numSteelBeamsMade == FIRSTQUESTTRIGGER) {
				// Show stuff in the minimap
				firstQuest.SetActive(true);
				questActive = true;
				questPromptShown = false;
				hintMsg.enabled = true;
				hintMsg.text = Strings.QUESTONEPROMPT;
				questButtonText.text = Strings.NEXTQUEST;

			} else if (_numSteelBeamsMade == SECONDQUESTTRIGGER) {
				questActive = true;
				questPromptShown = false;
				secondQuest.SetActive(true);
				hintMsg.enabled = true;
				hintMsg.text = Strings.QUESTTWOPROMPT;
				firstQuest.SetActive (false);

			} else if (_numSteelBeamsMade == THIRDQUESTTRIGGER) {
				questActive = true;
				questPromptShown = false;
				hintMsg.enabled = true;
				hintMsg.text = Strings.QUESTTHREEPROMPT;
				secondQuest.SetActive (false);
				thirdQuest.SetActive (true);
			}

		}
	}

	void Awake() {
		S = this;
        SignalTowerReference = GameObject.Find("SignalTowerLocation");
    }

    // Use this for initialization
    void Start () {
		playerInRange = false;
		numSteelBeamsMade = 0;
		terminalCanvas.enabled = false;
		hintMsg.enabled = false;
		triggerExited = false;
		SignalTowerReference.GetComponent<SignalTower>().CreateBase();
		firstQuest.SetActive (false);
		secondQuest.SetActive (false);
		thirdQuest.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			if (playerInRange) {
				if (!terminalCanvas.enabled)
					OpenInterface ();
				else CloseInterface ();
				Player.S.gameObject.GetComponent<FirstPersonController> ().ToggleCursorLock ();
			}
		}
	}

	void OnTriggerEnter(Collider c){
		if (c.CompareTag ("Player")) {
			playerInRange = true;
			triggerExited = false;
			GameManager.S.setPromptText (Strings.CONSOLEPROMPT);
		}
	}

	void OnTriggerStay (Collider c) {
		if (c.CompareTag("Player")) {
			// Replendish oxyen
			if (Time.time % 0.5f == 0.0f) {
				GameManager.S.oxygenValue += 2;
			}
		}
	}
	void OnTriggerExit (Collider c) {
		print("on trigger exit");

		if (c.CompareTag ("Player")) {
			if (!triggerExited) {
				triggerExited = true;
				playerInRange = false;
				if (questActive && !questPromptShown) {
					questPromptShown = true;

					GameManager.S.setPromptText ();
				} else {
					GameManager.S.closePrompt ();
				}
			}
		}
	}
		
	void OpenInterface() {
		terminalCanvas.enabled = true;
		Time.timeScale = 0;
		GameManager.S.crosshairImage.enabled = false;
		GameManager.S.closePrompt ();
	}

	void CloseInterface() {
		terminalCanvas.enabled = false;
		Time.timeScale = 1;
		GameManager.S.crosshairImage.enabled = true;
	}

	public void StartQuest() {
		if (!questActive) {
			if (numSteelBeamsMade < FIRSTQUESTTRIGGER) {
				numSteelBeamsMade = FIRSTQUESTTRIGGER;
			} else if (numSteelBeamsMade < SECONDQUESTTRIGGER) {
				numSteelBeamsMade = SECONDQUESTTRIGGER;
			} else if (numSteelBeamsMade < THIRDQUESTTRIGGER) {
				numSteelBeamsMade = THIRDQUESTTRIGGER;
			}
		}
	}

//	public void BuyPlasmaSmg() {
//		if (GameManager.S.ironValue >= SMGCOST) {
//			GameManager.S.ironValue -= SMGCOST;
//
//			WeaponManager.S.ownership[(int)weapons.SMG] = true;
//
//		} else {
//			insufficientIronMessage.enabled = true;
//		}
//	}

//	public void BuyAntimatterRifle() {
//		if (GameManager.S.ironValue >= RIFLECOST) {
//			GameManager.S.ironValue -= RIFLECOST;
//
//			WeaponManager.S.ownership[(int)weapons.Rifle] = true;
//		} else {
//			insufficientIronMessage.enabled = true;
//		}
//	}wwwww
//	public void BuyGravityGun() {
//		if (GameManager.S.ironValue >= GRAVITYGUNCOST) {
//			GameManager.S.ironValue -= GRAVITYGUNCOST;
//
//			WeaponManager.S.ownership[(int)weapons.BaseWeapon] = true;
//		} else {
//			insufficientIronMessage.enabled = true;
//		}
//	}

	public void questComplete() {
		Debug.Assert (questActive);
		questActive = false;

		// Show text to quest one complete
		GameManager.S.setPromptText ();

		if (numSteelBeamsMade == THIRDQUESTTRIGGER) {
			MusicManager.S.playThemeMusic ();
			Invoke ("LoadMenu", 6.0f);
		}
	}

	public void LoadMenu() {
		SceneManager.LoadScene ("Scene_Intro");
	}
}
