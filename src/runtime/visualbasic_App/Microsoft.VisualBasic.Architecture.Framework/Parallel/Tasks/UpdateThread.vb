﻿#Region "Microsoft.VisualBasic::d1080466140be726a5b79019f3a555c3, ..\VisualBasic_AppFramework\Microsoft.VisualBasic.Architecture.Framework\Parallel\Tasks\UpdateThread.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.

#End Region

Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.ComponentModel.Triggers

Namespace Parallel.Tasks

    ''' <summary>
    ''' Running a specific <see cref="System.Action"/> in the background periodically.
    ''' (比较适合用于在服务器上面执行周期性的计划任务)
    ''' </summary>
    Public Class UpdateThread : Inherits ICallbackInvoke
        Implements IDisposable
        Implements IObjectModel_Driver
        Implements ITimer

        ''' <summary>
        ''' ms
        ''' </summary>
        ''' <returns></returns>
        Public Property Periods As Integer Implements ITimer.Interval

        ''' <summary>
        ''' If this exception handler is null, then when the unhandled exception occurring,
        ''' this thread object will throw the exception and then stop working.
        ''' </summary>
        ''' <returns></returns>
        Public Property ErrHandle As Action(Of Exception)
        ''' <summary>
        ''' 指示当前的这个任务处理对象是否处于运行状态
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Running As Boolean

        ''' <summary>
        ''' Running a specific action in the background periodically. The time unit of the parameter <paramref name="Periods"/> is ms or Ticks.
        ''' </summary>
        ''' <param name="Periods">ms for update thread sleeps</param>
        ''' <param name="updates"></param>
        Sub New(Periods As Integer, updates As Action)
            Call MyBase.New(updates)

            Me.Running = False
            Me.Periods = Periods
        End Sub

        Private Sub __updates()
            Call $"Start running {Me.ToString}....".__DEBUG_ECHO
            Do While Running
                Call __invoke()
            Loop
            Call $"{Me.ToString} thread exit...".__DEBUG_ECHO
        End Sub

        ''' <summary>
        ''' 运行这条线程，假若更新线程已经在运行了，则会自动忽略这次调用
        ''' </summary>
        Public Function Start() As Integer Implements IObjectModel_Driver.Run
            If Running Then
                Return 2
            Else
                _Running = True
                Call RunTask(AddressOf __updates)
            End If

            Return 0
        End Function

        ''' <summary>
        ''' 停止更新线程的运行
        ''' </summary>
        Public Sub [Stop]() Implements ITimer.Stop
            _Running = False
        End Sub

        Private Sub __invoke()
            Try
                Call _execute()
            Catch ex As Exception
                If Not ErrHandle Is Nothing Then
                    Call _ErrHandle(ex)
                Else
                    Throw
                End If
            Finally
                Call Threading.Thread.Sleep(Periods)
            End Try
        End Sub

        Public Overrides Function ToString() As String
            Dim state As String = If(Running, NameOf(Running), NameOf([Stop]))
            Return $"[{state}, {Me.Periods}ms]  => {Me.CallbackInvoke.ToString}"
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    Call [Stop]()  ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            ' TODO: uncomment the following line if Finalize() is overridden above.
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class
End Namespace
