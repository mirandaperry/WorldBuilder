Imports System.Drawing.Size
Imports System.Drawing.Graphics

Public Class Timeline

    ' This form has a Panel named 'MainPanel' that will scroll if needed.

    Dim panelVerticalCenter As Integer
    Dim panelHorizontalCenter As Integer

    Private Sub testClick(sender As Object, eventArgs As System.EventArgs) Handles Test.Click
        Dim returnVal As Integer = drawSample()
    End Sub

    Private Function drawSample()

        findBaseline()

        ' Draw a test circle -- To be removed code
        Dim graphics As Graphics = MainPanel.CreateGraphics()
        Dim pen As New Pen(Drawing.Color.Firebrick)
        Dim point As New Point(panelHorizontalCenter, panelVerticalCenter)
        Dim size As New Size(100, 100)
        Dim rectangle As New Rectangle(point, size)
        Try
            graphics.DrawEllipse(pen, rectangle)
        Catch ex As Exception
            Return 9
        End Try

        Return 0
    End Function

    Private Sub findBaseline() ' TODO: Call in the event they resize their window, handle

        Dim panelSize As Size
        Dim panelWidth As Integer
        Dim panelHeight As Integer

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