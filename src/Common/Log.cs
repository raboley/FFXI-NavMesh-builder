﻿// *********************************************************************** Assembly : PathFinder
// Author : xenonsmurf Created : 03-16-2020 Created : 03-16-2020 Created : 03-16-2020 Created :
// Created : 03-16-2020 Created : 03-16-2020 Created : 03-16-2020 Created :
//
// Last Modified By : xenonsmurf Last Modified On : 03-23-2020 Last Modified On : 04-12-2020 Last
// Last Modified On : 07-13-2020 ***********************************************************************
// <copyright file="Log.cs" company="Xenonsmurf">
//     Copyright © 2020
// </copyright>
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FFXINAVBUILDER.Common
{
    /// <summary>
    /// Class Log.
    /// </summary>
    public class Log
    {
        #region Private Fields

        /// <summary>
        /// The font size
        /// </summary>
        private float FontSize = 9;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Adds the debug text.
        /// </summary>
        /// <param name="tb">   The tb. </param>
        /// <param name="text"> The text. </param>
        public void AddDebugText(RichTextBox tb, string text)
        {
            if (tb.InvokeRequired)
            {
                tb.Invoke(new Action<RichTextBox, string>(AddDebugText), tb, text);
            }
            else
            {
                tb.SelectionStart = tb.Text.Length;
                tb.SelectionFont =
                    new Font("Tahoma", FontSize, FontStyle.Regular); //delete if not letting user set font
                tb.SelectionColor = Color.DarkMagenta;
                tb.SelectedText += DateTime.Now;
                tb.SelectionStart = tb.Text.Length;
                tb.SelectionColor = Color.White;
                tb.SelectedText += " ";
                tb.SelectedText += text;
                tb.SelectedText += Environment.NewLine;
                tb.SelectionStart = tb.Text.Length - 1;
                tb.ScrollToCaret();
            }
        }

        /// <summary>
        /// Clears the log.
        /// </summary>
        public void ClearLog()
        {
            try
            {
                if (File.Exists("Log.txt"))
                {
                    var fi = new FileInfo("Log.txt");
                    if (fi.LastAccessTime < DateTime.Now.AddDays(-7))
                        using (new StreamWriter(fi.Open(FileMode.Truncate)))
                        {
                        }
                }
                else if (!File.Exists("Log.txt"))
                {
                    using (File.CreateText("Log.txt"))
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                using (TextWriter writer = File.CreateText("Log.txt"))
                {
                    writer.Write(ex);
                }
            }
        }

        /// <summary>
        /// Logs the file.
        /// </summary>
        /// <param name="sExceptionName"> Name of the s exception. </param>
        /// <param name="sFormName">      Name of the s form. </param>
        /// <param name="lineNumber">     The line number. </param>
        /// <param name="caller">         The caller. </param>
        public void LogFile(string sExceptionName, string sFormName, [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string caller = null)
        {
            try
            {
                if (File.Exists("Log.txt"))
                {
                    using (TextWriter tw = File.AppendText("Log.txt"))
                    {
                        tw.WriteLine(
                            $@"{DateTime.Now.ToString(CultureInfo.InvariantCulture)}, {sExceptionName}, at line {lineNumber},({caller}) ,{sFormName}");
                        tw.Close();
                    }
                }
                else if (!File.Exists("Log.txt"))
                {
                    using (File.CreateText("Log.txt"))
                    {
                    }

                    using (TextWriter tw = File.AppendText("Log.txt"))
                    {
                        tw.WriteLine(
                            $@"{DateTime.Now.ToString(CultureInfo.InvariantCulture)}, {sExceptionName}, at line {lineNumber},({caller}) ,{sFormName}");
                        tw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                using (TextWriter tw = File.CreateText("Log.txt"))
                {
                    tw.WriteLine(@"{0}, {1}, at line {2},({3}) ,{4}", DateTime.Now, ex, lineNumber, caller, sFormName);
                    tw.Close();
                }
            }
        }

        /// <summary>
        /// Saves the chat logs.
        /// </summary>
        /// <param name="rtb">  The RTB. </param>
        /// <param name="name"> The name. </param>
        public void SaveChatLogs(RichTextBox rtb, string name)
        {
            try
            {
                using (var diaLog = new SaveFileDialog())
                {
                    diaLog.InitialDirectory =
                        string.Format(Application.StartupPath + "\\Documents\\{0}\\ChatLog\\", name);
                    diaLog.RestoreDirectory = true;
                    diaLog.DefaultExt = "*.txt";
                    diaLog.Filter = @"TXT Files|*.txt";
                    if (diaLog.ShowDialog() == DialogResult.OK && diaLog.FileName.Length > 0)
                        rtb.SaveFile(diaLog.FileName, RichTextBoxStreamType.PlainText);
                }
            }
            catch (Exception ex)
            {
                LogFile(ex.Message, "Log");
            }
        }

        #endregion Public Methods
    }
}