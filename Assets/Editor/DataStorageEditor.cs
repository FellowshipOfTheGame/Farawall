using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DataStorage))]
public class DataStorageEditor : Editor {

	public override void OnInspectorGUI(){

		var inspector = target as DataStorage;

		inspector.saveInFile = GUILayout.Toggle (inspector.saveInFile,"Save In File");

		if (inspector.saveInFile) {
			inspector.path = EditorGUILayout.TextField ("File Path",inspector.path);
			inspector.encypt = GUILayout.Toggle (inspector.encypt,"Encrypt File");
		}
	}
}
