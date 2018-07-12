using UnityEngine;

public class CameraControl : MonoBehaviour {

    private GameObject player;
    private Vector3 offset = new Vector3(0, 2, -10);

    private void Start()
    {
        if (player == null) { player = GameObject.FindWithTag("Player"); }
    }

    private void FixedUpdate()
    {
        if (player != null) { transform.position = player.transform.position + offset; }
    }
}
