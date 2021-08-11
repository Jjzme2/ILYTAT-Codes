using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public static PlayerInput GetInput => Instance.GetComponent<PlayerInput>();
    public Vector2 GetMousePos;
    public Vector2 WorldPointMousePos => Camera.main.ScreenToWorldPoint(GetMousePos);



    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        GetMousePos = Mouse.current.position.ReadValue();
    }
}
