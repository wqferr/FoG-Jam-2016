using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 0;

    private SpriteRenderer sr;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
        // TAG: Player
        gameObject.name = "Player";
    }

    void FixedUpdate() {
        Vector3 moveDir = new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"),
            0
        ).normalized;

        transfrom.Translate(moveDir * speed);
        // TODO update sprite
    }

}
