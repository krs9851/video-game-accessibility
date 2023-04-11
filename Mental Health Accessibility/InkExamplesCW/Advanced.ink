//LIST of content warnings
LIST contentWarnings = firstWarning, secondWarning, thirdWarning

//VAR of summary boolean
VAR summary = false

Determine what you want hidden:
->determine

=== determine ===
/*
To create this user choice, substitute your content warning names with the following ____ 

+[turn ____ {contentWarnings ? ____: off} {contentWarnings !? ____: on}]
{contentWarnings !? ____:
    {addWarning(____)}
    -else:
         {removeWarning(____)}
}
->determine

*/

+[turn first warning {contentWarnings ? firstWarning: off} {contentWarnings !? firstWarning: on}]
{changeWarning(firstWarning)}
->determine

+[turn second warning {contentWarnings ? secondWarning: off} {contentWarnings !? secondWarning: on}]
{changeWarning(secondWarning)}
->determine

+[turn third warning {contentWarnings ? thirdWarning: off} {contentWarnings !? thirdWarning: on}]
{changeWarning(thirdWarning)}
->determine


+[turn summary {summary: off} {not summary: on}]
{changeSummary(not summary)}
->determine

+[Done]
-> choices_made

=== choices_made ===
{showContent(firstWarning, "The raw first warning content", "the summarized first warning content")}
{showContent(secondWarning, "The raw second warning content", "the summarized second warning content")}
{showContent(thirdWarning, "The raw third warning warning content", "the summarized third warning content")}
->DONE

=== function showContent(warning, content, summaryContent)
{contentWarnings !? warning: 
   {content}
    -else:
        {summary: 
            {summaryContent}
         }   
}


=== function changeWarning(warning)
{contentWarnings ? warning: 
    ~ contentWarnings -= warning
    -else:
        ~ contentWarnings += warning
}



=== function changeSummary(value)
~ summary = value

