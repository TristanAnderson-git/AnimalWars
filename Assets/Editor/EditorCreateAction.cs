using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class EditorCreateAction : EditorWindow
{
    static string actionName;
    static string actionFolderPath;
    static List<string> actionsInFolder;
    static bool overwrite;

    Vector2 scroll;

    [MenuItem("Tool/GOAP/Create Action")]
    public static void CreateActionDialogue()
    {
        actionName = "NewAction";
        actionFolderPath = Application.dataPath + "/Scripts/AI/Actions";
        overwrite = false;

        string[] files = new string[0];

        if (actionFolderPath != null)
            files = Directory.GetFiles(actionFolderPath);

        actionsInFolder = new List<string>();
        foreach (string file in files)
        {
            if (file.EndsWith(".cs"))
            {
                List<char> filename = new List<char>(file.TrimStart(actionFolderPath.ToCharArray()).TrimEnd(".cs".ToCharArray()));
                filename.RemoveRange(0, 7);

                actionsInFolder.Add(new string(filename.ToArray()));
            }
        }

        GetWindow<EditorCreateAction>().titleContent.text = "Create Action";
    }

    void OnGUI()
    {
        actionName = EditorGUILayout.TextField("Action Name: ", actionName);

        if (GUILayout.Button("Create Action"))
            CreateAction();
        //if (GUILayout.Button("Remove Action"))
        //    DeleteAction();

        scroll = EditorGUILayout.BeginScrollView(scroll, GUILayout.Height(200.0f));
        for (int i = 0; i < actionsInFolder.Count; i++)
        {
            GUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("Delete", GUILayout.Width(100)))
                    DeleteActionButton(i);
                
                GUILayout.Label(actionsInFolder[i]);
            }
            GUILayout.EndHorizontal();
        }
        EditorGUILayout.EndScrollView();

    }

    void CreateAction()
    {
        if (string.IsNullOrEmpty(actionName))
        {
            EditorUtility.DisplayDialog("Empty Name", "The action name has been left empty, please write a name you wish to call the action", "Okay");
            return;
        }

        string path = Application.dataPath + "/Scripts/AI/Actions/Action" + actionName + ".cs";
        path = path.Replace(" ", "_");

        if (File.Exists(path))
        {
            if (!EditorUtility.DisplayDialog("Overwrite Action" + actionName + ".cs", 
                                            "There is already an action with that name. Do you want to overwrite it?", 
                                            "Yes", 
                                            "No"))
            {
                return;
            }
            overwrite = true;
        }

        CreateFile(path);
    }

    void DeleteActionButton(int index)
    {
        actionName = actionsInFolder[index];
        DeleteAction();
    }

    void DeleteAction()
    {
        if (string.IsNullOrEmpty(actionName))
        {
            EditorUtility.DisplayDialog("Empty Name", "The action name has been left empty, please write the name of the action you wish to remove", "Okay");
            return;
        }

        string path = Application.dataPath + "/Scripts/AI/Actions/Action" + actionName + ".cs";
        path = path.Replace(" ", "_");

        if (File.Exists(path))
        {
            if (!EditorUtility.DisplayDialog("Delete Action" + actionName + ".cs",
                                            "You are about to delete Action" + actionName + ". Are you sure you want to delete is action?",
                                            "Yes",
                                            "No"))
            {
                return;
            }

            DeleteFile(path);
        }
        else
        {
            EditorUtility.DisplayDialog("File Does Not Exist", "The file Action" + actionName + ".cs can not be found. Please make sure you have spelt the action name correctly and try again", "Okay");
        }
    }

    void CreateFile(string path)
    {
        List<string> code = new List<string>
        {
            "using GOAP;",
            "using UnityEngine;\n",
            "public class Action" + actionName + " : Action\n{",
            "\tpublic override void Reset()\n\t{\n\t}\n",
            "\tpublic Action" + actionName + "()\n\t{\n\t}\n",
            "\tpublic override bool CheckPreconditions(GameObject agent)\n\t{\n\t\treturn true;\n\t}\n",
            "\tpublic override bool IsDone()\n\t{\n\t\treturn true;\n\t}\n",
            "\tpublic override bool Perform(GameObject agent)\n\t{\n\t\treturn true;\n\t}\n",
            "\tpublic override bool RequiresInRange()\n\t{\n\t\treturn true;\n\t}\n",
            "}"
        };
        WriteFile(path, code.ToArray());

        if (!overwrite)
        {
            path = Application.dataPath + "/Scripts/Enum.cs";
            code = CopyFile(path);
            code.Insert(code.Count - 2, "\t\t" + actionName + ",");
            WriteFile(path, code.ToArray());
        }

        GetWindow<EditorCreateAction>().Close();
        AssetDatabase.Refresh();
    }

    void DeleteFile(string path)
    {
        File.Delete(path);
        path += ".meta";
        File.Delete(path);

        path = Application.dataPath + "/Scripts/Enum.cs";
        List<string> code = CopyFile(path);
        RemoveLine(ref code);
        WriteFile(path, code.ToArray());

        
        GetWindow<EditorCreateAction>().Close();
        AssetDatabase.Refresh();
    }

    List<string> CopyFile(string path)
    {
        return new List<string>(File.ReadAllLines(path));
    }

    void RemoveLine(ref List<string> file)
    {
        string line = actionName + ",";
        bool inCorrectEnum = false;
        
        for (int i = 0; i < file.Count; i++)
        {
            if (file[i].Contains("public enum ActionKey"))
                inCorrectEnum = true;
            
            if (file[i].Contains(line) && inCorrectEnum)
            {
                file.RemoveAt(i);
                return;
            }
        }

        Debug.LogError("No value of " + actionName + " could be found, please remove from the ActionKey enum in the Enum script manually");
    }

    void WriteFile(string path, string[] file)
    {
        using (StreamWriter fileOutput = new StreamWriter(path))
        {
            foreach (string line in file)
                fileOutput.WriteLine(line);
            fileOutput.Flush();
        }
    }
}