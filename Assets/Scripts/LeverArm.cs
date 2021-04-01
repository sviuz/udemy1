using System;
using UnityEngine;

public class LeverArm : MonoBehaviour
{
    private FinishScript _finish;
    private void Start()
    {
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<FinishScript>();
    }

    public void Activate()
    {
        _finish.Activate();
    }
}
