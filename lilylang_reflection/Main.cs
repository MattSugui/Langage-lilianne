#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace fonder.Lilian.New.Tests.Reflection
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public void TryGettingClassViaTypeOf(params string[] things)
        {
            // get a StringBuilder class
            Type referral = typeof(StringBuilder);
            //MethodInfo refmethd = referral.GetMethod("Append");
            var refobj = Activator.CreateInstance(referral);
            foreach (string item in things)
            {
                object?[] vs = new object?[] { item };
                referral.InvokeMember("Append", BindingFlags.InvokeMethod, null, refobj, vs);
            }

            var retobj = referral.InvokeMember("ToString", BindingFlags.InvokeMethod, null, refobj, null);

            try { textBox2.Text = retobj.ToString(); } catch (Exception bruh) { MessageBox.Show("bruh\n\n" + bruh.Message, "bruh moment", MessageBoxButtons.OK, MessageBoxIcon.Error);  }
        }
       
        public void TryGettingClassViaQualifiedName(string Name, string Member, bool Shoot = false, params string[] things)
        {
            Type? referral = null;
            object? refobj, retobj = null;
            try { referral = Type.GetType(Name); //}
            //catch { MessageBox.Show("Cannot find the thing!!!"); }

            //if (referral is null) return;

            refobj = Activator.CreateInstance(referral);
            
            //try
            //{
                if (Shoot)
                {
                    //referral.InvokeMember(Member, BindingFlags.InvokeMethod, null, refobj, (object?[])things);
                    retobj = referral.InvokeMember(Member, BindingFlags.InvokeMethod, null, refobj, (object?[])things);
                }
                else
                {
                    if (referral.GetProperty(Member) is not null) referral.GetProperty(Member).SetValue(refobj, things[0] is not null ? things[0] : "yep");
                    else if (referral.GetField(Member) is not null) referral.GetField(Member).SetValue(refobj, things[0] is not null ? things[0] : "yep");
                    else throw new ArgumentException("There was no such name as \"\"");
                }
    

            StringBuilder bruh = new();

            //bruh.AppendLine("Properties:");
            //foreach (PropertyInfo prop in referral.GetProperties()) bruh.AppendLine($"{prop.Name}: {prop.GetValue(refobj)}");

            //bruh.AppendLine("\nFields:");
            //foreach (FieldInfo prop in referral.GetFields()) bruh.AppendLine($"{prop.Name}: {prop.GetValue(refobj)}");

            //MessageBox.Show($"The name of the type is {referral.Name}.\n\n{bruh}\n\n{(retobj is not null? $"It invoked which returned {retobj}":"It invoked either void or not a method.")}", "Results!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e) { if (MessageBox.Show("failure!!!!1\n\n" + e.Message) == DialogResult.OK) return; }

        }

        private void button1_Click(object sender, EventArgs e) => TryGettingClassViaTypeOf(textBox1.Text.Split(','));

        private void button2_Click(object sender, EventArgs e) => TryGettingClassViaQualifiedName(textBox3.Text, textBox4.Text, checkBox1.Checked, textBox1.Text.Split(','));
    }
}
