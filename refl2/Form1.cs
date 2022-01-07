using System;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace refl2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            breh2 = Assembly.Load("System.Windows.Forms, Version=6.0.0.0, PublicKeyToken=B77A5C561934E089, Culture=\"\"");
        }

        internal Assembly breh2;

        private void button1_Click(object sender, EventArgs e)
        {
            MethodInfo? methodInfo = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) });
            Debug.Write($"{methodInfo?.Name} that {methodInfo?.ReturnType}");
            if (methodInfo == null) return;
            else
            {
                methodInfo.Invoke(null, new object[] { textBox1.Text });
                MessageBox.Show("we did it!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // so far only one param today
            // e.g. Console.WriteLine("Hello!")
            if (Regex.IsMatch(textBox2.Text, @"(?<QualifiedName>(?:[A-Za-z][0-9A-Za-z]*\.?)+)\s?\((?:(?<StringValue>"".*"")|(?<IntegralValue>[0-9]+))\);"))
            {
                Match match = Regex.Match(textBox2.Text, @"(?<QualifiedName>(?:[A-Za-z][0-9A-Za-z]*\.?)+)\s?\((?:(?<StringValue>"".*"")|(?<IntegralValue>[0-9]+))\);");
                string test1 = match.Groups["QualifiedName"].Value;
                string[] QualifiedName = match.Groups["QualifiedName"].Value.Split('.');
                string QualifiedTypeName = string.Join('.', QualifiedName[0..(QualifiedName.Length - 1)]);
                string QualifiedMethodName = QualifiedName[^1];

                Type? QualifiedType = breh2.GetType(QualifiedTypeName) ?? Type.GetType(QualifiedTypeName);
                MethodInfo? QualifiedMethod = QualifiedType?.GetMethod(QualifiedMethodName, new Type[] { match.Groups["StringValue"] is not null ? typeof(string) : throw new InvalidOperationException("STRING ONLY FIRST!!!!") }) ?? null; // string only first
                MessageBox.Show($"" +
                    $"Type name: {(QualifiedType is not null ? QualifiedTypeName : $"Such type does not exist. ({QualifiedTypeName})")}\n" +
                    $"Method name: {(QualifiedMethod is not null ? QualifiedMethodName : $"Such type does not exist. ({QualifiedMethodName})")}");
                QualifiedMethod?.Invoke(this, new object[] { match.Groups["StringValue"].Value.Trim('"') });
            }
            else MessageBox.Show("Invalid pattern.");
        }
    }
}