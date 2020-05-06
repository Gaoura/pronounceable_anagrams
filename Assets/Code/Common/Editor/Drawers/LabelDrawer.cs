using UnityEngine;
using UnityEditor;


/// <summary> Drawer for the inspector label attribute </summary>
[CustomPropertyDrawer(typeof(LabelAttribute))]
public class LabelDrawer : PropertyDrawer
{
    /// <summary> Change the label of the <paramref name="property"/> </summary>
    /// <param name="position"> Position of the property </param>
    /// <param name="property"> Property to modifiy </param>
    /// <param name="label"> Property label </param>
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var property_attribute = this.attribute as LabelAttribute;

        // the property might point to an element of an array so we need to check
        // if that's the case because, then, the array label would be already drawed 
        // (and we would need his position to override it) so only an editor script can modify it
        if (!IsAnArray(property))
        {
            label.text = property_attribute.Label;
        }
        else
        {
            Debug.LogWarning($"{typeof(LabelAttribute).Name}(\"{property_attribute.Label}\") doesn't support arrays");
        }

        EditorGUI.PropertyField(position, property, label);
    }

    /// <summary> Is <paramref name="property"/> an array ? </summary>
    /// <param name="property"></param>
    /// <returns> Return true if <paramref name="property"/> is an array </returns>
    private bool IsAnArray(SerializedProperty property)
    {
        // CREDITS: https://answers.unity.com/questions/603882/serializedproperty-isnt-being-detected-as-an-array.html
        SerializedProperty parent_property = property.serializedObject.FindProperty(fieldInfo.Name);
        return parent_property.isArray;
    }
}
