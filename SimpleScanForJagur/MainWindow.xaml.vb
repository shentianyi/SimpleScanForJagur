Imports System.Text.RegularExpressions
Imports SimpleScanForJagur.MsgLevel
Imports SimpleScanForJagur.MsgDialog
Imports System.IO
Class MainWindow
    Public Sub New()
        InitializeComponent()
        ProjectTab.SelectedIndex = My.Settings.defaultProjectIndex
    End Sub
    Private Sub textBox_barcode1_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles textBox_barcode1.PreviewKeyDown
        If e.Key = Key.Enter Then
            textBox_barcode2.Focus()
        End If
    End Sub

    Private Sub textBox_barcode1_TextChanged(sender As Object, e As TextChangedEventArgs) Handles textBox_barcode1.TextChanged

    End Sub

    Private Sub textBox_barcode2_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles textBox_barcode2.PreviewKeyDown
        If e.Key = Key.Enter Then
            textBox_barcode3.Focus()
        End If
    End Sub

    Private Sub textBox_barcode3_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles textBox_barcode3.PreviewKeyDown
        If e.Key = Key.Enter Then
            textBox_barcode4.Focus()
        End If
    End Sub

    Private Sub textBox_barcode4_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles textBox_barcode4.PreviewKeyDown
        If e.Key = Key.Enter Then
            Dowork()
            init()
        End If
    End Sub


    Private Sub textBox_barcode5_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles textBox_barcode5.PreviewKeyDown
        If e.Key = Key.Enter Then
            textBox_barcode6.Focus()
        End If
    End Sub

    Private Sub textBox_barcode6_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles textBox_barcode6.PreviewKeyDown
        If e.Key = Key.Enter Then
            textBox_barcode7.Focus()
        End If
    End Sub

    Private Sub textBox_barcode7_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles textBox_barcode7.PreviewKeyDown
        If e.Key = Key.Enter Then
            Dowork()
            init()
        End If
    End Sub


    Private Sub Dowork()
        Dim checkResult As Boolean = True


        Dim checker As Regex

        If ProjectTab.SelectedIndex.Equals(0) Then
            If checkResult Then
                checker = New Regex(My.Settings.barcode1)
                If checker.IsMatch(Me.textBox_barcode1.Text) = False Then
                    CMsgDlg(MsgLevel.Mistake, "第一个条码不符合格式规定", True).ShowDialog()
                    checkResult = False
                End If
            End If
            If checkResult Then
                checker = New Regex(My.Settings.barcode2)
                If checker.IsMatch(Me.textBox_barcode2.Text) = False Then
                    CMsgDlg(MsgLevel.Mistake, "第二个条码不符合格式规定", True).ShowDialog()
                    checkResult = False
                End If
            End If
            If checkResult Then
                checker = New Regex(My.Settings.barcode3)
                If checker.IsMatch(Me.textBox_barcode3.Text) = False Then
                    CMsgDlg(MsgLevel.Mistake, "第三个条码不符合格式规定", True).ShowDialog()
                    checkResult = False
                End If
            End If

            If checkResult Then
                checker = New Regex(My.Settings.barcode4)
                If checker.IsMatch(Me.textBox_barcode4.Text) = False Then
                    CMsgDlg(MsgLevel.Mistake, "第四个条码不符合格式规定", True).ShowDialog()
                    checkResult = False
                End If
            End If

            If checkResult Then

                If String.Compare(textBox_barcode1.Text, textBox_barcode2.Text, True) <> 0 Or
            String.Compare(textBox_barcode2.Text, textBox_barcode3.Text, True) <> 0 Or
             String.Compare(textBox_barcode1.Text, textBox_barcode3.Text, True) <> 0 Then
                    CMsgDlg(MsgLevel.Mistake, "前三个条码不匹配", True).ShowDialog()
                    checkResult = False
                End If
            End If
            ''''If ####写入第四个条码和前三个条码一致的判断条件=false Then
            ''''        CMsgDlg(MsgLevel.Mistake, "第四个条码不匹配", True).ShowDialog()
            ''''Exit Sub
            ''''End e
            ''''
            If checkResult Then

                If Regex.Replace(textBox_barcode1.Text, My.Settings.barcode1ReplacePattern, My.Settings.barcode1Replacement).Equals(textBox_barcode4.Text) = False Then
                    CMsgDlg(MsgLevel.Mistake, "第四个条码不匹配", True).ShowDialog()
                    checkResult = False
                End If

            End If


            If checkResult Then
                CMsgDlg(MsgLevel.Successful, "匹配已经完成", True, Nothing, My.Settings.okCloseTime).ShowDialog()
            End If

            Try
                Dim dir As String = "history"
                If Not Directory.Exists(dir) Then
                    Directory.CreateDirectory(dir)
                End If

                Dim writer As StreamWriter = New StreamWriter(Path.Combine("history", Now.ToString("yyyy-MM-dd") & "-" & "history.txt"), True)
                writer.WriteLine(Now.ToString & "," & textBox_barcode1.Text & "," & textBox_barcode2.Text & "," & textBox_barcode3.Text & "," & textBox_barcode4.Text & "," & checkResult)
                writer.Close()
            Catch ex As Exception

            End Try
        ElseIf ProjectTab.SelectedIndex.Equals(1) Then


            If checkResult Then
                checker = New Regex(My.Settings.barcode5)
                If checker.IsMatch(Me.textBox_barcode5.Text) = False Then
                    CMsgDlg(MsgLevel.Mistake, "第一个条码不符合格式规定", True).ShowDialog()
                    checkResult = False
                End If
            End If

            If checkResult Then
                checker = New Regex(My.Settings.barcode6)
                If checker.IsMatch(Me.textBox_barcode6.Text) = False Then
                    CMsgDlg(MsgLevel.Mistake, "第二个条码不符合格式规定", True).ShowDialog()
                    checkResult = False
                End If
            End If
            If checkResult Then
                checker = New Regex(My.Settings.barcode7)
                If checker.IsMatch(Me.textBox_barcode7.Text) = False Then
                    CMsgDlg(MsgLevel.Mistake, "第三个条码不符合格式规定", True).ShowDialog()
                    checkResult = False
                End If
            End If


            If checkResult Then
                If String.Compare(textBox_barcode5.Text, textBox_barcode6.Text, True) <> 0 Then
                    CMsgDlg(MsgLevel.Mistake, "前两个条码不匹配", True).ShowDialog()
                    checkResult = False
                End If
            End If

            If checkResult Then

                If Regex.Replace(textBox_barcode5.Text, My.Settings.barcode5ReplacePattern, My.Settings.barcode5Replacement).Equals(textBox_barcode7.Text) = False Then
                    CMsgDlg(MsgLevel.Mistake, "第三个条码不匹配", True).ShowDialog()
                    checkResult = False
                End If

            End If


            If checkResult Then
                CMsgDlg(MsgLevel.Successful, "匹配已经完成", True, Nothing, My.Settings.okCloseTime).ShowDialog()
            End If

            Try
                Dim dir As String = "history"
                If Not Directory.Exists(dir) Then
                    Directory.CreateDirectory(dir)
                End If

                Dim writer As StreamWriter = New StreamWriter(Path.Combine("history", Now.ToString("yyyy-MM-dd") & "-" & "history.txt"), True)
                writer.WriteLine(Now.ToString & "," & textBox_barcode5.Text & "," & textBox_barcode6.Text & "," & textBox_barcode7.Text & "," & "" & "," & checkResult)
                writer.Close()
            Catch ex As Exception

            End Try


        End If

    End Sub

    Private Sub init()
        Me.textBox_barcode1.Text = ""
        Me.textBox_barcode2.Text = ""
        Me.textBox_barcode3.Text = ""
        Me.textBox_barcode4.Text = ""
        Me.textBox_barcode5.Text = ""
        Me.textBox_barcode6.Text = ""
        Me.textBox_barcode7.Text = ""
        If ProjectTab.SelectedIndex.Equals(0) Then
            Me.textBox_barcode1.Focus()
        ElseIf ProjectTab.SelectedIndex.Equals(1) Then

            Me.textBox_barcode5.Focus()

        End If

    End Sub

    Private Sub textBox_barcode2_TextChanged(sender As Object, e As TextChangedEventArgs) Handles textBox_barcode2.TextChanged

    End Sub

    'Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded


    'End Sub

    Private Sub ProjectTab_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ProjectTab.SelectionChanged


        init()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        init()
    End Sub
End Class
