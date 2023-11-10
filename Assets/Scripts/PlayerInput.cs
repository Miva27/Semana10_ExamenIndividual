using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action OnShoot = () => { };
    public event Action<Vector3> OnChangeDirection = (value) => { };

    private static PlayerInput instance;
    public static PlayerInput Instance => instance;

    [SerializeField]
    private KeyCode shootKeycode;

    private Vector3 directionInput;

    public Vector3 DirectionInput => directionInput;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        directionInput = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));

        if (directionInput.x != 0 || directionInput.y != 0)
        {
            OnChangeDirection?.Invoke(directionInput);
        }

        if (Input.GetKeyDown(shootKeycode))
        {
            OnShoot?.Invoke();
        }
    }
}
