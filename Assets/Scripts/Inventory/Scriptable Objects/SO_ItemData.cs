using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

#endif

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]

public class SO_ItemData : ScriptableObject
{

    enum ItemType { consumable, crop, key, resource, seed }
#pragma warning disable 0649
    [SerializeField] ItemType itemType;
#pragma warning restore 0649


    public string itemName;
    public Sprite itemImage;
    [TextArea]
    public string itemDescription;


    int itemPrice;
    int itemSell;

    int hpStat;
    int magicStat;
    int energyStat;

    string cropRating;

    string keyItemType;

    string plantingSeason;
    string plantGrowTime;
    string seedRating;
    string siblingCrop1 = "NONE";
    string siblingCrop2 = "NONE";
    string siblingCrop3 = "NONE";
    string siblingCrop4 = "NONE";


    bool showConsumable = false;
    bool showCrop = false;
    bool showKey = false;
    bool showResource = false;
    bool showSeed = false;



    #region Editor
#if UNITY_EDITOR

    [CustomEditor(typeof(SO_ItemData))]
    public class SO_ItemDataEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            SO_ItemData SO_ItemData = (SO_ItemData)target;

            if (SO_ItemData.itemType == ItemType.consumable)
            {
                EditorGUILayout.Space();
                SO_ItemData.showConsumable = EditorGUILayout.Foldout(SO_ItemData.showConsumable, "Consumable Information", true);

                if (SO_ItemData.showConsumable)
                {
                    EditorGUI.indentLevel++;

                    EditorGUILayout.LabelField("Item Buy Price", GUILayout.MaxWidth(100));
                    SO_ItemData.itemPrice = EditorGUILayout.IntField(SO_ItemData.itemPrice);

                    EditorGUILayout.LabelField("Item Sell Price", GUILayout.MaxWidth(100));
                    SO_ItemData.itemSell = EditorGUILayout.IntField(SO_ItemData.itemSell);

                    EditorGUILayout.LabelField("HP Stat", GUILayout.MaxWidth(100));
                    SO_ItemData.hpStat = EditorGUILayout.IntField(SO_ItemData.hpStat);

                    EditorGUILayout.LabelField("Magic Stat", GUILayout.MaxWidth(100));
                    SO_ItemData.magicStat = EditorGUILayout.IntField(SO_ItemData.magicStat);

                    EditorGUILayout.LabelField("Energy Stat", GUILayout.MaxWidth(100));
                    SO_ItemData.energyStat = EditorGUILayout.IntField(SO_ItemData.energyStat);

                    EditorGUI.indentLevel--;
                }

            }

            if (SO_ItemData.itemType == ItemType.crop)
            {
                EditorGUILayout.Space();
                SO_ItemData.showCrop = EditorGUILayout.Foldout(SO_ItemData.showCrop, "Crop Information", true);

                if (SO_ItemData.showCrop)
                {
                    EditorGUI.indentLevel++;

                    EditorGUILayout.LabelField("Crop Rating", GUILayout.MaxWidth(100));
                    SO_ItemData.cropRating = EditorGUILayout.TextField(SO_ItemData.cropRating);

                    EditorGUILayout.LabelField("Item Buy Price", GUILayout.MaxWidth(100));
                    SO_ItemData.itemPrice = EditorGUILayout.IntField(SO_ItemData.itemPrice);

                    EditorGUILayout.LabelField("Item Sell Price", GUILayout.MaxWidth(100));
                    SO_ItemData.itemSell = EditorGUILayout.IntField(SO_ItemData.itemSell);

                    EditorGUILayout.LabelField("HP Stat", GUILayout.MaxWidth(100));
                    SO_ItemData.hpStat = EditorGUILayout.IntField(SO_ItemData.hpStat);

                    EditorGUILayout.LabelField("Magic Stat", GUILayout.MaxWidth(100));
                    SO_ItemData.magicStat = EditorGUILayout.IntField(SO_ItemData.magicStat);

                    EditorGUILayout.LabelField("Energy Stat", GUILayout.MaxWidth(100));
                    SO_ItemData.energyStat = EditorGUILayout.IntField(SO_ItemData.energyStat);

                    EditorGUI.indentLevel--;
                }

            }

            if (SO_ItemData.itemType == ItemType.key)
            {
                EditorGUILayout.Space();
                SO_ItemData.showKey = EditorGUILayout.Foldout(SO_ItemData.showKey, "Key Item Information", true);

                if (SO_ItemData.showKey)
                {
                    EditorGUI.indentLevel++;

                    EditorGUILayout.LabelField("Key Item Type", GUILayout.MaxWidth(100));
                    SO_ItemData.keyItemType = EditorGUILayout.TextField(SO_ItemData.keyItemType);

                    EditorGUI.indentLevel--;
                }

            }

            if (SO_ItemData.itemType == ItemType.resource)
            {
                EditorGUILayout.Space();
                SO_ItemData.showResource = EditorGUILayout.Foldout(SO_ItemData.showResource, "Resource Information", true);

                if (SO_ItemData.showResource)
                {
                    EditorGUI.indentLevel++;

                    EditorGUILayout.LabelField("Item Buy Price", GUILayout.MaxWidth(100));
                    SO_ItemData.itemPrice = EditorGUILayout.IntField(SO_ItemData.itemPrice);

                    EditorGUILayout.LabelField("Item Sell Price", GUILayout.MaxWidth(100));
                    SO_ItemData.itemSell = EditorGUILayout.IntField(SO_ItemData.itemSell);

                    EditorGUI.indentLevel--;
                }

            }

            if (SO_ItemData.itemType == ItemType.seed)
            {
                EditorGUILayout.Space();
                SO_ItemData.showSeed = EditorGUILayout.Foldout(SO_ItemData.showSeed, "Seed Information", true);

                if (SO_ItemData.showSeed)
                {
                    EditorGUI.indentLevel++;

                    EditorGUILayout.LabelField("Item Buy Price", GUILayout.MaxWidth(100));
                    SO_ItemData.itemPrice = EditorGUILayout.IntField(SO_ItemData.itemPrice);

                    EditorGUILayout.LabelField("Item Sell Price", GUILayout.MaxWidth(100));
                    SO_ItemData.itemSell = EditorGUILayout.IntField(SO_ItemData.itemSell);

                    EditorGUILayout.LabelField("Planting Season", GUILayout.MaxWidth(100));
                    SO_ItemData.plantingSeason = EditorGUILayout.TextField(SO_ItemData.plantingSeason);

                    EditorGUILayout.LabelField("Plant Grow Time", GUILayout.MaxWidth(100));
                    SO_ItemData.plantGrowTime = EditorGUILayout.TextField(SO_ItemData.plantGrowTime);

                    EditorGUILayout.LabelField("Seed Rating", GUILayout.MaxWidth(100));
                    SO_ItemData.seedRating = EditorGUILayout.TextField(SO_ItemData.seedRating);

                    EditorGUILayout.LabelField("Sibling Crop 1", GUILayout.MaxWidth(100));
                    SO_ItemData.siblingCrop1 = EditorGUILayout.TextField(SO_ItemData.siblingCrop1);

                    EditorGUILayout.LabelField("Sibling Crop 2", GUILayout.MaxWidth(100));
                    SO_ItemData.siblingCrop2 = EditorGUILayout.TextField(SO_ItemData.siblingCrop2);

                    EditorGUILayout.LabelField("Sibling Crop 3", GUILayout.MaxWidth(100));
                    SO_ItemData.siblingCrop3 = EditorGUILayout.TextField(SO_ItemData.siblingCrop3);

                    EditorGUILayout.LabelField("Sibling Crop 4", GUILayout.MaxWidth(100));
                    SO_ItemData.siblingCrop4 = EditorGUILayout.TextField(SO_ItemData.siblingCrop4);

                    EditorGUI.indentLevel--;
                }

            }

        }
    }

#endif
    #endregion



}
