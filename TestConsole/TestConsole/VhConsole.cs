using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VH.Engine.Display;

namespace VH.Engine.VhConsole {

    public class VhConsole: IConsole {

        #region fields

        ConsoleForm consoleForm;

        #endregion

        #region constructors

        public VhConsole() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            consoleForm = new ConsoleForm();
            consoleForm.Show();
            Application.Run();
        }

        #endregion

        #region properties

        /// <summary>
        /// Indicates whether this IConsole implementation supports double buffering
        /// </summary>
        public bool IsDoubleBuffered {
            get { return true; }
        }

        /// <summary>
        /// Indicates whether this IConsole implementation supports color display
        /// </summary>
        public bool IsColor {
            get { return true; }
        }  

        /// <summary>
        /// Gets or sets the number of columns of this IConsole
        /// </summary>
        public int Width {
            get { return consoleForm.ConsoleWidth; }
            set { consoleForm.ConsoleWidth = value; }
        }

        /// <summary>
        /// Gets or sets the number of rows of this IConsole
        /// </summary>
        public int Height {
            get { return consoleForm.ConsoleHeight; }
            set { consoleForm.ConsoleHeight = value; }
        }

        /// <summary>
        /// Indicates the maximum possible number of columns of this IConsole
        /// </summary>
        public int MaximnumWidth { get; }

        /// <summary>
        /// Indicates the maximum possible number of rows of this IConsole
        /// </summary>
        public int MaximumHeight { get; }

        /// <summary>
        /// Gets or sets the color with which the next write operation will use as the foreground color
        /// </summary>
        public ConsoleColor ForegroundColor {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the color with which the next write operation will use as the background color
        /// </summary>
        public ConsoleColor BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the cursor is visible
        /// </summary>
        public bool CursorVisible { get; set; }

        #endregion

        #region public methods

        /// <summary>
        /// Writes the specified character at given coordinates
        /// </summary>
        /// <param name="c">The character to write</param>
        /// <param name="x">The x corrdinate of the write position</param>
        /// <param name="y">The y coordinate of the write position</param>
        public void Write(char c, int x, int y) {
            consoleForm.Write(c, x, y);
        }

        /// <summary>
        /// Writes the specified character at current cursor position
        /// </summary>
        /// <param name="c">The character to write</param>
        public void Write(char c) {
            consoleForm.Write(c);
        }

        /// <summary>
        /// Writes the specified string at current cursor position
        /// </summary>
        /// <param name="c">The string to write</param>
        public void Write(string s) {
            consoleForm.Write(s);
        }

        /// <summary>
        /// Places the cursor at the specified position
        /// </summary>
        /// <param name="x">The x corrdinate of the cursor position</param>
        /// <param name="y">The y coordinate of the cursor position</param>
        public void GoTo(int x, int y) {
            consoleForm.GoTo(x, y);
        }

        /// <summary>
        /// Refreshes this IConsole, provided that it is double buffered
        /// Does nothing otherwise
        /// </summary>
        public void Refresh() {
            consoleForm.RefreshConsole();
        }

        /// <summary>
        /// Reads a character from input
        /// </summary>
        /// <returns>The character read from input</returns>
        public char ReadKey() {
            return consoleForm.ReadKey();
        }

        /// <summary>
        /// Reads a line from input
        /// </summary>
        /// <returns>The line read from input</returns>
        public string ReadLine() {
            return Console.ReadLine();
        }

        /// <summary>
        /// Clears the whole IConsole
        /// </summary>
        public void Clear() {
            consoleForm.Clear();
        }

        /// <summary>
        /// Clears the buffer of this IConsole.
        /// </summary>
        public void ClearBuffer() {
            consoleForm.ClearBuffer();
        }

        #endregion
    }
}
