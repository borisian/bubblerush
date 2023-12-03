namespace GleyPushNotifications
{
    using System;
    using System.IO;
    using UnityEditor;
    using UnityEngine;

    public class SettingsWindow : EditorWindow
    {
        private Vector2 scrollPosition = Vector2.zero;
        NotificationSettings notificationSettongs;

        string info = "This asset requires Mobile Notifications by Unity \n" +
            "Go to Window -> Package Manager and install Mobile Notifications";
        private bool useForAndroid;
        private bool useForIos;
        private string additionalSettings = "To setup notification images open:\n" +
            "Edit -> Project Settings -> Mobile Notifications";

        private bool usePlaymaker;
        private bool useBolt;
        private bool useGameflow;

        [MenuItem("Window/Gley/Notifications", false, 70)]
        private static void Init()
        {
            string path = "Assets//GleyPlugins/Notifications/Scripts/Version.txt";
            StreamReader reader = new StreamReader(path);
            string longVersion = JsonUtility.FromJson<Gley.About.AssetVersion>(reader.ReadToEnd()).longVersion;

            SettingsWindow window = (SettingsWindow)GetWindow(typeof(SettingsWindow));
            window.titleContent = new GUIContent("Notifications - v." + longVersion);
            window.minSize = new Vector2(520, 520);
            window.Show();
        }

        private void OnEnable()
        {
            notificationSettongs = Resources.Load<NotificationSettings>("NotificationSettingsData");
            if (notificationSettongs == null)
            {
                CreateNotificationSettings();
                notificationSettongs = Resources.Load<NotificationSettings>("NotificationSettingsData");
            }

            useForAndroid = notificationSettongs.useForAndroid;
            useForIos = notificationSettongs.useForIos;
            usePlaymaker = notificationSettongs.usePlaymaker;
            useBolt = notificationSettongs.useBolt;
            useGameflow = notificationSettongs.useGameflow;
        }

        private void SaveSettings()
        {
            SetPreprocessorDirectives();
            if (useForAndroid)
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.EnableNotificationsAndroid, false, BuildTargetGroup.Android);
            }
            else
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.EnableNotificationsAndroid, true, BuildTargetGroup.Android);
            }
            if (useForIos)
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.EnableNotificationsIos, false, BuildTargetGroup.iOS);
            }
            else
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.EnableNotificationsIos, true, BuildTargetGroup.iOS);
            }

            notificationSettongs.useForAndroid = useForAndroid;
            notificationSettongs.useForIos = useForIos;
            notificationSettongs.usePlaymaker = usePlaymaker;
            notificationSettongs.useBolt = useBolt;
            notificationSettongs.useGameflow = useGameflow;

            EditorUtility.SetDirty(notificationSettongs);
        }

        private void OnGUI()
        {
            EditorStyles.label.wordWrap = true;
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, false, GUILayout.Width(position.width), GUILayout.Height(position.height));

            GUILayout.Label("Enable visual scripting tool support:", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            usePlaymaker = EditorGUILayout.Toggle("Playmaker Support", usePlaymaker);
            useBolt = EditorGUILayout.Toggle("Bolt Support", useBolt);
            useGameflow = EditorGUILayout.Toggle("Game Flow Support", useGameflow);
            EditorGUILayout.Space();

            GUILayout.Label("Select your platforms:", EditorStyles.boldLabel);
            useForAndroid = EditorGUILayout.Toggle("Android", useForAndroid);
            useForIos = EditorGUILayout.Toggle("iOS", useForIos);
            EditorGUILayout.Space();


            EditorGUILayout.LabelField(info);
            if (GUILayout.Button("Install Mobile Notifications by Unity"))
            {
                Gley.Common.ImportRequiredPackages.ImportPackage("com.unity.mobile.notifications", CompleteMethod);
            }
            EditorGUILayout.Space();
            EditorGUILayout.LabelField(additionalSettings);
            if (GUILayout.Button("Open Mobile Notification Settings"))
            {
                SettingsService.OpenProjectSettings("Project/Mobile Notification Settings");
            }
            EditorGUILayout.Space();
            if (GUILayout.Button("Save"))
            {
                SaveSettings();
            }


            GUILayout.EndScrollView();
        }

        private void CompleteMethod(string message)
        {
            Debug.Log(message);
        }

        private void SetPreprocessorDirectives()
        {
            if (usePlaymaker)
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Constants.USE_PLAYMAKER_SUPPORT, false, BuildTargetGroup.Android);
                Gley.Common.PreprocessorDirective.AddToPlatform(Constants.USE_PLAYMAKER_SUPPORT, false, BuildTargetGroup.iOS);
            }
            else
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Constants.USE_PLAYMAKER_SUPPORT, true, BuildTargetGroup.Android);
                Gley.Common.PreprocessorDirective.AddToPlatform(Constants.USE_PLAYMAKER_SUPPORT, true, BuildTargetGroup.iOS);
            }

            if (useBolt)
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Constants.USE_BOLT_SUPPORT, false, BuildTargetGroup.Android);
                Gley.Common.PreprocessorDirective.AddToPlatform(Constants.USE_BOLT_SUPPORT, false, BuildTargetGroup.iOS);
            }
            else
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Constants.USE_BOLT_SUPPORT, true, BuildTargetGroup.Android);
                Gley.Common.PreprocessorDirective.AddToPlatform(Constants.USE_BOLT_SUPPORT, true, BuildTargetGroup.iOS);
            }

            if (useGameflow)
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Constants.USE_GAMEFLOW_SUPPORT, false, BuildTargetGroup.Android);
                Gley.Common.PreprocessorDirective.AddToPlatform(Constants.USE_GAMEFLOW_SUPPORT, false, BuildTargetGroup.iOS);
            }
            else
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Constants.USE_GAMEFLOW_SUPPORT, true, BuildTargetGroup.Android);
                Gley.Common.PreprocessorDirective.AddToPlatform(Constants.USE_GAMEFLOW_SUPPORT, true, BuildTargetGroup.iOS);
            }
        }

        private void CreateNotificationSettings()
        {
            NotificationSettings asset = CreateInstance<NotificationSettings>();
            if (!AssetDatabase.IsValidFolder("Assets/GleyPlugins/Notifications/Resources"))
            {
                AssetDatabase.CreateFolder("Assets/GleyPlugins/Notifications", "Resources");
                AssetDatabase.Refresh();
            }

            AssetDatabase.CreateAsset(asset, "Assets/GleyPlugins/Notifications/Resources/NotificationSettingsData.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}