//Different possible content warnings
VAR firstWarning = false
VAR secondWarning = false
VAR thirdWarning = false

//VAR of summary boolean
VAR summary = false

Determine what you want hidden:
->determine

=== determine ===
/*
To create this user choice, substitute your content warning names with the following ____ 

+[turn ____ {____: off} {not ____: on}]
{changeWarning(____)}
->determine

*/
+[turn first warning {firstWarning: off} {not firstWarning: on}]
{changeWarning(firstWarning)}
->determine

+[turn second warning {secondWarning: off} {not secondWarning: on}]
{changeWarning(secondWarning)}
->determine

+[turn third warning {thirdWarning: off} {not thirdWarning: on}]
{changeWarning(thirdWarning)}
->determine


+[turn summary {summary: off} {not summary: on}]
{changeSummary()}
->determine

+[Done]
-> choices_made

=== choices_made ===
{showContent(firstWarning, "The raw first warning content", "the summarized first warning content")}
{showContent(secondWarning, "The raw second warning content", "the summarized second warning content")}
{showContent(thirdWarning, "The raw third warning content", "the summarized third warning content")}
->DONE


=== function changeWarning(ref warning)
~warning = not warning

=== function changeSummary()
~summary = not summary

=== function showContent(warning, content, summaryContent)
{not warning: 
    {content}
    -else:
        {summary:
            {summaryContent}
        }
}

