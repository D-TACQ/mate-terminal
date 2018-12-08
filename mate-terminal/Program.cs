/*
The MIT License (MIT)

Copyright (c) 2018 D-TACQ
Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
© 2018 GitHub, Inc.
    */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace mate_terminal
{
    class Tab
    {
        public string Title;
        public string Cmd;
        public Tab(string title, string cmd)
        {
            Title = title;
            Cmd = cmd;
        }
        public override string ToString()
        {
            return "title:" + Title + " cmd:" + Cmd;  
        }
    }
    static class Program
    {
        enum ParseArgsState {
            PAS_TAB,
            PAS_TITLE,
            PAS_CMD
        }

        static List<Tab> Tabs = new List<Tab>();

        static void ParseArgs(string[] args)
        {
            // don't have time to work out how to do this generically, simplify
            // MUST BE
            // --tab[xxxx], --title=TITLE, --cmd=CMD
     
            ParseArgsState pas = ParseArgsState.PAS_TAB;
            string title = "notitle";

            foreach (string arg in args)
            {
                switch(pas)
                {
                    case ParseArgsState.PAS_TAB:
                        if (arg.StartsWith("--tab") || arg.StartsWith("--window"))
                        {
                            pas = ParseArgsState.PAS_TITLE;
                        } else
                        {
                            Console.WriteLine("bad token wanted --tab, got:" + arg + "");
                            Debug.Assert(1 == 0);
                        }
                        break;
                    case ParseArgsState.PAS_TITLE:
                        if (arg.StartsWith("--title"))
                        {
                            title = arg.Split('=')[1];
                            pas = ParseArgsState.PAS_CMD;
                        } else
                        {
                            Console.WriteLine("bad token wanted --title, got:" + arg + "");
                            Debug.Assert(1 == 0);
                        }
                        break;
                    case ParseArgsState.PAS_CMD:
                        if (arg.StartsWith("--cmd"))
                        {
                            Tabs.Add(new Tab(title, arg.Split('=')[1]));
                            pas = ParseArgsState.PAS_TAB;
                        } else
                        {
                            Console.WriteLine("bad token wanted --cmd, got:" + arg + "");
                            Debug.Assert(1 == 0);
                        }
                        break;
                    default:
                        Console.WriteLine("BSD STATE");
                        Debug.Assert(1 == 0);
                        break;
                }

  
            }
            foreach (Tab tab in Tabs)
            {
                Console.WriteLine(tab);
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ParseArgs(args);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
            form1.Text = "mate-terminal";
            int itab = 0;
            foreach (Tab tab in Tabs)
            {
                form1.addTab(itab++, tab.Title, tab.Cmd);
            }
            Application.Run(form1);
        }
    }
}
