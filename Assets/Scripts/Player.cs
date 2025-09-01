using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput pi;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator ani;
    private Shoot st;

    private InputAction move;
    private InputAction shoot;
    private InputAction quit;
    private InputAction restart;

    [SerializeField] private bool moving;
    private float tankSpeed = 5.0f;
    private float direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pi = GetComponent<PlayerInput>();
        pi.currentActionMap.Enable();
        rb = GetComponent<Rigidbody2D>();
        st = GetComponent<Shoot>();
        ani = GetComponent<Animator>();

        move = pi.currentActionMap.FindAction("Move");
        shoot = pi.currentActionMap.FindAction("Shoot");
        quit = pi.currentActionMap.FindAction("Quit");
        restart = pi.currentActionMap.FindAction("Restart");

        move.started += Move_started;
        move.canceled += Move_canceled;
        shoot.performed += Shoot_performed;
        quit.started += Quit_started;
        restart.started += Restart_started;
    }

    private void Restart_started(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(0);
    }

    private void Quit_started(InputAction.CallbackContext obj)
    {
        Application.Quit();
        Debug.Log("You have quit.");
    }

    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        st.SpawnBullet();
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        moving = false;
    }

    private void Move_started(InputAction.CallbackContext obj)
    {
        moving = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            rb.linearVelocity = new Vector2(0, tankSpeed * direction);
        }

        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void Update()
    {
        if (moving)
        {
            direction = move.ReadValue<float>();
        }
    }
}
