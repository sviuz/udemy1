using System;
using UnityEngine;

public class LeverArm : MonoBehaviour
{
    private FinishScript _finish;
    private void Start()
    {
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<FinishScript>();
    }

    private void ActivateLeverArm()
    {
        _finish.Activate();
    }
}
