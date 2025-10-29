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
    public GameObject loseTextObject;
    private int count;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI lvlText;
    private int lvl;
    private int xp;
    public static bool isLVLup = false;



    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        lvl = 1;
        xp = 0;

        SetCountText();

        loseTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }

    private void Update()
    {
        if (Collector.isCollected)
        {
            count += 1;
            xp += 10;
            SetCountText();
            Collector.isCollected = false;
        }

        if (xp >= 50)
        {
            lvl++;
            xp = 0;
            isLVLup = true;
        }
        xpText.text = "XP: " + xp.ToString();
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
            Destroy(gameObject);
            loseTextObject.SetActive(true);
        }

    }

}
