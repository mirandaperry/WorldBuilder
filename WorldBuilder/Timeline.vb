Imports System.Drawing.Size
Imports System.Drawing.Graphics

Public Class Timeline

    ' This form has a Panel named 'MainPanel' that will scroll if needed.
    Dim panelSize As Size
    Dim panelWidth As Integer
    Dim panelHeight As Integer
    Dim panelVerticalCenter As Integer
    Dim panelHorizontalCenter As Integer
    Dim graphics As Graphics

    Private Sub testClick(sender As Object, eventArgs As System.EventArgs) Handles Test.Click
        findBaseline()
        Dim returnVal As Integer = drawSample()
    End Sub

    Private Function drawSample()

        ' Draw a test circle / line -- To be removed code
        graphics = MainPanel.CreateGraphics()
        'graphics.Flush()
        Dim pen1 As New Pen(Drawing.Color.Firebrick)
        pen1.Width = 5
        Dim pen2 As New Pen(Drawing.Color.SaddleBrown)
        pen2.Width = 5
        Dim pen3 As New Pen(Drawing.Color.Indigo)
        pen3.Width = 5
        Dim pen4 As New Pen(Drawing.Color.SpringGreen)
        pen4.Width = 5
        'Dim point As New Point(panelHorizontalCenter, panelVerticalCenter)
        'Dim size As New Size(100, 100)
        'Dim rectangle As New Rectangle(point, size)
        Dim pos1 As New Point(20, panelHeight - 20)
        Dim pos2 As New Point(30, panelHeight - 80)
        Dim pos3 As New Point(90, panelHeight - 80)
        Dim pos4 As New Point(190, panelHeight - 180)
        Dim pos5 As New Point(panelWidth + 100, panelHeight - 20)
        Try
            'graphics.DrawEllipse(pen, rectangle)

            graphics.DrawLine(pen1, pos1, pos2)
            graphics.DrawLine(pen2, pos2, pos3)
            graphics.DrawLine(pen3, pos3, pos4)
            graphics.DrawLine(pen4, pos4, pos5)

        Catch ex As Exception
            Return 9
        End Try

        Return 0
    End Function

    Private Sub findBaseline() ' TODO: Call in the event they resize their window, handle

        Try
            ' Get the current size of the panel
            panelSize = MainPanel.Size
        Catch ex As Exception
            ' For some reason the MainPanel cannot be accessed or does not exist
        End Try

        Try
            ' Extract the height and width
            panelWidth = panelSize.Width
            panelHeight = panelSize.Height
        Catch ex As Exception
            ' Could not extract height and width from the panel size, meaning it could be an empty size value
        End Try

        Try
            ' Find the center for the timeline
            panelVerticalCenter = panelHeight / 2
            panelHorizontalCenter = panelWidth / 2
        Catch ex As Exception
            ' If this doesn't work then something must be wrong with the / operation
        End Try

    End Sub
End Class

' Note that when we receive data from that we will have to determine and set what are max canvas size is and then draw all the elements in