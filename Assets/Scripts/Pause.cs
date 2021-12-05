using UnityEngine;

/*
SpriteRenderer.color = new Color(1f,1f,1f,1f) is a normal sprite
SpriteRenderer.color = new Color(1f,1f,1f,.5f) is about 50% transparent
SpriteRenderer.color = new Color(1f,1f,1f,0f) is about 100% transparent (Cant be seen at all, but still active)
*/

public class Pause : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    //public Sprite pauseIcon;

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public bool paused = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !this.paused ||
            Input.GetKeyDown(KeyCode.Return) && !this.paused ||
            Input.GetKeyDown("joystick button 9") && !this.paused) {
        
            Time.timeScale = 0;
            this.paused = true;
            _spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
            AudioListener.pause = true;
            //pauseIcon.color = new Color(1f, 1f, 1f, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && this.paused ||
            Input.GetKeyDown(KeyCode.Return) && this.paused ||
            Input.GetKeyDown("joystick button 9") && this.paused) {
            
            Time.timeScale = 1;
            this.paused = false;
            _spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            AudioListener.pause = false;
            //pauseIcon.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
