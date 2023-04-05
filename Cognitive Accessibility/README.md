# unity-accessibility
Learn how to add cognitive accessibility features to your unity game.

You must have [Ink by Inkle](https://www.inklestudios.com/ink/) integrated into your project to use these instructions. 

<h2>Tone Indicators</h2>
<p>Tone indicators are either words or shorthands for words that are used to convey tone. For example, /srs or /serious after a question means it is a serious question. Tone is very difficult to convey with text alone, which can confuse players. Tone indicators remove that barrier to understanding your story, especially for people with cognitive disabilities. All tone indicators have a / in front, to show the start of the tone indicator.</p>

<p>I would recommend using https://toneindicators.carrd.co/# to learn more about tone indicators and common indicators used.</p>

<h3>Creating Tone Indicators</h3>


<h2>Content Warnings</h2>
Content warnings are essentially warnings that let the readers know what future content will contain, in case reading that it would be harmful to them. 
Content warnings may include the following: 
<ul>
  <li>Sexual content</li>
  <li>Graphic Violence</li>
  <li>Character Death</li>
  <li>Abuse</li>
 </ul>

<p>Some people may need forwarning of heavy content, while others may need to skip it entirely. If a heavy topic is integral to your theme, then you can content warn at the beginning, and then players can make an informed choice on whether to read. Otherwise, you can allow users to skip text that has content that would cause harm.</p>

<h3>Creating Content Warnings</h3>
Now there are two ways to create tone indicators. To see the more advanced option, go to "InkExamples/Advanced.ink". This example uses ink lists to store a true and false value. The less advanced option uses different variables for each content warning, and can be found at "InkExamples/Beginner.ink". Either way works. 

<h4>Advanced.ink</h4>
<p>To use the lists, there are three functions you can call. But before you do that, you must create the LIST of content warnings and the boolean VAR of summary at the top of the file. You can add more content warnings at any time by appending them to the list. Next, copy and past the four functions  showContent(warning, content, summaryContent), changeWarning(warning), and changeSummary(value) to your file. These functions will change what content is shown.</p>

<p>Call changeWarning, with the warning name specified in your contentWarning list, to turn the on and off the content supression on for that type of content. The function changeSummary should be passed either true or false to change whether or not a summary is shown for the content instead. Then, call showContent with the warning name, the raw content, and the summarized content every time sensitive content is shown to automatically print out the correct content to be read. You do <b>not</b> need to do this for every line, just the lines that contain content a user might need to have changed.</p>

Steps
<ol>
  <li>Make a list of all content warnings: "LIST contentWarnings = ..."</li>
  <li>Make a variable called summary: "VAR summary = true"</li>
  <li>Copy and paste all of the functions in the Advanced.ink file</li>
  <li>Call the functions to change what the player sees</li>
 </ol>

<h4>Beginner.ink</h4>
