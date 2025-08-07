using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PropGenerator))]
[CanEditMultipleObjects]
public class PropGeneratorEditor : Editor
{
  private PropGenerator _propGenerator;

  void OnEnable()
  {
    _propGenerator = serializedObject.targetObject as PropGenerator;
  }

  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();

    if(GUILayout.Button("Generate Props"))
    {
      _propGenerator.GenerateProps();
    }
  }
}
