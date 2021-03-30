using UnityEngine;

public class FinishScript : MonoBehaviour
{
    private bool isActivated = false;
    public void FinishLevel()
    {
        if (isActivated)
        {
            gameObject.SetActive(false);
        }
    }
}
