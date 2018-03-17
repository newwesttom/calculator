
' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409


Public NotInheritable Class MainPage
    Inherits Page

    Dim bffFinal, bff1 As Integer
    Dim DoCalculation As Boolean = False
    Dim StoredOperator As String = ""
    Dim DoCleardisplay As Boolean = False




    Private Sub btn_Click(sender As Object, e As RoutedEventArgs) Handles btn_1.Click, btn_0.Click, btn_2.Click, btn_3.Click, btn_4.Click, btn_5.Click, btn_6.Click, btn_7.Click, btn_8.Click, btn_9.Click
        Dim btnNumber As Integer
        Dim StrDisplay As String


        'Next line will try to convert the button name to a integer
        'We start with "if" becuase if there is a problem with the conversion, then block
        ' should not run
        If DoCleardisplay = True Then
            txt_displaypanel1.Text = ""
        End If
        If Integer.TryParse(CType(sender, Button).Name.Remove(0, 4), btnNumber) Then
            txt_displaypanel1.Text = txt_displaypanel1.Text + btnNumber.ToString
            DoCleardisplay = False

        Else
            txt_displaypanel1.Text = "ERR, Button pressed =  " + CType(sender, Button).Name.Remove(0, 4)
        End If





    End Sub

    Private Sub btn_clear_Click(sender As Object, e As RoutedEventArgs) Handles btn_clear.Click
        txt_displaypanel1.Text = ""
        bffFinal = 0
    End Sub

    Private Sub btn_operator_Click(sender As Object, e As RoutedEventArgs) Handles btn_plus.Click, btn_equal.Click

        'Only do this if display is not blank
        If Not (String.IsNullOrEmpty(txt_displaypanel1.Text)) Then

            '
            '***********Do plus function***************
            '
            If CType(sender, Button).Name.Remove(0, 4) = "plus" Then

                If Not Integer.TryParse(txt_displaypanel1.Text, bff1) Then
                    txt_displaypanel1.Text = "ERR: not NUM " + bff1.ToString
                Else

                    'We calculate only if we have two values to work with
                    If (DoCalculation) Then

                        'Perform plus calculation (this comes from a previous event)
                        If StoredOperator = "plus" Then
                            bffFinal = bffFinal + bff1
                            'Display calculated value
                            txt_displaypanel1.Text = bffFinal.ToString
                        Else
                            'No other operations implemented yet.
                        End If ' plus operator

                    Else ' we only have one value to work with so we get ready for the next time.
                        'Next time we will perform a calculation
                        DoCalculation = True
                        'Set the initial total
                        bffFinal = bff1
                    End If 'DoCalulation

                    'Next Calculation will be a plus operator
                    StoredOperator = "plus"


                End If


                '
                '***************Do Equal function***************
                '
            ElseIf CType(sender, Button).Name.Remove(0, 4) = "equal" Then
                'Check if we should really calculate
                If DoCalculation Then
                    'Check what calculation must be performed
                    If StoredOperator = "plus" Then

                        'do calculation
                        If Integer.TryParse(txt_displaypanel1.Text, bff1) Then
                            bffFinal = bffFinal + bff1

                        Else ' show error with plus command
                            txt_displaypanel1.Text = "Err: not NUM"
                        End If

                        'we are done calculating until another operator is pressed
                        DoCalculation = False

                        'Display calculated value

                        txt_displaypanel1.Text = bffFinal.ToString
                    Else
                        'code block for future functionality, eg multiple, divide
                    End If



                End If
            End If

        Else
            'do if display was blank
        End If

        ' An operator button will cause the next number button to clear the display
        DoCleardisplay = True


    End Sub
End Class
