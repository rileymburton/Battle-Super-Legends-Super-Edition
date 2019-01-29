using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public Transform panel;
	// Use this for initialization
	public void startCharacterSelect () {
		
		SceneManager.LoadScene("Test");
	}

	public void startSettings(){
		SceneManager.LoadScene("Settings Menu");
	}
	public void startSettingsFromKeybinds(){
		panel.gameObject.SetActive(false);
		if(KeybindingsScript.Kb.right != KeyCode.None && KeybindingsScript.Kb.left != KeyCode.None && KeybindingsScript.Kb.jump != KeyCode.None && KeybindingsScript.Kb.crouch != KeyCode.None && KeybindingsScript.Kb.lightAttack != KeyCode.None && KeybindingsScript.Kb.mediumAttack != KeyCode.None && KeybindingsScript.Kb.heavyAttack != KeyCode.None && KeybindingsScript.Kb.uniqueAttack != KeyCode.None){
			SceneManager.LoadScene("Settings Menu");
		}
		else{
				StartCoroutine(checkBindsFail());
		}
	}

	public IEnumerator checkBindsFail(){
			panel.gameObject.SetActive(true);
			yield return new WaitForSeconds(2);
			panel.gameObject.SetActive(false);
	}
	public void startMapSelect(){
		SceneManager.LoadScene(4);
	}

	public void startKeyBindings(){
		SceneManager.LoadScene("KeyBindings");
	}

	public void quitGame(){
		Application.Quit();
	}
}