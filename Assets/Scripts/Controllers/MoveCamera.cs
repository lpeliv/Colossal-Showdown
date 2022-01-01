using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public Transform player;

    void Update() {

        //Camera Movement
        transform.position = player.transform.position;
    }

}