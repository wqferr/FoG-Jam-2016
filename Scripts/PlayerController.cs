using UnityEngine;

public class PlayerController : MonoBehaviour {

    public const int SPR_U = 0;
    public const int SPR_UR = 1;
    public const int SPR_R = 2;
    public const int SPR_DR = 3;
    public const int SPR_D = 4;

    public float speed = 0;

    public Sprite[] sprites = new Sprite[5];

    private SpriteRenderer sr;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
        // TAG: Player
        gameObject.name = "Player";
    }

    void FixedUpdate() {
        Vector3 moveDir = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        ).normalized;

        transform.Translate(moveDir * speed);
        // TODO update sprite
    }

    private void updateSprites(Vector3 moveDir) {
        if (moveDir.x == 0) {
            // Stopped horizontally
            if (moveDir.y > 0) {
                sr.sprite = sprites[SPR_U];
            } else if (moveDir.y < 0) {
                sr.sprite = sprites[SPR_D];
            }
        } else {
            // Moving horizontally
            if (moveDir.y > 0) {
                sr.sprite = sprites[SPR_UR];
            } else if (moveDir.y < 0) {
                sr.sprite = sprites[SPR_DR];
            }

            if (moveDir.x < 0) {
                sr.flipX = true;
            } else {
                sr.flipX = false;
            }
        }
    }
}
