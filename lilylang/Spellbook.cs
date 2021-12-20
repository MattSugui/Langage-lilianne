using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Reflection.Emit;

using static fonder.Lilian.New.Interpreter;
using static System.Console;
using System.Diagnostics.CodeAnalysis;

namespace fonder.Lilian.New
{
    public static partial class Interpreter
    {
        public static class Spellbook
        {
            public interface IContextualisable { }
            public struct FELObject
            {
                public FELObject(string nm)
                {
                    Name = nm;
                    Value = null;
                }
                public FELObject(string nm, object val)
                {
                    Name = nm;
                    Value = val;
                }
                public string Name { get; }
                public object Value { get; set; }

                public override string ToString()
                {
                    return Value.ToString();
                }
            }

            public struct Action
            {
                public enum WhatToDo
                {
                    NoOperation = 0,
                    Print = 1,
                    Assign = 2,
                    Define = 3,
                }

                public enum Operation : sbyte
                {
                    Nothing = -1,
                    Assignment,
                    Addition,
                    Subtraction,
                    Multiplication,
                    Division,
                    Exponentation,
                    Modulo,
                    LeftShift,
                    RightShift,
                    And,
                    Or,
                    Xor,
                    Concatenation,
                    ProveThat,
                    ProveThatGreaterThan,
                    ProveThatLessThan,
                    ProveThatNot,
                    ProveThatGreaterOr,
                    ProveThatLessOr,
                    Not,
                    AndAlso,
                    OrElse,
                    PatternMatches,
                    TypeMatches,
                    TypeDoesNotMatch
                }
            }

            public class Context: IEnumerable
            {
                internal IContextualisable[] ToDoList = new IContextualisable[0];

                internal int amount;

                public int Count
                {
                    get => amount;
                }

                public Context(params IContextualisable[] contextualisables)
                {
                    ToDoList = new IContextualisable[contextualisables.Length - 1];
                    if (contextualisables.Length > ToDoList.Length) throw new Lamentation("sdfsdf");

                    for (int i = 0; i < contextualisables.Length; i++) ToDoList[i] = contextualisables[i];
                    
                    amount = ToDoList.Length;
                }

                public void Append(params IContextualisable[] contextualisables)
                {
                    if (contextualisables.Length == 0) return;

                    IContextualisable[] temp = ToDoList;
                    ToDoList = new IContextualisable[Count + contextualisables.Length];
                    Array.Copy(temp, 0, ToDoList, 0, temp.Length);

                    for (int i = 0; i < Count + contextualisables.Length - 1; i++) ToDoList[i] = contextualisables[i - Count];

                    amount += contextualisables.Length;
                }

                public void RemoveAt(int index)
                {
                    ToDoList[index] = null;
                    amount--;
                }

                public void Clear()
                {
                    ToDoList = new IContextualisable[0];
                    amount = 0;
                }

                public IEnumerator GetEnumerator() => new Contextualisation(ToDoList, Count);
            }

            public class Contextualisation : IEnumerator
            {
                public IContextualisable[] ActionListing;
                int position;
                int count;

                public Contextualisation(IContextualisable[] list, int cnt)
                {
                    ActionListing = list;
                    count = cnt;
                }

                public object Current
                {
                    get
                    {
                        try
                        {
                            return ActionListing[position];
                        }
                        catch
                        {
                            throw new Lamentation("sdfsdfsdfs", 10);
                        }
                    }
                }

                public bool MoveNext()
                {
                    position++;
                    return (position < count);
                }

                public void Reset()
                {
                    position = -1;
                }
            }
        }
    }
}
