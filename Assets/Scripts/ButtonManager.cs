using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] PlayerController p;
    public void Play()
    {
        p.enabled = true;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
