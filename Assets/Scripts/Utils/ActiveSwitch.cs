using UnityEngine;

public class ActiveSwitch : MonoBehaviour
{
    /// <summary>
    /// Switches the target object between active and inactive
    /// </summary>
    public void SwitchActive(GameObject target)
    {
        target.SetActive(!target.activeSelf);
    }
}
