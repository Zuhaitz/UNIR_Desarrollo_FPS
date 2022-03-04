using UnityEngine;

public class Player : MonoBehaviour
{
    //Referencias
    PlayerControls controls;
    CharacterController controller;
    public Gun gun;

    //Camara
    Camera mainCamera;
    [SerializeField] float sensitivity = 100f;
    Vector2 rotate;
    float xRotation = 0f;

    //Movimiento
    Vector2 move;
    [SerializeField] float speed = 12f;
    [HideInInspector] public bool stop = false;

    void Awake(){
        //Obtener la camara, el controlador y  los controles
        mainCamera = Camera.main;
        controller = GetComponent<CharacterController>();
        controls = new PlayerControls();

        //Listener para el movimiento de la camara
        controls.Player.CameraMove.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Player.CameraMove.canceled += ctx => rotate = Vector2.zero;

        //Listener para el movimiento del personaje
        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;

        //Listener para el disparo
        controls.Player.Shoot.performed += ctx => ShootGun();
    }

    void Start(){
        //Bloqueael raton para que no se mueva
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Realiza el movimento
        cameraMovement();
        movement();
    }

    /*
    Encargado de procesar el movimiento de la camara
    */
    private void cameraMovement(){
        float mouseX = rotate.x * sensitivity * Time.deltaTime;
        float mouseY = rotate.y * sensitivity * Time.deltaTime;
        
        //Para evitar el giro completo de la camara
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotacion hacia arriba
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Rotacion a los lados
        transform.Rotate(Vector3.up * mouseX);
    }

    /*
    Encargado de procesar el movimiento del jugador
    */
    private void movement(){
        Vector3 m = transform.right * move.x + transform.forward * move.y;
        controller.Move(m * speed * Time.deltaTime);
    }

    /*
    Llama al arma para que dispare
    */
    private void ShootGun(){
        gun.Shoot();
    }

    /*
    Desactiva los controles del jugador
    */
    public void StopInput(){
        controls.Disable();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
