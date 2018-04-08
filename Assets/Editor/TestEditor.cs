using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Test))]
public class ScriptEditor:Editor{

	public override void OnInspectorGUI(){

		var inspector = target as Test;

		inspector.saveInFile = GUILayout.Toggle (inspector.saveInFile,"Save In File");

		if (inspector.saveInFile) {
			inspector.path = EditorGUILayout.TextField ("File Path",inspector.path);
			inspector.encypt = GUILayout.Toggle (inspector.encypt,"Encrypt File");
		}
	}
}