# unity-accessibility
Learn how to add mental health accessibility features in Inky. Add Ink to your unity project using the [plugin here](https://assetstore.unity.com/packages/tools/integration/ink-unity-integration-60055).

You must have [Ink by Inkle](https://www.inklestudios.com/ink/) integrated into your project to use these instructions. 

<h2>Content Supression / Summarization</h2>
Content supression is essentially removing content from a storyline that could potentially cause hard for a player. Players should have the option to decide what content they want to supress, if any, and whether they want the content fully suppressed or just summarized. 
Potentilly dangerous content may include the following: 
<ul>
  <li>Sexual content</li>
  <li>Graphic Violence</li>
  <li>Character Death</li>
  <li>Abuse</li>
 </ul>

<p>Some people may need a basic summary of heavy content, while others may need to skip it entirely. If a heavy topic is integral to your theme, then you can content warn at the beginning, and then players can make an informed choice on whether to read. Otherwise, you can allow users to skip text that has content that would cause harm.</p>

<h3>Creating Content Supression / Summarization</h3>
Now there are two ways to create content supression. To see the more advanced option, go to "InkExamplesCW/Advanced.ink". This example uses ink lists to store a true and false value. The less advanced option uses different variables for each content supression, and can be found at "InkExamplesCW/Beginner.ink". Either way works. 

<h4>Advanced.ink</h4>
<p>To use the lists, there are three functions you can call. But before you do that, you must create the LIST of content warnings and the boolean VAR of summary at the top of the file. You can add more content warnings at any time by appending them to the list. Next, copy and past the three functions  showContent(warning, content, summaryContent), changeWarning(warning), and changeSummary(value) to your file. These functions will change what content is shown.</p>

<p>Call changeWarning, with the warning name specified in your contentWarning list, to turn the on and off the content supression on for that type of content. The function changeSummary should be passed either true or false to change whether or not a summary is shown for the content instead. Then, call showContent with the warning name, the raw content, and the summarized content every time sensitive content is shown to automatically print out the correct content to be read. You do <b>not</b> need to do this for every line, just the lines that contain content a user might need to have changed.</p>

Steps
<ol>
  <li>Make a list of all content warnings: "LIST contentWarnings = ..."</li>
  <li>Make a variable called summary: "VAR summary = false"</li>
  <li>Copy and paste all of the functions in the Advanced.ink file</li>
  <li>Make choices that call changeWarning and changeSummary to allow the user to customize what they see</li>
  <li>Show sensitive content with showContent</li>
 </ol>

<h4>Beginner.ink</h4>
<p>The Beginner.ink file does the exact same thing as Advanced.ink, but instead of lists it uses individual variables. You must create a new boolean variable for each of your content warnings and summary at the top of the file. Set all those variables to false. Next, copy and paste the three functions changeWarning(warning), changeSummary(),  showContent(warning, content, summaryContent) to your file. These functions do the exact same as their advanced counterparts, so refer to he paragraph above to understand each of them.</p>

Steps
<ol>
  <li>Make a variable for each of the content warnings and set it to false</li>
  <li>Make a variable called summary: "VAR summary = false"</li>
  <li>Copy and paste all of the functions in the Advanced.ink file</li>
  <li>Make choices that call changeWarning and changeSummary to allow the user to customize what they see</li>
  <li>Show sensitive content with showContent</li>
 </ol>

