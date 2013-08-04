using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace User_Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TemplateMenu());

            //Application.Run(new GenerateTemplate());
            //Application.Run(new GeneratorMenu());
            //Application.Run(new EditTemplate());
            //Application.Run(new GenerateApplicationLayers());
        }
    }
}
