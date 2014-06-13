using UnityEngine;
using System.Collections;

public class ConsoleCommands : MonoBehaviour {
	protected Console console;
	public Console SetConsole {
		set {console = value;}
	}
	
	void log() {
		string output = "";
		for (int i = 1; i < console.CommandWords.Length; i++) {
			output += console.CommandWords[i] + " ";
		}
		
		console.Log(output, 0);
	}
}
