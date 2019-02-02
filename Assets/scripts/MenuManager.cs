using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void triggerMenuBehavior(int i) {
		switch (i) {
		default: 
		case 0:
			SceneManager.LoadScene ("Scene2");
			break;
		case 1:
			Application.Quit ();
			break;
		}
	}
}
