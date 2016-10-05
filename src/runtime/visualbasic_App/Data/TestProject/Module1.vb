﻿Imports Microsoft.VisualBasic.Data.IO.SearchEngine

Module Module1
    Sub Main()

        Dim test As IObject = IObject.FromString("1234")

        Console.WriteLine("12* AND (NOT ""4"" OR #\d+)".Evaluate(test)) ' T
        Console.WriteLine("#\d+".Evaluate(test))  ' T
        Console.WriteLine("""#\d+""".Evaluate(test)) 'F
        Console.WriteLine("Text:'#\d+'".Evaluate(test))
        Console.WriteLine("12* AND (NOT ""4"" OR #\d+)".Evaluate(test))
        Console.WriteLine("12* AND (NOT ""4"" OR #\d+)".Evaluate(test))

        Pause()

        If True And False Or (True And False) Then
            MsgBox(1)
        End If

        Dim exp = ExpressionBuilder.Build("D:\GCModeller\src\runtime\visualbasic_App\Data\query_syntaxTest.txt".ReadAllText)


        MsgBox("*.*".WildcardMatch("a.b"))
        MsgBox("*.?ab".WildcardMatch("a.ab"))
        MsgBox("*.*ab".WildcardMatch("a.ab"))
        MsgBox("ab*cc".WildcardMatch("abddddddcc"))
        MsgBox("*.*".WildcardMatch("a.b"))
        MsgBox("*.*".WildcardMatch("a.b"))
        MsgBox("*.*".WildcardMatch("a.b"))
        MsgBox("*.*".WildcardMatch("a.b"))

        Dim tk = SyntaxParser.Parser("D:\GCModeller\src\runtime\visualbasic_App\Data\query_syntaxTest.txt".ReadAllText)
    End Sub
End Module