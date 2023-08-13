using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Node
{
    internal class SingleNode : Node
    {
        private Node? _next;

        public SingleNode(string data)
        {
            Data = data;
            _next = null;
        }

        protected internal override string Data { get; protected set; }
        protected override Node? Next => _next;
        protected override Node? Prev => throw new InvalidOperationException("SingleNode does not have a previous node.");

        public override Node? GetNextNode() => _next;
        public override void SetNextNode(Node? node) => _next = node;
        public override Node? GetPrevNode() => throw new NotImplementedException();
        public override void SetPrevNode(Node? node) => throw new InvalidOperationException("Cannot set previous node in a singly linked list.");

        public override string ToString()
        {
            const string dataLabel = "Data: ";
            const string nextLabel = "Next: ";
            const char tableBorderChar = '=';
            const string nullString = "null";
            const string arrowTop = "||";
            const string arrowBottom = "\\/";
            const string borderLeft = "|=";
            const string borderRight = "=|";

            var nextValue = Next?.Data ?? nullString;

            var maxLength = Math.Max(
                Data.Length + dataLabel.Length, nextValue.Length + nextLabel.Length
            );

            StringBuilder sb = new();

            AppendHeader($"node_{Data}");
            AppendLabel(maxLength, borderLeft, borderRight, tableBorderChar);
            AppendValue(dataLabel, Data);
            AppendValue(nextLabel, nextValue);
            AppendLabel(maxLength, borderLeft, borderRight, tableBorderChar);
            AppendArrow(arrowTop, arrowBottom);

            return sb.ToString();

            void AppendHeader(string label) => sb.AppendLine($"\t{label}");
            void AppendLabel(int max, string left, string right, char borderChar)
            {
                string tableBorderLine = $"\t{left}{new string(borderChar, max)}{right}";
                sb.AppendLine(tableBorderLine);
            }
            void AppendValue(string label, string value)
            {
                sb.AppendLine($"\t| {label}{value.PadRight(maxLength - label.Length)} |");
            }
            void AppendArrow(string top, string bottom)
            {
                sb.AppendLine($"\t{top}");
                sb.AppendLine($"\t{bottom}");
            }
        }
    }
}
