using UnityEngine;

public class Door : Interactable {

    private Collider2D col;

    void Awake() {
        GameObject ch = GetChild(0);
        col = ch.GetComponent<Collider2D>();
    }

    public void OnInteract() {
        col.SetActive(!col.activeSelf);
        // TODO swap sprites
    }

}
