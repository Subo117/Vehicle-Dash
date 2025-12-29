using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject playerModel;
    [SerializeField] float moveSpeed = 100f;

    InputAction left;
    InputAction right;

    Animator animator;
    float laneDistance = 15f;
    int currentLane = 0;
    public bool isMovable = true;

    List<String> twoWheeler = new List<String>() { "Bike"};

    private void Awake()
    {
        left = InputSystem.actions.FindAction("Left");
        right = InputSystem.actions.FindAction("Right");
        animator = playerModel.GetComponent<Animator>();
        Debug.Log(playerModel.name);
        Debug.Log(animator == null);
    }
    
    private void Update()
    {
        if (!isMovable) return;
       
        if (left.WasPressedThisFrame() && (currentLane > -1))
        {
            currentLane--;
            if(twoWheeler.Contains(PlayerPrefs.GetString("SelectedVehicle"))) animator.Play("2Left", 0, 0f);
            else animator.Play("4Left", 0, 0f);
        }

        if (right.WasPressedThisFrame() && currentLane < 1)
        {
            currentLane++;
            if (twoWheeler.Contains(PlayerPrefs.GetString("SelectedVehicle"))) animator.Play("2Right", 0, 0f);
            else animator.Play("4Right", 0, 0f);
        }


        Vector3 targetPos = new Vector3(currentLane * laneDistance, playerModel.transform.position.y, playerModel.transform.position.z);

        playerModel.transform.position = Vector3.MoveTowards(playerModel.transform.position, targetPos, moveSpeed * Time.deltaTime
        );
    }

}
