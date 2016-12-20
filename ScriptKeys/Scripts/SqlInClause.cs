//css_reference ScriptKeys.exe;
//css_reference InputSimulator.dll;

using System;
using System.Text;
using System.Windows.Forms;
using ScriptKeys;
using WindowsInput;

public class Script : ScriptBase
{
    public override void Run(string[] parameters)
    {
        string input = GetClipboard();
        string output;

        if (String.IsNullOrEmpty(input)) return;
                
        if (Contains(parameters,"apostrophe"))
        {
            output = SqlInClauseWithApostrophe(input);
        }
        else
        {
            output = SqlInClause(input);
        }

        Clipboard.SetText(output);

        base.Paste();
    }

    private string SqlInClause(string input)
    {
        var sb = new StringBuilder((int)(input.Length * 1.5));
        var items = input.Split("\t\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        sb.Append("in (");

        if (items.Length == 1)
        {
            sb.Append(items[0]);
        }
        else if (items.Length > 1)
        {
            sb.AppendLine();

            for (int i = 0; i < items.Length - 1; i++)
            {
                sb.Append(items[i]);
                sb.AppendLine(",");
            }

            sb.AppendLine(items[items.Length - 1]);
        }

        sb.Append(")");

        return sb.ToString();
    }

    private string SqlInClauseWithApostrophe(string input)
    {
        var sb = new StringBuilder((int)(input.Length * 1.5));
        var items = input.Split("\t\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        sb.Append("in (");

        if (items.Length == 1)
        {
            sb.Append("'");
            sb.Append(items[0]);
            sb.Append("'");
        }
        else if (items.Length > 1)
        {
            sb.AppendLine();

            for (int i = 0; i < items.Length - 1; i++)
            {
                sb.Append("'");
                sb.Append(items[i]);
                sb.Append("'");
                sb.AppendLine(",");
            }

            sb.Append("'");
            sb.Append(items[items.Length - 1]);
            sb.AppendLine("'");
        }

        sb.Append(")");

        return sb.ToString();
    }

}



