using UnityEngine;

public class ActiveSwitch : MonoBehaviour
{
    /// <summary>
    /// Switches the target object between active and inactive
    /// </summary>
    public void SwitchActive(GameObject target)
    {
        //If the target is active, turn it inactive. If its inactive, turn it active.
        target.SetActive(!target.activeSelf);
    }
}
