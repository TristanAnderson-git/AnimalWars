using UnityEngine;
using UnityEditor;

public class EditorCreateOrder : EditorWindow
{
    static string orderName;
    static string orderDesc;
    static Sprite orderIcon;
    static GOAP.ActionKey orderGoal;
    static byte orderPrio;

    const int charLimit = 150;

    [MenuItem("Tool/GOAP/Create Order")]
    public static void CreateOrderDialogue()
    {
        orderName = "NewOrder";
        orderDesc = "Description of Order";

        GetWindow<EditorCreateOrder>().titleContent.text = "Create Action";
    }

    private void OnGUI()
    {
        orderName = EditorGUILayout.TextField("Order Name: ", orderName);
        GUILayout.Label(string.Format("Order Description ({0}/{1}):", orderDesc.Length, charLimit));

        EditorStyles.textArea.wordWrap = true;
        orderDesc = GUILayout.TextArea(orderDesc, charLimit, EditorStyles.textArea);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Order Icon: ");
        orderIcon = (Sprite)EditorGUILayout.ObjectField(orderIcon, typeof(Sprite), allowSceneObjects: false);
        EditorGUILayout.EndHorizontal();
        
        orderGoal = (GOAP.ActionKey)EditorGUILayout.EnumPopup("Goal: ", orderGoal);
        orderPrio = (byte)EditorGUILayout.IntField("Priority: ", orderPrio);

        if (GUILayout.Button("Create Order"))
            CreateOrder();
    }

    private void CreateOrder()
    {
        GOAP.Order asset = CreateAsset();

        string assetName = orderName.Replace(" ", "_");

        AssetDatabase.CreateAsset(asset, "Assets/Scripts/AI/Orders/" + assetName + ".asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        EditorUtility.FocusProjectWindow();
        GetWindow<EditorCreateOrder>().Close();

        Selection.activeObject = asset;
    }

    private GOAP.Order CreateAsset()
    {
        GOAP.Order asset = CreateInstance<GOAP.Order>();

        asset.name          = orderName;
        asset.description   = orderDesc;
        asset.icon          = orderIcon;
        asset.goal          = orderGoal;
        asset.priority      = orderPrio;

        return asset;
    }
}
