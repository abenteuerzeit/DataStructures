using System;
using System.Text;

namespace DataStructures.Node
{
    internal class DoubleNode : Node
    {
        private Node? _next;
        private Node? _prev;

        public DoubleNode(string data)
        {
            Data = data;
            _next = null;
            _prev = null;
        }

        protected internal override string Data { get; protected set; }

        protected override Node? Next => _next;
        protected override Node? Prev => _prev;

        public override Node? GetNextNode() => _next;
        public override void SetNextNode(Node? node) => _next = node;
        public override Node? GetPrevNode() => _prev;
        public override void SetPrevNode(Node? node) => _prev = node;

        public void UpdateData(string newData)
        {
            Data = newData;
        }


        public override string ToString()
        {
            const string dataLabel = "Data: ";
            const string nextLabel = "Next: ";
            const string prevLabel = "Prev: ";
            const char tableBorderChar = '=';
            const string nullString = "null";
            const string arrowTop = "||";
            const string arrowBottom = "\\/";
            const string arrowTopRight = "/\\";
            const string borderLeft = "|=";
            const string borderRight = "=|";

            var nextValue = Next?.Data ?? nullString;
            var prevValue = Prev?.Data ?? nullString;

            var maxLength = Math.Max(
                Data.Length + dataLabel.Length,
                Math.Max(nextValue.Length + nextLabel.Length, prevValue.Length + prevLabel.Length)
            );

            StringBuilder sb = new();

            if (Prev != null) AppendArrow(arrowTopRight);
            AppendHeader($"node_{Data}");
            AppendLabel(maxLength, borderLeft, borderRight, tableBorderChar);
            AppendValue(dataLabel, Data);
            AppendValue(nextLabel, nextValue);
            AppendValue(prevLabel, prevValue);
            AppendLabel(maxLength, borderLeft, borderRight, tableBorderChar);
            if (Next != null) AppendArrow(arrowTop, arrowBottom);

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

            void AppendArrow(string top, string bottom = "")
            {
                sb.AppendLine($"\t\t{top}");
                if (!string.IsNullOrEmpty(bottom))
                    sb.AppendLine($"\t\t{bottom}");
            }
        }

    }
}
