using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Projectile laserPrefab;
    public Sprite splat;
    public float speed = 7.5f;
    public float controller_speed = 5.0f;
    public int lives = 3;
    
    private bool _laserActive;
    //private bool killed = false;
    private SpriteRenderer _spriteRenderer;

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        // Input.GetKey: mantenir i segueix movent; Input.GetKeyDown: mantens i només es mou x1 cop.
        
        if (this.transform.position.x >= -14) {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                if (Input.GetJoystickNames()[0] != "") {
                    this.transform.position += Vector3.left * this.controller_speed * Time.deltaTime;
                } else {
                    this.transform.position += Vector3.left * this.speed * Time.deltaTime;
                }
            }
        }
        if (this.transform.position.x <= 14) {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                if (Input.GetJoystickNames()[0] != "") {
                    this.transform.position += Vector3.right * this.controller_speed * Time.deltaTime;
                } else {
                    this.transform.position += Vector3.right * this.speed * Time.deltaTime;
                }
            }
        }

        if (Input.GetJoystickNames()[0] != "") {
            float axisfl = Input.GetAxis("Horizontal");
            Vector3 _Axis = new Vector3(axisfl, 0.0f, 0.0f);

            if (this.transform.position.x >= -14 && axisfl <= 0) {
                this.transform.position += _Axis * this.speed * Time.deltaTime;
            }
            if (this.transform.position.x <= 14 && axisfl >= 0) {
                this.transform.position += _Axis * this.speed * Time.deltaTime;
            }
        }
    
        // Input.GetMouseButtonDown(button_index) -> 0 = left click
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 0")) {
            Shoot();
        }

        Debug.Log(/*Input.GetJoystickNames()[0] + " " + Input.GetAxis("Horizontal")*/Input.GetJoystickNames()[0]);
    }

    private void Shoot() {

        if (!_laserActive) {
            Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            _laserActive = true;
            Sound.PlaySound("shoot");
        }
    }

    private void LaserDestroyed() {
        _laserActive = false;
    }

    private void PlayerKilled() {
        _spriteRenderer.sprite = splat;
        System.Threading.Thread.Sleep(50);
        Sound.audioSrc.Stop();
        Sound.PlaySound("playerDead");
        
        //killed = true;

        // TODO: MAKE IT PAUSE WITH Pause.cs
        Time.timeScale = 0;
        
        //System.Threading.Thread.Sleep(1000);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader") || 
            other.gameObject.layer == LayerMask.NameToLayer("Missile")) {
            lives--;
            if (lives == 2) {
                GameObject.Find("Live1").transform.localScale = new Vector3(0, 0, 0);
                Sound.PlaySound("hit");
            } else if (lives == 1) {
                GameObject.Find("Live2").transform.localScale = new Vector3(0, 0, 0);
                Sound.PlaySound("hit");
            } else if (lives <= 0) {
                GameObject.Find("Live3").transform.localScale = new Vector3(0, 0, 0);
                PlayerKilled();
            }
        }
    }
}