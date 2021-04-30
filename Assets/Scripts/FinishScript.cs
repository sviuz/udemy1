using UnityEngine;

public class FinishScript : MonoBehaviour
{
    private bool _isActivated = false;

    public void Activate()
    {
        _isActivated = true;
    }
    
    public void FinishLevel()
    {
        if (_isActivated)
            gameObject.SetActive(false);
    }
}
