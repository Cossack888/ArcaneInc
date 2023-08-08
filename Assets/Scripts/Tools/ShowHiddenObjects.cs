using UnityEditor;
using UnityEngine;

public static class ShowHiddenObjects
{
    public const string k_menu = "Game/Show Slots";
    [MenuItem(k_menu)]
    static void ShowHiddenMenuItems()
    {
        EditorPrefs.SetBool(Constants.HIDDEN_FLAG, !EditorPrefs.GetBool(Constants.HIDDEN_FLAG, false));
        foreach (Hidden hidden in GameObject.FindObjectsOfType<Hidden>())
        {
            hidden.RefreshHiddenState();
        }
    }
    [MenuItem(k_menu,true)]
    static bool ShowHiddenMenuItemValidation()
    {
        Menu.SetChecked(k_menu, !EditorPrefs.GetBool(Constants.HIDDEN_FLAG, false));
        return true;
    }
}
