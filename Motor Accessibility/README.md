# unity-accessibility
Learn how to add accessibility features to your unity game. 
You must be using Unity's new input system:

[Install the input system here.](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.5/manual/Installation.html)

[Learn about using Unity's new input system here.](https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/)

**[If you get stuck on any steps, consult the wiki.](https://github.com/krs9851/unity-accessibility/wiki/Motor-Accessibility)**


<h1>Motor Accessibility</h1>


<h2>Key Rebinding</h2>

Key rebinding is the process of allowing different users to use differents key to preform the same action. For example, if "E" causes the playable charater to interact, but a user wants to press "spacebar" instead, key rebinding could solve that. While widespread, this is especially important functionality for users with physical disabilties. Having key rebinding can reduce pain, increase playtime, or even be the gateway to playing the game at all. All keys should have the option to be rebound, including UI keys. 

All work referenced is being done in the UnityMotorAccessibility/Assets folder. Before starting this section, make sure you have installed the new input system, created Input Actions, and set the intiial keybinds. Make sure you have a gameobject in the scene that contains a Player Input component with the Input Actions given to it. See the EventSystems gameobject for reference. This tutorial was inspired by [How To Implement Key Rebinding by Dapper Dino.](https://www.youtube.com/watch?v=dUCcZrPhwSo)

In this tutorial, instead of having a character move and jump, the words "move left", "move right", "move up", "move down", and "jump" will appear on screen. This is because the focus is rebinding controls, not hooking up the new input system. 

You can find the Input Actions in the /PlayerInput folder, named PlayerControls. For this tutorial, we have two options: keyboard-only gameplay and keyboard + mouse gameplay. The movement is the same for both the "keyboard" and "keyboard + mouse" control schemes. However, the jump action is the up arrow key for keyboard-only and left click for keyboard + mouse. This means that which control scheme is active is important because you do not want a player to move AND jump by using the same arrow keys. However, if the player is using the mouse or another key to jump, you want the arrow keys to be a rebind option. 

**[Once again, if you get stuck on any steps, consult the wiki.](https://github.com/krs9851/unity-accessibility/wiki/Motor-Accessibility)**

Steps:
<ol>
  <li>Set up the new <a href="https://docs.unity3d.com/Packages/com.unity.inputsystem@1.5/manual/Installation.html">Input System</a></li>
  <li>Create your Control Schemes (ie. the types of input you will accept)</li>
  <li><a href="https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/ActionAssets.html">Create your Input Actions and initial keybinds</a></li>
  <li>Create a gameobject that contains the Player Input component</li>
  <li>
  Either import the KeyrebindingPackage.unitypackage or recreate the scripts and gameobjects. At minimum you need: 
  <ul>
    <li><a href="https://github.com/krs9851/unity-accessibility/blob/main/Motor%20Accessibility/UnityMotorAccessibility/Assets/Prefabs/Rebind.prefab">The prefab Rebind which contains the UI elements present in rebinding</a></li>
    <li><a href="https://github.com/krs9851/unity-accessibility/blob/main/Motor%20Accessibility/UnityMotorAccessibility/Assets/_Scripts/ControlRebinding.cs">The ControlRebinding.cs script</a></li>
  </ul>
  </li>
  <li>Create a Rebind prefab for each of your different keys by changing the serialized variables Input Action and Binding
  <ul>
    <li>The Input Action corresponds to the Input Actions you created earlier</li>
    <li>The Binding is the index number that corresponds to the entry underneath the Input Action</li>
  </ul>
  </li>
  <li>Optional: Create a Rebinding Parent for different control schemes, using the <a href="https://github.com/krs9851/unity-accessibility/blob/main/Motor%20Accessibility/UnityMotorAccessibility/Assets/Prefabs/Rebinding%20Parent.prefab">Rebind Parent prefab</a> as an example. At minimum you need: 
  <ul>
    <li><a href="https://github.com/krs9851/unity-accessibility/blob/main/Motor%20Accessibility/UnityMotorAccessibility/Assets/_Scripts/ControlSceneChange.cs">The ControlSceneChange.cs script</a></li>
    <li>At least two different control schemes</li>
    <li>Gameobjects to contain the different Rebind prefabs that correspond to the different control schemes</li>
    <li>A dropdown to change the control schemes</li>
  </ul>
  </li>
</ol>

Tip: having a keyboard-only, mouse-only, and/or gamepad-only option for gameplay greatly increases the accessibility of the game. 
