using UnityEditor;
using UnityEngine;

namespace BAStudio.BitShape64
{
    [CustomPropertyDrawer(typeof(BitShape64Property))]
    public class BitShape64PropertyDrawer : PropertyDrawer
    {
        public override void OnGUI (UnityEngine.Rect position, SerializedProperty property, UnityEngine.GUIContent label)
        {
            BitShape64Property attr = attribute as BitShape64Property;
            if (attr.column == 0 || attr.row == 0)
            {
                EditorGUILayout.HelpBox("The column or row is 0.", MessageType.Error);
                return;
            }
            ulong value = unchecked((ulong) property.longValue);
            int right = 0, bottom = 0;
            for (int h = 0; h < attr.column; h++)
            for (int w = 0; w < attr.row; w++)
            {
                int index = attr.row * h + w;
                ulong mask = (ulong) 1 << index;
                if (EditorGUI.Toggle(new UnityEngine.Rect(position.xMin + w * 16, position.yMin + h * 16, 16, 16), (value & mask) > 0))
                {
                    if (right < w + 1) right = w + 1;
                    if (bottom < h + 1) bottom = h + 1;
                    value |= mask;
                }
                else
                {
                    value &= ~mask;
                }
                // GUI.Label(new UnityEngine.Rect(position.xMin + w * 16, position.yMin + h * 16, 16, 16), index.ToString());
            }
            if (value > 0) EditorGUI.DrawRect(new Rect(position.xMin, position.yMin, right * 16, bottom * 16), new Color(0.1f, 0.5f, 0.1f, 0.25f));
            property.longValue = unchecked((long)value);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            BitShape64Property attr = attribute as BitShape64Property;
            return attr.column * 16;
        }
}
}