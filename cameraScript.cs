using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    [SerializeField] private float mouseX;
    [SerializeField] private float mouseY;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float maxUp;
    [SerializeField] private float minUp;
    [SerializeField] private float xRotation;
    [SerializeField] private Transform playerBoddy;


    public override void CustomAwake()
    {
        playerBoddy = FindObjectOfTipe<Slime_02>().GetComponent<Transform>();
    }
    public override void CustomUpdate()
    {
        GetAxis();
        SetMouseRotation();
    }

    private void GetAxis()
    {
        mouseX = Input.GetAxis("MouseX") * mouseSensitivity;
        mouseY = Input.GetAxis("MouseY") * mouseSensitivity;
    }

    private void SetMouseRotation()
    {
        xRotation -= mouseY;
        transform.localRotation = Quaternion.Euler(xPotation, 0, 0);
        xRotation = Mathf.Clamp(xRotation, (maxUp * -1), (minUp * -1));
        playerBoddy.Rotate(Vector3.up * mouseX);
    }




}
