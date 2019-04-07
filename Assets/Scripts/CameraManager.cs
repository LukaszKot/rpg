using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset = new Vector3(-5f, -5f, 0); //położenie kamery wględem Playera
    public float cameraZoom = 1f; // startowy zoom kamery
    public float pitch = 1f; // nachylenie w osi x

    public float zoomSpeed = 2f; // szybkość przybliżania kamery do playera
    public float minZoom = 1f; // minimalny zoom kamery
    public float maxZoom = 10f; //maksymalny zoom kamery

    public float yawSpeed = 1f; // szybkość rozgladania klawiszami AD
    public float cameraYaw = 0f; // bieżąca wartość rozglądania wg osi Y
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cameraZoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed; // warość skrola
        cameraZoom = Mathf.Clamp(cameraZoom, minZoom, maxZoom); // ograniczenie zakresu zooma
        cameraYaw += Input.GetAxis("Horizontal") * yawSpeed; // klawiatura
    }

    void LateUpdate()
    {
        transform.position = player.transform.position - offset * cameraZoom;
        transform.LookAt(player.transform.position + Vector3.up * pitch);
        transform.RotateAround(player.transform.position, Vector3.up, cameraYaw);
    }
}
