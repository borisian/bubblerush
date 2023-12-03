#if GleyIAPiOS || GleyIAPGooglePlay || GleyIAPAmazon || GleyIAPMacOS || GleyIAPWindows
#define GleyIAPEnabled
#endif
namespace GleyEasyIAP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using UnityEditor;
    using UnityEngine;


    public class IAPSettingsWindow : EditorWindow
    {
        private List<StoreProduct> localShopProducts;
        private IAPSettings iapSettings;
        private GUIStyle labelStyle;
        private Color labelColor;
        private Vector2 scrollPosition;
        private string errorText = "";
        private bool useForGooglePlay;
        private bool useForAmazon;
        private bool useForIos;
        private bool useForMac;
        private bool useForWindows;
        private bool debug;
        private bool useReceiptValidation;
        private bool usePlaymaker;
        private bool useBolt;
        private bool useGameFlow;


        [MenuItem("Window/Gley/Easy IAP", false, 30)]
        private static void Init()
        {
            string path = "Assets//GleyPlugins/EasyIAP/Scripts/Version.txt";
            StreamReader reader = new StreamReader(path);
            string longVersion = JsonUtility.FromJson<Gley.About.AssetVersion>(reader.ReadToEnd()).longVersion;

            // Get existing open window or if none, make a new one:
            IAPSettingsWindow window = (IAPSettingsWindow)GetWindow(typeof(IAPSettingsWindow));
            window.titleContent = new GUIContent("Easy IAP - v." + longVersion);
            window.minSize = new Vector2(520, 520);
            window.Show();
        }

        private void OnEnable()
        {
            try
            {
                labelStyle = new GUIStyle(EditorStyles.label);
            }
            catch { }

            iapSettings = Resources.Load<IAPSettings>("IAPData");
            if (iapSettings == null)
            {
                CreateIAPSettings();
                iapSettings = Resources.Load<IAPSettings>("IAPData");
            }

            debug = iapSettings.debug;
            useReceiptValidation = iapSettings.useReceiptValidation;
            usePlaymaker = iapSettings.usePlaymaker;
            useBolt = iapSettings.useBolt;
            useGameFlow = iapSettings.useGameFlow;
            useForGooglePlay = iapSettings.useForGooglePlay;
            useForAmazon = iapSettings.useForAmazon;
            useForIos = iapSettings.useForIos;
            useForMac = iapSettings.useForMac;
            useForWindows = iapSettings.useForWindows;

            localShopProducts = new List<StoreProduct>();
            for (int i = 0; i < iapSettings.shopProducts.Count; i++)
            {
                localShopProducts.Add(iapSettings.shopProducts[i]);
            }
        }


        private void SaveSettings()
        {
            if (useForGooglePlay)
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.GleyIAPGooglePlay, false, BuildTargetGroup.Android);
#if GleyIAPEnabled
                UnityEditor.Purchasing.UnityPurchasingEditor.TargetAndroidStore(UnityEngine.Purchasing.AppStore.GooglePlay);
#endif
            }
            else
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.GleyIAPGooglePlay, true, BuildTargetGroup.Android);
            }

            if (useForAmazon)
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.GleyIAPAmazon, false, BuildTargetGroup.Android);
#if GleyIAPEnabled
                UnityEditor.Purchasing.UnityPurchasingEditor.TargetAndroidStore(UnityEngine.Purchasing.AppStore.AmazonAppStore);
#endif
            }
            else
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.GleyIAPAmazon, true, BuildTargetGroup.Android);
            }

            if (useForIos)
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.GleyIAPiOS, false, BuildTargetGroup.iOS);
            }
            else
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.GleyIAPiOS, true, BuildTargetGroup.iOS);
            }

            if (useForMac)
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.GleyIAPMacOS, false, BuildTargetGroup.Standalone);
            }
            else
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.GleyIAPMacOS, true, BuildTargetGroup.Standalone);
            }

            if (useForWindows)
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.GleyIAPWindows, false, BuildTargetGroup.WSA);
            }
            else
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.GleyIAPWindows, true, BuildTargetGroup.WSA);
            }


            if (useReceiptValidation)
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.GleyUseValidation, false, BuildTargetGroup.Android);
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.GleyUseValidation, false, BuildTargetGroup.iOS);
            }
            else
            {
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.GleyUseValidation, true, BuildTargetGroup.Android);
                Gley.Common.PreprocessorDirective.AddToPlatform(Gley.Common.Constants.GleyUseValidation, true, BuildTargetGroup.iOS);
            }

            if (usePlaymaker)
            {
                Gley.Common.PreprocessorDirective.AddToCurrent(Gley.Common.Constants.USE_PLAYMAKER_SUPPORT, false);
            }
            else
            {
                Gley.Common.PreprocessorDirective.AddToCurrent(Gley.Common.Constants.USE_PLAYMAKER_SUPPORT, true);
            }

            if (useBolt)
            {
                Gley.Common.PreprocessorDirective.AddToCurrent(Gley.Common.Constants.USE_BOLT_SUPPORT, false);
            }
            else
            {
                Gley.Common.PreprocessorDirective.AddToCurrent(Gley.Common.Constants.USE_BOLT_SUPPORT, true);
            }

            if (useGameFlow)
            {
                Gley.Common.PreprocessorDirective.AddToCurrent(Gley.Common.Constants.USE_GAMEFLOW_SUPPORT, false);
            }
            else
            {
                Gley.Common.PreprocessorDirective.AddToCurrent(Gley.Common.Constants.USE_GAMEFLOW_SUPPORT, true);
            }

            iapSettings.debug = debug;
            iapSettings.useReceiptValidation = useReceiptValidation;
            iapSettings.usePlaymaker = usePlaymaker;
            iapSettings.useBolt = useBolt;
            iapSettings.useGameFlow = useGameFlow;
            iapSettings.useForGooglePlay = useForGooglePlay;
            iapSettings.useForIos = useForIos;
            iapSettings.useForAmazon = useForAmazon;
            iapSettings.useForMac = useForMac;
            iapSettings.useForWindows = useForWindows;

            iapSettings.shopProducts = new List<StoreProduct>();
            for (int i = 0; i < localShopProducts.Count; i++)
            {
                iapSettings.shopProducts.Add(localShopProducts[i]);
            }

            CreateEnumFile();

            EditorUtility.SetDirty(iapSettings);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private void OnGUI()
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, false, GUILayout.Width(position.width), GUILayout.Height(position.height));
            GUILayout.Label("Before setting up the plugin enable In-App Purchasing from Unity Services");
            EditorGUILayout.Space();
            debug = EditorGUILayout.Toggle("Debug", debug);
            useReceiptValidation = EditorGUILayout.Toggle("Use Receipt Validation", useReceiptValidation);
            if (useReceiptValidation)
            {
                GUILayout.Label("Go to Window > Unity IAP > IAP Receipt Validation Obfuscator,\nand paste your GooglePlay public key and click Obfuscate.");
            }
            GUILayout.Label("Enable Visual Scripting Tool:", EditorStyles.boldLabel);
            usePlaymaker = EditorGUILayout.Toggle("Playmaker Support", usePlaymaker);
            useBolt = EditorGUILayout.Toggle("Bolt Support", useBolt);
            useGameFlow = EditorGUILayout.Toggle("Game Flow Support", useGameFlow);
            EditorGUILayout.Space();
            GUILayout.Label("Select your platforms:", EditorStyles.boldLabel);
            useForGooglePlay = EditorGUILayout.Toggle("Google Play", useForGooglePlay);
            if (useForGooglePlay == true)
            {
                useForAmazon = false;
            }
            useForAmazon = EditorGUILayout.Toggle("Amazon", useForAmazon);
            if (useForAmazon)
            {
                useForGooglePlay = false;
            }
            useForIos = EditorGUILayout.Toggle("iOS", useForIos);
            useForMac = EditorGUILayout.Toggle("MacOS", useForMac);
            useForWindows = EditorGUILayout.Toggle("Windows Store", useForWindows);
            EditorGUILayout.Space();

            if (GUILayout.Button("Import Unity IAP SDK"))
            {
                Gley.Common.ImportRequiredPackages.ImportPackage("com.unity.purchasing", CompleteMethod);
            }
            EditorGUILayout.Space();

            if (useForGooglePlay || useForIos || useForAmazon || useForMac || useForWindows)
            {
                GUILayout.Label("In App Products Setup", EditorStyles.boldLabel);

                for (int i = 0; i < localShopProducts.Count; i++)
                {
                    EditorGUILayout.BeginVertical();
                    labelStyle.alignment = TextAnchor.MiddleCenter;
                    labelStyle.normal.textColor = Color.black;
                    GUILayout.Label(localShopProducts[i].productName, labelStyle);
                    localShopProducts[i].productName = EditorGUILayout.TextField("Product Name:", localShopProducts[i].productName);
                    localShopProducts[i].productName = Regex.Replace(localShopProducts[i].productName, @"^[\d-]*\s*", "");
                    localShopProducts[i].productName = localShopProducts[i].productName.Replace(" ", "");
                    localShopProducts[i].productName = localShopProducts[i].productName.Trim();
                    localShopProducts[i].productType = (ProductType)EditorGUILayout.EnumPopup("Product Type:", localShopProducts[i].productType);
                    localShopProducts[i].value = EditorGUILayout.IntField("Reward Value:", localShopProducts[i].value);

                    if (useForGooglePlay)
                    {
                        localShopProducts[i].idGooglePlay = EditorGUILayout.TextField("Google Play ID:", localShopProducts[i].idGooglePlay);
                    }

                    if (useForAmazon)
                    {
                        localShopProducts[i].idAmazon = EditorGUILayout.TextField("Amazon SKU:", localShopProducts[i].idAmazon);
                    }

                    if (useForIos)
                    {
                        localShopProducts[i].idIOS = EditorGUILayout.TextField("App Store (iOS) ID:", localShopProducts[i].idIOS);
                    }

                    if (useForMac)
                    {
                        localShopProducts[i].idMac = EditorGUILayout.TextField("Mac Store ID:", localShopProducts[i].idMac);
                    }

                    if (useForWindows)
                    {
                        localShopProducts[i].idWindows = EditorGUILayout.TextField("Windows Store ID:", localShopProducts[i].idWindows);
                    }

                    if (GUILayout.Button("Remove Product"))
                    {
                        localShopProducts.RemoveAt(i);
                    }

                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.Space();

                if (GUILayout.Button("Add new product"))
                {
                    localShopProducts.Add(new StoreProduct());
                }
            }

            labelStyle.normal.textColor = labelColor;
            GUILayout.Label(errorText, labelStyle);
            if (GUILayout.Button("Save"))
            {
                if (CheckForNull() == false)
                {
                    SaveSettings();
                    labelColor = Color.black;
                    errorText = "Save Success";
                }
            }

            GUILayout.EndScrollView();
        }

        private void CompleteMethod(string message)
        {
            Debug.Log(message);
        }

        private bool CheckForNull()
        {
            for (int i = 0; i < localShopProducts.Count; i++)
            {
                if (String.IsNullOrEmpty(localShopProducts[i].productName))
                {
                    labelColor = Color.red;
                    errorText = "Product name cannot be empty! Please fill all of them";
                    return true;
                }

                if (useForGooglePlay)
                {
                    if (String.IsNullOrEmpty(localShopProducts[i].idGooglePlay))
                    {
                        labelColor = Color.red;
                        errorText = "Google Play ID cannot be empty! Please fill all of them";
                        return true;
                    }
                }

                if (useForAmazon)
                {
                    if (String.IsNullOrEmpty(localShopProducts[i].idAmazon))
                    {
                        labelColor = Color.red;
                        errorText = "Amazon SKU cannot be empty! Please fill all of them";
                        return true;
                    }
                }

                if (useForIos)
                {
                    if (String.IsNullOrEmpty(localShopProducts[i].idIOS))
                    {
                        labelColor = Color.red;
                        errorText = "App Store ID cannot be empty! Please fill all of them";
                        return true;
                    }
                }

                if (useForMac)
                {
                    if (String.IsNullOrEmpty(localShopProducts[i].idMac))
                    {
                        labelColor = Color.red;
                        errorText = "Mac Store ID cannot be empty! Please fill all of them";
                        return true;
                    }
                }

                if (useForWindows)
                {
                    if (String.IsNullOrEmpty(localShopProducts[i].idWindows))
                    {
                        labelColor = Color.red;
                        errorText = "Windows Store ID cannot be empty! Please fill all of them";
                        return true;
                    }
                }
            }
            return false;
        }


        private void CreateIAPSettings()
        {
            IAPSettings asset = ScriptableObject.CreateInstance<IAPSettings>();
            if (!AssetDatabase.IsValidFolder("Assets/GleyPlugins/EasyIAP/Resources"))
            {
                AssetDatabase.CreateFolder("Assets/GleyPlugins/EasyIAP", "Resources");
                AssetDatabase.Refresh();
            }

            AssetDatabase.CreateAsset(asset, "Assets/GleyPlugins/EasyIAP/Resources/IAPData.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private void CreateEnumFile()
        {
            string text =
            "public enum ShopProductNames\n" +
            "{\n";
            for (int i = 0; i < localShopProducts.Count; i++)
            {
                text += localShopProducts[i].productName + ",\n";
            }
            text += "}";
            File.WriteAllText(Application.dataPath + "/GleyPlugins/EasyIAP/Scripts/ShopProductNames.cs", text);
        }
    }
}
