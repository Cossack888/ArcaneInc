using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public const string HIDDEN_FLAG = "Hidden Flag";
}
public class Hidden : MonoBehaviour
{
    private void OnValidate()
    {
        RefreshHiddenState();

    }
    public void RefreshHiddenState()
    {
        bool hidden = UnityEditor.EditorPrefs.GetBool(Constants.HIDDEN_FLAG, false);
        this.gameObject.hideFlags = hidden ? HideFlags.HideInHierarchy : HideFlags.None;
    }
}
