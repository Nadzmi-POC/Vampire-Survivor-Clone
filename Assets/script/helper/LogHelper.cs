using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LogHelper
{
    public static void ShowErrorLog(string entity, string message)
    {
        Debug.LogError("[" + entity + "] " + message);
    }
}
