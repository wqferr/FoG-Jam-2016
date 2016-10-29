using UnityEngine;

public class Door : Interactable {

    private GameObject col;
    private int state = 0;
    public Sprite[] sprites = new Sprite[2];
    private SpriteRenderer sr;

    void Awake() {
        col = transform.GetChild(0).gameObject;
        sr = GetComponent<SpriteRenderer>();
    }

    public override void OnInteract() {
        col.SetActive(!col.activeSelf);
        state = (state + 1) % 2;
        sr.sprite = sprites[state];
    }

}
