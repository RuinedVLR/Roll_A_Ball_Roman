using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public static float speed = 50;
    public TextMeshProUGUI countText;
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

        speed = 7 + LVLupMenu.speedLvl;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            isDead = true;

            survivedTimeText.text = "You survived for: " + finalSurvivedTime;

            gameObject.SetActive(false);
            timeText.gameObject.SetActive(false);
            xpText.gameObject.SetActive(false);
            lvlText.gameObject.SetActive(false);
            loseTextObject.SetActive(true);
        }
    }

}
