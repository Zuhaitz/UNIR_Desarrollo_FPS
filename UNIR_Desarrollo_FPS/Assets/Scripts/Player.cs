using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    PlayerControls controls;
    CharacterController controller;
    Camera mainCamera;
    
    [SerializeField] Gun gun;
    [SerializeField] float sensitivity = 100f;

    Vector2 rotate;
    float xRotation = 0f;

    Vector2 move;
    [SerializeField] float speed = 12f;

    void Awake(){
        mainCamera = Camera.main;
        controller = GetComponent<CharacterController>();
        controls = new PlayerControls();

        controls.Player.CameraMove.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Player.CameraMove.canceled += ctx => rotate = Vector2.zero;

        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;

        controls.Player.Shoot.performed += ctx => ShootGun();
    }

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        cameraMovement();
        movement();
    }

    private void cameraMovement(){
        float mouseX = rotate.x * sensitivity * Time.deltaTime;
        float mouseY = rotate.y * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void movement(){
        Vector3 m = transform.right * move.x + transform.forward * move.y;

        controller.Move(m * speed* Time.deltaTime);
    }

    private void ShootGun(){
        gun.Shoot();
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
