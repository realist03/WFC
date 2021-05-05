using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Towards
{
    Up,
    Down,
    Left,
    Right,
    Front,
    Back
}

public class Module : MonoBehaviour
{
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool forward;
    public bool back;

}
