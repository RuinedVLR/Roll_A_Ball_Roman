using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;

    public static float speed = 7;

    public TextMeshProUGUI countText;

    public int playerHealth;
    public TextMeshProUGUI playerHealthText;

    public GameObject loseTextObject;
    public static bool isDead;
    public bool hasDied = false;
    public TextMeshProUGUI survivedTimeText;

    public TextMeshProUGUI timeText;
    private float timer;

    private string finalSurvivedTime;

    public TextMeshProUGUI xpText;
    public TextMeshProUGUI lvlText;
    private int lvl;
    private int xp;
    private int xpNeeded;
    public static bool isLVLup = false;

    public AudioClip pickupClip;
    public AudioSource randomPitch;

    public AudioSource hitSound;
    public AudioClip hitClip;
    public AudioClip deathSound;

    void Start()
    {
        isDead = false;

        rb = GetComponent<Rigidbody>();

        timer = 0;

        lvl = 1;
        xp = 0;

        loseTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void Update()
    {
        if (!isDead)
        {
            timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            finalSurvivedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
            timeText.text = finalSurvivedTime;
        }
        else if (!hasDied)
        {
            hasDied = true;
        }

        xpNeeded = 45 + (5 * lvl);

        if (Collector.isCollected)
        {
            randomPitch.pitch = Random.Range(0.8f, 1.2f);
            randomPitch.PlayOneShot(pickupClip, 0.1f);
            xp += 25;
            Collector.isCollected = false;
        }

        if (xp >= xpNeeded)
        {
            int leftOverXp = xp - xpNeeded;
            lvl++;
            xp = 0 + leftOverXp;
            isLVLup = true;
        }
        xpText.text = "XP: " + xp.ToString() + "/" + xpNeeded.ToString();
        lvlText.text = "LVL: " + lvl.ToString();
        playerHealthText.text = "Health: " + playerHealth.ToString();

        speed = 7 + LVLupMenu.speedLvl;


        if (playerHealth <= 0)
        {
            isDead = true;
            survivedTimeText.text = "You survived for: " + finalSurvivedTime;
            hitSound.PlayOneShot(deathSound);

            gameObject.SetActive(false);
            timeText.gameObject.SetActive(false);
            xpText.gameObject.SetActive(false);
            lvlText.gameObject.SetActive(false);
            playerHealthText.gameObject.SetActive(false);
            loseTextObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                enemy.Die();
            }
            else
            {
                Debug.LogWarning("EnemyScript not found on collided object", collision.gameObject);
            }

            if(playerHealth > 0)
            {
                hitSound.PlayOneShot(hitClip);
                playerHealth -= 1;
            }
        }
    }
}
