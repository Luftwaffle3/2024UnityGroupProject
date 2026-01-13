using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCorruption : MonoBehaviour
{
    public int maxCorruption = 100;
    public int currentCorruption;

    public CorruptionBar corruptionBar;

    // Start is called before the first frame update
    void Start()
    {
        corruptionBar.SetMaxCorruption(maxCorruption);
    }

    // Example function to increase corruption on an action, like stealing money
    public void IncreaseCorruption(int amount)
    {
        currentCorruption = Mathf.Clamp(currentCorruption + amount, 0, maxCorruption);
        corruptionBar.SetCorruption(currentCorruption);
    }

    public void AdjustCorruption(int amount)
    {
        currentCorruption = Mathf.Clamp(currentCorruption + amount, 0, maxCorruption);
        corruptionBar.SetCorruption(currentCorruption);
    }

}
