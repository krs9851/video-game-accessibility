LIST contentWarnings = sexualContent, graphicViolence, characterDeath
VAR toneIndicators = 0
//Note, do not use \ or " in the actual code, that just allows the code to be printed and formatted

->start

=== start ====
Welcome to Ink Accessibility! This module will teach you how to implement content warnings and tone indicators.
+[Tone Indicators Lesson]
->tone_indicators
+[Content Warnings Lesson]
->content_warnings
+[Example]
->example
+[Quit]
->quit

=== tone_indicators ===
Alright, lets discuss tone indicators! When creating tone indicators, I declair the variable toneIndicators at the top of each ink file: "VAR toneIndicators = 1". The initial value I set to 0. The numbers mean: 0 = no indicators, 1 = shorthand indicators, and 2 = full word indicators. For an example, look at Narrator under Assets/Ink/Dialogue. 
+[Continue]
->if

=if
To understand how to use these values, you need to understand an ink if statement. An if statement starts with a "\{", then has the if statment, next has ":", after that there's what will happen if the if statement is true, and finally ends with another "\}". For example "\{toneIndicators == 1: /srs \}" would print /srs if toneIndicators equals 1. 
+[Continue]
->shorthand

=shorthand
Let's take the statement, "You know me, I sure hate fish." This could be read as either sarcastic (the speaker loves fish) or serious (the speaker hates fish). If we want it to be sarcastic, we could put either /s or /sarcastic after the statement. If we want it to be serious, we could put /srs or /serious after it. 
+[Continue]
->code 

=code 
For this exercise, lets make the statement serious. To code that, we would need two if statements. "You know me, I sure hate fish. \{toneIndicators == 1: /srs\} \{toneIndicators == 2: /serious\}. Note, if toneIndicators is equal to 0, we don't need to do anything. 
+[Continue]
->getting_player_input

=getting_player_input
Now we need the player to choose if they want tone indicators or not, and if so, what type. To do that, you need to make three different choices. After each choice, you would set toneIndicators to either 0, 1, or 2 by using "\~ toneIndicators = 0/1/2"
+[No tone indicators]
You chose no tone indicators.
\~ toneIndicators = 0
->end

+[Shortened tone indicators]
You chose shortened tone indicators.
\~ toneIndicators = 1
->end

+[Full tone indicators]
You chose full tone indicators.
\~ toneIndicators = 2
->end

=end 
This is the end of the instructions for tone indicators.
+[Continue]
->start

=== content_warnings ===
Time to discuss content warnings. When creating content warnings, you'll need a inky list at the top of your ink files. You would declair that list with "\LIST contentWarnings = [list content warnings here]" For example, if your game contains graphic descriptions of violence and sexual content, you'd create "\LIST contentWarnings = graphicViolence, sexualContent" 
+[Continue]
->lists

=lists
Each value of a list has either a true or false value. When initiating the list, all values will have a false value. So to write a graphically violent passage, you would need to write "\{contentWarnings !? graphicViolence: violence here!\}". This way, if graphicViolence has been changed to true by the player, then "violence here!" won't be shown.
+[Continue]
->change_to_true

=change_to_true
So how do we change graphicViolence to true? You have to add the true version of it to the list with += and ( ). So changing graphicViolence to be true would look like this: "\~contentWarnings += (graphicViolence)". And changing graphicViolence to false would look like this:  "\~contentWarnings -= (graphicViolence)". 
+[Continue]
->input

=input
We need the player to choose what they want to have censored from the list of possible content warnings. To do that, we need several choices, each with their own if statment. For example,
"\{contentWarnings ? graphicViolence: +[Show graphic violence] \~contentWarnings -= (graphicViolence) \}
\{contentWarnings !? graphicViolence: +[Censor graphic violence] \~contentWarnings += (graphicViolence)  \}
\{contentWarnings ? sexualContent: +[Show sexual content] \~contentWarnings -= (sexualContent) \}
\{contentWarnings !? sexualContent: +[Censor sexual content] \~contentWarnings += (sexualContent) \}
\+[Continue]"
+[Continue]
->look_like

=look_like
It would look something like this: 
{contentWarnings ? graphicViolence: +[Show graphic violence] ~contentWarnings -= (graphicViolence) ->look_like }
{contentWarnings !? graphicViolence: 
    +[Censor graphic violence] 
    ~contentWarnings += (graphicViolence)  
    ->look_like
    }
{contentWarnings ? sexualContent: +[Show sexual content]  ~contentWarnings -= (sexualContent)  ->look_like }
{contentWarnings !? sexualContent: 
+[Censor sexual content] 

~contentWarnings += (sexualContent)  ->look_like }
+[Continue]"
->DONE

=== quit ===
Are you sure?
+[Yes]
#quit
->DONE
+[No]
->start


=== example ===
->start
