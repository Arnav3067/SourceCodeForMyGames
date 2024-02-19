using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsToMainMenu : MonoBehaviour
{
    private IEnumerator Start() {

        yield return new WaitForSeconds(14);
        Cursor.visible = true;
        Loader.LoadLevel(0);
    }
}
