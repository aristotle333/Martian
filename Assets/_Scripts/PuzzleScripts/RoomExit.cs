using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomExit : MonoBehaviour {

    public bool DoorIsQuestExit = false;
    public int  QuestNumber;

    void OnTriggerEnter(Collider coll) {
        string name = coll.gameObject.name;
        if (name == "Player") {
            Debug.Log("Player reached the exit");
            if (DoorIsQuestExit) {
                if (!Player.S.carriesSignalTowerPart) {
                    Debug.Log("Need to collect item before exit");
                    GameManager.S.setPromptText(Strings.NEEDTOCOLLECTPARTTOEXIT);
                    return;
                }
                Debug.Log("Spawning back to Quest " + QuestNumber + "location");
                this.GetComponent<AudioSource>().Play();
                SpawnPlayerBackToMars(QuestNumber);
                GameManager.S.activeRoomNumber++;
                return;
            }
            GameManager.S.changeMazeLevel();
            this.GetComponent<AudioSource>().Play();
        }
    }

    void SpawnPlayerBackToMars(int questNumber) {
        Debug.Log("Calling SpawnPlayerBackToMars() function");
        StartCoroutine(getOutOfQuest());
    }

    public IEnumerator getOutOfQuest() {
        Player.S.isInAPuzzleRoom = false;
        Debug.Log("Calling getOutOfQuest() function");
        float waitTime = FadeInFadeOut.S.BeginFade(1);
        yield return new WaitForSeconds(15 * waitTime);

        Vector3 QuestOrigin = GameManager.S.QuestLocations[QuestNumber - 1].gameObject.transform.position;
        Debug.Log("x = " + QuestOrigin.x + " ,y = " + QuestOrigin.y + " ,z = " + QuestOrigin.z);
        //Vector3 PlayerSpawn = QuestOrigin + GameManager.S.QuestExitOffset;
        Vector3 PlayerSpawn = QuestOrigin + new Vector3(0, 6, 10);
        Debug.Log("x = " + PlayerSpawn.x + " ,y = " + PlayerSpawn.y + " ,z = " + PlayerSpawn.z);

        Player.S.gameObject.transform.position = PlayerSpawn;
        MusicManager.S.playWindSound();
        //Player.S.gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);

        waitTime = FadeInFadeOut.S.BeginFade(-1);
        yield return new WaitForSeconds(30 * waitTime);
        Player.S.playerCollidedWithQuestDoor = false;
        TutorialManager.S.CallQuestBack();
        if (GameManager.S.activeRoomNumber == 8) {
            MusicManager.S.playThemeMusic();
        }
    }


    //[SerializeField]
    //List<Color> colorList;

    //public float animationSpeed = 1f;
    //private float animationCounter = 0;
    //private float currTime = 0;

    //void Start() {
    //    colorList.Add(Color.blue);
    //    colorList.Add(Color.red);
    //    colorList.Add(Color.cyan);
    //    colorList.Add(Color.green);
    //    colorList.Add(Color.gray);
    //    colorList.Add(Color.yellow);
    //    colorList.Add(Color.magenta);
    //}

    //void Update() {
    //    currTime = Time.time;
    //    if (currTime - animationCounter > animationSpeed) {
    //        Color32 newColor = (Color32)colorList[(int)Random.Range(0, colorList.Count)];
    //        GetComponent<Renderer>().material.color = new Color32(newColor.r, newColor.g, newColor.b, newColor.a);
    //        animationCounter = Time.time;
    //    }
    //}
}
