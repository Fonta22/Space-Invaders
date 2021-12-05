using UnityEngine;
using UnityEngine.SceneManagement;

public class Invader : MonoBehaviour 
{
    public Sprite[] animationSprites;
    public Sprite explosion;
    public float animationTime = 1.0f;
    public System.Action killed;
    public int row;

    private SpriteRenderer _spriteRenderer;
    private int _animationFrame; // index in animationSprites[]

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void AnimateSprite() {
        _animationFrame++;

        if (_animationFrame >= this.animationSprites.Length) {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }
    
    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.layer == LayerMask.NameToLayer("Laser")) {

            this.killed.Invoke();
            Sound.PlaySound("explosion");
            //Debug.Log(this.row);
            this.gameObject.SetActive(false);
        }
    }
}