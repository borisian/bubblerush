THANK YOU FOR PURCHASE
ALL LINES IN SCRIPTS FILES IS COMMENTED

/!\IMPORTANT THIS ASSET REQUIRE TEXT MESH PRO /!\
/!\DOWNLOAD TEXT MESH PRO IN ASSET STORE HERE => https://assetstore.unity.com/packages/essentials/beta-projects/textmesh-pro-84126

//----------------------------------------------------------------------------------------------------------------------------
ADD THE MONEYS SPRITE IN TEXT MESH PRO:
Download TextMeshPro, after downloading, go to "Asset\TextMesh Pro\Resources\" and click to "TMP Settings".
In "TMP Settings" go to line "Default Sprite Asset" and add asset sprite of folder "Asset\UI Mobile Menu Game\SpriteMoneysTMP".

Now when you write in a Text Mesh Pro GUI "<sprite = 0>" it will display a gems and "<sprite = 1>" it will display a coins.

//----------------------------------------------------------------------------------------------------------------------------
GENERATE OBJECTS:
In Scripts folder, look component "GenerateCards.cs".
In function "Start()" this component, create all cards from list "Category Obj".
Look in hierarchy the gameObject named "GenerateCards" and look component "GenerateCards.cs". Look all list in inspector.
For example, in inspector, open "Category Obj" and open "Pine Forest" category and open "Obj List" for view all cards in this category.
Each "Obj List" that you create, you can change its stats, its level, its name, if it is "prenium", is locked or not, change the stats, the level this card, 
the number count you have of this card , the number count max for this card, etc...

/!\IMPORTANT : If you add a category, do not forget to add objects in "Obj List". And If you add a category is not locked, in the "Obj List", do not forget to check is true
the Boolean "isEquipped", on at least one  object./!\

For add new category, open in hierarchy, "Canvas\Panels\Panel_Custom\Scroll Vertical\Viewport\Content\" and add Prebabs named "ContentCategory" path in folder "Prefabs\Custom\".
Go to in hierarchy the gameObject named "GenerateCards" and create new category in list inspector "Category Obj". Add to the "Content Cat" variable, the previous "ContentCategory" transform and
the child named "CatName" to variable "Name Cat". Now Add, to the variable "Obj List" in your new category, the new objects. Remember, if your new category is not locked, check true, 
the boolean "isEquipped", at least one object.

//----------------------------------------------------------------------------------------------------------------------------
ListMembers.cs :
Look in hierarchy the gameOjects named "CreateListChallenge", "CreateListMailbox", "CreateListRanking". This gameobjects have the script on them. It automatically creates the list of members
that you put in the inspector. In the inspector, specify in the list of members, if it is a member for the list of mailboxes, for the list of challenges or for the list of ranks, in the variable "Type".

In "ListMembers.cs", from line 31 to 56, create the gameobject of members in function of "Type". Depending on the "Type" the buttons or image on the prefabs will change.
"ListMembers.cs" sends all member stats to "InitMemberList.cs" attached of prefab and it will display the necessary components.

//----------------------------------------------------------------------------------------------------------------------------
NOTIFICATION 
In "UI.cs" script, in hierarchy the gameObject named "UIGlobal", the "Update()" function the line 49 to 84, count the numbers childs in "ContentMailbox" scrollview of Mailbox (Canvas\Panels\Panel_Friends\ScrollViewMailBox\Viewport\ContentMailbox),
and the sending to "Notif" gameobjects in the scene.


This is the most important thing to know, the rest of the asset remains only the basic things of Unity.
Most of the "OnClick ()" functions are executed in the "UI.cs" script in the gameobject in the hierarchy named "UIGlobal"

Cordially
For Help => paradox.ultimate@hotmail.fr
Web Site => http://www.ricl-chatland.fr
