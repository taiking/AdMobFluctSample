using UnityEditor.iOS.Xcode;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class MyBuildPostprocessor
{
    [PostProcessBuildAttribute(1)]
    public static void OnPostprocessBuild(BuildTarget buildTarget, string path)
    {
        string pjPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";
        PBXProject pj = new PBXProject();
        Debug.Log("bbbbbbbbb");
        pj.ReadFromString(File.ReadAllText(pjPath));
        Debug.Log("cccccccccccccc");

        string target = pj.TargetGuidByName("Unity-iPhone");
        Debug.Log("dddddddddd");

        pj.SetBuildProperty(target, "CLANG_ENABLE_MODULES", "YES");
        Debug.Log("eeeeeeeeeeeee");

        //string guid = null;
        //List<string> flags = new List<string>();
        //string mySharedLibraryPath = "Libraries/Plugins/iOS/PlatformUnity/";
        //flags.Add("-fno-objc-arc");
        //guid = pj.FindFileGuidByProjectPath(mySharedLibraryPath + "NSString+StringHelper.m");
        //pj.SetCompileFlagsForFile(target, guid, flags);
        //guid = pj.FindFileGuidByProjectPath(mySharedLibraryPath + "UIDevide-Hardware.m");
        //pj.SetCompileFlagsForFile(target, guid, flags);

        pj.AddBuildProperty(target, "OTHER_LDFLAGS", "-ObjC");
        Debug.Log("ffffffffffff");

        pj.AddFileToBuild(target, pj.AddFile("usr/lib/libsqlite3.tbd", "Frameworks/libsqlite3.tbd", PBXSourceTree.Sdk));
        pj.AddFileToBuild(target, pj.AddFile("usr/lib/libz.tbd", "Frameworks/libz.tbd", PBXSourceTree.Sdk));
        pj.AddFileToBuild(target, pj.AddFile("usr/lib/libc++.tbd", "Frameworks/libc++.tbd", PBXSourceTree.Sdk));

        Debug.Log("gggggggggg");

        string configGuid = pj.BuildConfigByName(target, "Release");
        pj.SetBuildPropertyForConfig(configGuid, "DEBUG_INFORMATION_FORMAT", "dwarf");

        Debug.Log("aaaaaaaaaaaa");

        File.WriteAllText(pjPath, pj.WriteToString());
    }
}
